using EcommerceProject.Areas.Admin.Models;
using EcommerceProject.Repositories.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceProject.Repositories
{
    public class ImageRepository : IImageRepository
    {
        private readonly ApplicationDbContext _context;

        public ImageRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(ImageModel image)
        {
            await _context.Images.AddAsync(image);
        }

        public async Task<IEnumerable<ImageModel>> GetImagesByProductIdAsync(int productId)
        {
            return await _context.Images
                .Where(i => i.ProductId == productId)
                .ToListAsync();
        }

        public async Task<ImageModel> GetByIdAsync(int id)
        {
            return await _context.Images.FindAsync(id);
        }

        public async Task DeleteAsync(int id)
        {
            var image = await _context.Images.FindAsync(id);
            if (image != null)
            {
                _context.Images.Remove(image);
            }
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
