using Microsoft.AspNetCore.Mvc;

namespace SmoothieShop.Areas.Admin.Controllers
{
    /// <summary>
    ///  Controls all functions of Admin;
    /// </summary>
    [Area("Admin")]
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
