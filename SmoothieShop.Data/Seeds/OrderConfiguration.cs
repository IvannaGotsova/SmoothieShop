using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using SmoothieShop.Data.Data.Entites;

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

        // A method used to seed DB with initial data of orders.
        private static List<Order> CreateOrders()
        {
            var orders = new List<Order>()
            {
                new Order()
                {
                   OrderId = 1,               
                   Price = 4.50M,
                   Date = DateTime.ParseExact("12/12/2023", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                   CustomerId = 1
                },
                new Order()
                {
                   OrderId = 2,               
                   Price = 5.50M,
                   Date = DateTime.ParseExact("12/12/2023", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                   CustomerId = 2
                }
            };

            return orders;
        }
    }
}
