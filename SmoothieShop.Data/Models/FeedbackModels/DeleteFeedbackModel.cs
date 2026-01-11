using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SmoothieShop.Data.Data.Entites;
using static SmoothieShop.Data.Data.DataConstants.DataConstants.FeedbackConstants;

namespace SmoothieShop.Data.Models.FeedbackModels
{
    /// <summary>
    /// Holds DeleteFeedbackModel class.
    /// </summary>
    public class DeleteFeedbackModel 
    {
        [Required]
        public int FeedbackId { get; set; }
        [Required]
        [Range(FeedbackMinLengthRating, FeedbackMaxLengthRating)]
        public int Rating { get; set; }
        [Required]
        [StringLength(FeedbackMaxLengthComment, MinimumLength = FeedbackMinLengthComment)]
        public string? Comment { get; set; }
        [Required]
        public string? FeedbackUserName { get; set; }
        public int CustomerId { get; set; }
        [ForeignKey(nameof(CustomerId))]
        public Customer? Customer { get; set; }
    }
}
