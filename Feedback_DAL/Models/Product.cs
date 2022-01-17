using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        public virtual User User { get; set; }
    }
}
