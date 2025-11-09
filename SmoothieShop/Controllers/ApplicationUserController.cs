using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SmoothieShop.Core.Contracts;
using SmoothieShop.Data.Data.Entites;
using SmoothieShop.Data.Models.ApplicationUserModels;

namespace SmoothieShop.Controllers
{
    [Authorize]
    /// <summary>
    /// Controls user functionalities.
    /// </summary>
    public class ApplicationUserController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IApplicationUserService applicationUser;

        public ApplicationUserController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IApplicationUserService applicationUserService)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.applicationUser = applicationUserService;
        }
        /// <summary>
        /// This method creates index page for a user.
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
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
        /// <summary>
        /// This method is used to login user.
        /// </summary>
        /// <param name="modelToBeLogin"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginModelView modelToBeLogin)
        {   //check if the model state is valid
            if (!ModelState.IsValid)
            {
                return View(modelToBeLogin);
            }

            var userToBeLogin = await userManager
                .FindByNameAsync(modelToBeLogin.UserName);
            //check if the user is null
            if (userToBeLogin != null)
            {
                var resultUserToBeLogin = await signInManager
                    .PasswordSignInAsync(userToBeLogin, modelToBeLogin.Password, true, false);

                if (resultUserToBeLogin.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }

            }

            ModelState.AddModelError("", "Invalid login attempt.");

            return View(modelToBeLogin);

        }
        /// <summary>
        /// This method is used to logout user
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();

            TempData["message"] = $"Goodbye! We are waiting for you to come back";

            return RedirectToAction("Index", "Home");
        }
        []
        /// <summary>
        /// This method returns all available application users.
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> AllApplicationUsers()
        {
            try
            {
                var applicationUsers = await
                    applicationUser
                   .GetApplicationUsers();

                return View(applicationUsers);
            }
            catch (Exception)
            {

                return RedirectToAction("Error", "Home", new { area = "" });
            }
        }

        [HttpGet]
        public async Task<IActionResult> ChangePasswordApplicationUser(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            if (user == null) return NotFound("");

            var changePasswordApplicationUserModel = new ChangePasswordApplicationUserModel
            {
                Id = user.Id

            };

            return View(changePasswordApplicationUserModel);
        }

        [HttpPost]
        public async Task<IActionResult> ChangePasswordApplicationUser(ChangePasswordApplicationUserModel changePasswordApplicationUserModel)
        {
            var user = await userManager.FindByIdAsync(changePasswordApplicationUserModel.Id);
            if (user == null) return NotFound();

            var result = await userManager.ChangePasswordAsync(user, changePasswordApplicationUserModel.OldPassword, changePasswordApplicationUserModel.NewPassword);
            if (result.Succeeded)
            {
                return Ok("Password changed successfully.");
            }

            return BadRequest(result.Errors);
        }
    }
}
