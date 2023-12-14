using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmoothieShop.Data.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmoothieShop.Data.Seeds
{
    /// <summary>
    /// Holds ApplicationUser Configuration.
    /// </summary>
    internal class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasData(CreateApplicationUsers());
        }

        // A method used to seed DB with initial data of applicationusers.
        private static List<ApplicationUser> CreateApplicationUsers()
        {
            var applicationUsers = new List<ApplicationUser>();
            var hasher = new PasswordHasher<ApplicationUser>();

            var applicationUser = new ApplicationUser()
            {
                Id = "admin@admin.com",
                UserName = "admin@admin.com", 
                NormalizedUserName = "admin@admin.com",
                Email = "admin@admin.com",
                NormalizedEmail = "admin@admin.com",
                FirstName = "Ivan",
                LastName = "Ivanov"
            };

            applicationUser.PasswordHash =
                 hasher.HashPassword(applicationUser, "Admin123");

            applicationUsers.Add(applicationUser);

            applicationUser = new ApplicationUser()
            {
                Id = "productUser@product.com",
                UserName = "productUser@product.com",
                NormalizedUserName = "productUser@product.com",
                Email = "productUser@product.com",
                NormalizedEmail = "productUser@product.com",
                FirstName = "Stoqn",
                LastName = "Stoqnov"
            };

            applicationUser.PasswordHash =
                 hasher.HashPassword(applicationUser, "Product123");

            applicationUsers.Add(applicationUser);

            applicationUser = new ApplicationUser()
            {
                Id = "customerUser@customer.com",
                UserName = "customerUser@customer.com",
                NormalizedUserName = "customerUser@customer.com",
                Email = "customerUser@customer.com",
                NormalizedEmail = "customerUser@customer.com",
                FirstName = "Yordan",
                LastName = "Yordanov"
            };

            applicationUser.PasswordHash =
                 hasher.HashPassword(applicationUser, "Customer123");

            applicationUsers.Add(applicationUser);

            applicationUser = new ApplicationUser()
            {
                Id = "guest1@guest.com",
                UserName = "guest1@guest.com",
                NormalizedUserName = "guest1@guest.com",
                Email = "guest1@guest.com",
                NormalizedEmail = "guest1@guest.com",
                FirstName = "Petar",
                LastName = "Petrov"
            };

            applicationUser.PasswordHash =
                 hasher.HashPassword(applicationUser, "Guest1123");

            applicationUsers.Add(applicationUser);

            applicationUser = new ApplicationUser()
            {
                Id = "guest2@guest.com",
                UserName = "guest2@guest.com",
                NormalizedUserName = "guest2@guest.com",
                Email = "guest2@guest.com",
                NormalizedEmail = "guest2@guest.com",
                FirstName = "Dimitar",
                LastName = "Dimitrov"
            };

            applicationUser.PasswordHash =
                 hasher.HashPassword(applicationUser, "Guest2123");

            applicationUsers.Add(applicationUser);

            return applicationUsers;
        }
    }
}

