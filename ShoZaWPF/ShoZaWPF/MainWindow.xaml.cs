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

namespace ShoZaWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool check = true;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (check == true)
                button16.IsEnabled = true;
            textBox1.Text += (sender as Button).Content.ToString();
            button2.IsEnabled = true;
            button3.IsEnabled = true;
            button7.IsEnabled = true;
            button11.IsEnabled = true;
            button15.IsEnabled = true;
            button17.IsEnabled = true;
            button18.IsEnabled = true;
            if (textBox1.Text.EndsWith("."))
            {
                button3.IsEnabled = false;
                button7.IsEnabled = false;
                button11.IsEnabled = false;
                button15.IsEnabled = false;
                button16.IsEnabled = false;
                button18.IsEnabled = false;
                check = false;
            }
            else if (textBox1.Text.EndsWith("+"))
            {
                button3.IsEnabled = false;
                button7.IsEnabled = false;
                button11.IsEnabled = false;
                button15.IsEnabled = false;
                button16.IsEnabled = false;
                button18.IsEnabled = false;
                check = true;
            }
            else if (textBox1.Text.EndsWith("-"))
            {
                button3.IsEnabled = false;
                button7.IsEnabled = false;
                button11.IsEnabled = false;
                button15.IsEnabled = false;
                button16.IsEnabled = false;
                button18.IsEnabled = false;
                check = true;
            }
            else if (textBox1.Text.EndsWith("*"))
            {
                button3.IsEnabled = false;
                button7.IsEnabled = false;
                button11.IsEnabled = false;
                button15.IsEnabled = false;
                button16.IsEnabled = false;
                button18.IsEnabled = false;
                check = true;
            }
            else if (textBox1.Text.EndsWith("/"))
            {
                button3.IsEnabled = false;
                button7.IsEnabled = false;
                button11.IsEnabled = false;
                button15.IsEnabled = false;
                button16.IsEnabled = false;
                button18.IsEnabled = false;
                check = true;
            }
        }

        private void button18_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text = textBox1.Text;
            var compute = new System.Data.DataTable().Compute(textBox1.Text, null);
            textBox1.Text = compute.ToString();
            textBox1.Text = textBox1.Text.Replace(',', '.');
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            if (textBox1.Text.EndsWith("."))
            {
                button3.IsEnabled = true;
                button7.IsEnabled = true;
                button11.IsEnabled = true;
                button15.IsEnabled = true;
                button16.IsEnabled = true;
                button18.IsEnabled = true;
            }
            else if (textBox1.Text.EndsWith("+"))
            {
                button3.IsEnabled = true;
                button7.IsEnabled = true;
                button11.IsEnabled = true;
                button15.IsEnabled = true;
                button18.IsEnabled = true;
            }
            else if (textBox1.Text.EndsWith("-"))
            {
                button3.IsEnabled = true;
                button7.IsEnabled = true;
                button11.IsEnabled = true;
                button15.IsEnabled = true;
                button18.IsEnabled = true;
            }
            else if (textBox1.Text.EndsWith("*"))
            {
                button3.IsEnabled = true;
                button7.IsEnabled = true;
                button11.IsEnabled = true;
                button15.IsEnabled = true;
                button18.IsEnabled = true;
            }
            else if (textBox1.Text.EndsWith("/"))
            {
                button3.IsEnabled = true;
                button7.IsEnabled = true;
                button11.IsEnabled = true;
                button15.IsEnabled = true;
                button18.IsEnabled = true;
            }
            if (textBox1.Text.Length == 1)
            {
                textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);
                button2.IsEnabled = false;
                button3.IsEnabled = false;
                button7.IsEnabled = false;
                button11.IsEnabled = false;
                button15.IsEnabled = false;
                button16.IsEnabled = false;
                button17.IsEnabled = false;
                button18.IsEnabled = false;
            }
            else if (textBox1.Text.Length != 0)
                textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);                
        }

        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            textBox1.Text = "";
            button2.IsEnabled = false;
            button3.IsEnabled = false;
            button7.IsEnabled = false;
            button11.IsEnabled = false;
            button15.IsEnabled = false;
            button16.IsEnabled = false;
            button17.IsEnabled = false;
            button18.IsEnabled = false;
            check = true;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            textBox1.Text = "";
            textBox.Text = "";
            button2.IsEnabled = false;
            button3.IsEnabled = false;
            button7.IsEnabled = false;
            button11.IsEnabled = false;
            button15.IsEnabled = false;
            button16.IsEnabled = false;
            button17.IsEnabled = false;
            button18.IsEnabled = false;
            check = true;
        }
    }
}
