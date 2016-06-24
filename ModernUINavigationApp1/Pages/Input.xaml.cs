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

namespace ModernUINavigationApp1.Pages
{
    /// <summary>
    /// Interaction logic for Input.xaml
    /// </summary>
    public partial class Input : UserControl
    {
        public Input()
        {
            InitializeComponent();
        }

        private void InputHandler(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            string c = btn.Content as string;

            if (!string.IsNullOrEmpty(c))
                ExpressionTextBox.Text += c;
            else
                MessageBox.Show("null");
        }

        private void ClearHandler(object sender, RoutedEventArgs e)
        {
            ExpressionTextBox.Text = string.Empty;
        }

        private void BackspaceHandler(object sender, RoutedEventArgs e)
        {
            string text = ExpressionTextBox.Text;
            if (text.Length > 0)
                ExpressionTextBox.Text = text.Substring(0, text.Length - 1);
        }
    }
}
