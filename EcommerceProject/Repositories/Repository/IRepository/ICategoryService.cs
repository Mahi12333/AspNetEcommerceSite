using EcommerceProject.Areas.Admin.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EcommerceProject.Repositories.Repository.IRepository
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryModel>> GetAllCategoriesAsync();
        Task<CategoryModel> GetCategoryByIdAsync(int id);
        Task AddCategoryAsync(CategoryModel category);
        Task UpdateCategoryAsync(CategoryModel category);
        Task DeleteCategoryAsync(int id);
        Task<(IEnumerable<CategoryModel> Categories, int TotalCount)> GetCategoriesAsync(string search, int page, int pageSize);
    }
}
