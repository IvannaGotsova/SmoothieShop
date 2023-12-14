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
    /// Holds OrderSmoothie Configuration.
    /// </summary>
    internal class OrderSmoothieConfiguration : IEntityTypeConfiguration<OrderSmoothie>
    {
        public void Configure(EntityTypeBuilder<OrderSmoothie> builder)
        {
            builder.HasData(CreateOrderSmoothies());
        }

        // A method used to seed DB with initial data of OrderSmoothie.
        private static List<OrderSmoothie> CreateOrderSmoothies()
        {
            var orderSmoothies = new List<OrderSmoothie>()
            {
                new OrderSmoothie()
                {
                   OrderId = 1,
                   SmoothieId = 1
                },

                 new OrderSmoothie()
                {
                   OrderId = 2,
                   SmoothieId = 2
                },
            };

            return orderSmoothies;
        }
    }
}
