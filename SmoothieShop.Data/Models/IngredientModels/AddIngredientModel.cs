using SmoothieShop.Data.Data.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SmoothieShop.Data.Data.DataConstants.DataConstants.IngredientConstants;

namespace SmoothieShop.Data.Models.IngredientModels
{
    /// <summary>
    /// Holds AddIngredientModel class.
    /// </summary>
    public class AddIngredientModel
    {
        [Required]
        [StringLength(IngredientMaxLengthName, MinimumLength = IngredientMinLengthName)]
        public string? IngredientName { get; set; }
        [Required]
        [Range(typeof(double), "0.00", "10000.00", ConvertValueInInvariantCulture = true)]
        public double Calories { get; set; }
        [Required]
        [StringLength(IngredientMaxLengthInfo, MinimumLength = IngredientMinLengthInfo)]
        public string? IngredientInfo { get; set; }
        [Required]
        public IEnumerable<Smoothie> Smoothies { get; set; } = new List<Smoothie>();
    }
}
