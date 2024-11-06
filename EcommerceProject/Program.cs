using EcommerceProject.Areas.Admin.Models;
//using EcommerceProject.Data;
using EcommerceProject.Repositories.Repository.IRepository;
using EcommerceProject.Repositories.Repository;
using EcommerceProject.Utils;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using EcommerceProject.Services;

namespace EcommerceProject
{
    public class Program
    {
        public static async Task Main(string[] args) // Change to async Task
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            // Register IHttpContextAccessor
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                  options.UseSqlServer(builder.Configuration.GetConnectionString("Ecommerce_connection"))
             );

             // Adds Identity services to manage authentication and authorization. AddEntityFrameworkStores  will be work when IdentityUser will be use.
             // AddEntityFrameworkStores is designed to work with a class that inherits from IdentityUser, but you have replaced IdentityUser with your own custom ApplicationUserModel
             builder.Services.AddIdentity<ApplicationUserModel, CustomRoleModel>()
                 .AddEntityFrameworkStores<ApplicationDbContext>()
                 .AddDefaultTokenProviders();

            // Custom Services Registration
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IEmailSender, EmailSender>();
            builder.Services.AddScoped<IRoleService, RoleService>();
            builder.Services.AddScoped<IPermissionService, PermissionService>();
            builder.Services.AddScoped<IUserService, UserService>();

            // Register OtpManager
            builder.Services.AddTransient<OtpManager>();
            // Register OtpService
            builder.Services.AddTransient<OtpService>();

            // Configure Cookie Authentication
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/Admin/Authentication/Login"; // Path to your Login page
                    options.AccessDeniedPath = "/Admin/Authentication/AccessDenied"; // Path to access denied page
                });

            // Add Razor Pages
            builder.Services.AddRazorPages();

            var app = builder.Build();

           /* // Seed the database with roles and default user
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    await SeedData.Initialize(services);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred seeding the DB.");
                }
            }*/

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            //app.UseHttpsRedirection(); // Ensure this is added for redirecting HTTP to HTTPS
            app.UseStaticFiles();

            // Routing middleware
            app.UseRouting();
            // For Pagination
            app.UseDeveloperExceptionPage();


            // Authentication & Authorization Middleware
            app.UseAuthentication();  // Ensure authentication is added here
            app.UseAuthorization();   // Authorization comes after authentication

            app.MapRazorPages(); // Enable the routing of Razor Pages
            app.MapControllerRoute(
                 name: "default",
                 pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
