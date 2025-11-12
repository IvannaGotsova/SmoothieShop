using Microsoft.EntityFrameworkCore;
using SmoothieShop.Core.Contracts;
using SmoothieShop.Data.Data.Entites;
using SmoothieShop.Data.Models.CustomerModels;
using SmoothieShop.Data.Models.FeedbackModels;
using SmoothieShop.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmoothieShop.Core.Services
{
    /// <summary>
    /// Holds Service for Feedback functionality.
    /// </summary>
    public class FeedbackService : IFeedbackService
    {
        private readonly IRepository data;

        public FeedbackService(IRepository data)
        {
            this.data = data;
        }
        /// <summary>
        /// This method is used to add a feedback.
        /// </summary>
        /// <param name="addFeedbackModel"></param>
        /// <returns></returns>
        public async Task Add(AddFeedbackModel addFeedbackModel)
        {
            var feedbackToBeAdded = new Feedback()
            {
                Rating = addFeedbackModel.Rating,
                Comment = addFeedbackModel.Comment,
                CustomerId = addFeedbackModel.CustomerId
            };

            await this.data.AddAsync(feedbackToBeAdded);
            await this.data.SaveChangesAsync();
        }

        public int Count()
        {
            return
                this.data
                .AllReadonly<Feedback>()
                .Count();
        }

        /// <summary>
        /// This method deletes a particular feddback with a given id.
        /// </summary>
        /// <param name="feedbackId"></param>
        /// <returns></returns>
        public async Task Delete(int feedbackId)
        {
            await this.data.DeleteAsync<Feedback>(feedbackId);
            await this.data.SaveChangesAsync();
        }
        /// <summary>
        /// This method creates form for deleting a feedback.
        /// </summary>
        /// <param name="feedbackId"></param>
        /// <returns></returns>
        public async Task<DeleteFeedbackModel> DeleteFeedbackForm(int feedbackId)
        {
            var feedbackToBeDeleted = await
                GetFeedbackById(feedbackId);

            var deleteFeedbackModel = new DeleteFeedbackModel()
            {
                Rating = feedbackToBeDeleted.Rating,
                Comment = feedbackToBeDeleted.Comment,
                CustomerId = feedbackToBeDeleted.CustomerId
            };

            return deleteFeedbackModel;
        }
        /// <summary>
        /// This method is used to edit a particular feedback with a given id.
        /// </summary>
        /// <param name="feedbackId"></param>
        /// <param name="editFeedbackModel"></param>
        /// <returns></returns>
        public async Task Edit(int feedbackId, EditFeedbackModel editFeedbackModel)
        {
            var feedbackToBeEdited = await
                GetFeedbackById(feedbackId);

            feedbackToBeEdited.Rating = editFeedbackModel.Rating;
            feedbackToBeEdited.Comment = editFeedbackModel.Comment;

            this.data.Update<Feedback>(feedbackToBeEdited);
            await this.data.SaveChangesAsync();
        }
        /// <summary>
        /// This method creates form for editing a feedback.
        /// </summary>
        /// <param name="feedbackId"></param>
        /// <returns></returns>
        public async Task<EditFeedbackModel> EditCreateForm(int feedbackId)
        {
            var feedbackToBeEdited = await
                  GetFeedbackById(feedbackId);

            var editFeedbackModel = new EditFeedbackModel()
            {
                Rating = feedbackToBeEdited.Rating,
                Comment = feedbackToBeEdited.Comment,
            };

            return editFeedbackModel;
        }
        /// <summary>
        /// This method returns IEnumerable of all feedbacks.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<AllFeedbacksModel>> GetAllFeedbacks()
        {
            var feedbacks = await data
                .AllReadonly<Feedback>()
                .ToListAsync();


            return feedbacks
                .Select(f => new AllFeedbacksModel()
                {
                    FeedbackId = f.FeedbackId,
                    Rating = f.Rating,
                    Comment = f.Comment,
                    CustomerId = f.CustomerId
                })
                .ToList();
        }
        /// <summary>
        /// This method returns a particular feedback with a given id.
        /// </summary>
        /// <param name="feedbackId"></param>
        /// <returns></returns>
        public async Task<Feedback> GetFeedbackById(int feedbackId)
        {
            var feedback = await
               this.data
               .AllReadonly<Feedback>()
               .Where(f => f.FeedbackId == feedbackId)
               .FirstOrDefaultAsync();

            //check if customer is null
            if (feedback == null)
            {
                throw new ArgumentNullException(null, nameof(feedback));
            }

            return feedback;
        }
        /// <summary>
        /// This method returns Details of particular feedback with a given id.
        /// </summary>
        /// <param name="feedbackId"></param>
        /// <returns></returns>
        public async Task<DetailsFeedbackModel> GetFeedbackDetailsById(int feedbackId)
        {
            var feedback = await
               this.data
               .AllReadonly<Feedback>()
               .Include(f => f.Customer)
               .Where(f => f.FeedbackId == feedbackId)
               .Select(f => new DetailsFeedbackModel()
               {
                   FeedbackId = f.FeedbackId,
                   Rating = f.Rating,
                   Comment = f.Comment,
                   CustomerId = f.CustomerId,
               }).FirstOrDefaultAsync();

            //check if customer is null
            if (feedback == null)
            {
                throw new ArgumentNullException(null, nameof(feedback));
            }

            return feedback;
        }
        /// <summary>
        /// This method returns IEnumerable of all feedbacks used for Select.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Feedback>> GetFeedbacksForSelect()
        {
            return await
                this.data
                .AllReadonly<Feedback>()
                .ToListAsync();
        }
    }
}
