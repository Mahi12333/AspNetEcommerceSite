using EcommerceProject.Areas.Admin.Models;

namespace EcommerceProject.Repositories.Repository.IRepository
{
    public interface IPermissionService
    {
        Task<IEnumerable<PermissionModel>> GetAllPermissionsAsync();
        Task AssignPermissionToUserAsync(string userId, int permissionId);
        Task RemovePermissionFromUserAsync(string userId, int permissionId);
        Task<IEnumerable<PermissionModel>> GetPermissionsForUserAsync(string userId);
    }
}
