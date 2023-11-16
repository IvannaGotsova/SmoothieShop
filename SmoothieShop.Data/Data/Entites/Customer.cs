using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SmoothieShop.Data.Data.DataConstants.DataConstants.CustomerConstants;

namespace SmoothieShop.Data.Data.Entites
{
    public class Customer
    {
        public int CustomerId { get; set; }
        [Required]
        [StringLength(CustomerMaxLengthName)]
        public string? FirstName { get; set; }
        [Required]
        [StringLength(CustomerMaxLengthName)]
        public string? LastName { get; set; }
        [Required]
        [StringLength(CustomerMaxLengthEmail)]
        public string? Email { get; set; }
        [Required]
        [StringLength(CustomerMaxLengthPhoneNumber)]
        public string? PhoneNumber { get; set; }
        [Required]
        [StringLength(CustomerMaxLengthAddress)]
        public string? Address { get; set; }

    }
}
