using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using SmoothieShop.Data.Data.Entites;

namespace SmoothieShop.Data.Models.CustomerUserModels
{
    /// <summary>
    /// Holds EditCustomerUserModel class.
    /// </summary>
    public class EditCustomerUserModel
    {
        [Required]
        public int CustomerUserId { get; set; }
        [Required]
        public string ApplicationUserId { get; set; } = null!;
        [ForeignKey(nameof(ApplicationUserId))]
        public ApplicationUser? ApplicationUser { get; set; }
        [Required]
        public IEnumerable<Customer> Customers = new List<Customer>();
    }
}
