using Feedback_DAL.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public Gender Gender { get; set; }

        [Required]
        [MaxLength(30)]
        public string Email { get; set; }
        
        public int? AddressId { get; set; }

        [Required]
        [MaxLength(30)]
        public string Password { get; set; }

        [ForeignKey("AddressId")]
        public virtual Address Address { get; set; }//fot 1-1

        public List<FeedbackRating> Feedbacks = new List<FeedbackRating>();
        //public List<Product> Products = new List<Product>();
    }
}
