using System.ComponentModel.DataAnnotations;

namespace EcommerceProject.Areas.Admin.Models.ViewModels
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

       // public bool RememberMe { get; set; }

        // Add the OTP property here
        // Optional: Include OTP here but don't make it required for the initial login.
        //public string Otp { get; set; }

    }
}
