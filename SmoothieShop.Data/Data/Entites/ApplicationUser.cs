using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SmoothieShop.Data.Data.DataConstants.DataConstants.ApplicationUserConstants;

namespace SmoothieShop.Data.Data.Entites
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [StringLength(ApplicationUserMaxLengthName)]
        public string? FirstName { get; set; }
        [Required]
        [StringLength(ApplicationUserMaxLengthName)]
        public string? LastName { get; set; }

    }
}
