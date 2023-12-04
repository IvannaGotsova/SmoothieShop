using System.ComponentModel.DataAnnotations;
using static SmoothieShop.Data.Data.DataConstants.DataConstants.ApplicationUserConstants;

namespace SmoothieShop.Data.Models.ApplicationUserModels
{
    public class RegisterModelView
    {
        [Required]
        [StringLength(ApplicationUserMaxLengthName, MinimumLength = ApplicationUserMinLengthName)]
        public string UserName { get; set; } = null!;
        [Required]
        [StringLength(ApplicationUserMaxLengthName, MinimumLength = ApplicationUserMinLengthName)]
        public string FirstName { get; set; } = null!;
        [Required]
        [StringLength(ApplicationUserMaxLengthName, MinimumLength = ApplicationUserMinLengthName)]
        public string LastName { get; set; } = null!;
        [Required]
        [EmailAddress]
        [StringLength(ApplicationUserMaxLengthEmail, MinimumLength = ApplicationUserMinLengthEmail)]
        public string Email { get; set; } = null!;
        [Required]
        [StringLength(ApplicationUserMaxLengthPassword, MinimumLength = ApplicationUserMinLengthPassword)]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
        [Required]
        [Compare(nameof(Password))]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; } = null!;
    }
}
