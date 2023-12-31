﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SmoothieShop.Data.Data.DataConstants.DataConstants.MenuConstants;

namespace SmoothieShop.Data.Data.Entites
{
    /// <summary>
    /// Holds Menu class.
    /// </summary>
    public class Menu
    {
        [Required]
        public int MenuId { get; set; }
        [Required]
        [StringLength(MenuMaxLengthName)]
        public string? MenuName { get; set; }
        [Required]
        public int ProductUserId { get; set; }
        [ForeignKey(nameof(ProductUserId))]
        public ProductUser? ProductUser { get; set; }
        [Required]
        public IEnumerable<Smoothie> Smoothies { get; set; } = new List<Smoothie>();
        [Required]
        public IEnumerable<Order> Orders { get; set; } = new List<Order> { };
    }
}
