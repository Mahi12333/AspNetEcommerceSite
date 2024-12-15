using EcommerceProject.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Permissions;

namespace EcommerceProject.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Authorize(Roles = "admin,subAdmin")] // Roles check
    [Route("admin/[controller]")] // Base route for the controller
    public class HomeController : Controller
    {
        [HttpGet]
        //[Permission("view")] // Permissions check
        public IActionResult Dashboard()
        {
           
            return View();
        }
    }
}
