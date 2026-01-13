using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SmoothieShop.Core.Contracts;
using SmoothieShop.Data.Data.Entites;
using SmoothieShop.Data.Models.ApplicationUserModels;
using static SmoothieShop.Common.Common.GetCurrentUser;

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
            TempData["message"] = $"Application User Index!";

            return View();
        }
        [AllowAnonymous]
        /// <summary>
        /// This method creates form to register a user.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
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
        [AllowAnonymous]
        /// <summary>
        /// This method is used to register user.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
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

            TempData["message"] = $"You have successfully register! Please login!"; 

            return RedirectToAction("Login", "ApplicationUser");
        }
        [AllowAnonymous]
        /// <summary>
        /// This method creates form for login.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
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
        [AllowAnonymous]
        /// <summary>
        /// This method is used to login user.
        /// </summary>
        /// <param name="modelToBeLogin"></param>
        /// <returns></returns>
        [HttpPost]
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
                    TempData["message"] = $"You have successfully login!";

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
        /// <summary>
        /// This method is used to change the password of user
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> ChangePasswordApplicationUser(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            if (user == null) return NotFound("");

            var changePasswordApplicationUserModel = new ChangePasswordApplicationUserModel
            {
                Id = user.Id

            };

            TempData["message"] = $"Here you can change your password!";

            return View(changePasswordApplicationUserModel);
        }
        /// <summary>
        /// This method is used to change the password of user
        /// </summary>
        /// <returns></returns>
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
        [Authorize]
        /// <summary>
        /// This method is used to access the profile of user
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> ApplicationUserMyProfile()
        {
            string currentUserId = User.GetCurrentUserId();

            var currentUser = await applicationUser
                .GetApplicaionUserById(currentUserId);

            if (currentUser == null)
            {
                return BadRequest("No such ApplicationUser");
            }

            var applicationUserMyProfile = new ApplicationUserMyProfile
            {
                Id = currentUser.Id,
                UserName = currentUser.UserName,
                FirstName = currentUser.FirstName,
                LastName = currentUser.LastName
            };

            TempData["message"] = $"Welcome to your profile!";

            return View(applicationUserMyProfile);
        }
    }
}
