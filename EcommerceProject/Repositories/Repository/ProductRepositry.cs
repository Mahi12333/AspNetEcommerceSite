using EcommerceProject.Areas.Admin.Models;
using EcommerceProject.Repositories.Repository.IRepository;
using Microsoft.EntityFrameworkCore;


namespace EcommerceProject.Repositories.Repository
{
    public class ProductRepositry : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepositry(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductModel>> GetAllAsync()
        {
            return await _context.Products
                .Include(p => p.Category)
                .Include(p => p.SubCategory)
                .ToListAsync();
        }

        public async Task<ProductModel> GetByIdAsync(string slug)
        {
            return await _context.Products
                .Include(p => p.Category)
                .Include(p => p.SubCategory)
                .FirstOrDefaultAsync(p => p.slug == slug);
        }

        public async Task AddAsync(ProductModel product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ProductModel product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string slug)
        {
            var product = await GetByIdAsync(slug);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
        }

        public async Task SaveChangesAsync()
        {
                await _context.SaveChangesAsync();
        }
    }
}
