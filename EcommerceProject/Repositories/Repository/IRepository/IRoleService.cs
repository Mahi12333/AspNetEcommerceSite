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
    }
}
