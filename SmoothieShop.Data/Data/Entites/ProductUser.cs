using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmoothieShop.Data.Data.Entites
{
    /// <summary>
    /// Holds ProductUser class.
    /// </summary>
    public class ProductUser 
    {
        [Key]
        [Required]
        public int ProductUserId { get; set; }
        [Required]
        public string ApplicationUserId { get; set; }
        [ForeignKey(nameof(ApplicationUserId))]
        public ApplicationUser? ApplicationUser { get; set; } = null!;
    }
}
