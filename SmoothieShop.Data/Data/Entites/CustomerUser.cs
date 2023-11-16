using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmoothieShop.Data.Data.Entites
{
    public class CustomerUser : ApplicationUser
    {
        [Required]
        public int CustomerUserId { get; set; }
        [Required]
        public string ApplicationUserId { get; set; } = null!;
    }
}
