namespace EcommerceProject.Areas.Admin.Models.ViewModels
{
    public class CategoryPaginationVM
    {
        public IEnumerable<CategoryModel> Categories { get; set; }
        public int PageSize { get; set; }
        public int Page { get; set; }
        public int TotalCount { get; set; }
    }
}
