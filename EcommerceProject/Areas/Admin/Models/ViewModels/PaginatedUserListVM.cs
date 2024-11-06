namespace EcommerceProject.Areas.Admin.Models.ViewModels
{
    public class PaginatedUserListVM
    {
        public IEnumerable<ApplicationUserModel> Users { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalUsers { get; set; }
        public string Search { get; set; }

        public int TotalPages => (int)Math.Ceiling((double)TotalUsers / PageSize);
    }
}
