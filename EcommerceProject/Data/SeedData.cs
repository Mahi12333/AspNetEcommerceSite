//using EcommerceProject.Areas.Admin.Models;
//using Microsoft.AspNetCore.Identity;

//namespace EcommerceProject.Data
//{
//    public class SeedData
//    {
//        public static async Task Initialize(IServiceProvider serviceProvider)
//        {
//            var userManager = serviceProvider.GetRequiredService<UserManager<CustomUser>>();
//            var roleManager = serviceProvider.GetRequiredService<RoleManager<CustomRole>>();

//            // Create a default admin user
//            var adminUser = new CustomUser
//            {
//                UserName = "adminUser",
//                Email = "admin@example.com",
//                Slug = "admin-user",
//                EmailVerified = true,
//                RoleId = (await roleManager.FindByNameAsync("Admin")).Id
//            };

//            var user = await userManager.FindByEmailAsync(adminUser.Email);
//            if (user == null)
//            {
//                await userManager.CreateAsync(adminUser, "Admin@123");
//            }
//        }
//    }
//}
