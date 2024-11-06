using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EcommerceProject.Areas.Admin.Models
{
    public class UserPermissionModel
    {
        [Key, Column(Order = 0)]
        public string UserId { get; set; }
        public ApplicationUserModel User { get; set; }

        [Key, Column(Order = 1)]
        public int PermissionId { get; set; }
        public PermissionModel Permission { get; set; }
    }
}
