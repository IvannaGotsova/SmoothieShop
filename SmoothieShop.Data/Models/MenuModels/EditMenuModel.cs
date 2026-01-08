using SmoothieShop.Data.Data.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SmoothieShop.Data.Data.DataConstants.DataConstants.MenuConstants;

namespace SmoothieShop.Data.Models.MenuModels
{
    /// <summary>
    /// Holds EditMenuModel class.
    /// </summary>
    public class EditMenuModel
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
        public List<int> SmoothiesIds { get; set; } = new List<int>();
        public IEnumerable<int> SelectedSmoothiesIds { get; set; } = new List<int>();
        public IEnumerable<MenuSmoothie> SmoothiesMenus { get; set; } = new List<MenuSmoothie> { };
    }
}
