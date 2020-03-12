﻿using System;
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

        private void ButtonAction_Click(object sender, RoutedEventArgs e)
        {
            if ((string)buttonAction.Content == "Виж резултата си")
            {
                buttonAction.IsEnabled = false;
                StreamReader r = new StreamReader("results.txt", Encoding.GetEncoding("windows-1251"));
                richText.Document.Blocks.Clear();
                richText.Document.Blocks.Add(new Paragraph(new Run(r.ReadToEnd())));
                r.Close();
                return;
            }
            if ((string)buttonAction.Content == "Край на теста")
            {
                timer.Stop();
                labelQuestionsLeft.Content = $"Брой точки: {points.ToString()}";
                w.Close();
                buttonAction.Content = "Виж резултата си";
                return;
            }
            if (!(bool)radioA.IsChecked &&
                !(bool)radioB.IsChecked &&
                !(bool)radioC.IsChecked &&
                !(bool)radioD.IsChecked)
            {
                MessageBox.Show("Маркирай отговор!");
                return;
            }
            string ans = "";
            if ((bool)radioA.IsChecked) { ans = "A"; }
            if ((bool)radioB.IsChecked) { ans = "B"; }
            if ((bool)radioC.IsChecked) { ans = "C"; }
            if ((bool)radioD.IsChecked) { ans = "D"; }
            if ((bool)radioA.IsChecked && answers[currQuestion] == "A") { points++; }
            if ((bool)radioB.IsChecked && answers[currQuestion] == "B") { points++; }
            if ((bool)radioC.IsChecked && answers[currQuestion] == "C") { points++; }
            if ((bool)radioD.IsChecked && answers[currQuestion] == "D") { points++; }
            w.WriteLine($"{currQuestion}\t{ans}\t\t\t{answers[currQuestion]}");
            if (currQuestion == numQuestions - 1)
            {
                buttonAction.Content = "Край на теста";
                radioA.IsEnabled = false;
                radioB.IsEnabled = false;
                radioC.IsEnabled = false;
                radioD.IsEnabled = false;
                return;
            }
            currQuestion++;
            richText.Document.Blocks.Clear();
            richText.Document.Blocks.Add(new Paragraph(new Run(questions[currQuestion])));
            labelQuestionNumber.Content = "Въпрос " + currQuestion.ToString();
            labelQuestionsLeft.Content = "Оставащи въпроси: " + (numQuestions - currQuestion).ToString();
            radioA.IsChecked = false;
            radioB.IsChecked = false;
            radioC.IsChecked = false;
            radioD.IsChecked = false;
        }

        StreamWriter w = new StreamWriter("results.txt");
        public MainWindow()
        {
            InitializeComponent();
            using var db = new QuestionsDbContext();
            db.Database.EnsureCreated();
            questions = db.Questions.Select(q => q.Content + "\n a) " +
                                                 q.Answers.AnswerA + "\n б) " +
                                                 q.Answers.AnswerB + "\n в) " +
                                                 q.Answers.AnswerC + "\n г) " +
                                                 q.Answers.AnswerD).ToList();
            answers = db.Questions.Select(q => q.Answers.RightAnswer).ToList();
            numQuestions = questions.Count;

            timer.Tick += new EventHandler(this.timer1_Tick);
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();
            currQuestion = 0;
            richText.Document.Blocks.Clear();
            richText.Document.Blocks.Add(new Paragraph(new Run(questions[currQuestion])));
            labelQuestionsLeft.Content = "Оставащи въпроси: " + (numQuestions - currQuestion).ToString();
            w.WriteLine("№\tТвоят отговор\tВерен отговор");
            labelQuestionNumber.Content = "Въпрос " + currQuestion;
            time = numQuestions * 10; //времето в секунди
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            time--;
            labelTimeLeft.Content = "Оставащо време: " + time / 60 + " мин. " + time % 60 + " сек.";
            if (time == 0)
            {
                timer.Stop();
                buttonAction.Content = "Край на теста";
                radioA.IsEnabled = false;
                radioB.IsEnabled = false;
                radioC.IsEnabled = false;
                radioD.IsEnabled = false;
            }
        }
    }
}
