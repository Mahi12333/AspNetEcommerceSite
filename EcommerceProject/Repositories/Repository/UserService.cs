using EcommerceProject.Repositories.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace EcommerceProject.Repositories.Repository
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Modify CreateUserAsync to return the new user ID as a string
        public async Task<string> CreateUserAsync(ApplicationUserModel user)
        {
            await _context.ApplicationUsers.AddAsync(user);
            await _context.SaveChangesAsync();
            return user.Id; // Return the ID of the created user
        }

        public async Task<ApplicationUserModel> GetUserByIdAsync(string userId)
        {
            return await _context.ApplicationUsers.FindAsync(userId);
        }

        public async Task UpdateUserAsync(ApplicationUserModel user)
        {
            var existingUser = await _context.ApplicationUsers.FindAsync(user.Id);
            if (existingUser == null)
            {
                throw new InvalidOperationException("User not found.");
            }

            _context.Entry(existingUser).CurrentValues.SetValues(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(string userId)
        {
            var user = await _context.ApplicationUsers.FindAsync(userId);
            if (user != null)
            {
                _context.ApplicationUsers.Remove(user);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException("User not found.");
            }
        }

        public async Task<IEnumerable<ApplicationUserModel>> GetUsersAsync(int page, int pageSize, string search = "")
        {
            try
            {
                var query = _context.ApplicationUsers
            .Include(u => u.Role) // Include the Role details
            .Include(u => u.UserPermissions) // Include the UserPermissions details
                .ThenInclude(up => up.Permission) // Optionally, include Permission details if needed
            .AsQueryable();

                Console.WriteLine("Query initialized: " + query);

                if (!string.IsNullOrEmpty(search))
                {
                    query = query.Where(u => (u.UserName != null && u.UserName.Contains(search)) ||
                                             (u.Email != null && u.Email.Contains(search)));
                }

                return await query
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in GetUsersAsync: " + ex.Message);
                return Enumerable.Empty<ApplicationUserModel>();
            }
        }

        public async Task<int> GetUserCountAsync(string search = "")
        {
            if (_context.ApplicationUsers == null)
            {
                Console.WriteLine("Error: ApplicationUsers DbSet is null.");
                return 0;
            }

            if (!string.IsNullOrEmpty(search))
            {
                return await _context.ApplicationUsers.CountAsync(u =>
                    (u.UserName != null && u.UserName.Contains(search)) ||
                    (u.Email != null && u.Email.Contains(search)));
            }

            return await _context.ApplicationUsers.CountAsync();
        }



    }
}
