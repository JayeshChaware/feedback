using Feedback_DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Feedback_DAL.Data
{
    public class UsersDbContext : DbContext
    {
        public UsersDbContext(DbContextOptions options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
