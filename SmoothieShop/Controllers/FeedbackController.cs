using Microsoft.AspNetCore.Mvc;

namespace SmoothieShop.Controllers
{
    public class FeedbackController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
