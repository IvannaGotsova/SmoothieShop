using Microsoft.AspNetCore.Mvc;

namespace SmoothieShop.Controllers
{
    public class SmoothieController : Controller
    {
        /// <summary>
        /// Controls Smoothie functionalities.
        /// </summary>
        public IActionResult Index()
        {
            return View();
        }
    }
}
