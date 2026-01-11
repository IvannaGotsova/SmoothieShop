using System.ComponentModel.DataAnnotations;
using static SmoothieShop.Data.Data.DataConstants.DataConstants.ApplicationUserConstants;

namespace SmoothieShop.Data.Models.ApplicationUserModels
{
    /// <summary>
    /// Holds DetailsApplicationUserModel class.
    /// </summary>
    public class DetailsApplicationUserModel
    {
        public string Id { get; set; } = null!;
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
