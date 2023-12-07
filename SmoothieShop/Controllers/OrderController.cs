using Microsoft.AspNetCore.Mvc;

namespace SmoothieShop.Controllers
{
    public class OrderController : Controller
    {
        /// <summary>
        /// Controls Order functionalities.
        /// </summary>
        public IActionResult Index()
        {
            return View();
        }
    }
}
