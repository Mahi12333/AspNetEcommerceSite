using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceProject.Areas.Customer.Controllers
{
    [Area("Customer")]
    //[Route("/[controller]")] // Base route for the controller
    public class HomeController : Controller
    {
        [HttpGet]
      //[AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
    }
}
