using EcommerceProject.Areas.Admin.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using static System.Net.WebRequestMethods;

public class ApplicationDbContext : IdentityDbContext<ApplicationUserModel, CustomRoleModel, string>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    // Add DbSet properties for your custom entities
    public DbSet<ApplicationUserModel> ApplicationUsers { get; set; }
    public DbSet<CustomRoleModel> CustomRoles { get; set; }
    public DbSet<OtpModel> Otps { get; set; } // Example: If you have an Otp table
    public DbSet<PermissionModel> Permissions { get; set; }
    public DbSet<UserPermissionModel> UserPermissions { get; set; }
    public DbSet<CategoryModel> Categories { get; set; }
    public DbSet<SubCategoryModel> SubCategories { get; set; }
    public DbSet<ProductModel> Products { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Configure one-to-one relationship between ApplicationUserModel and CustomRoleModel
        builder.Entity<ApplicationUserModel>()
            .HasOne(u => u.Role)
            .WithMany() // no collection on the CustomRoleModel side
            .HasForeignKey(u => u.RoleId)
            .OnDelete(DeleteBehavior.Restrict); // Prevent cascading delete to avoid accidental deletions


        // Predefined role GUIDs
        var adminRoleId = "B993F718-51B6-4FBE-9F17-037FA1585827";
        var subadminRoleId = "C0CF4D0F-9BC6-4B70-BAED-2CA10F1AAA30";
        var supersubadminRoleId = "5482176B-6706-476D-A273-1EA9AD5AD217";

        // Seeding roles
        builder.Entity<CustomRoleModel>().HasData(
            new CustomRoleModel
            {
                Id = adminRoleId,
                Name = "Admin",
                Slug = "admin",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new CustomRoleModel
            {
                Id = subadminRoleId,
                Name = "Subadmin",
                Slug = "subadmin",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new CustomRoleModel
            {
                Id = supersubadminRoleId,
                Name = "Supersubadmin",
                Slug = "supersubadmin",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            }
        );

        // Seeding an admin user with a hashed password
        var adminUserId = Guid.NewGuid().ToString();
        builder.Entity<ApplicationUserModel>().HasData(
            new ApplicationUserModel
            {
                Id = adminUserId,
                UserName = "adminUser",
                Email = "mahitoshgiri287@gmail.com",
                RoleId = adminRoleId, // Directly assigning the role ID
                PasswordHash = new PasswordHasher<ApplicationUserModel>().HashPassword(null, "Admin"),
                EmailConfirmed = true,
                Slug = "admin-user",
                RefreshToken = "SomeDummyTokenValue3543564",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            }
        );

        // Seeding permissions
        var permissions = new List<PermissionModel>
    {
       new PermissionModel { Id = 1, PermissionName = "Create Product" },
       new PermissionModel { Id = 2, PermissionName = "Edit Product" },
       new PermissionModel { Id = 3, PermissionName = "Delete Product" },
       new PermissionModel { Id = 4, PermissionName = "View Orders" },
       new PermissionModel { Id = 5, PermissionName = "Manage Users" },
       new PermissionModel { Id = 6, PermissionName = "Access Admin Dashboard" },
       new PermissionModel { Id = 7, PermissionName = "Edit User" },
       new PermissionModel { Id = 8, PermissionName = "Delete User" },
       new PermissionModel { Id = 9, PermissionName = "Create Category" },
       new PermissionModel { Id = 10, PermissionName = "Edit Category" },
       new PermissionModel { Id = 11, PermissionName = "Delete Category" },
       new PermissionModel { Id = 12, PermissionName = "Create Subcategory" },
       new PermissionModel { Id = 13, PermissionName = "Edit Subcategory" },
       new PermissionModel { Id = 14, PermissionName = "Delete Subcategory" }
        // Add remaining permissions here...
    };
        builder.Entity<PermissionModel>().HasData(permissions);

        // Assign all permissions to the admin user
        var adminPermissions = permissions.Select(permission =>
            new UserPermissionModel { UserId = adminUserId, PermissionId = permission.Id }).ToArray();

        builder.Entity<UserPermissionModel>().HasData(adminPermissions);

        // Define many-to-many relationship between ApplicationUserModel and PermissionModel
        builder.Entity<UserPermissionModel>()
            .HasKey(up => new { up.UserId, up.PermissionId });

        builder.Entity<UserPermissionModel>()
            .HasOne(up => up.User)
            .WithMany(u => u.UserPermissions)
            .HasForeignKey(up => up.UserId);

        builder.Entity<UserPermissionModel>()
            .HasOne(up => up.Permission)
            .WithMany(p => p.UserPermissions)
            .HasForeignKey(up => up.PermissionId);

        // Configure one-to-many relationship between Category and SubCategory
        builder.Entity<SubCategoryModel>()
            .HasOne(s => s.Category)
            .WithMany(c => c.SubCategories)
            .HasForeignKey(s => s.CategoryId);

        // Products - Categories relationship
        builder.Entity<ProductModel>()
            .HasOne(p => p.Category)
            .WithMany(c => c.Products)
            .HasForeignKey(p => p.CategoryId)
            .OnDelete(DeleteBehavior.Restrict); // Use Restrict or SetNull

        // Products - SubCategories relationship
        builder.Entity<ProductModel>()
            .HasOne(p => p.SubCategory)
            .WithMany(sc => sc.Products)
            .HasForeignKey(p => p.SubCategoryId)
            .OnDelete(DeleteBehavior.Restrict); // Use Restrict or SetNull


        builder.Entity<ProductModel>(entity =>
        {
            entity.Property(p => p.Discount)
                  .HasColumnType("decimal(18,2)"); // Adjust precision and scale as needed
            entity.Property(p => p.OriginalPrice)
                  .HasColumnType("decimal(18,2)"); // Adjust precision and scale as needed
        });

    }
}
