using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace EcommerceProject.Areas.Admin.Models.ViewModels
{
    public class CreateUserVM
    {
        [Required]
        [Display(Name = "Username")]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Phone]
        [Display(Name = "Mobile")]
        public string Mobile { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "Role")]
        public string RoleId { get; set; }

        // Dropdown list for roles
        public List<SelectListItem> Roles { get; set; } = new List<SelectListItem>();

        // List of permissions
        public List<SelectListItem> Permissions { get; set; } = new List<SelectListItem>();

        // Selected permissions
        public List<int> SelectedPermissions { get; set; } = new List<int>(); // Add this property
    }
    public class EditUserVM : CreateUserVM
    {
        public string UserId { get; set; }
    }
}
