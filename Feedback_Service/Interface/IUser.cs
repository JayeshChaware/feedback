using Feedback_DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Feedback_Service.Interface
{
    public interface IUser : IDisposable
    {
        public int AddUser(User user);
        public User GetUserByID(int? id);
        public void DeleteUserByID(int? id);
        IEnumerable<User> GetAllUser();
        void UpdateUser(User user);
        bool Any(int? Id);
    }
}
