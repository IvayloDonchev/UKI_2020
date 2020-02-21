using System;
using System.Windows;
using System.Windows.Media;

namespace Quadratic_Equation_Solver
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnClearClick(object sender, RoutedEventArgs e)
        {
            boxA.Text = "";
            boxB.Text = "";
            boxC.Text = "";
            blockX1.Text = "";
            blockX2.Text = "";
        }

        private void btnCalcClick(object sender, RoutedEventArgs e)
        {
            double a, b, c, d;
            if (boxA.Text == "") boxA.Text = "0";
            try
            {
                a = Double.Parse(boxA.Text);
                b = Double.Parse(boxB.Text);
                c = Double.Parse(boxC.Text);
                d = b * b - 4 * a * c;
            }
            catch(System.FormatException ex)
            {
                blockX1.Text = "Некоректно въведени данни!";
                blockX1.Foreground = Brushes.Red;
                blockX2.Text = ex.Message;
                blockX2.Foreground = Brushes.Blue;
                return;
            }
            blockX1.Foreground = Brushes.Black;
            blockX2.Foreground = Brushes.Black;
            if (a == 0.0)       // Линейно уравнение
            {
                double x = -c / b;
                blockX1.Text = $"X = {x}";
                blockX2.Text = "";
            }
            else
            {
                if (d > 0)  // Два корена
                {
                    double x1 = (-b + Math.Sqrt(d)) / (2 * a);
                    double x2 = (-b - Math.Sqrt(d)) / (2 * a);
                    blockX1.Text = $"X1 = {x1}";
                    blockX2.Text = $"X2 = {x2}";
                }
                else
                    if (d == 0) // Един корен
                {
                    double x = (-b) / (2 * a);
                    blockX1.Text = $"X = {x}";
                    blockX2.Text = "";
                }
                else          // Няма реални корени
                {
                    blockX1.Text = "Уравнението няма реални корени";
                    blockX2.Text = "";
                }
            }
        }
    }
}
