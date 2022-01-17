using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Feedback_DAL.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
     
        [Required]
        [MaxLength(500)]
        public string Description { get; set; }
        public List<FeedbackRating> Feedbacks = new List<FeedbackRating>();
    }
}
