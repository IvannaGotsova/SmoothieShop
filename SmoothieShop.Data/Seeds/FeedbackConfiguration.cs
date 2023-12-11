using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmoothieShop.Data.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmoothieShop.Data.Seeds
{
    /// <summary>
    /// Holds Feedback Configuration.
    /// </summary>
    internal class FeedbackConfiguration : IEntityTypeConfiguration<Feedback>
    {
        public void Configure(EntityTypeBuilder<Feedback> builder)
        {
            builder.HasData(CreateFeedbacks());
        }

        private static List<Feedback> CreateFeedbacks()
        {
            var feedbacks = new List<Feedback>()
            {
                new Feedback()
                {
                   FeedbackId = 1,
                   CustomerId = 1,
                   Rating = 10,
                   Comment = "That was great smoothie."
                },

                 new Feedback()
                {
                   FeedbackId = 2,
                   CustomerId = 2,
                   Rating = 10,
                   Comment = "That was amazing smoothie."
                },


            };

            return feedbacks;
        }
    }
}
