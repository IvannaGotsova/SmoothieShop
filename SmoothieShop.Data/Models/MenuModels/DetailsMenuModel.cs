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
        public int ProductUserId { get; set; }
        [ForeignKey(nameof(ProductUserId))]
        public ProductUser? ProductUser { get; set; }
        [Required]
        public IEnumerable<Smoothie> Smoothies { get; set; } = new List<Smoothie>();
        [Required]
        public IEnumerable<Order> Orders { get; set; } = new List<Order> { };
        public int SmoothiesCount { get; set; }
        public int OrdersCount { get; set; }
    }
}
