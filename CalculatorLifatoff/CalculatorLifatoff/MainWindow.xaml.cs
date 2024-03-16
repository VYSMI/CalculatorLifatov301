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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CalculatorLifatoff
{
    public partial class Calculator : Window
    {
        private double number;
        private char func;
        private bool ifNextNum = true;

        public Calculator()
        {
            InitializeComponent();
        }

        private void windowMoused(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void btnClose2_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Number_Click(object sender, RoutedEventArgs e)
        {
            if (ifNextNum == true)
            {
                resultText.Clear();
                ifNextNum = false;
            }

            Button button = (Button)sender;
            resultText.Text += button.Content.ToString();
        }

        private void Func_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(resultText.Text))
            {
                return;
            }
            Button buttonFunc = (Button)sender;

            number = double.Parse(resultText.Text);
            func = char.Parse(buttonFunc.Content.ToString());
            ifNextNum = true;
        }

        private void buttonEqual_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(resultText.Text))
            {
                return;
            }

            double secondNumber = double.Parse(resultText.Text);
            double result = 0;

            switch (func)
            {
                case '+':
                    result = number + secondNumber;
                    break;
                case '-':
                    result = number - secondNumber;
                    break;
                case '×':
                    result = number * secondNumber;
                    break;
                case '÷':
                    if (secondNumber == 0)
                    {
                        MessageBox.Show("Деление на ноль невозможно!", "Ошибка");
                        return;
                    }
                    else
                    {
                        result = number / secondNumber;
                    }
                    break;
            }
            resultText.Text = result.ToString();
            ifNextNum = true;
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            resultText.Clear();
            ifNextNum = true;
        }
    }

}
