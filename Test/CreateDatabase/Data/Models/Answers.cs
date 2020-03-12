namespace CreateDatabase.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    public class Answers
    {
        public int Id { get; set; }
        [Required]
        public int QuestionId { get; set; }
        public Question Question { get; set; }
        public string AnswerA { get; set; }
        public string AnswerB { get; set; }
        public string AnswerC { get; set; }
        public string AnswerD { get; set; }
        public string RightAnswer { get; set; }
    }
}
