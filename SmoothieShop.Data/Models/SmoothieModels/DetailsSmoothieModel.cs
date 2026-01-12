using System.ComponentModel.DataAnnotations;
using SmoothieShop.Data.Data.Entites;
using static SmoothieShop.Data.Data.DataConstants.DataConstants.SmoothieConstants;

namespace SmoothieShop.Data.Models.SmoothieModels
{
    /// <summary>
    /// Holds DetailsSmoothieModel class.
    /// </summary>
    public class DetailsSmoothieModel
    {
        [Required]
        public int SmoothieId { get; set; }
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
        public int MenusCount { get; set; }
        [Required]
        public IEnumerable<Order> Orders { get; set; } = new List<Order> { };
        public int OrdersCount { get; set; }
        [Required]
        public IEnumerable<Ingredient> Ingredients { get; set; } = new List<Ingredient> { };
        public int IngredientsCount { get; set; }
    }
}
