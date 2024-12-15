using Microsoft.AspNetCore.Mvc;

namespace EcommerceProject.Areas.Customer.Controllers
{
    [Area("Customer")]
    //[Route("/[controller]")] // Base route for the controller
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
