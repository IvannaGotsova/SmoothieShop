using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmoothieShop.Core.Contracts;
using SmoothieShop.Data.Models.ProductUserModels;
using static SmoothieShop.ErrorConstants.ErrorConstants.GlobalErrorConstants;

namespace SmoothieShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    /// <summary>
    /// Controls ProductUser functionalities of Admin.
    /// </summary>
    public class ProductUserController : Controller
    {
        private readonly IProductUserService productUserService;
        private readonly IApplicationUserService applicationUserService;

        public ProductUserController(IProductUserService productUserService, IApplicationUserService applicationUserService)
        {
            this.productUserService = productUserService;
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
        /// This method returns all available products.
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> AllProductUsers()
        {
            try
            {
                var productUsers = await
                    productUserService
                   .GetAllProductUsers();

                return View(productUsers);
            }
            catch (Exception)
            {

                return RedirectToAction("Error", "Home", new { area = "" });
            }
        }
        [HttpGet]
        public async Task<IActionResult> AddProductUser()
        {
            var modelProductUser = new AddProductUserModel()
            {
                ApplicationUsers = await
                applicationUserService.GetApplicationUsersForSelect(),
            };

            return View(modelProductUser);
        }
        /// <summary>
        /// This method is used to add a productUser.
        /// </summary>
        /// <param name="addProductUserModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddProductUser(AddProductUserModel addProductUserModel)
        {
            //check if the model state is valid
            if (!ModelState.IsValid)
            {
                addProductUserModel.ApplicationUsers = await
                applicationUserService.GetApplicationUsersForSelect();

                return View(addProductUserModel);
            }

            try
            {
                await productUserService
                    .Add(addProductUserModel);

                TempData["message"] = $"You have successfully added a product user!";

                return RedirectToAction("AllProductUsers", "productUser");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", somethingWrong);

                return View(addProductUserModel);
            }

        }
        /// <summary>
        /// This method returns a details about particular productUser with a given id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> DetailsProductUser(int id)
        {
            //check if the productUser is null
            if (
                await productUserService
                .GetProductUserById(id) == null)
            {
                return RedirectToAction("Error", "Home", new { area = "" });
            }

            try
            {
                var productUserModel = await
                productUserService
                .GetProductUserDetailsById(id);

                return View(productUserModel);
            }
            catch (Exception)
            {

                return RedirectToAction("Error", "Home", new { area = "" });
            }

        }
        /// <summary>
        /// This metod creates a form for editing a particular productUser with a given id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> EditProductUser(int id)
        {
            //check if the productUser is null
            if (await productUserService
                .GetProductUserById(id) == null)
            {
                return BadRequest();
            }

            try
            {
                var editFormModel = await
                       productUserService
                       .EditCreateForm(id);

                return View(editFormModel);
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home", new { area = "" });
            }



        }
        /// <summary>
        /// This method is used to edit a particular productUser with given id.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="editProductUserModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> EditProductUser(int id, EditProductUserModel editProductUserModel)
        {
            //check if the productUser is null
            if (await productUserService
                .GetProductUserById(id) == null)
            {
                return RedirectToAction("Error", "Home", new { area = "" });
            }

            try
            {
                await productUserService
                    .Edit(id, editProductUserModel);

                TempData["message"] = $"You have successfully edited a product user!";

                return RedirectToAction("AllProductUsers", "productUser");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", somethingWrong);

                return View(editProductUserModel);
            }
        }
        /// <summary>
        /// This metod creates a form for deleting a particular productUser with a given id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> DeleteProductUser(int id)
        {
            //check if the productUser is null
            if (await productUserService
                .GetProductUserById(id) == null)
            {
                return RedirectToAction("Error", "Home", new { area = "" });
            }

            try
            {
                var editFormModel = await
               productUserService
               .DeleteProductUserForm(id);

                return View(editFormModel);
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home", new { area = "" });
            }

        }
        /// <summary>
        /// This method is used to delete a particular productUser.
        /// </summary>
        /// <param name="deleteProductUserModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> DeleteProductUser(DeleteProductUserModel deleteProductUserModel)
        {
            //check if the productUser is null
            if (await productUserService
                .GetProductUserById(deleteProductUserModel.ProductUserId) == null)
            {
                return RedirectToAction("Error", "Home", new { area = "" });
            }

            try
            {
                await productUserService
                    .Delete(deleteProductUserModel.ProductUserId);

                TempData["message"] = $"You have successfully deleted a product user!";

                return RedirectToAction("AllproductUsers", "productUser");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", somethingWrong);

                return View(deleteProductUserModel);
            }
        }

    }
}
