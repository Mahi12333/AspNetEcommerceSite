using EcommerceProject.Areas.Admin.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

public class ApplicationUserModel : IdentityUser
{
    public string Slug { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    // Foreign key for the Role (one-to-one relationship)
    [Required]
    public string RoleId { get; set; }
    public CustomRoleModel Role { get; set; }

    // Navigation property for UserPermissions
    public ICollection<UserPermissionModel> UserPermissions { get; set; } = new List<UserPermissionModel>();
}
