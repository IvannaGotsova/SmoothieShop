using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmoothieShop.Common.Common;
using SmoothieShop.Core.Contracts;
using SmoothieShop.Data.Data.Entites;
using SmoothieShop.Data.Models.OrderModels;
using SmoothieShop.Data.Models.SmoothieModels;
using SmoothieShop.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Claims;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static SmoothieShop.Common.Common.GetCurrentUser;

namespace SmoothieShop.Core.Services
{
    /// <summary>
    /// Holds Service for Order functionality.
    /// </summary>
    public class OrderService : IOrderService
    {
        private readonly IRepository data;

        public OrderService(IRepository data)
        {
            this.data = data;
        }
        /// <summary>
        /// This method is used to add a order.
        /// </summary>
        /// <param name="addOrderModel"></param>
        /// <returns></returns>
        public async Task Add(AddOrderModel addOrderModel)
        {
            var orderToBeAdded = new Order()
            {
                Price = addOrderModel.Price,
                Date = DateTime.Now         
            };

            await this.data.AddAsync(orderToBeAdded);

            foreach (var menu in addOrderModel.MenusIds)
            {
                var menuOrderToBeAdded = new MenuOrder()
                {
                    MenuId = menu,
                    Order = orderToBeAdded

                };

                await this.data.AddAsync(menuOrderToBeAdded);
            }

            foreach (var smoothie in addOrderModel.SmoothiesIds)
            {
                var smoothieOrdderToBeAdded = new OrderSmoothie()
                {
                    SmoothieId = smoothie,
                    Order = orderToBeAdded

                };

                await this.data.AddAsync(smoothieOrdderToBeAdded);
            }

            await this.data.SaveChangesAsync();
        }

        public int Count()
        {
            return
                 this.data
                 .AllReadonly<Order>()
                 .Count();
        }

        /// <summary>
        /// This method deletes a particular order with a given id.
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public async Task Delete(int orderId)
        {
            var menusOrders = await
                this.data
                .AllReadonly<MenuOrder>()
                .Where(mo => mo.OrderId == orderId)
                .ToListAsync();

            this.data.RemoveRange(menusOrders);

            var smoothiesOrders = await
                this.data
                .AllReadonly<OrderSmoothie>()
                .Where(mo => mo.OrderId == orderId)
                .ToListAsync();

            this.data.RemoveRange(smoothiesOrders);

            await this.data.DeleteAsync<Order>(orderId);
            await this.data.SaveChangesAsync();
        }
        /// <summary>
        /// This method creates form for deleting a order.
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public async Task<DeleteOrderModel> DeleteOrderForm(int orderId)
        {
            var orderToBeDeleted = await
                GetOrderById(orderId);

            var deleteOrderModel = new DeleteOrderModel()
            {
                OrderId = orderToBeDeleted.OrderId,
                Price = orderToBeDeleted.Price,
                Date = orderToBeDeleted.Date,
                CustomerId = orderToBeDeleted.CustomerId
            };

            return deleteOrderModel;
        }
        /// <summary>
        /// This method is used to edit a particular order with a given id.
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="editOrderModel"></param>
        /// <returns></returns>
        public async Task Edit(int orderId, EditOrderModel editOrderModel)
        {
            var orderToBeEdited = await
                GetOrderById(orderId);

            orderToBeEdited.Price = editOrderModel.Price;
            orderToBeEdited.Date = editOrderModel.Date;
            orderToBeEdited.CustomerId = editOrderModel.CustomerId;

            this.data.Update<Order>(orderToBeEdited);

            var menusOrdersToDelete = await
              this.data
              .AllReadonly<MenuOrder>()
              .Where(mo => mo.OrderId == orderId)
              .ToListAsync();

            this.data.DeleteRange<MenuOrder>(menusOrdersToDelete);


            foreach (var menu in editOrderModel.SelectedMenusIds)
            {
                var menusOrdersToBeEdited = new MenuOrder ()
                {
                    MenuId = menu,
                    Order = orderToBeEdited

                };

                await this.data.AddAsync(menusOrdersToBeEdited);
            }


            var smoothiesOrderToDelete = await
              this.data
              .AllReadonly<OrderSmoothie>()
              .Where(os => os.OrderId == orderId)
              .ToListAsync();

            this.data.DeleteRange<OrderSmoothie>(smoothiesOrderToDelete);


            foreach (var smoothie in editOrderModel.SelectedSmoothiesIds)
            {
                var smoothiesOrdersToBeEdited = new OrderSmoothie()
                {
                    SmoothieId = smoothie,
                    Order = orderToBeEdited

                };

                await this.data.AddAsync(smoothiesOrdersToBeEdited);
            }

            await this.data.SaveChangesAsync();
        }
        /// <summary>
        /// This method creates form for editing a order.
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public async Task<EditOrderModel> EditCreateForm(int orderId)
        {
            var orderToBeEdited = await
                 GetOrderById(orderId);

            var editOrderModel = new EditOrderModel()
            {
                Price = orderToBeEdited.Price,
                Date = orderToBeEdited.Date,
                CustomerId = orderToBeEdited.Customer.CustomerId,
                MenusIds = orderToBeEdited.MenusOrders.Select(mo => mo.OrderId).ToList(),
                MenusOrders = new List<MenuOrder>(),
                SmoothiesIds = orderToBeEdited.OrdersSmoothies.Select(os => os.OrderId).ToList(),
                OrdersSmoothies = new List<OrderSmoothie>()

            };

            return editOrderModel;


        }
        /// <summary>
        /// This method returns IEnumerable of all orders.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<AllOrdersModel>> GetAllOrders()
        {
            var orders = await data
                .AllReadonly<Order>()
                .ToListAsync();

            return orders
                .Select(o => new AllOrdersModel()
                {
                    OrderId = o.OrderId,
                    Price = o.Price,
                    Date = o.Date,
                    CustomerId = o.CustomerId
                })
                .ToList();
        }

