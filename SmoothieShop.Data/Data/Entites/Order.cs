using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmoothieShop.Data.Data.Entites
{
    public class Order
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public List<int> Smoothies { get; set; } = new List<int>();
        public decimal Price{ get; set; }
        public DateTime Date { get; set; }
    }
}
