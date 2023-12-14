using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmoothieShop.Data.Data.Entites
{
    /// <summary>
    /// This is mapping class od Menu and Smoothie.
    /// </summary>
    public class MenuSmoothie
    {
        [Required]
        public int MenuId { get; set; }
        [ForeignKey(nameof(MenuId))]
        public Menu? Menu { get; set; }
        [Required]
        public int SmoothieId { get; set; }
        [ForeignKey(nameof(SmoothieId))]
        public Smoothie? Smoothie { get; set; }
    }
}
