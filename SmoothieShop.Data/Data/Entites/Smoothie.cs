using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SmoothieShop.Data.Data.DataConstants.DataConstants.SmoothieConstants;

namespace SmoothieShop.Data.Data.Entites
{
    public class Smoothie
    {
        [Required]
        public int SmoothieId { get; set; }
        [Required]
        [StringLength(SmoothieMaxLengthName)]
        public string? Name { get; set; }
        [Required]
        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient> { };
        [Required]
        [Range(typeof(double), "0.00", "10000.00", ConvertValueInInvariantCulture = true)]
        public double Size { get; set; }
        [Required]
        [Range(typeof(decimal), "0.00", "10000.00", ConvertValueInInvariantCulture = true)]
        public decimal Price{ get; set; }
        [Required]
        [Range(typeof(double), "0.00", "10000.00", ConvertValueInInvariantCulture = true)]
        public double Calories { get; set; }
    }
}
