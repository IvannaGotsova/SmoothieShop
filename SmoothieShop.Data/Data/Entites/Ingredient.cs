using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmoothieShop.Data.Data.Entites
{
    public class Ingredient
    {
        public int IngredientId { get; set; }
        public string? Name { get; set; }
        public double Calories { get; set; }
    }
}
