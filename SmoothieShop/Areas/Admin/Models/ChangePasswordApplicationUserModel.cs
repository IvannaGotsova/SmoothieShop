using System.ComponentModel.DataAnnotations;

namespace SmoothieShop.Areas.Admin.Models
{
    public class ChangePasswordApplicationUserModel
    {
        public string Id { get; set; }
        [Required]
        public string OldPassword { get; set; }
        [Required]
        public string NewPassword { get; set; }
    }
}
