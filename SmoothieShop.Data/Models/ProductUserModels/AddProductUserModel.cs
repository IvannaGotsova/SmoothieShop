using SmoothieShop.Data.Data.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmoothieShop.Data.Models.ProductUserModels
{
    /// <summary>
    /// Holds AddProductUserModel class.
    /// </summary>
    public class AddProductUserModel
    {
        [Required]
        public string ApplicationUserId { get; set; } = null!;
        [ForeignKey(nameof(ApplicationUserId))]
        public ApplicationUser? ApplicationUser { get; set; }
        [Required]
        public IEnumerable<ApplicationUser> ApplicationUsers = new List<ApplicationUser>();
    }
}
