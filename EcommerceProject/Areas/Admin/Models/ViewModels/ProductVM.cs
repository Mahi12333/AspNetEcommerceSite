using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace EcommerceProject.Areas.Admin.Models.ViewModels
{
    public class ProductVM
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal OriginalPrice { get; set; }
        public decimal Discount { get; set; }
        public List<IFormFile>? Images { get; set; }
        public List<string> Sizes { get; set; } = new List<string>();
        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }

        // Additional properties for display purposes (if needed)
        public IEnumerable<CategoryModel>? Categories { get; set; }
        public IEnumerable<SubCategoryModel>? SubCategories { get; set; }
    }
}
