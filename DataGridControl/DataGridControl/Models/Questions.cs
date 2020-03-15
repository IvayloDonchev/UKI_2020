namespace DataGridControl.Models
{
    public partial class Questions
    {
        public int Id { get; set; }
        public string Content { get; set; }

        public virtual Answers Answers { get; set; }
    }
}
