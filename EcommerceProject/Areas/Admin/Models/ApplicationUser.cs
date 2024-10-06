using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EcommerceProject.Areas.Admin.Models
{
    public class ApplicationUser
    {
        [Required]
        public string Name { get; set; }
        public string? StreetAddress { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? PostalCode { get; set; }
        public int? CompanyId { get; set; }
        //[ForeignKey("CompanyId")]
        //[ValidateNever]
        //public Company? Company { get; set; }
        [NotMapped]
        public string Role { get; set; }
    }
}
