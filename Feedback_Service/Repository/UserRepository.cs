﻿using Feedback_DAL.Data;
using Feedback_DAL.Models;
using Feedback_Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Feedback_Service.Repository
{
    public class UserRepository : IUser
    {
        private readonly UsersDbContext _usersDbContext;
        public UserRepository(UsersDbContext context)
        {
            _usersDbContext = context;
        }
        public void AddUser(User user)
        {
            _usersDbContext.Users.Add(user);
            _usersDbContext.SaveChanges();
        }

        public bool Any(int? Id)
        {
            if (_usersDbContext.Users.Any(x => x.ID == Id))
            {
                return true;
            }
            return false;
        }

        public void DeleteUserByID(int? id)
        {
            User temp = _usersDbContext.Users.Find(id);    
            _usersDbContext.Users.Remove(temp);
            _usersDbContext.SaveChanges();
        }

        public void Dispose()
        {
            _usersDbContext.Dispose();
            GC.SuppressFinalize(this);
        }

        public User GetUserByID(int? id)
        {
            return _usersDbContext.Users.FirstOrDefault(u => u.ID == id);
        }

        public void UpdateUser(User user)
        {
            _usersDbContext.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _usersDbContext.SaveChanges();
        }
    }
}
