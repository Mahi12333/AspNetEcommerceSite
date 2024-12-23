using System.Threading.Tasks;
using EcommerceProject.Areas.Admin.Models;
using EcommerceProject.Areas.Admin.Models.ViewModels;
using EcommerceProject.Areas.Admin.Services;
using EcommerceProject.Repositories.Repository;
using EcommerceProject.Repositories.Repository.IRepository;
using EcommerceProject.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EcommerceProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [MyAuthorization("Admin", "Subadmin")]
    public class SubCategoryController : Controller
    {
        private readonly ISubCategoryService _subCategoryService;
        private readonly ICategoryService _categoryService;

        public SubCategoryController(ISubCategoryService subCategoryService, ICategoryService categoryService)
        {
            _subCategoryService = subCategoryService;
            _categoryService = categoryService;
        }

        [HttpGet("Index")]
        [Permission("View Subcategory")]
        public async Task<IActionResult> Index(int page = 1, int pageSize = 10, string search = null)
        {
            var viewModel = await _subCategoryService.GetPagedSubCategoriesAsync(page, pageSize, search);
            return View(viewModel);
        }

        // HttpGet version of Create
        [HttpGet("Create")]
        [Permission("Create Subcategory")]
        public async Task<IActionResult> Create()
        {
            // Fetch all categories and convert them to SelectListItems for the dropdown
            var categories = await _categoryService.GetAllCategoriesAsync();
            ViewBag.Categories = categories.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name
            }).ToList();

            return View();
        }

        [HttpPost("Create")]
        [Permission("Create Subcategory")]
        public async Task<IActionResult> Create(SubCategoryVM viewModel)
        {
            if (!ModelState.IsValid)
            {
                var categories = await _categoryService.GetAllCategoriesAsync();
                ViewBag.Categories = categories.Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                }).ToList();

                TempData["ErrorMessage"] = "Please fix the errors.";
                return View(viewModel);
            }

            var categoryExists = await _categoryService.GetCategoryByIdAsync(viewModel.CategoryId) != null;
            if (!categoryExists)
            {
                TempData["ErrorMessage"] = "Invalid Category selected.";
                return View(viewModel);
            }

            // Map the ViewModel to the actual Model
            var subCategory = new SubCategoryModel
            {
                Name = viewModel.Name,
                CategoryId = viewModel.CategoryId,
                Status = viewModel.Status
            };

            bool result = await _subCategoryService.CreateSubCategoryAsync(subCategory);

            if (result)
            {
                TempData["SuccessMessage"] = "SubCategory created successfully!";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                TempData["ErrorMessage"] = "Failed to create SubCategory.";
                return View(viewModel);
            }
        }

        [HttpGet("Edit")]
        [Permission("Edit Subcategory")]
        public async Task<IActionResult> Edit(int id)
        {
            var subCategory = await _subCategoryService.GetSubCategoryByIdAsync(id);
            if (subCategory == null) return NotFound();

            // Map SubCategoryModel to SubCategoryVM, include Id
            var subCategoryVM = new SubCategoryVM
            {
                Id = subCategory.Id,       // Ensure Id is set
                Name = subCategory.Name,
                CategoryId = subCategory.CategoryId,
                Status = subCategory.Status
            };

            // Populate the categories dropdown list
            var categories = await _categoryService.GetAllCategoriesAsync();
            ViewBag.Categories = categories.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name
            }).ToList();

            return View(subCategoryVM);
        }


        [HttpPost("Edit")]
        [Permission("Edit Subcategory")]
        public async Task<IActionResult> Edit(SubCategoryVM subCategoryVM)
        {
            if (!ModelState.IsValid)
            {
                // Populate the categories dropdown list for redisplaying the form with errors
                var categories = await _categoryService.GetAllCategoriesAsync();
                ViewBag.Categories = categories.Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                }).ToList();

                TempData["ErrorMessage"] = "Please fix the errors.";
                return View(subCategoryVM);
            }

            // Map SubCategoryVM back to SubCategoryModel
            var subCategory = new SubCategoryModel
            {
                Id = subCategoryVM.Id, // Make sure to set the Id if needed
                Name = subCategoryVM.Name,
                CategoryId = subCategoryVM.CategoryId,
                Status = subCategoryVM.Status,
                UpdatedAt = DateTime.Now
            };

            bool result = await _subCategoryService.UpdateSubCategoryAsync(subCategory);
            TempData["SuccessMessage"] = result ? "SubCategory updated successfully!" : "Failed to update SubCategory.";

            return RedirectToAction(nameof(Index));
        }

        [HttpPost("Delete")]
        [Permission("Delete Subcategory")]
        public async Task<IActionResult> Delete(int id)
        {
            bool result = await _subCategoryService.DeleteSubCategoryAsync(id);
            TempData["SuccessMessage"] = result ? "SubCategory deleted successfully!" : "Failed to delete SubCategory.";
            return RedirectToAction(nameof(Index));
        }
    }

}
