using EcommerceProject.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Permissions;

namespace EcommerceProject.Areas.Admin.Controllers
{

    [Area("Admin")]
    //[MyAuthorization] // This is for AuthMiddleware
    [MyAuthorization("Admin")]   // This is for Authorization Middleware
    [Route("Admin")]  // Base route for the controller
    public class HomeController : Controller
    {
        [HttpGet("Dashboard")]
        //[Permission("view")] // Permissions check
        public IActionResult Dashboard()
        {
           
            return View();
        }
    }
}
