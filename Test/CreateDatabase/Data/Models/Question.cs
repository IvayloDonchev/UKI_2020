using System;
using System.Collections.Generic;
using System.Text;

namespace CreateDatabase.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    public class Question
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(500)]
        public string Content { get; set; }
        public Answers Answers { get; set; }
    }
}
