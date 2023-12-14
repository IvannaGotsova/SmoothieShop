using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SmoothieShop.Data.Data.DataConstants.DataConstants.IngredientConstants;

namespace SmoothieShop.Data.Data.Entites
{
    /// <summary>
    /// Holds Ingredient class.
    /// </summary>
    public class Ingredient
    {
        [Required]
        public int IngredientId { get; set; }
        [Required]
        [StringLength(IngredientMaxLengthName)]
        public string? IngredientName { get; set; }
        [Required]
        [Range(typeof(double), "0.00", "10000.00", ConvertValueInInvariantCulture = true)]
        public double Calories { get; set; }
        [Required]
        [StringLength(IngredientMaxLengthInfo)]
        public string? IngredientInfo { get; set;}
        [Required]
        public int SmoothieId { get; set; }
        [ForeignKey(nameof(SmoothieId))]
        public Smoothie? Smoothie { get; set; }
    }
}
