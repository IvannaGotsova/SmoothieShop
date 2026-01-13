using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SmoothieShop.Core.Contracts;
using SmoothieShop.Data.Data.Entites;
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
        private readonly ICustomerService customerService;

        public OrderController(IOrderService orderService,
                               IMenuService menuService,
                               ISmoothieService smoothiesService,
                               ICustomerService customerService)
        {
            this.orderService = orderService;
            this.menuService = menuService;
            this.smoothiesService = smoothiesService;
            this.customerService = customerService;
        }
        /// <summary>
        /// This method returns index view.
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            TempData["message"] = $"Order Index!";

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

                TempData["message"] = $"All Orders!";

                return View(orders);
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home", new { area = "" });
            }
        }
        [AllowAnonymous]
        /// <summary>
        /// This method is used to add a order.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> AddOrder()
        {

            var modelOrder = new AddOrderModel()
            {
                Date = DateTime.Now,
                Menus = await
                menuService.GetMenusForSelect(),
                Smoothies = await
                smoothiesService.GetSmoothiesForSelect(),
                Customers = await
                customerService.GetCustomersForSelect()
            };

            TempData["message"] = $"Here you can add an order!";

            return View(modelOrder);
        }
        [AllowAnonymous]
        /// <summary>
        /// This method is used to add a order.
        /// </summary>
        /// <param name="addOrderModel"></param>
        /// <returns></returns>
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
                addOrderModel.Customers = await
                customerService.GetCustomersForSelect();

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
                addOrderModel.Customers = await
                customerService.GetCustomersForSelect();

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

                TempData["message"] = $"Here you can see order details";

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

                editFormModel.Menus = await
                menuService.GetMenusForSelect();

                editFormModel.SelectedMenusIds = await
                orderService.GetMenusIdsByOrder(id);

                editFormModel.Smoothies = await
                smoothiesService.GetSmoothiesForSelect();

                editFormModel.SelectedSmoothiesIds = await
                orderService.GetSmoothiesIdsByOrder(id);

                editFormModel.Customers = await
                customerService.GetCustomersForSelect();

                TempData["message"] = $"Here you can edit an order!";

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

                editOrderModel.Menus = await
                menuService.GetMenusForSelect();

                editOrderModel.Smoothies = await
                smoothiesService.GetSmoothiesForSelect();

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
                var deleteFormModel = await
               orderService
               .DeleteOrderForm(id);

                TempData["message"] = $"Here you can delete an order!";

                return View(deleteFormModel);
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
        /// <summary>
        /// This method returns all menus in a order
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> OrderMenus(int id)
        {
            //check if the order is null
            if (await orderService
                .GetOrderById(id) == null)
            {
                return RedirectToAction("Error", "Home", new { area = "" });
            }

            try
            {
                var menus = await orderService.GetMenusByOrder(id);

                TempData["message"] = $"Here you can see all menus by order";

                return View(menus);
            }
            catch (Exception)
            {
                ModelState.AddModelError("", somethingWrong);

                return RedirectToAction("AllOrders", "Order", new { area = "" });
            }
        }
        /// <summary>
        /// This method returns all smoothies in a order
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> OrderSmoothies(int id)
        {
            //check if the order is null
            if (await orderService
                .GetOrderById(id) == null)
            {
                return RedirectToAction("Error", "Home", new { area = "" });
            }

            try
            {
                var smoothies = await orderService.GetSmoothiesByOrder(id);

                TempData["message"] = $"Here you can see all smoothies by order";

                return View(smoothies);
            }
            catch (Exception)
            {
                ModelState.AddModelError("", somethingWrong);

                return RedirectToAction("AllOrders", "Order", new { area = "" });
            }
        }
        [Authorize(Roles = "CustomerUser, Admin")]
        /// <summary>
        /// This method returns all orders by a customer
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> OrdersCustomer(int id)
        {
            //check if the customer is null
            if (await orderService
                .GetAllOrdersByCustomer(id) == null)
            {
                return RedirectToAction("Error", "Home", new { area = "" });
            }

            try
            {
                var orders = await orderService.GetAllOrdersByCustomer(id);

                TempData["message"] = $"Here you can see all orders by customer";

                return View(orders);
            }
            catch (Exception)
            {
                ModelState.AddModelError("", somethingWrong);

                return RedirectToAction("AllOrders", "Order", new { area = "" });
            }
        }
    }
}
