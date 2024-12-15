using EcommerceProject.Areas.Admin.Models;
using EcommerceProject.Repositories.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace EcommerceProject.Repositories.Repository
{
    public class RoleService : IRoleService
    {
        private readonly ApplicationDbContext _context;

        public RoleService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Asynchronous method to get all roles
        public async Task<IEnumerable<CustomRoleModel>> GetAllRolesAsync()
        {
            return await _context.CustomRoles.ToListAsync();
        }

        // Asynchronous method to get a role by ID
        public async Task<CustomRoleModel> GetRoleByIdAsync(string roleId)
        {
            return await _context.CustomRoles.FindAsync(roleId);
        }

        // Asynchronous method to create a role
        public async Task CreateRoleAsync(CustomRoleModel role)
        {
            await _context.CustomRoles.AddAsync(role);
            await _context.SaveChangesAsync();
        }

        // Asynchronous method to update a role
        public async Task UpdateRoleAsync(CustomRoleModel role)
        {
            _context.CustomRoles.Update(role);
            await _context.SaveChangesAsync();
        }

        // Asynchronous method to delete a role
        public async Task DeleteRoleAsync(string roleId)
        {
            var role = await _context.CustomRoles.FindAsync(roleId);
            if (role != null)
            {
                _context.CustomRoles.Remove(role);
                await _context.SaveChangesAsync();
            }
        }

        // Asynchronous method to get a role by user ID
        public async Task<CustomRoleModel> GetRoleByUserIdAsync(string userId) // Return single role
        {
            var user = await _context.ApplicationUsers
                .Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.Id == userId);

            return user?.Role;
        }
    }
}
