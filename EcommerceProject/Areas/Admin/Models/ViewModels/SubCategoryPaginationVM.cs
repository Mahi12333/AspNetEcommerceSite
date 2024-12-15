namespace EcommerceProject.Areas.Admin.Models.ViewModels
{
    public class SubCategoryPaginationVM
    {
        public IEnumerable<SubCategoryModel> SubCategories { get; set; }
        public int PageSize { get; set; }
        public int Page { get; set; }
        public int TotalCount { get; set; }
    }
}
