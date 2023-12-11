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


        private static List<ApplicationUser> CreateApplicationUsers()
        {
            var applicationUsers = new List<ApplicationUser>();
            var hasher = new PasswordHasher<ApplicationUser>();

            var applicationUser = new ApplicationUser()
            {
                Id = "dea12856-c198-4129-b3f3-b893d8395082",
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
                Id = "fire8756-c198-4129-b3f3-b893d8395082",
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
                Id = "roof9675-c198-4129-b3f3-b893d8395082",
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

