using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using static SmoothieShop.Data.Data.DataConstants.DataConstants.ApplicationUserConstants;

namespace SmoothieShop.Data.Data.Entites
{
    /// <summary>
    /// Holds ApplicationUser class.
    /// </summary>
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [StringLength(ApplicationUserMaxLengthName)]
        public string? FirstName { get; set; }
        [Required]
        [StringLength(ApplicationUserMaxLengthName)]
        public string? LastName { get; set; }
        public Customer? Customer { get; set; }
        public CustomerUser? CustomerUser { get; set; }
        public ProductUser? ProductUser { get; set; }
    }
}
