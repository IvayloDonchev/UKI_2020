using System;
using System.Windows;

namespace Guess_the_Number
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static int compNum = 0, cnt = 0;
        
        private void BtnStart_Click(object sender, RoutedEventArgs e)
        {
            Random r = new Random();
            compNum = r.Next(1, 101);
            BtnTry.IsEnabled = true;
            BtnStart.IsEnabled = false;
            cnt = 0;
            BoxNumber.Clear();
            BoxAnswer.Clear();
            BoxCount.Clear();
        }

        private void BtnTry_Click(object sender, RoutedEventArgs e)
        {
            int myNumber=0;
            try
            {
                myNumber = Convert.ToInt32(BoxNumber.Text);
            }
            catch(FormatException ex)
            {
                _ = MessageBox.Show(ex.Message, "Грешка!", MessageBoxButton.OK, MessageBoxImage.Error);
                BoxNumber.Focus();
                BoxNumber.SelectAll();
                return;
            }
            ++cnt;
            BoxCount.Text = cnt.ToString();
            BoxNumber.Focus();
            BoxNumber.SelectAll();
            if (myNumber < compNum)
                BoxAnswer.Text = "Нагоре";
            if (myNumber > compNum)
                BoxAnswer.Text = "Надолу";
            if(myNumber == compNum)
            {
                BoxAnswer.Text = "Позна!";
                BtnTry.IsEnabled = false;
                BtnStart.IsEnabled = true;
            }
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        public MainWindow()
        {
            InitializeComponent();
            BtnTry.IsEnabled = false;
        }
    }
}
