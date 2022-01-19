using Feedback_DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Feedback_Service.Interface
{
    public interface IFeedback
    {
        public void AddFeedback(FeedbackRating feedback);
        public IEnumerable<FeedbackRating> GetAllFeedbacks();
        public FeedbackRating GetFeedbackById(int? id);
        public IEnumerable<FeedbackRating> GetAllFeedbackById(int? id);
        void DeleteFeedbackById(int? id);
        void UpdateFeedback(FeedbackRating feedback);
        bool Any(int? Id);

    }
}
