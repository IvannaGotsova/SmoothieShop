using SmoothieShop.Data.Data.Entites;
using SmoothieShop.Data.Models.ApplicationUserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmoothieShop.Core.Contracts
{
    /// <summary>
    /// Holds Interface for ApplicationUser functionality.
    /// </summary>
    public interface IApplicationUserService
    {
        /// <summary>
        /// This method returns IEnumerable of all users.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<AllApplicationUsersModel>> GetApplicationUsers();
        /// <summary>
        /// This method returns IEnumerable of all VIP users.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<ApplicationUserModel>> GetApplicationVIPUsers();
        /// <summary>
        /// This method returns particular user with a given id.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<ApplicationUser> GetApplicaionUserById(string userId);
        /// <summary>
        /// This method creates form for deleting a particular user with a given id.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<ApplicationUserModel> DeleteCreateForm(string userId);
        /// <summary>
        /// This method deletes a particular user with a given id.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task Delete(string userId);
        /// <summary>
        /// This method returns IEnumerable of all applicationUsers used for Select.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<ApplicationUser>> GetApplicationUsersForSelect();
        /// <summary>
        /// This method returns Details of particular applicationUser with a given id.
        /// </summary>
        /// <param name="applicationUserId"></param>
        /// <returns></returns>
        Task<DetailsApplicationUserModel> GetApplicationUserDetailsById(string applicationUserId);

        int Count();


    }
}