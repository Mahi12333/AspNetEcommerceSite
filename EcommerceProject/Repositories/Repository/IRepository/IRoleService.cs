using EcommerceProject.Areas.Admin.Models;

namespace EcommerceProject.Repositories.Repository.IRepository
{
    public interface IRoleService
    {
        Task<IEnumerable<CustomRoleModel>> GetAllRolesAsync();
        Task<CustomRoleModel> GetRoleByIdAsync(string roleId);
        Task CreateRoleAsync(CustomRoleModel role);
        Task UpdateRoleAsync(CustomRoleModel role);
        Task DeleteRoleAsync(string roleId);
        //Task GetRoleByUserIdAsync(string userId);
        Task<CustomRoleModel> GetRoleByUserIdAsync(string userId); // Change return type to CustomRoleModel

    }
}
