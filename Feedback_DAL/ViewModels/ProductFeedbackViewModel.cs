using Feedback_DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Feedback_DAL.ViewModels
{
    public class ProductFeedbackViewModel
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(500)]
        public string Description { get; set; }
        public IEnumerable<FeedbackRating> ProductFeedback{ get; set; }
    }
}
