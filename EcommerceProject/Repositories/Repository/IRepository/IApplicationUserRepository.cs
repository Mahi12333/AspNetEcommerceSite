using EcommerceProject.Areas.Admin;
using EcommerceProject.Areas.Admin.Models;

namespace EcommerceProject.Repositories.Repository.IRepository
{
    public interface IApplicationUserRepository : IRepository<ApplicationUserModel>
    {
        // Add any custom methods specific to ApplicationUserModel
        Task<ApplicationUserModel> GetUserByEmailAsync(string email);
    }
}
