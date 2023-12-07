using Microsoft.AspNetCore.Mvc;

namespace SmoothieShop.Controllers
{
    public class ProductUserController : Controller
    {
        /// <summary>
        /// Controls ProductUser functionalities.
        /// </summary>
        public IActionResult Index()
        {
            return View();
        }
    }
}
