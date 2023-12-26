using SmoothieShop.Data.Data.Entites;
using SmoothieShop.Data.Models.CustomerModels;
using SmoothieShop.Data.Models.CustomerUserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmoothieShop.Core.Contracts
{
    /// <summary>
    /// Holds Interface for CustomerUser functionality.
    /// </summary>
    public interface ICustomerUserService
    {
        /// <summary>
        /// This method returns IEnumerable of all customerUsers.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<AllCustomerUsersModel>> GetAllCustomerUsers();
        /// <summary>
        /// This method is used to add a customerUser.
        /// </summary>
        /// <param name="addCustomerUserModel"></param>
        /// <returns></returns>
        Task Add(AddCustomerUserModel addCustomerUserModel);
        /// <summary>
        /// This method returns IEnumerable of all customerUsers used for Select.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<CustomerUser>> GetCustomerUsersForSelect();
        /// <summary>
        /// This method returns Details of particular customerUser with a given id.
        /// </summary>
        /// <param name="customerUserId"></param>
        /// <returns></returns>
        Task<DetailsCustomerUserModel> GetCustomerUserDetailsById(int customerUserId);
        /// <summary>
        /// This method creates form for editing a customerUser.
        /// </summary>
        /// <param name="customerUserId"></param>
        /// <returns></returns>
        Task<EditCustomerUserModel> EditCreateForm(int customerUserId);
        /// <summary>
        /// This method is used to edit a particular customerUser with a given id.
        /// </summary>
        /// <param name="customerUserId"></param>
        /// <param name="editCustomerUserModel"></param>
        /// <returns></returns>
        Task Edit(int customerUserId, EditCustomerUserModel editCustomerUserModel);
        /// <summary>
        /// This method returns a particular customerUser with a given id.
        /// </summary>
        /// <param name="customerUserId"></param>
        /// <returns></returns>
        Task<CustomerUser> GetCustomerUserById(int customerUserId);
        /// <summary>
        /// This method creates form for deleting a customerUser.
        /// </summary>
        /// <param name="customerUserId"></param>
        /// <returns></returns>
        Task<DeleteCustomerUserModel> DeleteCustomerUserForm(int customerUserId);
        /// <summary>
        /// This method deletes a particular customerUser with a given id.
        /// </summary>
        /// <param name="customerUserId"></param>
        /// <returns></returns>
        Task Delete(int customerUserId);
    }
}
