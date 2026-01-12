using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using SmoothieShop.Data.Data.Entites;

namespace SmoothieShop.Data.Models.OrderModels
{
    /// <summary>
    /// Holds DetailsOrderModel class.
    /// </summary>
    public class DetailsOrderModel
    {
        [Required]
        public int OrderId { get; set; }
        [Required]
        [Range(typeof(decimal), "0.00", "10000.00", ConvertValueInInvariantCulture = true)]
        public decimal Price { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public int CustomerId { get; set; }
        [ForeignKey(nameof(CustomerId))]
        public Customer? Customer { get; set; }
        [Required]
        public string CustomerName { get; set; }
        public string CustomerUserName { get; set; }
        public IEnumerable<Smoothie> Smoothies { get; set; } = new List<Smoothie>();
        public int SmoothiesCount { get; set; }
        public IEnumerable<Menu> Menus { get; set; } = new List<Menu>();
        public int MenusCount { get; set; }
    }
}
