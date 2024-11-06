using EcommerceProject.Areas.Admin.Models;
using static System.Net.WebRequestMethods;

namespace EcommerceProject.Repositories.Repository.IRepository
{
    public interface IOtpRepository : IRepository<OtpModel>
    {
        Task<OtpModel> GetOtpByEmailAsync(string email);
    }
}
