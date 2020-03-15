﻿using DataGridControl.Data.Models;
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

namespace DataGridControl
{
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