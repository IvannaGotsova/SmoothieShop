using Microsoft.AspNetCore.Mvc;

namespace SmoothieShop.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
