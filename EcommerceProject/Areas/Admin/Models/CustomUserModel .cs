//using Microsoft.AspNetCore.Identity;
//using System;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;

//namespace EcommerceProject.Areas.Admin.Models
//{
//    public class CustomUser : IdentityUser
//    {
//        [Key]
//        public string Id { get; set; } = Guid.NewGuid().ToString();

//        [Required]
//        [MaxLength(200)]
//        public string Username { get; set; }

//        [Required]
//        [MaxLength(200)]
//        public string Slug { get; set; }

//        [Required]
//        public bool EmailVerified { get; set; }

//        [Required]
//        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

//        [Required]
//        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

//        // Role Relationship
//        public string RoleId { get; set; }

//        [ForeignKey("RoleId")]
//        public CustomRole Role { get; set; }
//    }
//}
