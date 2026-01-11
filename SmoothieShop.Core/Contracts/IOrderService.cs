using SmoothieShop.Data.Data.Entites;
using SmoothieShop.Data.Models.OrderModels;

namespace SmoothieShop.Core.Contracts
{
    /// <summary>
    /// Holds Interface for Order functionality.
    /// </summary>
    public interface IOrderService
    {
        /// <summary>
        /// This method returns IEnumerable of all orders.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<AllOrdersModel>> GetAllOrders();
        /// <summary>
        /// This method is used to add a order.
        /// </summary>
        /// <param name="addOrderModel"></param>
        /// <returns></returns>
        Task Add(AddOrderModel addOrderModel);
        /// <summary>
        /// This method returns IEnumerable of all orders used for Select.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Order>> GetOrdersForSelect();
        /// <summary>
        /// This method returns Details of particular order with a given id.
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        Task<DetailsOrderModel> GetOrderDetailsById(int orderId);
        /// <summary>
        /// This method creates form for editing a order.
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        Task<EditOrderModel> EditCreateForm(int orderId);
        /// <summary>
        /// This method is used to edit a particular order with a given id.
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="editOrderModel"></param>
        /// <returns></returns>
        Task Edit(int orderId, EditOrderModel editOrderModel);
        /// <summary>
        /// This method returns a particular order with a given id.
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        Task<Order> GetOrderById(int orderId);
        /// <summary>
        /// This method creates form for deleting a order.
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        Task<DeleteOrderModel> DeleteOrderForm(int orderId);
        /// <summary>
        /// This method deletes a particular order with a given id.
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        Task Delete(int orderId);
        /// <summary>
        /// This method returns count of all Orders.
        /// </summary>
        /// <returns></returns>
        int Count();
        /// <summary>
        /// This method get smoothies by order ID.
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        Task<IEnumerable<Smoothie>> GetSmoothiesByOrder(int orderId);
        /// <summary>
        /// /// This method get menus by order ID.
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        Task<IEnumerable<Menu>> GetMenusByOrder(int orderId);
        /// <summary>
        /// /// This method get menus Ids by order ID.
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        Task<IEnumerable<int>> GetMenusIdsByOrder(int orderId);
        /// <summary>
        /// /// This method get smoothies Ids by order ID.
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        Task<IEnumerable<int>> GetSmoothiesIdsByOrder(int orderId);
        /// <summary>
        /// /// This method get all orders by customer ID.
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        Task<IEnumerable<Order>> GetAllOrdersByCustomer(int customerId);
    }
}
