using Microsoft.EntityFrameworkCore;
using SmoothieShop.Core.Contracts;
using SmoothieShop.Data.Data.Entites;
using SmoothieShop.Data.Models.CustomerModels;
using SmoothieShop.Data.Repositories;

namespace SmoothieShop.Core.Services
{
    /// <summary>
    /// Holds Service for Customer functionality.
    /// </summary>
    public class CustomerService : ICustomerService
    {
        private readonly IRepository data;

        public CustomerService(IRepository data)
        {
            this.data = data;
        }
        /// <summary>
        /// This method is used to add a customer.
        /// </summary>
        /// <param name="addCustomerModel"></param>
        /// <returns></returns>
        public async Task Add(AddCustomerModel addCustomerModel)
        {
            var customerToBeAdded = new Customer()
            {
                FirstName = addCustomerModel.FirstName,
                LastName = addCustomerModel.LastName,
                PhoneNumber = addCustomerModel.PhoneNumber,
                Address = addCustomerModel.Address,
                Email = addCustomerModel.Email,
                ApplicationUserId = addCustomerModel.ApplicationUserId
            };

            await this.data.AddAsync(customerToBeAdded);
            await this.data.SaveChangesAsync();
        }
        /// <summary>
        /// This method deletes a particular customer with a given id.
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public async Task Delete(int customerId)
        {
            await this.data.DeleteAsync<Customer>(customerId);
            await this.data.SaveChangesAsync();
        }
        /// <summary>
        /// This method creates form for deleting a customer.
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public async Task<DeleteCustomerModel> DeleteCustomerForm(int customerId)
        {
            var customerToBeDeleted = await
                GetCustomerById(customerId);

            var deleteCustomerModel = new DeleteCustomerModel()
            {
                CustomerId = customerToBeDeleted.CustomerId,
                FirstName = customerToBeDeleted.FirstName,
                LastName = customerToBeDeleted.LastName,
                PhoneNumber = customerToBeDeleted.PhoneNumber,
                Address = customerToBeDeleted.Address,
                Email = customerToBeDeleted.Email
            };

            return deleteCustomerModel;
        }
        /// <summary>
        /// This method is used to edit a particular customer with a given id.
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="editCustomerModel"></param>
        /// <returns></returns>
        public async Task Edit(int customerId, EditCustomerModel editCustomerModel)
        {
            var customerToBeEdited = await
                GetCustomerById(customerId);

            customerToBeEdited.FirstName = editCustomerModel.FirstName;
            customerToBeEdited.LastName = editCustomerModel.LastName;
            customerToBeEdited.PhoneNumber = editCustomerModel.PhoneNumber;
            customerToBeEdited.Email = editCustomerModel.Email;
            customerToBeEdited.Address = editCustomerModel.Address;

            this.data.Update<Customer>(customerToBeEdited);
            await this.data.SaveChangesAsync();
        }
        /// <summary>
        /// This method creates form for editing a customer.
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public async Task<EditCustomerModel> EditCreateForm(int customerId)
        {
            var customerToBeEdited = await
                 GetCustomerById(customerId);

            var editCustomerModel = new EditCustomerModel()
            {
                FirstName = customerToBeEdited.FirstName,
                LastName = customerToBeEdited.LastName,
                PhoneNumber = customerToBeEdited.PhoneNumber,
                Email = customerToBeEdited.Email,
                Address = customerToBeEdited.Address
            };

            return editCustomerModel;
        }
        /// <summary>
        /// This method returns IEnumerable of all customers.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<AllCustomersModel>> GetAllCustomers()
        {
            var customers = await data
                .AllReadonly<Customer>()
                .ToListAsync();

            return customers
                .Select(c => new AllCustomersModel()
                {
                    CustomerId = c.CustomerId,
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    PhoneNumber = c.PhoneNumber,
                    Email = c.Email,
                    Address = c.Address,
                    isVip = c.isVip
                })
                .ToList();
        }
        /// <summary>
        /// This method returns a particular customer with a given id.
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public async Task<Customer> GetCustomerById(int customerId)
        {
            var customer = await
               this.data
               .AllReadonly<Customer>()
               .Where(c => c.CustomerId == customerId)
               .FirstOrDefaultAsync();

            //check if customer is null
            if (customer == null)
            {
                throw new ArgumentNullException(null, nameof(customer));
            }

            return customer;
        }
        /// <summary>
        /// This method returns Details of particular customer with a given id.
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public async Task<DetailsCustomerModel> GetCustomerDetailsById(int customerId)
        {
            var customer = await
               this.data
               .AllReadonly<Customer>()
               .Include(c => c.ApplicationUser)
               .Include(c => c.Orders)
               .Include(c => c.Feedbacks)
               .Where(c => c.CustomerId == customerId)
               .Select(c => new DetailsCustomerModel()
               {
                   CustomerId = c.CustomerId,
                   FirstName = c.FirstName,
                   LastName = c.LastName,
                   PhoneNumber = c.PhoneNumber,
                   Email = c.Email,
                   Address = c.Address,
                   isVip = c.isVip,
                   ApplicationUser = c.ApplicationUser,
                   OrdersCount = c.Orders.Count(),
                   FeedbacksCount = c.Feedbacks.Count()
               }).FirstOrDefaultAsync();

            //check if customer is null
            if (customer == null)
            {
                throw new ArgumentNullException(null, nameof(customer));
            }

            return customer;
        }
        /// <summary>
        /// This method returns IEnumerable of all customers used for Select.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Customer>> GetCustomersForSelect()
        {
            return await
                this.data
                .AllReadonly<Customer>()
                .ToListAsync();
        }
        /// <summary>
        /// This method makes customer vip.
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public async Task VipCustomer(int customerId)
        {
            var customer = await
               this.data
               .AllReadonly<Customer>()
               .Where(c => c.CustomerId == customerId)
               .FirstOrDefaultAsync();

            //check if customer is null
            if (customer == null)
            {
                throw new ArgumentNullException(null, nameof(customer));
            }

            customer.isVip = true;

            this.data.Update<Customer>(customer);
            await this.data.SaveChangesAsync();
        }
        /// <summary>
        /// This method makes customer not vip.
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public async Task NotVipCustomer(int customerId)
        {
            var customer = await
               this.data
               .AllReadonly<Customer>()
               .Where(c => c.CustomerId == customerId)
               .FirstOrDefaultAsync();

            //check if customer is null
            if (customer == null)
            {
                throw new ArgumentNullException(null, nameof(customer));
            }

            customer.isVip = false;

            this.data.Update<Customer>(customer);
            await this.data.SaveChangesAsync();
        }
        /// <summary>
        /// This method returns count of all Customers.
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            return
                this.data
                .AllReadonly<Customer>()
                .Count();
        }
        /// <summary>
        /// This method get current user customer ID.
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public int GetCurrentUserCustomerId(string currentUserId)
        {
            return 
                this.data
                .AllReadonly<Customer>()
                .Include(c => c.ApplicationUser)
                .Where(c => c.ApplicationUserId == currentUserId)
                .Select(c => c.CustomerId)
                .FirstOrDefault();

        }
        /// <summary>
        /// This method get customer application username.
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public string GetCustomerApplicationUsername(int customerId)
        {
            var applicationUser =
                this.data
                .AllReadonly<Customer>()
                .Where(c => c.CustomerId == customerId)
                .Select(c => c.ApplicationUser)
                .FirstOrDefault();

            return applicationUser.UserName;
        }
    }
}
