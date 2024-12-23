using EcommerceProject.Areas.Admin.Models.ViewModels;
using EcommerceProject.Repositories.Repository.IRepository;
using EcommerceProject.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [MyAuthorization("Admin", "Subadmin")]
    [Route("Admin/User")]
    public class UserController : Controller
    {
        private readonly IRoleService _roleService;
        private readonly IPermissionService _permissionService;
        private readonly IUserService _userService;

        public UserController(IRoleService roleService, IPermissionService permissionService, IUserService userService)
        {
            _roleService = roleService;
            _permissionService = permissionService;
            _userService = userService;
        }

        // GET: Create
        [HttpGet("Create")]
        [Permission("Create User")] // Permissions check
        public async Task<IActionResult> Create()
        {
            var model = new CreateUserVM
            {
                Roles = (await _roleService.GetAllRolesAsync())
                    .Select(r => new SelectListItem { Value = r.Id.ToString(), Text = r.Name })
                    .ToList(),
                Permissions = (await _permissionService.GetAllPermissionsAsync())
                    .Select(p => new SelectListItem { Value = p.Id.ToString(), Text = p.PermissionName })
                    .ToList()
            };
            return View(model);
        }

        [HttpGet("Index")]
        [Permission("View User")] // Permissions check
        public async Task<IActionResult> Index(int page = 1, int pageSize = 10, string search = "")
        {
            var users = await _userService.GetUsersAsync(page, pageSize, search);
            var totalUsers = await _userService.GetUserCountAsync(search);
            Console.WriteLine("users", users);
            // Debug output to verify 'users' is not null
            if (users == null)
            {
                Console.WriteLine("Error: 'users' is null.");
            }
            else
            {
                Console.WriteLine("Users count: " + users.Count());
            }
            var viewModel = new PaginatedUserListVM
            {
                Users = users,
                Page = page,
                PageSize = pageSize,
                TotalUsers = totalUsers,
                Search = search
            };

            return View(viewModel);
        }




        // POST: Create
        [HttpPost("Create")]
        [Permission("Create User")] // Permissions check
        public async Task<IActionResult> Create(CreateUserVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            if (model.Password != model.ConfirmPassword)
            {
                Console.WriteLine($"password not match: {model.Password}");
                ModelState.AddModelError("ConfirmPassword", "Passwords do not match.");
                return View(model);
            }


            var newUser = new ApplicationUserModel
            {
                UserName = model.UserName,
                Email = model.Email,
                PhoneNumber = model.Mobile,
                RoleId = model.RoleId,
                Slug = model.UserName,
                RefreshToken = "Enter your Refresh Token",
                PasswordHash =  new PasswordHasher<ApplicationUserModel>().HashPassword(null, model.Password),

            };

            try
            {
                var userId = await _userService.CreateUserAsync(newUser);

                // Assign permissions to user
                foreach (var permissionId in model.SelectedPermissions)
                {
                    await _permissionService.AssignPermissionToUserAsync(userId, permissionId);
                }

                TempData["SuccessMessage"] = "User created successfully!";
                return RedirectToAction("Create");
            }
            catch (Exception)
            {
                TempData["ErrorMessage"] = "An error occurred while creating the user. Please try again.";
                return View(model);
            }
        }

        // GET: Edit User
        [HttpGet("Edit")]
        [Permission("Edit User")] // Permissions check
        public async Task<IActionResult> Edit(string userId)
        {
            var user = await _userService.GetUserByIdAsync(userId);
            if (user == null)
            {
                TempData["ErrorMessage"] = "User not found.";
                return RedirectToAction("Index");
            }

            var model = new EditUserVM
            {
                UserId = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                Mobile = user.PhoneNumber,
                RoleId = user.RoleId,
                SelectedPermissions = (await _permissionService.GetPermissionsForUserAsync(userId))
                    .Select(p => p.Id)
                    .ToList(),
                Permissions = (await _permissionService.GetAllPermissionsAsync())
                    .Select(p => new SelectListItem { Value = p.Id.ToString(), Text = p.PermissionName })
                    .ToList(),
                Roles = (await _roleService.GetAllRolesAsync())
                    .Select(r => new SelectListItem { Value = r.Id.ToString(), Text = r.Name })
                    .ToList()
            };

            return View(model);
        }

        // PUT: Edit User
        [HttpPost("Edit")]
        [Permission("Edit User")] // Permissions check
        public async Task<IActionResult> EditSubmit(EditUserVM model)
        {
            ModelState.Remove("Password");
            ModelState.Remove("ConfirmPassword");
            ModelState.Remove("email");
         

            if (!ModelState.IsValid)
            {
                Console.WriteLine("Model state is invalid");
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine($"Error: {error.ErrorMessage}");
                }
                return View("Edit", model);
            }

            try
            {
                var user = await _userService.GetUserByIdAsync(model.UserId);
                Console.WriteLine($"User: {user}");
                if (user == null)
                {
                    TempData["ErrorMessage"] = "User not found.";
                    return RedirectToAction("Index");
                }

                // Update user fields
                user.UserName = model.UserName;
                user.Email = model.Email;
                user.RoleId = model.RoleId;
                user.PhoneNumber = model.Mobile;
                



                // Update user in the database
                 await _userService.UpdateUserAsync(user);
               

                // Handle permissions
                var existingPermissions = (await _permissionService.GetPermissionsForUserAsync(user.Id))
                    .Select(p => p.Id).ToList();

                foreach (var permissionId in model.SelectedPermissions.Except(existingPermissions))
                {
                    await _permissionService.AssignPermissionToUserAsync(user.Id, permissionId);
                    Console.WriteLine($"Assigned permission {permissionId} to user {user.Id}");
                }

                foreach (var permissionId in existingPermissions.Except(model.SelectedPermissions))
                {
                    await _permissionService.RemovePermissionFromUserAsync(user.Id, permissionId);
                    Console.WriteLine($"Removed permission {permissionId} from user {user.Id}");
                }

                TempData["SuccessMessage"] = "User updated successfully!";
                return RedirectToAction("Edit", new { userId = model.UserId });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                TempData["ErrorMessage"] = "An error occurred while updating the user. Please try again.";
                return View("Edit", model);
            }
        }

        // POST: Confirm Delete User
        [HttpPost("Delete")]
        [Permission("Delete User")] // Permissions check
        public async Task<IActionResult> ConfirmDelete(string userId)
        {
            try
            {
                var user = await _userService.GetUserByIdAsync(userId);
                if (user == null)
                {
                    TempData["ErrorMessage"] = "User not found.";
                    return RedirectToAction("Index");
                }

                foreach (var permission in await _permissionService.GetPermissionsForUserAsync(user.Id))
                {
                    await _permissionService.RemovePermissionFromUserAsync(user.Id, permission.Id);
                }

                await _userService.DeleteUserAsync(userId);
                TempData["SuccessMessage"] = "User deleted successfully!";
            }
            catch (Exception)
            {
                TempData["ErrorMessage"] = "An error occurred while deleting the user. Please try again.";
            }

            return RedirectToAction("Index");
        }
    }
}
