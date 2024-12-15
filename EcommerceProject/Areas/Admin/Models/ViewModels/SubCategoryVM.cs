using System.ComponentModel.DataAnnotations;

namespace EcommerceProject.Areas.Admin.Models.ViewModels
{
    public class SubCategoryVM
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public string Status { get; set; }
    }
}