        public async Task<IEnumerable<Menu>> GetMenusByOrder(int orderId)
        {
            var menus = await data
               .AllReadonly<MenuOrder>()
               .Where(mo => mo.OrderId == orderId)
               .Select(mo => mo.Menu)
               .ToListAsync();

            return menus;
        }

        public async Task<IEnumerable<int>> GetMenusIdsByOrder(int orderId)
        {
            var menusIds = await data
                .AllReadonly<MenuOrder>()
                .Where(mo => mo.OrderId == orderId)
                .Select(mo => mo.MenuId)
                .ToListAsync();

            return menusIds;
        }

        /// <summary>
        /// This method returns a particular order with a given id.
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public async Task<Order> GetOrderById(int orderId)
        {
            var order = await
               this.data
               .AllReadonly<Order>()
               .Include(o => o.Customer)
               .ThenInclude(c => c.ApplicationUser)
               .Where(o => o.OrderId == orderId)
               .FirstOrDefaultAsync();

            //check if order is null
            if (order == null)
            {
                throw new ArgumentNullException(null, nameof(order));
            }

            return order;
        }
        /// <summary>
        /// This method returns Details of particular order with a given id.
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public async Task<DetailsOrderModel> GetOrderDetailsById(int orderId)
        {
            var order = await
               this.data
               .AllReadonly<Order>()
               .Include(o => o.Smoothies)
               .Include(o => o.Menus)
               .Include(o => o.Customer)
               .Where(o => o.OrderId == orderId)
               .Select(o => new DetailsOrderModel()
               {
                   OrderId = o.OrderId,
                   Price = o.Price,
                   Date = o.Date,
                   CustomerId = o.CustomerId,
                   CustomerName = o.Customer.ApplicationUser.FirstName + " " + o.Customer.ApplicationUser.LastName,
                   CustomerUserName = o.Customer.ApplicationUser.UserName,
                   SmoothiesCount = o.Smoothies.Count(),
                   MenusCount = o.Menus.Count()
               }).FirstOrDefaultAsync();

            //check if order is null
            if (order == null)
            {
                throw new ArgumentNullException(null, nameof(order));
            }

            return order;
        }
        /// <summary>
        /// This method returns IEnumerable of all orders used for Select.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Order>> GetOrdersForSelect()
        {
            return await
                this.data
                .AllReadonly<Order>()
                .ToListAsync();
        }

        public async Task<IEnumerable<Smoothie>> GetSmoothiesByOrder(int orderId)
        {
            var smoothies = await data
               .AllReadonly<OrderSmoothie>()
               .Where(os => os.OrderId == orderId)
               .Select(os => os.Smoothie)
               .ToListAsync();

            return smoothies;
        }

        public async Task<IEnumerable<int>> GetSmoothiesIdsByOrder(int orderId)
        {
            var smoothiesIds = await data
                 .AllReadonly<OrderSmoothie>()
                 .Where(os => os.OrderId == orderId)
                 .Select(os => os.SmoothieId)
                 .ToListAsync();

            return smoothiesIds;
        }
    }
}
