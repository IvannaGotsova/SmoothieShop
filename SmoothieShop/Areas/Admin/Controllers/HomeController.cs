using Microsoft.AspNetCore.Mvc;

namespace SmoothieShop.Areas.Admin.Controllers
{
    /// <summary>
    ///  Controls all functions of Home Controller of Admin;
    /// </summary>
    [Area("Admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
