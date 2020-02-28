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

namespace Guess_the_Number
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int compNum = 0, cnt = 0;

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
            catch(FormatException)
            {
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

        public MainWindow()
        {
            InitializeComponent();
            BtnTry.IsEnabled = false;
        }
    }
}
