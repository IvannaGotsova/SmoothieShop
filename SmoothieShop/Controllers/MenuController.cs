using Microsoft.AspNetCore.Mvc;

namespace SmoothieShop.Controllers
{
    public class MenuController : Controller
    {
        /// <summary>
        /// Controls Menu functionalities.
        /// </summary>
        public IActionResult Index()
        {
            return View();
        }
    }
}
