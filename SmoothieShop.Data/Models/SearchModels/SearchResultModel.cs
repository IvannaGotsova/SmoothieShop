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
        public List<Smoothie> Smoothies { get; set; }
        public List<Menu> Menus { get; set; }
    }
}
