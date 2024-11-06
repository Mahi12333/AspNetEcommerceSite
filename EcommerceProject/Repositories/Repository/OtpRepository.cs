using EcommerceProject.Areas.Admin.Models;
using EcommerceProject.Repositories.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using static System.Net.WebRequestMethods;

namespace EcommerceProject.Repositories.Repository
{
    public class OtpRepository : Repository<OtpModel>, IOtpRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public OtpRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OtpModel> GetOtpByEmailAsync(string email)
        {
            return await _dbContext.Otps
                .FirstOrDefaultAsync(o => o.UserId == email && !o.IsUsed);
        }
    }
}
