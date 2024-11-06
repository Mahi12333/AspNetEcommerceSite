using System.ComponentModel.DataAnnotations;

namespace EcommerceProject.Areas.Admin.Models
{
    public class PermissionModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string PermissionName { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // Navigation property for UserPermissions
        public ICollection<UserPermissionModel> UserPermissions { get; set; } = new List<UserPermissionModel>();
    }
}
