using EcommerceProject.Areas.Admin.Models;
using System.Threading.Tasks;

namespace EcommerceProject.Repositories.Repository.IRepository
{
    public interface IUserService
    {
        Task<string> CreateUserAsync(ApplicationUserModel user);  // Return type updated to Task<string>
        Task<ApplicationUserModel> GetUserByIdAsync(string userId);
        Task UpdateUserAsync(ApplicationUserModel user);
        Task DeleteUserAsync(string userId);
        Task<IEnumerable<ApplicationUserModel>> GetUsersAsync(int page, int pageSize, string search = "");
        Task<int> GetUserCountAsync(string search = "");
    }
}
