﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Documents;
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
        List<string> questions;
        List<Answers> answers;
        int numQuestions, currQuestion, points = 0, time;

        private void ButtonAction_Click(object sender, RoutedEventArgs e)
        {
            if ((string)buttonAction.Content == "Изход")
            {
                Close();
                return;
            }
            if ((string)buttonAction.Content == "Виж резултата си")
            {
                StreamReader r = new StreamReader("results.txt", Encoding.UTF8);
                richText.Document.Blocks.Clear();
                richText.Visibility = Visibility.Visible;
                richText.Document.Blocks.Add(new Paragraph(new Run(r.ReadToEnd())));
                r.Close();
                labelQuestionNumber.Content = "Резултати: ";
                buttonAction.Content = "Изход";
                return;
            }
            if ((string)buttonAction.Content == "Край на теста")
            {
                timer.Stop();
                labelQuestionsLeft.Content = $"Брой точки: {points.ToString()}";
                labelQuestionNumber.Content = "";
                richText.Visibility = Visibility.Hidden;
                w.Close();
                buttonAction.Content = "Виж резултата си";
                radioA.Visibility = Visibility.Hidden;
                radioB.Visibility = Visibility.Hidden;
                radioC.Visibility = Visibility.Hidden;
                radioD.Visibility = Visibility.Hidden;
                blockInfo.Visibility = Visibility.Hidden;
                return;
            }
            if (!(bool)radioA.IsChecked &&
                !(bool)radioB.IsChecked &&
                !(bool)radioC.IsChecked &&
                !(bool)radioD.IsChecked)
            {
                _ = MessageBox.Show("Маркирай отговор!", "Грешка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            string ans = "";
            if ((bool)radioA.IsChecked) { ans = "A"; }
            if ((bool)radioB.IsChecked) { ans = "B"; }
            if ((bool)radioC.IsChecked) { ans = "C"; }
            if ((bool)radioD.IsChecked) { ans = "D"; }
            if ((bool)radioA.IsChecked && answers[currQuestion].RightAnswer == "A") { points++; }
            if ((bool)radioB.IsChecked && answers[currQuestion].RightAnswer == "B") { points++; }
            if ((bool)radioC.IsChecked && answers[currQuestion].RightAnswer == "C") { points++; }
            if ((bool)radioD.IsChecked && answers[currQuestion].RightAnswer == "D") { points++; }
            w.WriteLine($"{currQuestion + 1}\t\t{ans}\t\t\t{answers[currQuestion].RightAnswer}");
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
            labelQuestionNumber.Content = "Въпрос " + (currQuestion + 1).ToString();
            labelQuestionsLeft.Content = "Оставащи въпроси: " + (numQuestions - currQuestion - 1).ToString();
            radioA.Content = answers[currQuestion].AnswerA;
            radioB.Content = answers[currQuestion].AnswerB;
            radioC.Content = answers[currQuestion].AnswerC;
            radioD.Content = answers[currQuestion].AnswerD;
            radioA.IsChecked = false;
            radioB.IsChecked = false;
            radioC.IsChecked = false;
            radioD.IsChecked = false;
        }

        StreamWriter w = new StreamWriter("results.txt");
        public MainWindow()
        {
            InitializeComponent();
            using (var db = new QuestionsDbContext())
            {
                _ = db.Database.EnsureCreated();
                questions = db.Questions.Select(q => q.Content).ToList();
                answers = db.Questions.Select(q => q.Answers).ToList();
            }
            numQuestions = questions.Count;
            timer.Tick += new EventHandler(this.timer1_Tick);
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();
            currQuestion = 0;
            richText.Document.Blocks.Clear();
            richText.Document.Blocks.Add(new Paragraph(new Run(questions[currQuestion])));
            radioA.Content = answers[currQuestion].AnswerA;
            radioB.Content = answers[currQuestion].AnswerB;
            radioC.Content = answers[currQuestion].AnswerC;
            radioD.Content = answers[currQuestion].AnswerD;
            labelQuestionsLeft.Content = "Оставащи въпроси: " + (numQuestions - currQuestion -1).ToString();
            w.WriteLine("№\tТвоят отговор\t\tВерен отговор");
            labelQuestionNumber.Content = "Въпрос " + (currQuestion + 1).ToString();
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
