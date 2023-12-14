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
    /// This is mapping class of Ingredient and Smoothie.
    /// </summary>
    public class IngredientSmoothie
    {
        [Required]
        public int IngredientId { get; set; }
        [ForeignKey(nameof(IngredientId))]
        public Ingredient? Ingredient { get; set; }
        [Required]
        public int SmoothieId { get; set; }
        [ForeignKey(nameof(SmoothieId))]
        public Smoothie? Smoothie { get; set; }
    }
}
