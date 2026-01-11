using System.ComponentModel.DataAnnotations;

namespace SmoothieShop.Data.Models.ApplicationUserModels
{
    /// <summary>
    /// Holds LoginModelView class.
    /// </summary>
    public class LoginModelView 
    {
        [Required]
        public string UserName { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
    }
}
