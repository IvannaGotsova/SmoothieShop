using System.ComponentModel.DataAnnotations;
using SmoothieShop.Data.Data.Entites;
using static SmoothieShop.Data.Data.DataConstants.DataConstants.MenuConstants;

namespace SmoothieShop.Data.Models.MenuModels
{
    /// <summary>
    /// Holds DetailsMenuModel class.
    /// </summary>
    public class DetailsMenuModel
    {
        [Required]
        public int MenuId { get; set; }
        [Required]
        [StringLength(MenuMaxLengthName, MinimumLength = MenutMinLengthName)]
        public string? MenuName { get; set; }
        [Required]
        [Range(typeof(decimal), "0.00", "10000.00", ConvertValueInInvariantCulture = true)]
        public decimal Price { get; set; }
        [Required]
        [Range(typeof(double), "0.00", "10000.00", ConvertValueInInvariantCulture = true)]
        public double Calories { get; set; }
        public IEnumerable<Smoothie> Smoothies { get; set; } = new List<Smoothie>();
        public IEnumerable<Order> Orders { get; set; } = new List<Order> { };
        public int SmoothiesCount { get; set; }
        public int OrdersCount { get; set; }
    }
}
