using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceProject.Areas.Admin.Models
{
    public class SubCategoryModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        public CategoryModel Category { get; set; }
        [Required]
        public string Status { get; set; } // True for active, False for inactive  as string

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime? UpdatedAt { get; set; }

        // Add the navigation property for Products
        public ICollection<ProductModel> Products { get; set; } = new List<ProductModel>();
    }
}
