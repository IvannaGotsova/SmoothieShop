using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmoothieShop.Data.Data.Entites
{
    /// <summary>
    /// Holds CustomerUser class.
    /// </summary>
    public class CustomerUser 
    {
        [Key]
        [Required]
        public int CustomerUserId { get; set; }
        [Required]
        public string ApplicationUserId { get; set; } 
        [ForeignKey(nameof(ApplicationUserId))]
        public ApplicationUser? ApplicationUser { get; set; } = null!;
    }
}
