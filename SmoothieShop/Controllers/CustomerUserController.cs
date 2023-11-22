using Microsoft.AspNetCore.Mvc;

namespace SmoothieShop.Controllers
{
    public class CustomerUserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
