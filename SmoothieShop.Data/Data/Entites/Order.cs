using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmoothieShop.Data.Data.Entites
{
    /// <summary>
    /// Holds Order class.
    /// </summary>
    public class Order
    {
        [Required]
        public int OrderId { get; set; }
        public List<Smoothie> Smoothies { get; set; } = new List<Smoothie>();
        [Required]
        [Range(typeof(double), "0.00", "10000.00", ConvertValueInInvariantCulture = true)]
        public decimal Price{ get; set; }
        public DateTime Date { get; set; }
        [Required]
        public int CustomerId { get; set; }
        [ForeignKey(nameof(CustomerId))]
        public Customer? Customer { get; set; }
    }
}
