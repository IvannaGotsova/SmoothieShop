using SmoothieShop.Data.Data.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SmoothieShop.Data.Data.DataConstants.DataConstants.SmoothieConstants; 

namespace SmoothieShop.Data.Models.SmoothieModels
{
    /// <summary>
    /// Holds AddSmoothieModel class.
    /// </summary>
    public class AddSmoothieModel
    {
        [Required]
        [StringLength(SmoothieMaxLengthName, MinimumLength = SmoothieMinLengthName)]
        public string? SmoothieName { get; set; }
        [Range(typeof(double), "0.00", "10000.00", ConvertValueInInvariantCulture = true)]
        public double Size { get; set; }
        [Required]
        [Range(typeof(decimal), "0.00", "10000.00", ConvertValueInInvariantCulture = true)]
        public decimal Price { get; set; }
        [Required]
        [Range(typeof(double), "0.00", "10000.00", ConvertValueInInvariantCulture = true)]
        public double Calories { get; set; }
        [Required]
        public IEnumerable<Menu> Menus { get; set; } = new List<Menu> { };
        [Required]
        public IEnumerable<Order> Orders { get; set; } = new List<Order> { };
        [Required]
        public IEnumerable<Ingredient> Ingredients { get; set; } = new List<Ingredient> { };
        public List<int> IngredientsIds { get; set; } = new List<int>();
    }
}
