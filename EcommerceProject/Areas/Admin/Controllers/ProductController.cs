using EcommerceProject.Areas.Admin.Models;
using EcommerceProject.Areas.Admin.Models.ViewModels;
using EcommerceProject.Repositories;
using EcommerceProject.Repositories.Repository;
using EcommerceProject.Repositories.Repository.IRepository;
using EcommerceProject.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
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
        private readonly IImageRepository _imageRepository;
        private readonly ApplicationDbContext _dbContext;

        public ProductController(
            IProductRepository productRepository,
            ICategoryService categoryRepository,
            ISubCategoryService subCategoryRepository,
            IWebHostEnvironment environment,
            IImageRepository imageRepository,
            ApplicationDbContext dbContext)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _subCategoryRepository = subCategoryRepository;
            _environment = environment;
            _imageRepository = imageRepository;
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Index(int page = 1, int pageSize = 10, string? search = null)
        {
            // Fetch the products from the database
            var query = _dbContext.Products.AsQueryable();
            Console.WriteLine($"query : {query}");

            // Filter products if a search query is provided
            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(p => p.Name.Contains(search) || p.Category.Name.Contains(search) || p.SubCategory.Name.Contains(search));
            }

            // Calculate total products after filtering
            int totalProducts = await query.CountAsync();

            // Paginate the results
            var products = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            // Prepare the list of ProductVMs
            var productVMs = new List<ProductVM>();

            foreach (var product in products)
            {
                Console.WriteLine($"slug : { product.slug }");
                // Fetch associated images for each product
                var images = await _imageRepository.GetImagesByProductIdAsync(product.Id);
                var categoryDb = await _categoryRepository.GetCategoryByIdAsync(product.CategoryId);
                var subcategoryDb = await _subCategoryRepository.GetSubCategoryByIdAsync(product.SubCategoryId);
                string baseUrl = "http://localhost:5115";
                 // Convert Sizes to List<string>

                // Map product data to ProductVM
                var productVM = new ProductVM
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    Category = categoryDb.Name,
                    SubCategory = subcategoryDb.Name,
                    ImagesPath = images?.Select(img => $"{baseUrl}{img.path}").ToList() ?? new List<string>(), // Assuming 'Path' is the field that stores the image URL
                    Sizes = product.Sizes?.Split(',').ToList(),
                    OriginalPrice = product.OriginalPrice,
                    Discount = product.Discount,
                    CreatedAt = product.CreatedAt,
                    Status = product.Status == "true" ? "Active" : "Inactive", // Or use product.Status if applicable
                    slug = product.slug,
                    finalPrice = product.finalPrice,
                   // ExistingImages = images?.Select(img => new ImageVM { Path = img.path }).ToList() ?? new List<ImageVM>() // Optional: If you need to show existing image details separately
                };

                productVMs.Add(productVM);
            }

            // Prepare the ViewModel
            var viewModel = new ProductPaginationListVM
            {
                Products = productVMs,
                Page = page,
                PageSize = pageSize,
                TotalProducts = totalProducts,
                SearchQuery = search
            };

            return View(viewModel);
        }


        /* [HttpGet("Index")]
         //[Route("")]
         public async Task<IActionResult> Index()
         {
             var products = await _productRepository.GetAllAsync();
             return View(products);
         }  */

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
            Console.WriteLine($"model : {model}");
            Console.WriteLine($"Name: {model.Name}");
            Console.WriteLine($"Description: {model.Description}");
            Console.WriteLine($"Images: {model.Images}");
            Console.WriteLine($"Sizes: {string.Join(",", model.Sizes)}");
            Console.WriteLine($"CategoryId: {model.CategoryId}");
            Console.WriteLine($"SubCategoryId: {model.SubCategoryId}");

            // Error message display 
            if (!ModelState.IsValid)
            {
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine($"Validation Error: {error.ErrorMessage}");
                }

                var categories = await _categoryRepository.GetAllCategoriesAsync();
                var productVM = new ProductVM
                
                {
                    Categories = categories
                };
                return View(productVM);
            }

            Guid uniqueId = Guid.NewGuid(); // Convert to a string if needed
            string uniqueIdString = uniqueId.ToString();

            try
            {
                // Save the product
                var product = new ProductModel
                {
                    Name = model.Name,
                    Description = model.Description,
                    OriginalPrice = model.OriginalPrice,
                    Discount = model.Discount,
                    Sizes = string.Join(",", model.Sizes),
                    CategoryId = model.CategoryId,
                    SubCategoryId = model.SubCategoryId,
                    CreatedAt = DateTime.UtcNow,
                    Status = model.Status,
                    finalPrice = model.finalPrice,
                    slug = uniqueIdString,
                };

                await _productRepository.AddAsync(product);
                await _productRepository.SaveChangesAsync();

                // Save images
                if (model.Images != null && model.Images.Count > 0)
                {
                    foreach (var image in model.Images)
                    {
                        // Save image to the server
                        var fileName = Path.GetFileName(image.FileName);
                        var uniqueFileName = $"{DateTime.Now.Ticks}_{fileName}";
                        var filePath = Path.Combine("wwwroot/uploads/products", uniqueFileName);

                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await image.CopyToAsync(stream);
                        }

                        // Add image metadata to the database
                        var imageModel = new ImageModel
                        {
                            ProductId = product.Id,
                            filename = fileName,
                            path = "/uploads/products/" + uniqueFileName,
                            size = image.Length.ToString(),
                            type = image.ContentType,
                            CreatedAt = DateTime.Now,
                            UpdatedAt = DateTime.Now,
                        };

                        await _imageRepository.AddAsync(imageModel);
                    }

                    await _imageRepository.SaveChangesAsync();
                }

                TempData["SuccessMessage"] = "Product created successfully!";
                return RedirectToAction("Create");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"error product----------: {ex.Message}");
                ModelState.AddModelError(string.Empty, "An error occurred while creating the product.");

                // Reload categories for dropdown
                var categories = await _categoryRepository.GetAllCategoriesAsync();
                model.Categories = categories;
                return View(model);
            }
        }


        // GET: Edit
        [HttpGet("Edit")]
        public async Task<IActionResult> Edit(string slug)
        {
            try
            {
                // Fetch product details by ID
                var product = await _productRepository.GetByIdAsync(slug);
                
                if (product == null)
                {
                    TempData["ErrorMessage"] = "Product not found.";
                    return RedirectToAction("Index");
                }

                // Fetch associated images
                var images = await _imageRepository.GetImagesByProductIdAsync(product.Id);

                // Prepare the view model
                var model = new EditProductVM
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    OriginalPrice = product.OriginalPrice,
                    Discount = product.Discount,
                    Sizes = product.Sizes?.Split(',').ToList() ?? new List<string>(),
                    CategoryId = product.CategoryId,
                    SubCategoryId = product.SubCategoryId,
                    finalPrice = product.finalPrice,
                    Categories = await _categoryRepository.GetAllCategoriesAsync(),
                    SubCategories = await _subCategoryRepository.GetSubCategoriesByCategoryIdAsync(product.CategoryId),
                    slug = slug,
                    Status = product.Status,
                    ExistingImages = images.Select(img => new ImageVM
                    {
                        Id = img.Id,
                        Path = img.path,
                        FileName = img.filename,
                        Size = img.size,
                        Type = img.type
                    }).ToList()
                };

                return View(model);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching product details: {ex.Message}");
                TempData["ErrorMessage"] = "An error occurred while fetching product details.";
                return RedirectToAction("Index");
            }
        }

        // POST: Edit
        [HttpPost("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditProductVM model)
        {
            Console.WriteLine($"model : {model}");
            Console.WriteLine($"Name: {model.Name}");
            Console.WriteLine($"Description: {model.Description}");
            Console.WriteLine($"Images: {model.Images}");
            Console.WriteLine($"Sizes: {string.Join(",", model.Sizes)}");
            Console.WriteLine($"CategoryId: {model.CategoryId}");
            Console.WriteLine($"SubCategoryId: {model.SubCategoryId}");
            Console.WriteLine($"ImagesToRemove : {model.ImagesToRemove}");
            Console.WriteLine($"slug : {model.slug}");

            if (!ModelState.IsValid)
            {
                /*var categories = await _categoryRepository.GetAllCategoriesAsync();
                var subcategories = await _subCategoryRepository.GetSubCategoriesByCategoryIdAsync(model.CategoryId);
                var images = await _imageRepository.GetImagesByProductIdAsync(model.Id); // Re-fetch images
                model.Categories = categories;
                model.SubCategories = subcategories;
                model.slug = model.slug;
                model.ExistingImages = images.Select(img => new ImageVM 
                { Id = img.Id, Path = img.path, FileName = img.filename, Size = img.size, Type = img.type }).ToList();
                Console.WriteLine($"ExistingImages Count: {model.ExistingImages?.Count ?? 0}");*/

                Console.WriteLine("Model state is invalid");
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine($"Error: {error.ErrorMessage}");
                }
                TempData["ErrorMessage"] = "Product created successfully!";
                return View("Edit", model);
            }

            try
            {
                var product = await _productRepository.GetByIdAsync(model.slug);
                if (product == null)
                {
                    Console.WriteLine($"productssssssssss : {product}");
                    return NotFound();
                }

                product.Name = model.Name;
                product.Description = model.Description;
                product.OriginalPrice = model.OriginalPrice;
                product.Discount = model.Discount;
                product.Sizes = string.Join(",", model.Sizes);
                product.CategoryId = model.CategoryId;
                product.SubCategoryId = model.SubCategoryId;
                product.UpdatedAt = DateTime.UtcNow;
                product.CreatedAt = product.CreatedAt;
                product.slug = product.slug;


                await _productRepository.UpdateAsync(product);

                // Handle image updates
                var imagesToRemove = JsonConvert.DeserializeObject<List<int>>(model.ImagesToRemove);
                var existingImages = await _imageRepository.GetImagesByProductIdAsync(product.Id);

                // Remove selected images from the database and filesystem
                foreach (var imageId in imagesToRemove)
                {
                    var image = existingImages.FirstOrDefault(i => i.Id == imageId);
                    if (image != null)
                    {
                        await _imageRepository.DeleteAsync(image.Id);
                        var filePath = Path.Combine("wwwroot", image.path.TrimStart('/'));
                        Console.WriteLine($"filepath : {filePath}");
                        if (System.IO.File.Exists(filePath))
                        {
                            System.IO.File.Delete(filePath);
                        }
                    }
                }

                // Save new images if provided
                if (model.Images != null && model.Images.Any())
                {
                    var newImageUrls = await SaveProductImagesAsync(model.Images);
                    foreach (var imageUrl in newImageUrls)
                    {
                        var imageModel = new ImageModel
                        {
                            ProductId = product.Id,
                            filename = Path.GetFileName(imageUrl),
                            path = imageUrl,
                            size = model.Images.First().Length.ToString(),
                            type = model.Images.First().ContentType,
                            CreatedAt = DateTime.UtcNow,
                            UpdatedAt = DateTime.UtcNow
                        };
                        await _imageRepository.AddAsync(imageModel);
                    }
                }

                TempData["SuccessMessage"] = "Product updated successfully!";
                return RedirectToAction("Edit", new { slug = model.slug });
                //return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Product created successfully!";
                ModelState.AddModelError(string.Empty, $"An error occurred: {ex.Message}");
                return RedirectToAction("Edit", new { slug = model.slug });
                //return View(model);
            }
        }



   /*     // POST: Edit
        [HttpPost("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string slug, ProductVM model)
        {
            if (!ModelState.IsValid)
            {
                var categories = await _categoryRepository.GetAllCategoriesAsync();
                var subcategories = await _subCategoryRepository.GetSubCategoriesByCategoryIdAsync(model.CategoryId);

                model.Categories = categories;
                model.SubCategories = subcategories;
                return View(model);
            }

            try
            {
                var product = await _productRepository.GetByIdAsync(slug);
                if (product == null)
                {
                    return NotFound();
                }

                product.Name = model.Name;
                product.Description = model.Description;
                product.OriginalPrice = model.OriginalPrice;
                product.Discount = model.Discount;
                product.Sizes = string.Join(",", model.Sizes);
                product.CategoryId = model.CategoryId;
                product.SubCategoryId = model.SubCategoryId;
                product.UpdatedAt = DateTime.UtcNow;

                await _productRepository.UpdateAsync(product);

                // Handle image updates if new images are provided
                if (model.Images != null && model.Images.Any())
                {
                    var existingImages = await _imageRepository.GetImagesByProductIdAsync(product.Id);
                    foreach (var image in existingImages)
                    {
                        Console.WriteLine($"image Id : {image.Id}");
                        _imageRepository.DeleteAsync(image.Id);
                        var filePath = Path.Combine("wwwroot", image.path.TrimStart('/'));
                        if (System.IO.File.Exists(filePath))
                        {
                            System.IO.File.Delete(filePath);
                        }
                    }

                    var newImageUrls = await SaveProductImagesAsync(model.Images);
                    foreach (var imageUrl in newImageUrls)
                    {
                        var imageModel = new ImageModel
                        {
                            ProductId = product.Id,
                            filename = Path.GetFileName(imageUrl),
                            path = imageUrl,
                            size = model.Images.First().Length.ToString(),
                            type = model.Images.First().ContentType,
                            CreatedAt = DateTime.UtcNow,
                            UpdatedAt = DateTime.UtcNow
                        };
                        await _imageRepository.AddAsync(imageModel);
                    }
                }

                TempData["SuccessMessage"] = "Product updated successfully!";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"An error occurred: {ex.Message}");
                return View(model);
            }
        } */

        // DELETE: Delete
        [HttpPost("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string slug)
        {
            try
            {
                var product = await _productRepository.GetByIdAsync(slug);
                if (product == null)
                {
                    return NotFound();
                }

                // Delete associated images
                var images = await _imageRepository.GetImagesByProductIdAsync(product.Id);
                foreach (var image in images)
                {
                    Console.WriteLine($"delete image Id : {image.Id} ");
                    _imageRepository.DeleteAsync(image.Id);
                    var filePath = Path.Combine("wwwroot", image.path.TrimStart('/'));
                    if (System.IO.File.Exists(filePath))
                    {
                        System.IO.File.Delete(filePath);
                    }
                }

                await _productRepository.DeleteAsync(product.slug);

                TempData["SuccessMessage"] = "Product deleted successfully!";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"An error occurred while deleting the product: {ex.Message}";
                return RedirectToAction("Index");
            }
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
                Console.WriteLine($"images : {images}");

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
