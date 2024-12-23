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

        // Initialize the navigation properties to avoid validation errors
        public ICollection<SubCategoryModel> SubCategories { get; set; } = new List<SubCategoryModel>();
        public ICollection<ProductModel> Products { get; set; } = new List<ProductModel>();
    }
}
