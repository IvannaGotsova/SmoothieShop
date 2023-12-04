using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SmoothieShop.Data.Data.Entites;
using SmoothieShop.Models.AplplicationUserModels;

namespace SmoothieShop.Controllers
{
    public class ApplicationUserController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public ApplicationUserController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        /// <summary>
        /// This method creates form to register a user.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            //check if the user is login already
            if (User?.Identity?.IsAuthenticated ?? false)
            {
                return RedirectToAction("Index", "Home");
            }

            RegisterModelView modelToBeRegistered = new();

            TempData["message"] = $"Hello! Welcome!";

            return View(modelToBeRegistered);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
