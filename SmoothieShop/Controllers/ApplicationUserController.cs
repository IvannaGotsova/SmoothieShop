using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SmoothieShop.Data.Data.Entites;
using SmoothieShop.Data.Models.ApplicationUserModels;
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

        /// <summary>
        /// This method is used to register user.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterModelView modelToBeRegistered)
        {
            //check if the model state is valid
            if (!ModelState.IsValid)
            {
                return View(modelToBeRegistered);
            }
            //creates new ApplicationUser
            ApplicationUser userToBeRegistered = new()
            {
                UserName = modelToBeRegistered.UserName,
                Email = modelToBeRegistered.Email,
                FirstName = modelToBeRegistered.FirstName,
                LastName = modelToBeRegistered.LastName
            };

            var resultUserToBeRegistered = await userManager
                .CreateAsync(userToBeRegistered, modelToBeRegistered.Password);
            //check if the user registration is correct
            if (!resultUserToBeRegistered.Succeeded)
            {
                foreach (var error in resultUserToBeRegistered.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View(modelToBeRegistered);
            }



            return RedirectToAction("Login", "ApplicationUsers");
        }
        /// <summary>
        /// This method creates form for login.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {

            if (User.IsInRole("Admin"))
            {
                return RedirectToAction("Index", "Home", new { area = "Admin" });
            }

            //check if the user is login already 
            if (User?.Identity?.IsAuthenticated ?? false)
            {
                return RedirectToAction("Index", "Home");
            }

            LoginModelView modelToBeLogin = new();

            TempData["message"] = $"Hello! Have a great time!";

            return View(modelToBeLogin);
        }
    }
}
