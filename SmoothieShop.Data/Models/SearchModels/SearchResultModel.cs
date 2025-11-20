using SmoothieShop.Data.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmoothieShop.Data.Models.SearchModels
{
    public class SearchResultModel
    {
        //All
        public List<Smoothie> Smoothies { get; set; }
        public List<Menu> Menus { get; set; }
        //User
        public List<Ingredient> Ingredients { get; set; }
        public List<Feedback> Feedbacks { get; set; }
        //Customer User
        public List<Customer> Customers { get; set; }
        //Product User
        public List<Order> Orders { get; set; }
        //Admin
        public List<ApplicationUser> ApplicationUsers { get; set; }
        public List<CustomerUser> CustomerUsers { get; set; }
        public List<ProductUser> ProductUsers { get; set; }
    }
}
