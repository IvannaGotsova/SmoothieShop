using SmoothieShop.Data.Data.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SmoothieShop.Data.Data.DataConstants.DataConstants.CustomerConstants;

namespace SmoothieShop.Data.Models.CustomerModels
{
    /// <summary>
    /// Holds EditCustomerModel class.
    /// </summary>
    public class EditCustomerModel
    {
        [Required]
        public int CustomerId { get; set; }
        [Required]
        [StringLength(CustomerMaxLengthName, MinimumLength = CustomerMinLengthName)]
        public string? FirstName { get; set; }
        [Required]
        [StringLength(CustomerMaxLengthName, MinimumLength = CustomerMinLengthName)]
        public string? LastName { get; set; }
        [Required]
        [StringLength(CustomerMaxLengthEmail, MinimumLength = CustomerMinLengthEmail)]
        public string? Email { get; set; }
        [Required]
        [StringLength(CustomerMaxLengthPhoneNumber, MinimumLength = CustomerMinLengthPhoneNumber)]
        public string? PhoneNumber { get; set; }
        [Required]
        [StringLength(CustomerMaxLengthAddress, MinimumLength = CustomerMinLengthAddress)]
        public string? Address { get; set; }
        [Required]
        public int ApplicationUserId { get; set; }
        [ForeignKey(nameof(ApplicationUserId))]
        public ApplicationUser? ApplicationUser { get; set; }

    }
}
