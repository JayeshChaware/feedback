using Feedback_DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Feedback_Service.Interface
{
    public interface IFeedback
    {
        void AddFeedback(FeedbackRating feedback);
        IEnumerable<FeedbackRating> GetAllFeedbacks();
        void DeleteFeedbackById(int id);
        void UpdateFeedback(FeedbackRating feedback);

    }
}
