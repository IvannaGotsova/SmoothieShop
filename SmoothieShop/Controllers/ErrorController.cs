using Microsoft.AspNetCore.Mvc;

namespace SmoothieShop.Controllers
{
    /// <summary>
    /// Controls Error functionalities.
    /// </summary>
    public class ErrorController : Controller
    {
        public ActionResult PageNotFoundError()
        {
            return View();
        }
        public ActionResult UnauthorizedError()
        {
            return View();
        }
        public ActionResult InternalServerError()
        {
            return View();
        }
        public ActionResult GenericError()
        {
            return View();
        }
    }
}
