using EcommerceProject.Areas.Admin.Models;
using EcommerceProject.Areas.Admin.Models.ViewModels;
using EcommerceProject.Repositories.Repository;
using EcommerceProject.Repositories.Repository.IRepository;
using EcommerceProject.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryService _categoryRepository; // Assume similar repository exists
        private readonly ISubCategoryService _subCategoryRepository; // Assume similar repository exists
        private readonly IWebHostEnvironment _environment;

        public ProductController(
            IProductRepository productRepository,
            ICategoryService categoryRepository,
            ISubCategoryService subCategoryRepository,
            IWebHostEnvironment environment)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _subCategoryRepository = subCategoryRepository;
            _environment = environment;
        }

        [HttpGet]
        //[Route("")]
        public async Task<IActionResult> Index()
        {
            var products = await _productRepository.GetAllAsync();
            return View(products);
        }

        // GET: Create
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = await _categoryRepository.GetAllCategoriesAsync();
            return View(new ProductVM());
        }
        // POST: Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductVM model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = await _categoryRepository.GetAllCategoriesAsync();
                return View(model);
            }

            try
            {
                var imageUrls = await SaveProductImagesAsync(model.Images);
                var product = new ProductModel
                {
                    Name = model.Name,
                    Description = model.Description,
                    OriginalPrice = model.OriginalPrice,
                    Discount = model.Discount,
                    ImageUrls = imageUrls,
                    Sizes = string.Join(",", model.Sizes),
                    CategoryId = model.CategoryId,
                    SubCategoryId = model.SubCategoryId,
                    CreatedAt = DateTime.UtcNow
                };

                await _productRepository.AddAsync(product);
                TempData["Success"] = "Product created successfully!";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "An error occurred while creating the product.");
                ViewBag.Categories = await _categoryRepository.GetAllCategoriesAsync();
                return View(model);
            }
        }

        // GET: Edit
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            var model = new ProductVM
            {
                Name = product.Name,
                Description = product.Description,
                OriginalPrice = product.OriginalPrice,
                Discount = product.Discount,
                Sizes = product.Sizes.Split(',').ToList(),
                CategoryId = product.CategoryId,
                SubCategoryId = product.SubCategoryId
            };

            ViewBag.Categories = await _categoryRepository.GetAllCategoriesAsync();
            return View(model);
        }

        // POST: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProductVM model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = await _categoryRepository.GetAllCategoriesAsync();
                return View(model);
            }

            try
            {
                var product = await _productRepository.GetByIdAsync(id);
                if (product == null)
                {
                    return NotFound();
                }

                var imageUrls = model.Images != null && model.Images.Any()
                    ? await SaveProductImagesAsync(model.Images)
                    : product.ImageUrls;

                product.Name = model.Name;
                product.Description = model.Description;
                product.OriginalPrice = model.OriginalPrice;
                product.Discount = model.Discount;
                product.ImageUrls = imageUrls;
                product.Sizes = string.Join(",", model.Sizes);
                product.CategoryId = model.CategoryId;
                product.SubCategoryId = model.SubCategoryId;

                await _productRepository.UpdateAsync(product);
                TempData["Success"] = "Product updated successfully!";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "An error occurred while updating the product.");
                ViewBag.Categories = await _categoryRepository.GetAllCategoriesAsync();
                return View(model);
            }
        }


        [HttpPost]
       // [Route("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _productRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]

        public async Task<IActionResult> GetSubcategories(int categoryId)
        {
            try
            {
                Console.WriteLine("Dropdown section is call");
                Console.WriteLine($"Category ID received: {categoryId}");
                var subcategories = await _subCategoryRepository.GetSubCategoriesByCategoryIdAsync(categoryId);

                var response = new ApiResponse<IEnumerable<object>>(
                statusCode: 200,
                success: true,
                message: "Subcategories retrieved successfully",
                data: subcategories
                );

                return Json(response);
            }
            catch (Exception ex)
            {
                var errorResponse = new ApiResponse<string>(
               statusCode: 500,
               success: false,
               message: "An error occurred while retrieving subcategories.",
               data: ex.Message
           );

                return StatusCode(500, errorResponse);
            }
        }


        private async Task<List<string>> SaveProductImagesAsync(IEnumerable<IFormFile>? imageFiles)
        {
            var imageUrls = new List<string>();
            if (imageFiles == null) return imageUrls;

            var uploadsFolder = Path.Combine(_environment.WebRootPath, "uploads/products");
            Directory.CreateDirectory(uploadsFolder);

            foreach (var file in imageFiles)
            {
                if (file.Length > 0)
                {
                    var uniqueFileName = $"{Guid.NewGuid()}_{Path.GetFileName(file.FileName)}";
                    var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

                    imageUrls.Add($"/uploads/products/{uniqueFileName}");
                }
            }

            return imageUrls;
        }
    }
}
