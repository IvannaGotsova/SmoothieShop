using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using SmoothieShop.Data.Data.Entites;

namespace SmoothieShop.Data.Models.CustomerUserModels
{
    /// <summary>
    /// Holds AddCustomerUserModel class.
    /// </summary>
    public class AddCustomerUserModel
    {
        [Required]
        public string ApplicationUserId { get; set; } = null!;
        [ForeignKey(nameof(ApplicationUserId))]
        public ApplicationUser? ApplicationUser { get; set; }
        [Required]
        public IEnumerable<ApplicationUser> ApplicationUsers = new List<ApplicationUser>();
    }
}
