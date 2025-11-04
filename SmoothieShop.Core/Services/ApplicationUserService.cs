using Microsoft.EntityFrameworkCore;
using SmoothieShop.Core.Contracts;
using SmoothieShop.Data.Data.Entites;
using SmoothieShop.Data.Models.ApplicationUserModels;
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
    /// Holds Service for ApplicationUser functionality.
    /// </summary>
    public class ApplicationUserService : IApplicationUserService
    {
        private readonly IRepository data;
        public ApplicationUserService(IRepository data)
        {
            this.data = data;
        }
        /// <summary>
        /// This method deletes a particular user with given id.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task Delete(string userId)
        {

            await this.data
                .DeleteAsync<ApplicationUser>(userId);
            await this.data
                .SaveChangesAsync();
        }
        /// <summary>
        /// This method creates form for deleting a particular user with given id.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<ApplicationUserModel> DeleteCreateForm(string userId)
        {
            var userToBeDeleted = await
                GetApplicaionUserById(userId);

            var deleteApplicationUserModel = new ApplicationUserModel()
            {
                Id = userToBeDeleted!.Id,
                UserName = userToBeDeleted!.UserName,
                FirstName = userToBeDeleted!.FirstName,
                LastName = userToBeDeleted!.LastName,
            };

            return deleteApplicationUserModel;
        }
        /// <summary>
        /// This method returns particular user with given id.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<ApplicationUser> GetApplicaionUserById(string userId)
        {
            //check if user is null
            if (await this.data
                .GetByIdAsync<ApplicationUser>(userId) == null)
            {
                throw new ArgumentNullException(null, nameof(userId));
            }

            return await
               this.data
               .AllReadonly<ApplicationUser>()
               .Where(au => au.Id == userId)
               .FirstAsync();
        }
        /// <summary>
        /// This method returns IEnumerable of all users.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<AllApplicationUsersModel>> GetApplicationUsers()
        {
            var allUsers = await
                this.data
                .AllReadonly<ApplicationUser>()
                .ToListAsync();

            return allUsers
                .Select(u => new AllApplicationUsersModel()
                {
                    Id = u.Id,
                    UserName = u.UserName,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    //IsVIP = u.IsVIP is true ? "VIP" : "Regular"

                })
                .ToList();

        }
        /// <summary>
        /// This method returns IEnumerable of all VIP users.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<ApplicationUserModel>> GetApplicationVIPUsers()
        {
            var vipUsers = await
               this.data
               .AllReadonly<ApplicationUser>()
               //.Where(au => au.IsVIP == true)
               .ToListAsync();

            return vipUsers
                .Select(u => new ApplicationUserModel()
                {
                    Id = u.Id,
                    UserName = u.UserName,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    //IsVIP = u.IsVIP is true ? "VIP" : "Regular"

                })
                .ToList();
        }
        /// <summary>
        /// This method gives a particular user with given id VIP Status.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task MakeVIP(string userId)
        {

            var user = await
                this.data
                .AllReadonly<ApplicationUser>()
                .Where(au => au.Id == userId)
                .FirstOrDefaultAsync();
            //check if user is null
            if (user == null)
            {
                throw new ArgumentNullException(null, nameof(user));
            }

            //user.IsVIP = true;

            this.data.Update<ApplicationUser>(user);
            await this.data.SaveChangesAsync();
        }
        /// <summary>
        /// This method removes VIP Status from a particular user with given id .
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task RemoveVIP(string userId)
        {
            var user = await
                this.data
                .AllReadonly<ApplicationUser>()
                .Where(au => au.Id == userId)
                .FirstOrDefaultAsync();
            //check if user is null
            if (user == null)
            {
                throw new ArgumentNullException(null, nameof(user));
            }

            //user.IsVIP = false;

            this.data.Update<ApplicationUser>(user);
            await this.data.SaveChangesAsync();
        }
        /// <summary>
        /// This method returns IEnumerable of all applicationUsers used for Select.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<ApplicationUser>> GetApplicationUsersForSelect()
        {
            return await
                this.data
                .AllReadonly<ApplicationUser>()
                .ToListAsync();
        }

        /// <summary>
        /// This method returns Details of particular applicationUser with a given id.
        /// </summary>
        /// <param name="applicationUserId"></param>
        /// <returns></returns>
        public async Task<DetailsApplicationUserModel> GetApplicationUserDetailsById(string applicationUserId)
        {
            var applicationUser = await
               this.data
               .AllReadonly<ApplicationUser>()
               //.Include(au => au.Applications)
               .Select(au => new DetailsApplicationUserModel()
               {
                   Id = au.Id,
                   UserName = au.UserName,
                   FirstName = au.FirstName,
                   LastName = au.LastName
               }).FirstOrDefaultAsync();

            //check if appplicationUser is null
            if (applicationUser == null)
            {
                throw new ArgumentNullException(null, nameof(applicationUser));
            }

            return applicationUser;
        }

    }
}
