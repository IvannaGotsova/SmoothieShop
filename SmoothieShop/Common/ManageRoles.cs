using Microsoft.AspNetCore.Identity;
using SmoothieShop.Data.Data.Entites;

namespace SmoothieShop.Common
{
    /// <summary>
    /// This method seed roles for the users.
    /// </summary>
    /// <param name="applicationBuilder"></param>
    public static class ManageRoles
    {
        public static IApplicationBuilder SeedUsersRoles(this IApplicationBuilder applicationBuilder)
        {
            using var scopedServices = applicationBuilder.ApplicationServices.CreateScope();

            var services = scopedServices.ServiceProvider;

            var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = services.GetRequiredService<RoleManager<ApplicationRole>>();

            CreateRoles(roleManager);
            AssignUsers(userManager);

            return applicationBuilder;
        }
        /// <summary>
        /// This method creates roles for the users.
        /// </summary>
        /// <param name="roleManager"></param>
        private static void CreateRoles(RoleManager<ApplicationRole> roleManager)
        {
            Task
                 .Run(async () =>
                 {
                     if (await roleManager.RoleExistsAsync("Admin") == false)
                     {
                         var roleToBeCreated = new ApplicationRole()
                         {
                             Name = "Admin"
                         };

                         var resultCreateRole = await roleManager.CreateAsync(roleToBeCreated);
                     }
                 })
                 .GetAwaiter()
                 .GetResult();

            Task
                 .Run(async () =>
                 {
                     if (await roleManager.RoleExistsAsync("CustomerUser") == false)
                     {
                         var roleToBeCreated = new ApplicationRole()
                         {
                             Name = "CustomerUser"
                         };

                         var resultCreateRole = await roleManager.CreateAsync(roleToBeCreated);
                     }
                 })
                 .GetAwaiter()
                 .GetResult();

            Task
                 .Run(async () =>
                 {
                     if (await roleManager.RoleExistsAsync("ProductUser") == false)
                     {
                         var roleToBeCreated = new ApplicationRole()
                         {
                             Name = "ProductUser"
                         };

                         var resultCreateRole = await roleManager.CreateAsync(roleToBeCreated);
                     }
                 })
                 .GetAwaiter()
                 .GetResult();
        }
        /// <summary>
        /// This method assign users to roles.
        /// </summary>
        /// <param name="userManager"></param>
        private static void AssignUsers(UserManager<ApplicationUser> userManager)
        {
            Task
                 .Run(async () =>
                 {
                     var userToBeAssigned = new ApplicationUser();

                     if (await userManager.FindByNameAsync("admin@admin.com") == null)
                     {
                         userToBeAssigned.UserName = "admin@admin.com";
                         userToBeAssigned.Email = "admin@admin.com";

                         var resultFromCreatingUser = await userManager.CreateAsync(userToBeAssigned, "Admin123");

                         if (resultFromCreatingUser.Succeeded)
                         {
                             await userManager.AddToRoleAsync(userToBeAssigned, "Admin");
                         }
                     }
                     else
                     {
                         userToBeAssigned = await userManager.FindByEmailAsync("admin@admin.com");
                         await userManager.AddToRoleAsync(userToBeAssigned, "Admin");
                     }
                 })
                 .GetAwaiter()
                 .GetResult();

            Task
                 .Run(async () =>
                 {
                     var userToBeAssigned = new ApplicationUser();

                     if (await userManager.FindByNameAsync("customerUser@customer.com") == null)
                     {
                         userToBeAssigned.UserName = "customerUser@customer.com";
                         userToBeAssigned.Email = "customerUser@customer.com";

                         var resultFromCreatingUser = await userManager.CreateAsync(userToBeAssigned, "Customer123");

                         if (resultFromCreatingUser.Succeeded)
                         {
                             await userManager.AddToRoleAsync(userToBeAssigned, "CustomerUser");
                         }
                     }
                     else
                     {
                         userToBeAssigned = await userManager.FindByEmailAsync("customerUser@customer.com");
                         await userManager.AddToRoleAsync(userToBeAssigned, "CustomerUser");
                     }
                 })
                 .GetAwaiter()
                 .GetResult();

            Task
                 .Run(async () =>
                 {
                     var userToBeAssigned = new ApplicationUser();

                     if (await userManager.FindByNameAsync("productUser@product.com") == null)
                     {
                         userToBeAssigned.UserName = "productUser@product.com";
                         userToBeAssigned.Email = "productUser@product.com";

                         var resultFromCreatingUser = await userManager.CreateAsync(userToBeAssigned, "Product123");

                         if (resultFromCreatingUser.Succeeded)
                         {
                             await userManager.AddToRoleAsync(userToBeAssigned, "ProductUser");
                         }
                     }
                     else
                     {
                         userToBeAssigned = await userManager.FindByEmailAsync("productUser@product.com");
                         await userManager.AddToRoleAsync(userToBeAssigned, "ProductUser");
                     }
                 })
                 .GetAwaiter()
                 .GetResult();

        }

    }
}

