using Microsoft.EntityFrameworkCore;
using SmoothieShop.Core.Contracts;
using SmoothieShop.Data.Data.Entites;
using SmoothieShop.Data.Models.CustomerModels;
using SmoothieShop.Data.Models.CustomerUserModels;
using SmoothieShop.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmoothieShop.Core.Services
{
    /// <summary>
    /// Holds Service for CustomerUser functionality.
    /// </summary>
    public class CustomerUserService : ICustomerUserService
    {
        private readonly IRepository data;

        public CustomerUserService(IRepository data)
        {
            this.data = data;
        }
        /// <summary>
        /// This method is used to add a customerUser.
        /// </summary>
        /// <param name="addCustomerUserModel"></param>
        /// <returns></returns>
        public async Task Add(AddCustomerUserModel addCustomerUserModel)
        {
            var customerUserToBeAdded = new CustomerUser()
            {
                ApplicationUserId = addCustomerUserModel.ApplicationUserId,
            };

            await this.data.AddAsync(customerUserToBeAdded);
            await this.data.SaveChangesAsync();
        }

        public int Count()
        {
            return
                this.data
                .AllReadonly<CustomerUser>()
                .Count();
        }

        /// <summary>
        /// This method deletes a particular customerUser with a given id.
        /// </summary>
        /// <param name="customerUserId"></param>
        /// <returns></returns>
        public async Task Delete(int customerUserId)
        {
            await this.data.DeleteAsync<CustomerUser>(customerUserId);
            await this.data.SaveChangesAsync();
        }
        /// <summary>
        /// This method creates form for deleting a customerUser.
        /// </summary>
        /// <param name="customerUserId"></param>
        /// <returns></returns>
        public async Task<DeleteCustomerUserModel> DeleteCustomerUserForm(int customerUserId)
        {
            var customerUserToBeDeleted = await
                GetCustomerUserById(customerUserId);

            var deleteCustomerUserModel = new DeleteCustomerUserModel()
            {
                CustomerUserId = customerUserToBeDeleted.CustomerUserId,
                ApplicationUserId = customerUserToBeDeleted.ApplicationUserId
            };

            return deleteCustomerUserModel;
        }
        /// <summary>
        /// This method is used to edit a particular customerUser with a given id.
        /// </summary>
        /// <param name="customerUserId"></param>
        /// <param name="editCustomerUserModel"></param>
        /// <returns></returns>
        public async Task Edit(int customerUserId, EditCustomerUserModel editCustomerUserModel)
        {
            var customerUserToBeEdited = await
               GetCustomerUserById(customerUserId);

            customerUserToBeEdited.ApplicationUserId = editCustomerUserModel.ApplicationUserId;

            this.data.Update<CustomerUser>(customerUserToBeEdited);
            await this.data.SaveChangesAsync();
        }
        /// <summary>
        /// This method creates form for editing a customerUser.
        /// </summary>
        /// <param name="customerUserId"></param>
        /// <returns></returns>
        public async Task<EditCustomerUserModel> EditCreateForm(int customerUserId)
        {
            var customerUserToBeEdited = await
                 GetCustomerUserById(customerUserId);

            var editCustomerUserModel = new EditCustomerUserModel()
            {
                ApplicationUserId = customerUserToBeEdited.ApplicationUserId
            };

            return editCustomerUserModel;
        }
        /// <summary>
        /// This method returns IEnumerable of all customerUsers.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<AllCustomerUsersModel>> GetAllCustomerUsers()
        {
            var customerUsers = await data
                 .AllReadonly<CustomerUser>()
                 .ToListAsync();

            return customerUsers
                .Select(cu => new AllCustomerUsersModel()
                {
                    CustomerUserId = cu.CustomerUserId,
                    ApplicationUserId= cu.ApplicationUserId

                })
                .ToList();
        }
        /// <summary>
        /// This method returns a particular customerUser with a given id.
        /// </summary>
        /// <param name="customerUserId"></param>
        /// <returns></returns>
        public async Task<CustomerUser> GetCustomerUserById(int customerUserId)
        {
            var customerUser = await
              this.data
              .AllReadonly<CustomerUser>()
              .Where(c => c.CustomerUserId == customerUserId)
              .FirstOrDefaultAsync();

            //check if customerUser is null
            if (customerUser == null)
            {
                throw new ArgumentNullException(null, nameof(customerUser));
            }

            return customerUser;
        }
        /// <summary>
        /// This method returns Details of particular customerUser with a given id.
        /// </summary>
        /// <param name="customerUserId"></param>
        /// <returns></returns>
        public async Task<DetailsCustomerUserModel> GetCustomerUserDetailsById(int customerUserId)
        {
            var customerUser = await
               this.data
               .AllReadonly<CustomerUser>()
               //.Include(cu => cu.Customers)
               .Select(cu => new DetailsCustomerUserModel()
               {
                   CustomerUserId = cu.CustomerUserId,
                   ApplicationUserId = cu.ApplicationUserId,
               }).FirstOrDefaultAsync();

            //check if customerUser is null
            if (customerUser == null)
            {
                throw new ArgumentNullException(null, nameof(customerUser));
            }

            return customerUser;
        }
        /// <summary>
        /// This method returns IEnumerable of all customerUsers used for Select.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<CustomerUser>> GetCustomerUsersForSelect()
        {
            return await
                this.data
                .AllReadonly<CustomerUser>()
                .ToListAsync();
        }
    }
}
