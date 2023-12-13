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
                   Orders = new List<Order>(){ 
                                               new Order {
                                                           OrderId = 1,
                                                           Smoothies = new List<Smoothie>() {
                                                                   new Smoothie { SmoothieId = 1,
                                                                                  Name = "Banana Smoothie",
                                                                                  Ingredients = new List<Ingredient>(){
                                                                                                             new Ingredient  { IngredientId = 1,                             
                                                                                                                               Name = "Banana",                       
                                                                                                                               Calories = 105,                             
                                                                                                                               IngredientInfo = "Bananas are berries, not fruits."}},
                                                                                  Size = 250,
                                                                                  Price = 4.50M,
                                                                                  Calories = 210, //to make a method to calculate automatically                   
                                                                                  MenuId = 1,
                                                                                  OrderId = 1,} },
                                                            Price = 4.50M,
                                                            Date = DateTime.ParseExact("12/12/2023", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                                                            CustomerId = 1} }
                },

                new Customer()
                {
                   CustomerId = 2,
                   FirstName = "Dimitar",
                   LastName = "Dimitrov",
                   Email = "guest2@guest.com",
                   PhoneNumber = "0000000000",
                   Address = "Bulgaria",
                   Orders = new List<Order>(){
                                               new Order {
                                                           OrderId = 2,
                                                           Smoothies = new List<Smoothie>() {
                                                                   new Smoothie { SmoothieId = 2,
                                                                                  Name = "Strawberry Smoothie",
                                                                                  Ingredients = new List<Ingredient>(){
                                                                                                             new Ingredient  { IngredientId = 3,
                                                                                                                               Name = "Strawberry",
                                                                                                                               Calories = 32,
                                                                                                                               IngredientInfo = "Strawberries are not actually berries, but rather an accessory fruit."}},
                                                                                  Size = 250,
                                                                                  Price = 5.50M,
                                                                                  Calories =  480, //to make a method to calculate  automatic                        
                                                                                  MenuId = 1,
                                                                                  OrderId = 2,} },
                                                           Price = 5.50M,
                                                           Date = DateTime.ParseExact("12/12/2023", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                                                           CustomerId = 2} }
                },
            };

            return customers;
        }
    }
}
