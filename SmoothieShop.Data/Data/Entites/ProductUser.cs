using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmoothieShop.Data.Data.Entites
{
    public class ProductUser : ApplicationUser
    {
        [Required]
        public int ProductUserId { get; set; }
        [Required]
        public string ApplicationUserId { get; set; } = null!;
    }
}
