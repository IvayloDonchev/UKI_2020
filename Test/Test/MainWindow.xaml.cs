using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Threading;

namespace Test
{
    using CreateDatabase.Data;
    using CreateDatabase.Data.Models;
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        List<string> answers;
        List<string> questions;
        int numQuestions, currQuestion, points = 0, time;
       // StreamWriter w = new StreamWriter("results.txt", true, Encoding.GetEncoding("windows-1251"));
        public MainWindow()
        {
            InitializeComponent();
            using var db = new QuestionsDbContext();
            db.Database.EnsureCreated();
            questions = db.Questions.Select(q => q.Content).ToList();
            answers = db.Questions.Select(q => q.Answers.RightAnswer).ToList();
            numQuestions = questions.Count;
        }
    }
}
