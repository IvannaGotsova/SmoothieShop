using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmoothieShop.Data.Data.Entites
{
    public class Smoothie
    {
        public int SmoothieId { get; set; }
        public string? Name { get; set; }
        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient> { };
        public double Size { get; set; }
        public decimal Price{ get; set; }
        public double Calories { get; set; }
    }
}
