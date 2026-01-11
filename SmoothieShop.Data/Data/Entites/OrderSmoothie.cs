using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SmoothieShop.Data.Data.Entites
{
    /// <summary>
    /// This is mapping class of Order and Smoothie
    /// </summary>
    public class OrderSmoothie
    {
        [Required]
        public int OrderId { get; set; }
        [ForeignKey(nameof(OrderId))]
        public Order? Order { get; set; }
        [Required]
        public int SmoothieId { get; set; }
        [ForeignKey(nameof(SmoothieId))]
        public Smoothie? Smoothie { get; set; }
    }
}

