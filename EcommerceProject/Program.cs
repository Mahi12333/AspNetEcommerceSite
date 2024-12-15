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
using EcommerceProject.Areas.Admin.Services;
using EcommerceProject.middleware;
using Humanizer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

            /* // Configure Cookie Authentication
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/Admin/Authentication/Login"; // Path to your Login page
                    options.AccessDeniedPath = "/Admin/Authentication/AccessDenied"; // Path to access denied page
                });
            */

            // Add CORS policies
            /*builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigins", builder =>
                {
                    builder.WithOrigins("http://localhost:5115", "https://anotherexample.com") // Allowed origins
                           .AllowAnyHeader()
                           .AllowAnyMethod()
                           .AllowCredentials();
                });

                options.AddPolicy("AllowAll", builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyHeader()
                           .AllowAnyMethod();
                });
            });*/

            // Custom Services Registration
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IEmailSender, EmailSender>();
            builder.Services.AddScoped<IRoleService, RoleService>();
            builder.Services.AddScoped<IPermissionService, PermissionService>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<ISubCategoryService, SubCategoryService>();
            builder.Services.AddScoped<IProductRepository, ProductRepositry>();
            builder.Services.AddScoped<TokenService>();
            builder.Services.AddScoped<IJwtService, JwtService>();
            //builder.Services.AddTransient<AuthMiddleware>();


            // Register OtpManager
            builder.Services.AddTransient<OtpManager>();
            // Register OtpService
            builder.Services.AddTransient<OtpService>();

            builder.Configuration.AddEnvironmentVariables();
            DotNetEnv.Env.Load();

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
            app.UseDeveloperExceptionPage(); // For debugging

            // Add Routing middleware first
            app.UseRouting();

            // Custom Middleware
            //app.UseMiddleware<AuthMiddleware>();
            //app.UseMiddleware<AuthorizationMiddleware>();
            //app.UseMiddleware<PermissionMiddleware>();

            // For Pagination
            //app.UseDeveloperExceptionPage();
            // Add environment variables to configuration
            

            // Authentication & Authorization Middleware
            app.UseAuthentication();  // Ensure authentication is added here
            app.UseAuthorization();   // Authorization comes after authentication
                                      // Routing middleware
            // Routing for Admin and Customer Areas
            //app.MapControllerRoute(
            //    name: "admin",
            //    pattern: "{area=Admin}/{controller=Home}/{action=Dashboard}/{id?}");
            ////.RequireAuthorization(); // This ensures that the entire Admin area requires authorization

            //app.MapControllerRoute(
            //    name: "customer",
            //    pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}");

            // Routing for Admin Area
            app.MapControllerRoute(
                name: "admin",
                pattern: "{area=Admin}/{controller=Home}/{action=Dashboard}/{id?}");
               // .RequireAuthorization(); // Enforces authorization for all Admin routes

            // Routing for Customer Area
            app.MapControllerRoute(
                name: "customer",
                pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}");

            // Fallback for general controllers (optional)
            //app.MapControllerRoute(
            //    name: "default",
            //    pattern: "{controller=Home}/{action=Index}/{id?}");



            app.Run();
        }
    }
}
