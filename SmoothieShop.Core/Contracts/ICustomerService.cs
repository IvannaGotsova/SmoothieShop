using SmoothieShop.Data.Data.Entites;
using SmoothieShop.Data.Models.CustomerModels;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmoothieShop.Core.Contracts
{
    /// <summary>
    /// Holds Interface for Customer functionality.
    /// </summary>
    public interface ICustomerService
    {
        /// <summary>
        /// This method returns IEnumerable of all customers.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<AllCustomersModel>> GetAllCustomers();
        /// <summary>
        /// This method is used to add a customer.
        /// </summary>
        /// <param name="addCustomerModel"></param>
        /// <returns></returns>
        Task Add(AddCustomerModel addCustomerModel);
        /// <summary>
        /// This method returns IEnumerable of all customers used for Select.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Customer>> GetCustomersForSelect();
        /// <summary>
        /// This method returns Details of particular customer with a given id.
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        Task<DetailsCustomerModel> GetCustomerDetailsById(int customerId);
        /// <summary>
        /// This method creates form for editing a customer.
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        Task<EditCustomerModel> EditCreateForm(int customerId);
        /// <summary>
        /// This method is used to edit a particular customer with a given id.
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="editCustomerModel"></param>
        /// <returns></returns>
        Task Edit(int customerId, EditCustomerModel editCustomerModel);
        /// <summary>
        /// This method returns a particular customer with a given id.
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        Task<Customer> GetCustomerById(int customerId);
        /// <summary>
        /// This method creates form for deleting a customer.
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        Task<DeleteCustomerModel> DeleteCustomerForm(int customerId);
        /// <summary>
        /// This method deletes a particular customer with a given id.
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        Task Delete(int customerId);
    }
}
