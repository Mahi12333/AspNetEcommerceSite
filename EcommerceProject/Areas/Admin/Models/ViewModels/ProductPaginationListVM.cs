namespace EcommerceProject.Areas.Admin.Models.ViewModels
{
    public class ProductPaginationListVM
    {
        public IEnumerable<ProductVM> Products { get; set; } = new List<ProductVM>();
        public int Page { get; set; } // Current page
        public int PageSize { get; set; } // Entries per page
        public int TotalProducts { get; set; } // Total number of products
        public string? SearchQuery { get; set; } // Optional search query
    }
}
