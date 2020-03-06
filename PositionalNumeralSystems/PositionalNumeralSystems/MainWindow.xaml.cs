using System;
using System.Windows;
using static Utils.Functions;

namespace PositionalNumeralSystems
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

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BtnFromDec_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BoxHex.Text = FromDec(int.Parse(BoxDec.Text), 16);
                //BoxHex.Text = Convert.ToString(int.Parse(BoxDec.Text), 16);
                BoxBin.Text = FromDec(int.Parse(BoxDec.Text), 2);
                BoxCustom.Text = FromDec(int.Parse(BoxDec.Text), int.Parse(BoxBase.Text));
            }
            catch (FormatException)
            {
                _ = MessageBox.Show("Некоректен формат на данните", "Грешка", MessageBoxButton.OK, MessageBoxImage.Error);
                BoxDec.SelectAll();
                BoxDec.Focus();
            }
        }

        private void BtnFromBin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BoxDec.Text = ToDec(BoxBin.Text, 2).ToString();
                BoxHex.Text = FromDec(int.Parse(BoxDec.Text), 16);
                BoxCustom.Text = FromDec(int.Parse(BoxDec.Text), int.Parse(BoxBase.Text));
            }
            catch(FormatException)
            {
                _ = MessageBox.Show("Некоректен формат на данните", "Грешка", MessageBoxButton.OK, MessageBoxImage.Error);
                BoxBin.SelectAll();
                BoxBin.Focus();
            }
            
        }

        private void BtnFromHex_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BoxDec.Text = ToDec(BoxHex.Text, 16).ToString();
                BoxBin.Text = FromDec(int.Parse(BoxDec.Text), 2);
                BoxCustom.Text = FromDec(int.Parse(BoxDec.Text), int.Parse(BoxBase.Text));
            }
            catch(FormatException)
            {
                _ = MessageBox.Show("Некоректен формат на данните", "Грешка", MessageBoxButton.OK, MessageBoxImage.Error);
                BoxHex.SelectAll();
                BoxHex.Focus();
            }
            
        }

        private void BtnFromCustomBase_Click(object sender, RoutedEventArgs e)
        {
            int b;  // основа на бройната с-ма
            try
            {
                b = int.Parse(BoxBase.Text);
            }
            catch(FormatException)
            {
                _ = MessageBox.Show("Некоректно въведена основа", "Грешка!",MessageBoxButton.OK, MessageBoxImage.Error);
                BoxBase.SelectAll();
                BoxBase.Focus();
                return;
            }
            try
            {
                BoxDec.Text = ToDec(BoxCustom.Text, int.Parse(BoxBase.Text)).ToString();
                BoxBin.Text = FromDec(int.Parse(BoxDec.Text), 2);
                BoxHex.Text = FromDec(int.Parse(BoxDec.Text), 16);
            }
            catch(FormatException)
            {
                _ = MessageBox.Show("Некоректен формат на данните", "Грешка", MessageBoxButton.OK, MessageBoxImage.Error);
                BoxCustom.SelectAll();
                BoxCustom.Focus();
            }
            
        }

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            BoxDec.Text = "0";
            BoxBin.Text = "0";
            BoxHex.Text = "0";
            BoxCustom.Text = "0";
            BoxBase.Text = "8";
        }
    }
}
