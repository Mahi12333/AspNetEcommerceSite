using EcommerceProject.Areas.Admin.Models.ViewModels;
using EcommerceProject.Areas.Admin.Models;

namespace EcommerceProject.Repositories.Repository.IRepository
{
    public interface ISubCategoryService
    {
        Task<IEnumerable<SubCategoryModel>> GetAllSubCategoriesAsync();
        Task<SubCategoryModel> GetSubCategoryByIdAsync(int id);
        Task<bool> CreateSubCategoryAsync(SubCategoryModel subCategory);
        Task<bool> UpdateSubCategoryAsync(SubCategoryModel subCategory);
        Task<bool> DeleteSubCategoryAsync(int id);
        Task<SubCategoryPaginationVM> GetPagedSubCategoriesAsync(int page, int pageSize, string searchQuery = null);
        Task<IEnumerable<SubCategoryModel>> GetSubCategoriesByCategoryIdAsync(int categoryId);
    }
}
