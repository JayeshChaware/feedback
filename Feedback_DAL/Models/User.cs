using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Feedback_DAL.Models
{
    public class User
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [MaxLength(15)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(15)]
        public string LastName { get; set; }

        [Required]
        public Enum.Gender Gender { get; set; }

        [Required]
        [MaxLength(30)]
        public string Email { get; set; }

        [Required]
        [MaxLength(30)]
        public string Password { get; set; }

        public List<FeedbackRating> Feedbacks = new List<FeedbackRating>();
    }
}
