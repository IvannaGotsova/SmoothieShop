using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmoothieShop.Data.Data.Entites;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SmoothieShop.Data.Seeds
{
    /// <summary>
    /// Holds Customer Configuration.
    /// </summary>
    internal class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasData(CreateCustomers());
        }

        // A method used to seed DB with initial data of customers.
        private static List<Customer> CreateCustomers()
        {
            var customers = new List<Customer>()
            {
                new Customer() 
                {
                   CustomerId = 1,
                   FirstName = "Petar",
                   LastName = "Petrov",
                   Email = "guest1@guest.com",
                   PhoneNumber = "0000000000",
                   Address = "Bulgaria",        
                   ApplicationUserId = "guest1@guest.com"
                },

                new Customer()
                {
                   CustomerId = 2,
                   FirstName = "Dimitar",
                   LastName = "Dimitrov",
                   Email = "guest2@guest.com",
                   PhoneNumber = "0000000000",
                   Address = "Bulgaria",
                   ApplicationUserId = "guest2@guest.com"
                },
            };

            return customers;
        }
    }
}
