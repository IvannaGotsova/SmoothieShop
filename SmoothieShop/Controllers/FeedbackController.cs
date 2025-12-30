using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmoothieShop.Common.Common;
using SmoothieShop.Core.Contracts;
using SmoothieShop.Core.Services;
using SmoothieShop.Data.Data.Entites;
using SmoothieShop.Data.Models.CustomerModels;
using SmoothieShop.Data.Models.FeedbackModels;
using static SmoothieShop.Common.Common.GetCurrentUser;
using static SmoothieShop.ErrorConstants.ErrorConstants.GlobalErrorConstants;

namespace SmoothieShop.Controllers
{
    [Authorize]
    /// <summary>
    /// Controls Feedback functionalities.
    /// </summary>
    public class FeedbackController : Controller
    {
        private readonly IFeedbackService feedbackService;
        private readonly ICustomerService customerService;

        public FeedbackController(IFeedbackService feedbackService, ICustomerService customerService)
        {
            this.feedbackService = feedbackService;
            this.customerService = customerService;
        }
        /// <summary>
        /// This method returns index view.
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// This method returns all available feedbacks.
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> AllFeedbacks()
        {
            try
            {
                var feedbacks = await
                    feedbackService
                   .GetAllFeedbacks();

                foreach (var feedback in feedbacks)
                {
                    feedback.FeedbackUserName = customerService.GetCustomerApplicationUsername(feedback.CustomerId);
                }

                return View(feedbacks);
            }
            catch (Exception)
            {

                return RedirectToAction("Error", "Home", new { area = "" });
            }
        }
        [HttpGet]
        public async Task<IActionResult> AddFeedback()
        {
            var currentUserId = User.GetCurrentUserId();
            var currentUserUsername = User.GetCurrentUserName();
            var customerId = customerService.GetCurrentUserCustomerId(currentUserId);
            var customer = customerService.GetCustomerById(customerId);

            if (await Task.Run(() => customer.Result == null))
                return RedirectToAction("Error", "Home", new { area = "" });

            if (await Task.Run(() => !customer.Result.isVip))
                return RedirectToAction("Error", "Home", new { area = "" });

            var modelFeedback = await Task.Run(() => new AddFeedbackModel());
          

            return View(modelFeedback);
        }
        /// <summary>
        /// This method is used to add a feedback.
        /// </summary>
        /// <param name="addFeedbackModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddFeedback(AddFeedbackModel addFeedbackModel)
        {
            var currentUserId = User.GetCurrentUserId();
            var currentUserUsername = User.GetCurrentUserName();
            var customerId = customerService.GetCurrentUserCustomerId(currentUserId);
            var customer = customerService.GetCustomerById(customerId);

            addFeedbackModel.CustomerId = customerId;
            addFeedbackModel.Customer = await customer;

            //check if the model state is valid
            if (!ModelState.IsValid)
            {
                return View(addFeedbackModel);
            }

            try
            {
                await feedbackService
                    .Add(addFeedbackModel);

                TempData["message"] = $"You have successfully added a feedback!";

                return RedirectToAction("AllFeedbacks", "Feedback");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", somethingWrong);

                return View(addFeedbackModel);
            }

        }
        /// <summary>
        /// This method returns a details about particular feedback with a given id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> DetailsFeedback(int id)
        {
            //check if the feedback is null
            if (
                await feedbackService
                .GetFeedbackDetailsById(id) == null)
            {
                return RedirectToAction("Error", "Home", new { area = "" });
            }

            try
            {
                var feedbackModel = await
                feedbackService
                .GetFeedbackDetailsById(id);

                feedbackModel.FeedbackUserName = customerService.GetCustomerApplicationUsername(feedbackModel.CustomerId);

                return View(feedbackModel);
            }
            catch (Exception)
            {

                return RedirectToAction("Error", "Home", new { area = "" });
            }

        }
        /// <summary>
        /// This metod creates a form for editing a particular feedback with a given id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize(Roles = "CustomerUser, Admin")]
        [HttpGet]
        public async Task<IActionResult> EditFeedback(int id)
        {
            //check if the feedback is null
            if (await feedbackService
                .GetFeedbackDetailsById(id) == null)
            {
                return BadRequest();
            }

            try
            {
                var editFormModel = await
                       feedbackService
                       .EditCreateForm(id);

                return View(editFormModel);
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home", new { area = "" });
            }

        }
        /// <summary>
        /// This method is used to edit a particular feedback with a given id.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="editFeedbackModel"></param>
        /// <returns></returns>
        [Authorize(Roles = "CustomerUser, Admin")]
        [HttpPost]
        public async Task<IActionResult> EditFeedback(int id, EditFeedbackModel editFeedbackModel)
        {
            //check if the feedback is null
            if (await feedbackService
                .GetFeedbackDetailsById(id) == null)
            {
                return RedirectToAction("Error", "Home", new { area = "" });
            }

            try
            {
                await feedbackService
                    .Edit(id, editFeedbackModel);

                TempData["message"] = $"You have successfully edited a feedback!";

                return RedirectToAction("AllFeedbacks", "Feedback");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", somethingWrong);

                return View(editFeedbackModel);
            }
        }
        /// <summary>
        /// This metod creates a form for deleting a particular feedback with a given id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize(Roles = "CustomerUser, Admin")]
        [HttpGet]
        public async Task<IActionResult> DeleteFeedback(int id)
        {
            //check if the feedback is null
            if (await feedbackService
                .GetFeedbackDetailsById(id) == null)
            {
                return RedirectToAction("Error", "Home", new { area = "" });
            }

            try
            {
                var deleteFormModel = await
                feedbackService
               .DeleteFeedbackForm(id);

                deleteFormModel.FeedbackUserName = customerService.GetCustomerApplicationUsername(deleteFormModel.CustomerId);

                return View(deleteFormModel);
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home", new { area = "" });
            }

        }
        /// <summary>
        /// This method is used to delete a particular feedback.
        /// </summary>
        /// <param name="deleteFeedbackModel"></param>
        /// <returns></returns>
        [Authorize(Roles = "CustomerUser, Admin")]
        [HttpPost]
        public async Task<IActionResult> DeleteFeedback(DeleteFeedbackModel deleteFeedbackModel)
        {
            //check if the feedback is null
            if (await feedbackService
                .GetFeedbackById(deleteFeedbackModel.FeedbackId) == null)
            {
                return RedirectToAction("Error", "Home", new { area = "" });
            }

            try
            {
                await feedbackService
                    .Delete(deleteFeedbackModel.FeedbackId);

                TempData["message"] = $"You have successfully deleted a feedback!";

                return RedirectToAction("AllFeedbacks", "Feedback");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", somethingWrong);

                deleteFeedbackModel.FeedbackUserName = customerService.GetCustomerApplicationUsername(deleteFeedbackModel.CustomerId);

                return View(deleteFeedbackModel);
            }
        }
        [Authorize(Roles = "CustomerUser, Admin")]
        public async Task<IActionResult> FeedbacksCustomer(int id)
        {
            //check if the customer is null
            if (await feedbackService
                .GetAllFeedbacksByCustomer(id) == null)
            {
                return RedirectToAction("Error", "Home", new { area = "" });
            }

            try
            {
                var feedbacks = await feedbackService.GetAllFeedbacksByCustomer(id);

                return View(feedbacks);
            }
            catch (Exception)
            {
                ModelState.AddModelError("", somethingWrong);

                return RedirectToAction("AllFeedbacks", "Feedback", new { area = "" });
            }
        }

    }
}

