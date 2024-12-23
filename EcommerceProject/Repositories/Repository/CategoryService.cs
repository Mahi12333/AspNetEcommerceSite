using EcommerceProject.Areas.Admin.Models;
using EcommerceProject.Repositories.Repository.IRepository;
using Microsoft.EntityFrameworkCore;


namespace EcommerceProject.Repositories.Repository
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext _context;

        public CategoryService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<CategoryModel>> GetAllCategoriesAsync()
        {
            var Category = await _context.Categories.ToListAsync();
            Console.WriteLine($"Category --- Product: { Category }");
            return await _context.Categories.ToListAsync();
        }

        public async Task<CategoryModel> GetCategoryByIdAsync(int id)
        {
            return await _context.Categories.FindAsync(id);
        }

        public async Task AddCategoryAsync(CategoryModel category)
        {
            try
            {

                category.UpdatedAt = DateTime.Now;
                _context.Categories.Add(category);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error mahitosh: {ex.Message}");
                throw;
            }
        }

        public async Task UpdateCategoryAsync(CategoryModel category)
        {
            var existingCategory = await _context.Categories.FindAsync(category.Id);
            if (existingCategory != null)
            {
                existingCategory.Name = category.Name;
                existingCategory.Status = category.Status;
                existingCategory.UpdatedAt = DateTime.Now;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteCategoryAsync(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category != null)
            {
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<(IEnumerable<CategoryModel> Categories, int TotalCount)> GetCategoriesAsync(string search, int page, int pageSize)
        {
            var query = _context.Categories.AsQueryable();

            // Apply search filter
            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(c => c.Name.Contains(search) || c.Status.Contains(search));
            }

            // Get total count before pagination
            int totalCount = await query.CountAsync();

            // Apply pagination
            var categories = await query
                .OrderBy(c => c.Name)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (categories, totalCount);
        }
    }
}
