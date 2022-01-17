using Feedback_DAL.Data;
using Feedback_DAL.Models;
using Feedback_Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Feedback_Service.Repository
{
    public class FeedbackRepository : IFeedback
    {
        private readonly UsersDbContext _usersDbContext;
        public FeedbackRepository(UsersDbContext context)
        {
            _usersDbContext = context;
        }
        public void AddFeedback(FeedbackRating feedback)
        {
            _usersDbContext.Feedbacks.Add(feedback);
            _usersDbContext.SaveChanges();
        }

        public bool Any(int? Id)
        {
            if (_usersDbContext.Feedbacks.Any(x => x.Id == Id))
            {
                return true;
            }
            return false;
        }

        public void DeleteFeedbackById(int? id)
        {
            FeedbackRating temp=_usersDbContext.Feedbacks.Find(id);
            _usersDbContext.Feedbacks.Remove(temp);
            _usersDbContext.SaveChanges();

        }

        public IEnumerable<FeedbackRating> GetAllFeedbacks()
        {
            
            return _usersDbContext.Feedbacks.ToList();
        }

        public FeedbackRating GetFeedbackById(int? id)
        {
            FeedbackRating temp = _usersDbContext.Feedbacks.Find(id);
            return temp;
        }

        public void UpdateFeedback(FeedbackRating feedback)
        {
            _usersDbContext.Entry(feedback).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _usersDbContext.SaveChanges();
        }
    }
}
