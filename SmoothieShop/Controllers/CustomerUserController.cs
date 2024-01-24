using System.Web;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmoothieShop.Core.Contracts;
using SmoothieShop.Core.Services;
using SmoothieShop.Data.Data.Entites;
using SmoothieShop.Data.Models.CustomerModels;
using SmoothieShop.Data.Models.CustomerUserModels;
using static SmoothieShop.ErrorConstants.ErrorConstants.GlobalErrorConstants;

namespace SmoothieShop.Controllers
{
    [Authorize(Roles = "CustomerUser")]
    /// <summary>
    /// Controls CustomerUser functionalities.
    /// </summary>
    public class CustomerUserController : Controller
    {
        private readonly ICustomerUserService customerUserService;
        private readonly IApplicationUserService applicationUserService;
        public CustomerUserController(ICustomerUserService customerUserService, IApplicationUserService applicationUserService)
        {
            this.customerUserService = customerUserService;
            this.applicationUserService = applicationUserService;   
        }
        /// <summary>
        /// This method returns index view.
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// This method returns all available customers.
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> AllCustomerUsers()
        {
            try
            {
                var customerUsers = await
                    customerUserService
                   .GetAllCustomerUsers();

                return View(customerUsers);
            }
            catch (Exception)
            {

                return RedirectToAction("Error", "Home", new { area = "" });
            }
        }
        [HttpGet]
        public async Task<IActionResult> AddCustomerUser()
        {
            var modelCustomerUser = new AddCustomerUserModel()
            {
                ApplicationUsers = await
                applicationUserService.GetApplicationUsersForSelect(),
            };

            return View(modelCustomerUser);
        }
        /// <summary>
        /// This method is used to add a customerUser.
        /// </summary>
        /// <param name="addCustomerUserModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddCustomerUser(AddCustomerUserModel addCustomerUserModel)
        {
            //check if the model state is valid
            if (!ModelState.IsValid)
            {
                addCustomerUserModel.ApplicationUsers = await
                applicationUserService.GetApplicationUsersForSelect();

                return View(addCustomerUserModel);
            }

            try
            {
                await customerUserService
                    .Add(addCustomerUserModel);

                TempData["message"] = $"You have successfully added a customer user!";

                return RedirectToAction("AllCustomerUsers", "CustomerUser");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", somethingWrong);

                return View(addCustomerUserModel);
            }

        }
        /// <summary>
        /// This method returns a details about particular customerUser with a given id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> DetailsCustomerUser(int id)
        {
            //check if the customerUser is null
            if (
                await customerUserService
                .GetCustomerUserById(id) == null)
            {
                return RedirectToAction("Error", "Home", new { area = "" });
            }

            try
            {
                var customerUserModel = await
                customerUserService
                .GetCustomerUserDetailsById(id);

                return View(customerUserModel);
            }
            catch (Exception)
            {

                return RedirectToAction("Error", "Home", new { area = "" });
            }

        }
        /// <summary>
        /// This metod creates a form for editing a particular customerUser with a given id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> EditCustomerUser(int id)
        {
            //check if the customerUser is null
            if (await customerUserService
                .GetCustomerUserById(id) == null)
            {
                return BadRequest();
            }

            try
            {
                var editFormModel = await
                       customerUserService
                       .EditCreateForm(id);

                return View(editFormModel);
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home", new { area = "" });
            }



        }
        /// <summary>
        /// This method is used to edit a particular customerUser with given id.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="editCustomerUserModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> EditCustomerUser(int id, EditCustomerUserModel editCustomerUserModel)
        {
            //check if the customerUser is null
            if (await customerUserService
                .GetCustomerUserById(id) == null)
            {
                return RedirectToAction("Error", "Home", new { area = "" });
            }

            try
            {
                await customerUserService
                    .Edit(id, editCustomerUserModel);

                TempData["message"] = $"You have successfully edited a customer user!";

                return RedirectToAction("AllCustomerUsers", "CustomerUser");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", somethingWrong);

                return View(editCustomerUserModel);
            }
        }
        /// <summary>
        /// This metod creates a form for deleting a particular customerUser with a given id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> DeleteCustomerUser(int id)
        {
            //check if the customerUser is null
            if (await customerUserService
                .GetCustomerUserById(id) == null)
            {
                return RedirectToAction("Error", "Home", new { area = "" });
            }

            try
            {
                var editFormModel = await
               customerUserService
               .DeleteCustomerUserForm(id);

                return View(editFormModel);
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home", new { area = "" });
            }

        }
        /// <summary>
        /// This method is used to delete a particular customerUser.
        /// </summary>
        /// <param name="deleteCustomerUserModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> DeleteCustomerUser(DeleteCustomerUserModel deleteCustomerUserModel)
        {
            //check if the customerUser is null
            if (await customerUserService
                .GetCustomerUserById(deleteCustomerUserModel.CustomerUserId) == null)
            {
                return RedirectToAction("Error", "Home", new { area = "" });
            }

            try
            {
                await customerUserService
                    .Delete(deleteCustomerUserModel.CustomerUserId);
                
                TempData["message"] = $"You have successfully deleted a customer user!";

                return RedirectToAction("AllCustomerUsers", "CustomerUser");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", somethingWrong);

                return View(deleteCustomerUserModel);
            }
        }

    }
}
