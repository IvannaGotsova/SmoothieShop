using System.ComponentModel.DataAnnotations;
using static SmoothieShop.Data.Data.DataConstants.DataConstants.MenuConstants;

namespace SmoothieShop.Data.Data.Entites
{
    /// <summary>
    /// Holds Menu class.
    /// </summary>
    public class Menu
    {
        [Required]
        public int MenuId { get; set; }
        [Required]
        [StringLength(MenuMaxLengthName)]
        public string? MenuName { get; set; }
        [Required]
        [Range(typeof(decimal), "0.00", "10000.00", ConvertValueInInvariantCulture = true)]
        public decimal Price { get; set; }
        [Required]
        [Range(typeof(double), "0.00", "10000.00", ConvertValueInInvariantCulture = true)]
        public double Calories { get; set; }
        public IEnumerable<Smoothie> Smoothies { get; set; } = new List<Smoothie>();
        public IEnumerable<MenuSmoothie> MenusSmoothies { get; set; } = new List<MenuSmoothie>();
        public IEnumerable<Order> Orders { get; set; } = new List<Order> { };
        public IEnumerable<MenuOrder> MenusOrders { get; set; } = new List<MenuOrder>();


    }
}
