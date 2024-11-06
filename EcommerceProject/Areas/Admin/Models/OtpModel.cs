using System;
using System.ComponentModel.DataAnnotations;

namespace EcommerceProject.Areas.Admin.Models
{
    public class OtpModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }  // This will store the email or user identifier
        public string Otp { get; set; }  // The OTP code
        public bool IsUsed { get; set; }  // Whether the OTP has already been used
        public DateTime CreatedAt { get; set; }  // When the OTP was created
        public DateTime UpdatedAt { get; set; }  // When the OTP was last updated
    }

}
