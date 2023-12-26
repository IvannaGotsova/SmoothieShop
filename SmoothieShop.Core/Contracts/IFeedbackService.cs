using SmoothieShop.Data.Data.Entites;
using SmoothieShop.Data.Models.CustomerModels;
using SmoothieShop.Data.Models.FeedbackModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmoothieShop.Core.Contracts
{
    /// <summary>
    /// Holds Interface for Feedback functionality.
    /// </summary>
    public interface IFeedbackService
    {
        /// <summary>
        /// This method returns IEnumerable of all feedbacks.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<AllFeedbacksModel>> GetAllFeedbacks();
        /// <summary>
        /// This method is used to add a feedback.
        /// </summary>
        /// <param name="addFeedbackModel"></param>
        /// <returns></returns>
        Task Add(AddFeedbackModel addFeedbackModel);
        /// <summary>
        /// This method returns IEnumerable of all feedbacks used for Select.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Feedback>> GetFeedbacksForSelect();
        /// <summary>
        /// This method returns Details of particular feedback with a given id.
        /// </summary>
        /// <param name="feedbackId"></param>
        /// <returns></returns>
        Task<DetailsFeedbackModel> GetFeedbackDetailsById(int feedbackId);
        /// <summary>
        /// This method creates form for editing a feedback.
        /// </summary>
        /// <param name="feedbackId"></param>
        /// <returns></returns>
        Task<EditFeedbackModel> EditCreateForm(int feedbackId);
        /// <summary>
        /// This method is used to edit a particular feedback with a given id.
        /// </summary>
        /// <param name="feedbackId"></param>
        /// <param name="editFeedbackModel"></param>
        /// <returns></returns>
        Task Edit(int feedbackId, EditFeedbackModel editFeedbackModel);
        /// <summary>
        /// This method returns a particular feedback with a given id.
        /// </summary>
        /// <param name="feedbackId"></param>
        /// <returns></returns>
        Task<Feedback> GetFeedbackById(int feedbackId);
        /// <summary>
        /// This method creates form for deleting a feedback.
        /// </summary>
        /// <param name="feedbackId"></param>
        /// <returns></returns>
        Task<DeleteFeedbackModel> DeleteFeedbackForm(int feedbackId);
        /// <summary>
        /// This method deletes a particular feedback with a given id.
        /// </summary>
        /// <param name="feedbackId"></param>
        /// <returns></returns>
        Task Delete(int feedbackId);
    }
}
