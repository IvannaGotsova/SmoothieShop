using Microsoft.AspNetCore.Mvc;
using SmoothieShop.Common;
using SmoothieShop.Core.Contracts;
using SmoothieShop.Data.Models.CustomerModels;
using static SmoothieShop.ErrorConstants.ErrorConstants.GlobalErrorConstants;

namespace SmoothieShop.Controllers
{
    /// <summary>
    /// Controls Customer functionalities.
    /// </summary>
    public class CustomerController : Controller
    {
        private readonly ICustomerService customerService;
        private readonly ICustomerUserService customerUserService;
        public CustomerController(ICustomerService customerService, ICustomerUserService customerUserService)
        {
            this.customerService = customerService;
            this.customerUserService = customerUserService;
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
        public async Task<IActionResult> AllCustomers()
        {
            try
            {
                var customers = await
                    customerService
                   .GetAllCustomers();

                return View(customers);
            }
            catch (Exception)
            {

                return RedirectToAction("Error", "Home", new { area = "" });
            }
        }
        [HttpGet]
        public async Task<IActionResult> AddCustomer()
        {
            var modelCustomer = new AddCustomerModel()
            {
                CustomerUsers = await
                customerUserService.GetCustomerUsersForSelect(),
            };

            return View(modelCustomer);
        }
        /// <summary>
        /// This method is used to add a customer.
        /// </summary>
        /// <param name="addCustomerModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddCustomer(AddCustomerModel addCustomerModel)
        {
            //check if the model state is valid
            if (!ModelState.IsValid)
            {
                addCustomerModel.CustomerUsers = await
                customerUserService.GetCustomerUsersForSelect();

                return View(addCustomerModel);
            }

            try
            {
                await customerService
                    .Add(addCustomerModel);

                TempData["message"] = $"You have successfully added a customer!";

                return RedirectToAction("AllCustomers", "Customer");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", somethingWrong);

                addCustomerModel.CustomerUsers = await
                customerUserService.GetCustomerUsersForSelect();

                return View(addCustomerModel);
            }

        }
        /// <summary>
        /// This method returns a details about particular customer with a given id.
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public async Task<IActionResult> DetailsCustomer(int customerId)
        {
            //check if the customer is null
            if (
                await customerService
                .GetCustomerDetailsById(customerId) == null)
            {
                return RedirectToAction("Error", "Home", new { area = "" });
            }

            try
            {
                var customerModel = await
                customerService
                .GetCustomerDetailsById(customerId);

                return View(customerModel);
            }
            catch (Exception)
            {

                return RedirectToAction("Error", "Home", new { area = "" });
            }

        }
        /// <summary>
        /// This metod creates a form for editing a particular customer with a given id.
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> EditCustomer(int customerId)
        {
            //check if the customer is null
            if (await customerService
                .GetCustomerDetailsById(customerId) == null)
            {
                return BadRequest();
            }

            try
            {
                var editFormModel = await
                       customerService
                       .EditCreateForm(customerId);

                return View(editFormModel);
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home", new { area = "" });
            }



        }
        /// <summary>
        /// This method is used to edit a particular customer with a given id.
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="editCustomerModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> EditCustomer(int customerId, EditCustomerModel editCustomerModel)
        {
            //check if the customer is null
            if (await customerService
                .GetCustomerDetailsById(customerId) == null)
            {
                return RedirectToAction("Error", "Home", new { area = "" });
            }

            try
            {
                await customerService
                    .Edit(customerId, editCustomerModel);

                TempData["message"] = $"You have successfully edited a customer!";

                return RedirectToAction("AllCustomers", "Customer");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", somethingWrong);

                return View(editCustomerModel);
            }
        }
        /// <summary>
        /// This metod creates a form for deleting a particular customer with a given id.
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> DeleteCustomer(int customerId)
        {
            //check if the customer is null
            if (await customerService
                .GetCustomerDetailsById(customerId) == null)
            {
                return RedirectToAction("Error", "Home", new { area = "" });
            }

            try
            {
                var editFormModel = await
               customerService
               .DeleteCustomerForm(customerId);

                return View(editFormModel);
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home", new { area = "" });
            }

        }
        /// <summary>
        /// This method is used to delete a particular customer.
        /// </summary>
        /// <param name="deleteCustomerModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> DeleteCustomer(DeleteCustomerModel deleteCustomerModel)
        {
            //check if the customer is null
            if (await customerService
                .GetCustomerById(deleteCustomerModel.CustomerId) == null)
            {
                return RedirectToAction("Error", "Home", new { area = "" });
            }

            try
            {
                await customerService
                    .Delete(deleteCustomerModel.CustomerId);

                TempData["message"] = $"You have successfully deleted a customer!";

                return RedirectToAction("AllCustomers", "Customer");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", somethingWrong);

                return View(deleteCustomerModel);
            }
        }

    }
}
