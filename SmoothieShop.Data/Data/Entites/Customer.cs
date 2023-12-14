using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SmoothieShop.Data.Data.DataConstants.DataConstants.CustomerConstants;

namespace SmoothieShop.Data.Data.Entites
{
    /// <summary>
    /// Holds Customer class.
    /// </summary>
    public class Customer
    {
        [Required]
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
        [Required]
        public int CustomerUserId { get; set; }
        [ForeignKey(nameof(CustomerUserId))]
        public CustomerUser? CustomerUser { get; set; }
        [Required]
        public IEnumerable<Order> Orders { get; set; } = new List<Order>();
        [Required]
        public IEnumerable<Feedback> Feedbacks { get; set; } = new List<Feedback>();

    }
}
