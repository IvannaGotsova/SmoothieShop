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
    /// Holds Order Configuration.
    /// </summary>
    internal class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasData(CreateOrders());
        }

        private static List<Order> CreateOrders()
        {
            var orders = new List<Order>()
            {
                new Order()
                {
                   OrderId = 1,
                   // Smoothies - to finished lately
                   Price = 4.50M,
                   // Date - to finish lately
                   CustomerId = 1
                },
                 new Order()
                {
                   OrderId = 2,
                   // Smoothies - to finished lately
                   Price = 5.50M,
                   // Date - to finish lately
                   CustomerId = 1
                },

            };

            return orders;
        }
    }
}
