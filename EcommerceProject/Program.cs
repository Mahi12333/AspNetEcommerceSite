using EcommerceProject.Areas.Admin.Models;
using EcommerceProject.Repositories.Repository.IRepository;
using EcommerceProject.Repositories.Repository;
using EcommerceProject.Utils;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using EcommerceProject.Services;
using EcommerceProject.Areas.Admin.Services;
using EcommerceProject.middleware;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace EcommerceProject
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddHttpContextAccessor();

            // Add DBContext
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("Ecommerce_connection"))
            );

            // Add Identity without default UI
            builder.Services.AddIdentity<ApplicationUserModel, CustomRoleModel>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders(); // Removed AddDefaultUI()

           /* // Configure custom Login Path for cookies
            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Admin/Authentication/Login"; // Custom login path
                options.AccessDeniedPath = "/Admin/Authentication/AccessDenied";
                options.Cookie.HttpOnly = true;
                options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
            });*/

            // Custom Service Registration
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

            // Middleware Registration
            builder.Services.AddTransient<OtpManager>();
            builder.Services.AddTransient<OtpService>();

            builder.Configuration.AddEnvironmentVariables();
            DotNetEnv.Env.Load();

            var app = builder.Build();

            // HTTP Request Pipeline Configuration
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            else
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseRouting();
            /*// Authentication & Authorization Middleware
            app.UseAuthentication();
            app.UseAuthorization();*/

            // Custom Middlewares
            //app.UseMiddleware<AuthMiddleware>();
            app.UseMiddleware<AuthorizationMiddleware>();
            app.UseMiddleware<PermissionMiddleware>();

            

            // Admin Area Routing
            app.MapControllerRoute(
                name: "admin",
                pattern: "{area=Admin}/{controller=Home}/{action=Dashboard}/{id?}");

            // Customer Area Routing
            app.MapControllerRoute(
                name: "customer",
                pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
