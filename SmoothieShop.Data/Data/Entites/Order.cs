using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmoothieShop.Data.Data.Entites
{
    public class Order
    {
        [Required]
        public int OrderId { get; set; }
        [Required]
        public int CustomerId { get; set; }
        public List<int> Smoothies { get; set; } = new List<int>();
        [Required]
        [Range(typeof(double), "0.00", "10000.00", ConvertValueInInvariantCulture = true)]
        public decimal Price{ get; set; }
        public DateTime Date { get; set; }
    }
}
