using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Feedback_DAL.Models
{
    public class Product
    {
        public Product()
        {
            FeedbackRatings = new HashSet<FeedbackRating>();
        }
        [Key]
        public int Id { get; set; }
      
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
     
        [Required]
        [MaxLength(500)]
        public string Description { get; set; }

        public virtual User User { get; set; }
        [InverseProperty("Product")]
        public virtual ICollection<FeedbackRating> FeedbackRatings { get; set; }
    }
}
