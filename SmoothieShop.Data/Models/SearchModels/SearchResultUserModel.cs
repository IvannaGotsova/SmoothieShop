using SmoothieShop.Data.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmoothieShop.Data.Models.SearchModels
{
    public class SearchResultUserModel
    {
        public List<Ingredient> Ingredients { get; set; }
        public List<Feedback> Feedbacks { get; set; }

    }
}
