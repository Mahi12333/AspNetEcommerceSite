using System.ComponentModel.DataAnnotations;

namespace EcommerceProject.Areas.Admin.Models
{
    public class CategoryModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public string Status { get; set; } // True for active, False for inactive

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime? UpdatedAt { get; set; }

        // Add the navigation property for SubCategories
        public ICollection<SubCategoryModel> SubCategories { get; set; }
        // Add the navigation property for Products
        public ICollection<ProductModel> Products { get; set; }
    }
}
