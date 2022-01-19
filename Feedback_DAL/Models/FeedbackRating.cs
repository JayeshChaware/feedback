using Feedback_DAL.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Feedback_DAL.Models
{
    public class FeedbackRating
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        public int ProductId { get; set; }
        [Required]
        public StarRating Rating { get; set; }
        [MaxLength(500)]
        public string Comment { get; set; }
        
        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        [ForeignKey("ProductId")]
        //[InverseProperty("FeedbackRating")]
        public virtual Product Product { get; set; }

        
    }
}
