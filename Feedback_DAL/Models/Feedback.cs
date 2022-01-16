using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Feedback_DAL.Models
{
    public class Feedback
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public Enum.StarRating Rating { get; set; }
        public string Comment { get; set; }

    }
}
