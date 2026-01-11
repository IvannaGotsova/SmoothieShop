using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SmoothieShop.Data.Data.Entites
{
    /// <summary>
    /// This is mapping class od Menu and Order.
    /// </summary>
    public class MenuOrder
    {
        [Required]
        public int MenuId { get; set; } 
        [ForeignKey(nameof(MenuId))]
        public Menu? Menu { get; set; }
        [Required]
        public int OrderId { get; set; }
        [ForeignKey(nameof(OrderId))]
        public Order? Order { get; set; }
    }
}
