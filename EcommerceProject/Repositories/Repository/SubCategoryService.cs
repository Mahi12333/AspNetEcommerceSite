using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcommerceProject.Areas.Admin.Models;
using EcommerceProject.Areas.Admin.Models.ViewModels;
using EcommerceProject.Repositories.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using Sprache;

namespace EcommerceProject.Areas.Admin.Services
{
    public class SubCategoryService : ISubCategoryService
    {
        private readonly ApplicationDbContext _context;

        public SubCategoryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SubCategoryModel>> GetAllSubCategoriesAsync()
        {
            return await _context.SubCategories.Include(s => s.Category).ToListAsync();
        }

        public async Task<SubCategoryModel> GetSubCategoryByIdAsync(int id)
        {
            return await _context.SubCategories.Include(s => s.Category).FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<bool> CreateSubCategoryAsync(SubCategoryModel subCategory)
        {
            try
            {
                Console.WriteLine("CategoryIdcccc");
                Console.WriteLine($"Nameccc: {subCategory.Name}");
                Console.WriteLine($"Statusccc: {subCategory.Status}");

                _context.SubCategories.Add(subCategory);
                var result = await _context.SaveChangesAsync();
                // Return true if save operation affected at least one row
                return result > 0;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errornnnnnnn: {ex.Message}");
                throw;
            }
        }

        public async Task<bool> UpdateSubCategoryAsync(SubCategoryModel subCategory)
        {
            _context.SubCategories.Update(subCategory);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteSubCategoryAsync(int id)
        {
            var subCategory = await _context.SubCategories.FindAsync(id);
            if (subCategory == null) return false;

            _context.SubCategories.Remove(subCategory);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<SubCategoryPaginationVM> GetPagedSubCategoriesAsync(int page, int pageSize, string searchQuery = null)
        {
            var query = _context.SubCategories.Include(s => s.Category).AsQueryable();

            if (!string.IsNullOrEmpty(searchQuery))
            {
                query = query.Where(s => s.Name.Contains(searchQuery) || s.Category.Name.Contains(searchQuery));
            }

            var totalCount = await query.CountAsync();
            var subCategories = await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            return new SubCategoryPaginationVM
            {
                SubCategories = subCategories,
                PageSize = pageSize,
                Page = page,
                TotalCount = totalCount
            };
        }

        public async Task<IEnumerable<SubCategoryModel>> GetSubCategoriesByCategoryIdAsync(int categoryId)
        {
            return await _context.SubCategories
            .Where(sc => sc.CategoryId == categoryId)
             .ToListAsync();
        }

    }
}
