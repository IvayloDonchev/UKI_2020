namespace DataGridControl
{
    using DataGridControl.Models;
    using System.Linq;
    using System.Windows;
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            using var db = new QuestionsForTestContext();
            MainDataGrid.ItemsSource =
                db.Questions.Select(q => 
                new
                {
                    q.Id,
                    q.Content,
                    q.Answers.AnswerA,
                    q.Answers.AnswerB,
                    q.Answers.AnswerC,
                    q.Answers.AnswerD
                })
                .ToList();
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
