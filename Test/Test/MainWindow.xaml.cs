using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Test
{
    using Models;
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static void CreateDatabase()
        {
            using var db = new QuestionsDbContext();
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
        
            var question = new Question
            {
                Content = "Коя е столицата на България?",
                Answers = new Answers
                {
                    AnswerA = "Москва",
                    AnswerB = "София",
                    AnswerC = "Пловдив",
                    AnswerD = "Варна",
                    RightAnswer = 'B'
                }
            };
            db.Questions.Add(question);
            db.SaveChanges();

        }
        public MainWindow()
        {
            InitializeComponent();
            CreateDatabase();
            
        }
    }
}
