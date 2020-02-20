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
            try
            {
                a = Double.Parse(boxA.Text);
                b = Double.Parse(boxB.Text);
                c = Double.Parse(boxC.Text);
                d = b * b - 4 * a * c;
            }
            catch(System.FormatException)
            {
                blockX1.Text = "Некоректно въведени данни!";
                blockX2.Text = "";
                return;
            }
            if (a == 0.0)
            {
                double x = -c / b;
                blockX1.Text = $"X = {x}";
                blockX2.Text = "";
            }
            else
            {
                if (d > 0)
                {
                    double x1 = (-b + Math.Sqrt(d)) / (2 * a);
                    double x2 = (-b - Math.Sqrt(d)) / (2 * a);
                    blockX1.Text = $"X1 = {x1}";
                    blockX2.Text = $"X2 = {x2}";
                }
                else
                    if (d == 0)
                {
                    double x = (-b) / (2 * a);
                    blockX1.Text = $"X = {x}";
                    blockX2.Text = "";
                }
                else
                {
                    blockX1.Text = "Уравнението няма реални корени";
                    blockX2.Text = "";
                }
            }
        }
    }
}
