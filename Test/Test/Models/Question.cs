namespace Test.Models
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
