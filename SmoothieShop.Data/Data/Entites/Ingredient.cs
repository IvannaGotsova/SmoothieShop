using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SmoothieShop.Data.Data.DataConstants.DataConstants.IngredientConstants;

namespace SmoothieShop.Data.Data.Entites
{
    public class Ingredient
    {
        [Required]
        public int IngredientId { get; set; }
        [Required]
        [StringLength(IngredientMaxLengthName)]
        public string? Name { get; set; }
        [Required]
        [Range(typeof(double), "0.00", "10000.00", ConvertValueInInvariantCulture = true)]
        public double Calories { get; set; }
        [Required]
        public string? IngredientInfo { get; set;} 
    }
}
