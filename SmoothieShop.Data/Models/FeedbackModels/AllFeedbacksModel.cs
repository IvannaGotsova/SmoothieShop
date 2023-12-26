using SmoothieShop.Data.Data.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SmoothieShop.Data.Data.DataConstants.DataConstants.FeedbackConstants;

namespace SmoothieShop.Data.Models.FeedbackModels
{
    /// <summary>
    /// Holds AllFeedbacksModel class.
    /// </summary>
    public class AllFeedbacksModel 
    {
        [Required]
        public int FeedbackId { get; set; }
        [Required]
        [StringLength(FeedbackMaxLengthRating, MinimumLength = FeedbackMinLengthRating)]
        public int Rating { get; set; }
        [Required]
        [StringLength(FeedbackMaxLengthComment, MinimumLength = FeedbackMinLengthComment)]
        public string? Comment { get; set; }
        [Required]
        public int CustomerId { get; set; }
        [ForeignKey(nameof(CustomerId))]
        public Customer? Customer { get; set; }
    }
}
