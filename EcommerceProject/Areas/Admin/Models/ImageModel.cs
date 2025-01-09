using System.ComponentModel.DataAnnotations;

namespace EcommerceProject.Areas.Admin.Models
{
    public class ImageModel
    {
        [Key]
        public int Id { get; set; }

        public int ProductId { get; set; }

        [Required]
        public string filename { get; set; }

        [Required]
        public string path { get; set; }

        [Required]
        public string size { get; set; }

        [Required]
        public string type { get; set; }


        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime? UpdatedAt { get; set; }

        // Navigation property
         public ProductModel Product { get; set; }

    }
}
