using EcommerceProject.Areas.Admin.Models;
using EcommerceProject.Repositories.Repository.IRepository;
using Microsoft.EntityFrameworkCore; // Required for async methods
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceProject.Repositories.Repository
{
    public class PermissionService : IPermissionService
    {
        private readonly ApplicationDbContext _context;

        public PermissionService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Asynchronous method to get all permissions
        public async Task<IEnumerable<PermissionModel>> GetAllPermissionsAsync()
        {
            return await _context.Permissions.ToListAsync();
        }

        // Asynchronous method to assign a permission to a user
        public async Task AssignPermissionToUserAsync(string userId, int permissionId)
        {
            var userPermission = new UserPermissionModel { UserId = userId, PermissionId = permissionId };
            await _context.UserPermissions.AddAsync(userPermission);
            await _context.SaveChangesAsync();
        }

        // Asynchronous method to remove a permission from a user
        public async Task RemovePermissionFromUserAsync(string userId, int permissionId)
        {
            var userPermission = await _context.UserPermissions
                .FirstOrDefaultAsync(up => up.UserId == userId && up.PermissionId == permissionId);

            if (userPermission != null)
            {
                _context.UserPermissions.Remove(userPermission);
                await _context.SaveChangesAsync();
            }
        }

        // Asynchronous method to get permissions for a user
        public async Task<IEnumerable<PermissionModel>> GetPermissionsForUserAsync(string userId)
        {
            return await _context.UserPermissions
                .Where(up => up.UserId == userId)
                .Select(up => up.Permission)
                .ToListAsync();
           // var permissions = await _context.UserPermissions
           //.Where(up => up.UserId == userId)
           //.Select(up => up.Permission.Id)  // Selecting only the Permission IDs
           //.ToListAsync();

           // return permissions;
        }
    }
}
