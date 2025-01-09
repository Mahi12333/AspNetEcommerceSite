using EcommerceProject.Areas.Admin.Models;

namespace EcommerceProject.Repositories.Repository.IRepository
{
    public interface IImageRepository
    {
        Task AddAsync(ImageModel image);
        Task<IEnumerable<ImageModel>> GetImagesByProductIdAsync(int productId);
        Task<ImageModel> GetByIdAsync(int id);
        Task DeleteAsync(int id);
        Task SaveChangesAsync();
    }
}
