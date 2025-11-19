using SmoothieShop.Data.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmoothieShop.Data.Models.SearchModels
{
    public class SearchResultAdminModel
    {
        public List<ApplicationUser> ApplicationUsers { get; set; }
        public List<CustomerUser> CustomerUsers { get; set; }
        public List<ProductUser> ProductUsers { get; set; }



    }
}
