using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using SmoothieShop.Data.Data.Entites;

namespace SmoothieShop.Data.Models.CustomerUserModels
{
    /// <summary>
    /// Holds DetailsCustomerUserModel class.
    /// </summary>
    public class DetailsCustomerUserModel
    {
        [Required]
        public int CustomerUserId { get; set; }
        [Required]
        public string ApplicationUserId { get; set; } = null!;
        [ForeignKey(nameof(ApplicationUserId))]
        public ApplicationUser? ApplicationUser { get; set; }
        [Required]
        public IEnumerable<Customer> Customers = new List<Customer>();
        public int CustomersCount { get; set; }
    }
}
