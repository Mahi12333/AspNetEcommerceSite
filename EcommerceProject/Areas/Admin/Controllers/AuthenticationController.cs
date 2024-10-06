using Microsoft.AspNetCore.Mvc;

namespace EcommerceProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AuthenticationController : Controller
    {
        public IActionResult Index()
        {
            return View("ForgetPassword");
        }
    }
}
