﻿using EcommerceProject.Areas.Admin.Models;
using EcommerceProject.Areas.Admin.Models.ViewModels;
using EcommerceProject.Repositories.Repository.IRepository;
using EcommerceProject.Utils;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [MyAuthorization("Admin", "Subadmin")]
    [Route("Admin/Category")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("Index")]
        [Permission("View Category")]
        public async Task<IActionResult> Index(string search, int page = 1, int pageSize = 10)
        {
            var result = await _categoryService.GetCategoriesAsync(search, page, pageSize);
            var viewModel = new CategoryPaginationVM
            {
                Categories = result.Categories,
                PageSize = pageSize,
                Page = page,
                TotalCount = result.TotalCount
            };
            return View(viewModel);
        }

        [HttpGet("Create")]
        [Permission("Create Category")]
        // GET: Admin/Category/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Category/Create
        [HttpPost("Create")]
        [Permission("Create Category")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoryModel category)
        {
            if (!ModelState.IsValid)
            {
                foreach (var modelState in ModelState.Values)
                {
                    foreach (var error in modelState.Errors)
                    {
                        Console.WriteLine($"required field : {error.ErrorMessage}");
                    }
                }
            }

            if (ModelState.IsValid)
            {
                Console.WriteLine("category", category);
                await _categoryService.AddCategoryAsync(category);
                TempData["SuccessMessage"] = "Category created successfully!";
                return RedirectToAction("Index");
            }
            return View(category);
        }

        [HttpGet("Edit")]
        [Permission("Edit Category")]
        // GET: Admin/Category/Edit/{id}
        public async Task<IActionResult> Edit(int id)
        {
            var category = await _categoryService.GetCategoryByIdAsync(id);
            if (category == null)
            {
                TempData["ErrorMessage"] = "Category not found.";
                return RedirectToAction("Index");
            }
            return View(category);
        }

        // POST: Admin/Category/Edit/{id}
        [HttpPost("Edit")]
        [Permission("Edit Category")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CategoryModel category)
        {
            if (ModelState.IsValid)
            {
                await _categoryService.UpdateCategoryAsync(category);
                TempData["SuccessMessage"] = "Category updated successfully!";
                return RedirectToAction("Index");
            }
            return View(category);
        }

        // POST: Admin/Category/Delete/{id}
        [HttpPost("Delete")]
        [Permission("Delete Category")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _categoryService.DeleteCategoryAsync(id);
            TempData["SuccessMessage"] = "Category deleted successfully!";
            return RedirectToAction("Index");
        }
    }
}
