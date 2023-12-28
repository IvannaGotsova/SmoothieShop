﻿using Microsoft.EntityFrameworkCore;
using SmoothieShop.Core.Contracts;
using SmoothieShop.Data.Data.Entites;
using SmoothieShop.Data.Models.OrderModels;
using SmoothieShop.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                Date = addOrderModel.Date,
                CustomerId = addOrderModel.CustomerId
            };

            await this.data.AddAsync(orderToBeAdded);
            await this.data.SaveChangesAsync();
        }
        /// <summary>
        /// This method deletes a particular order with a given id.
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public async Task Delete(int orderId)
        {
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
                CustomerId = orderToBeEdited.CustomerId
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
               .Where(o => o.OrderId == orderId)
               .Select(o => new DetailsOrderModel()
               {
                   OrderId = o.OrderId,
                   Price = o.Price,
                   Date = o.Date,
                   CustomerId = o.CustomerId,
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
    }
}
