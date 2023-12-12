using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SmoothieShop.Data.Data.Entites;
using System;
using System.Collections.Generic;
using System.Globalization;
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

        // A method used to seed DB with initial data of orders.
        private static List<Order> CreateOrders()
        {
            var orders = new List<Order>()
            {
                new Order()
                {
                   OrderId = 1,
                   Smoothies = new List<Smoothie>() {
                                                     new Smoothie { SmoothieId = 1,
                                                                    Name = "Banana Smoothie",
                                                                    Ingredients = new List<Ingredient>(){
                                                                                               new Ingredient  { IngredientId = 1,
                                                                                                                 Name = "Banana",
                                                                                                                 Calories = 105,
                                                                                                                 IngredientInfo = "Bananas are berries, not fruits."} },
                                                                    Size = 250,
                                                                    Price = 4.50M,
                                                                    Calories = 210, //to make a method to calculate automatically
                                                                    MenuId = 1,
                                                                    OrderId = 1,} },
                   Price = 4.50M,
                   Date = DateTime.ParseExact("12/12/2023", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                   CustomerId = 1
                },
                new Order()
                {
                   OrderId = 2,
                   Smoothies = new List<Smoothie>() {
                                                      new Smoothie { SmoothieId = 2,
                                                                     Name = "Strawberry Smoothie",
                                                                     Ingredients = new List<Ingredient>(){
                                                                                                new Ingredient  { IngredientId = 3,
                                                                                                                  Name = "Strawberry",
                                                                                                                  Calories = 32,
                                                                                                                  IngredientInfo = "Strawberries are not actually berries, but rather an accessory fruit."} },
                                                                     Size = 250,
                                                                     Price = 5.50M,
                                                                     Calories =  480, //to make a method to calculate automatically                                 
                                                                     MenuId = 1,
                                                                     OrderId = 2,} },
                   Price = 5.50M,
                   Date = DateTime.ParseExact("12/12/2023", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                   CustomerId = 2
                },

            };

            return orders;
        }
    }
}
