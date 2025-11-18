using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        [Required]
        public IEnumerable<Menu> Menus = new List<Menu>();
    }
}
