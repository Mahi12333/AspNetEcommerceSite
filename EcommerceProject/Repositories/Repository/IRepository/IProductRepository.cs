using EcommerceProject.Areas.Admin.Models;
using EcommerceProject.Areas.Admin.Models.ViewModels;

namespace EcommerceProject.Repositories.Repository.IRepository
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductModel>> GetAllAsync();
        Task<ProductModel> GetByIdAsync(int id);
        Task AddAsync(ProductModel product);
        Task UpdateAsync(ProductModel product);
        Task DeleteAsync(int id);
    }
}
