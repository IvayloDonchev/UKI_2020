namespace DataGridControl.Models
{
    public partial class Answers
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public string AnswerA { get; set; }
        public string AnswerB { get; set; }
        public string AnswerC { get; set; }
        public string AnswerD { get; set; }
        public string RightAnswer { get; set; }

        public virtual Questions Question { get; set; }
    }
}
