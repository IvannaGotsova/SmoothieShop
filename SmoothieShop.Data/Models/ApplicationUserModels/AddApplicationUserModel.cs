using System.ComponentModel.DataAnnotations;
using static SmoothieShop.Data.Data.DataConstants.DataConstants.ApplicationUserConstants;

namespace SmoothieShop.Data.Models.ApplicationUserModels
{
    /// <summary>
    /// Holds AddApplicationUserModel class.
    /// </summary>
    public class AddApplicationUserModel
    {
        [Required]
        [StringLength(ApplicationUserMaxLengthName, MinimumLength = ApplicationUserMinLengthName)]
        public string UserName { get; set; } = null!;
        [Required]
        [StringLength(ApplicationUserMaxLengthName, MinimumLength = ApplicationUserMinLengthName)]
        public string? FirstName { get; set; }
        [Required]
        [StringLength(ApplicationUserMaxLengthName, MinimumLength = ApplicationUserMinLengthName)]
        public string? LastName { get; set; }
    }
}
