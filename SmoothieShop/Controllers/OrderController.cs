using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmoothieShop.Core.Contracts;
using SmoothieShop.Data.Models.OrderModels;
using static SmoothieShop.ErrorConstants.ErrorConstants.GlobalErrorConstants;

namespace SmoothieShop.Controllers
{
    [Authorize(Roles = "ProductUser, Admin")]
    /// <summary>
    /// Controls Order functionalities.
    /// </summary>
    public class OrderController : Controller
    {
        private readonly IOrderService orderService;
        private readonly IMenuService menuService;
        private readonly ISmoothieService smoothiesService;
        public OrderController(IOrderService orderService, IMenuService menuService, ISmoothieService smoothiesService)
        {
            this.orderService = orderService;
            this.menuService = menuService;
            this.smoothiesService = smoothiesService;
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
        /// This method returns all available orders.
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> AllOrders()
        {
            try
            {
                var orders = await
                    orderService
                   .GetAllOrders();

                return View(orders);
            }
            catch (Exception)
            {

                return RedirectToAction("Error", "Home", new { area = "" });
            }
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> AddOrder()
        {
            var modelOrder = new AddOrderModel()
            {
                Menus = await
                menuService.GetMenusForSelect(),
                Smoothies = await
                smoothiesService.GetSmoothiesForSelect(),
            };

            return View(modelOrder);
        }
        /// <summary>
        /// This method is used to add a order.
        /// </summary>
        /// <param name="addOrderModel"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> AddOrder(AddOrderModel addOrderModel)
        {
            //check if the model state is valid
            if (!ModelState.IsValid)
            {
                addOrderModel.Menus = await
                menuService.GetMenusForSelect();
                addOrderModel.Smoothies = await
                smoothiesService.GetSmoothiesForSelect();

                return View(addOrderModel);
            }

            try
            {
                await orderService
                    .Add(addOrderModel);

                TempData["message"] = $"You have successfully added a order!";

                return RedirectToAction("AllOrders", "Order");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", somethingWrong);

                addOrderModel.Menus = await
                menuService.GetMenusForSelect();
                addOrderModel.Smoothies = await
                smoothiesService.GetSmoothiesForSelect();

                return View(addOrderModel);
            }

        }
        /// <summary>
        /// This method returns a details about particular order with a given id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> DetailsOrder(int id)
        {
            //check if the order is null
            if (
                await orderService
                .GetOrderDetailsById(id) == null)
            {
                return RedirectToAction("Error", "Home", new { area = "" });
            }

            try
            {
                var orderModel = await
                orderService
                .GetOrderDetailsById(id);

                return View(orderModel);
            }
            catch (Exception)
            {

                return RedirectToAction("Error", "Home", new { area = "" });
            }

        }
        /// <summary>
        /// This metod creates a form for editing a particular order with a given id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> EditOrder(int id)
        {
            //check if the order is null
            if (await orderService
                .GetOrderDetailsById(id) == null)
            {
                return BadRequest();
            }

            try
            {
                var editFormModel = await
                       orderService
                       .EditCreateForm(id);

                return View(editFormModel);
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home", new { area = "" });
            }



        }
        /// <summary>
        /// This method is used to edit a particular order with a given id.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="editOrderModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> EditOrder(int id, EditOrderModel editOrderModel)
        {
            //check if the order is null
            if (await orderService
                .GetOrderDetailsById(id) == null)
            {
                return RedirectToAction("Error", "Home", new { area = "" });
            }

            try
            {
                await orderService
                    .Edit(id, editOrderModel);

                TempData["message"] = $"You have successfully edited a order!";

                return RedirectToAction("AllOrders", "Order");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", somethingWrong);

                return View(editOrderModel);
            }
        }
        /// <summary>
        /// This metod creates a form for deleting a particular order with a given id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            //check if the order is null
            if (await orderService
                .GetOrderDetailsById(id) == null)
            {
                return RedirectToAction("Error", "Home", new { area = "" });
            }

            try
            {
                var editFormModel = await
               orderService
               .DeleteOrderForm(id);

                return View(editFormModel);
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home", new { area = "" });
            }

        }
        /// <summary>
        /// This method is used to delete a particular order.
        /// </summary>
        /// <param name="deleteOrderModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> DeleteOrder(DeleteOrderModel deleteOrderModel)
        {
            //check if the order is null
            if (await orderService
                .GetOrderById(deleteOrderModel.OrderId) == null)
            {
                return RedirectToAction("Error", "Home", new { area = "" });
            }

            try
            {
                await orderService
                    .Delete(deleteOrderModel.OrderId);

                TempData["message"] = $"You have successfully deleted a order!";

                return RedirectToAction("AllOrders", "Order");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", somethingWrong);

                return View(deleteOrderModel);
            }
        }

    }
}
