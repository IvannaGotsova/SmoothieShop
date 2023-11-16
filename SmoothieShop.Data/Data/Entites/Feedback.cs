using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SmoothieShop.Data.Data.DataConstants.DataConstants.FeedbackConstants;

namespace SmoothieShop.Data.Data.Entites
{
    public class Feedback
    {
        public int FeedbackId { get; set; }
        public int CustomerId { get; set; }
        [Required]
        [StringLength(FeedbackMaxLengthRating)]
        public int Rating { get; set; }
        [Required]
        [StringLength(FeedbackMaxLengthComments)]
        public string? Comments { get; set; }
    }
}
