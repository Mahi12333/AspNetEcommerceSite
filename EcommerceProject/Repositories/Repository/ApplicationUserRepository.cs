using EcommerceProject.Areas.Admin.Models;
using EcommerceProject.Repositories.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace EcommerceProject.Repositories.Repository
{
    public class ApplicationUserRepository : Repository<ApplicationUserModel>, IApplicationUserRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ApplicationUserRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ApplicationUserModel> GetUserByEmailAsync(string email)
        {
            return await _dbContext.ApplicationUsers
                .FirstOrDefaultAsync(u => u.Email == email);
        }

    }
}
