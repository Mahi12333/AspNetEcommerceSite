using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace EcommerceProject.Areas.Admin.Models.ViewModels
{
    public class ProductVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal OriginalPrice { get; set; }
        public decimal Discount { get; set; }
        public List<IFormFile>? Images { get; set; }
        public List<string>? Sizes { get; set; } = new List<string>();
        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }
        public List<ImageVM>? ExistingImages { get; set; } = new List<ImageVM>();
        public string Status { get; set; } = "active";
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public List<string>? ImagesPath { get; set; } // Use List<string> for paths
        public decimal finalPrice { get; set; }
        public string? slug { get; set; }
        public string? ImagesToRemove { get; set; }

        public string? Category { get; set; } // Name of the category
        public string? SubCategory { get; set; } // Name of the subcategory


        // Additional properties for display purposes (if needed)
        public IEnumerable<CategoryModel>? Categories { get; set; }
        public IEnumerable<SubCategoryModel>? SubCategories { get; set; }

        
    }

    public class EditProductVM : ProductVM
    {
        public string slug { get; set; }
    }
}
