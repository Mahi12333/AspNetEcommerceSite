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
    [MyAuthorization("Admin", "Subadmin")]
    [Route("Admin/Product")]
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

        [HttpGet("Index")]
        //[Route("")]
        public async Task<IActionResult> Index()
        {
            var products = await _productRepository.GetAllAsync();
            return View(products);
        }

        // GET: Create
        [HttpGet("Create")]
        public async Task<IActionResult> Create()
        {
            var categories = await _categoryRepository.GetAllCategoriesAsync();
            var productVM = new ProductVM
            {
                Categories = categories // Assign fetched categories to the ProductVM
            };
            return View(productVM);
        }
        // POST: Create
        /* [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductVM model)
        {
            Console.WriteLine($"Name: {model.Name}");
            Console.WriteLine($"Description : {model.Description}");
            Console.WriteLine($"imageUrls : {model.Images}");
            Console.WriteLine($"Sizes: {model.Sizes}");
            Console.WriteLine($"CategoryId : {model.CategoryId}");
            Console.WriteLine($"SubCategoryId : {model.SubCategoryId} ");
            if (!ModelState.IsValid)
            {
                var categories = await _categoryRepository.GetAllCategoriesAsync();
                var productVM = new ProductVM
                {
                    Categories = categories // Assign fetched categories to the ProductVM
                };
                return View(productVM);
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
                return RedirectToAction("Create");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error Product : {ex.Message}");
                ModelState.AddModelError(string.Empty, "An error occurred while creating the product.");
                ViewBag.Categories = await _categoryRepository.GetAllCategoriesAsync();
                return View(model);
            }
        }*/


        [HttpPost("Create")]
        public async Task<IActionResult> Create(ProductVM model)
        {
            // Log incoming data for debugging
            Console.WriteLine($"Name: {model.Name}");
            Console.WriteLine($"Description: {model.Description}");
            Console.WriteLine($"Images: {model.Images}");
            Console.WriteLine($"Sizes: {string.Join(",", model.Sizes)}");
            Console.WriteLine($"CategoryId: {model.CategoryId}");
            Console.WriteLine($"SubCategoryId: {model.SubCategoryId}");

            if (!ModelState.IsValid)
            {
                // Log model validation errors
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine($"Validation Error: {error.ErrorMessage}");
                }

                var categories = await _categoryRepository.GetAllCategoriesAsync();
                var productVM = new ProductVM
                {
                    Categories = categories // Assign fetched categories to the ProductVM
                };
                return View(productVM);
            }

            try
            {
                // Save images and get URLs
                var imageUrls = await SaveProductImagesAsync(model.Images);

                // Create product model
                var product = new ProductModel
                {
                    Name = model.Name,
                    Description = model.Description,
                    OriginalPrice = model.OriginalPrice,
                    Discount = model.Discount,
                    ImageUrls = imageUrls, // Save image URLs
                    Sizes = string.Join(",", model.Sizes),
                    CategoryId = model.CategoryId,
                    SubCategoryId = model.SubCategoryId,
                    CreatedAt = DateTime.UtcNow
                };

                // Save to the database
                await _productRepository.AddAsync(product);
                TempData["Success"] = "Product created successfully!";
                return RedirectToAction("Create");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                ModelState.AddModelError(string.Empty, "An error occurred while creating the product.");

                // Reload categories for dropdown
                var categories = await _categoryRepository.GetAllCategoriesAsync();
                model.Categories = categories;
                return View(model);
            }
        }


        // GET: Edit
        [HttpGet("Edit")]
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
        [HttpPost("Edit")]
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


        [HttpPost("Delete")]
       // [Route("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _productRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }


        [HttpGet("GetSubcategories")]

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


        //private async Task<List<string>> SaveProductImagesAsync(IEnumerable<IFormFile>? imageFiles)
        //{
        //    var imageUrls = new List<string>();
        //    Console.WriteLine($"imageUrls : {imageUrls}");
        //    if (imageFiles == null) return imageUrls;

        //    var uploadsFolder = Path.Combine(_environment.WebRootPath, "uploads/products");
        //    Directory.CreateDirectory(uploadsFolder);

        //    foreach (var file in imageFiles)
        //    {
        //        if (file.Length > 0)
        //        {
        //            var uniqueFileName = $"{Guid.NewGuid()}_{Path.GetFileName(file.FileName)}";
        //            var filePath = Path.Combine(uploadsFolder, uniqueFileName);

        //            using (var stream = new FileStream(filePath, FileMode.Create))
        //            {
        //                await file.CopyToAsync(stream);
        //            }

        //            imageUrls.Add($"/uploads/products/{uniqueFileName}");
        //        }
        //    }

        //    return imageUrls;
        //}

        private async Task<List<string>> SaveProductImagesAsync(IEnumerable<IFormFile> images)
        {
            var imageUrls = new List<string>();

            foreach (var image in images)
            {
                if (image.Length > 0)
                {
                    var fileName = Path.GetFileNameWithoutExtension(image.FileName) + "_" + Guid.NewGuid() + Path.GetExtension(image.FileName);
                    var filePath = Path.Combine("wwwroot/uploads/products", fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await image.CopyToAsync(stream);
                    }

                    // Add the relative URL to the list
                    imageUrls.Add($"/uploads/products/{fileName}");
                }
            }

            return imageUrls;
        }


    }
}
