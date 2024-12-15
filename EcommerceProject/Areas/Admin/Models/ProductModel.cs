using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EcommerceProject.Areas.Admin.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal OriginalPrice { get; set; }
        public decimal Discount { get; set; }
        public List<string> ImageUrls { get; set; } = new List<string>();
        public string Sizes { get; set; } // Stored as a comma-separated string
        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        // Navigation properties
        public CategoryModel? Category { get; set; }
        public SubCategoryModel? SubCategory { get; set; }

    }
}
