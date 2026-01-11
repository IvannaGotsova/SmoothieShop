using System.ComponentModel.DataAnnotations;
using static SmoothieShop.Data.Data.DataConstants.DataConstants.FeedbackConstants;

namespace SmoothieShop.Data.Models.FeedbackModels
{
    /// <summary>
    /// Holds EditFeedbackModel class.
    /// </summary>
    public class EditFeedbackModel  
    {
        [Required]
        public int FeedbackId { get; set; }
        [Required]
        [Range(FeedbackMinLengthRating, FeedbackMaxLengthRating)]
        public int Rating { get; set; }
        [Required]
        [StringLength(FeedbackMaxLengthComment, MinimumLength = FeedbackMinLengthComment)]
        public string? Comment { get; set; }
    }
}
