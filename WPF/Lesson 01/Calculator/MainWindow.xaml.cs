using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Calculator
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool isOperation = false, invalidOperation = false;
        private double oldNumber = 0, memoryNumber = 0;
        private int operationNumber = -1;

        private enum MathOperation { ADDITION, SUBTRACTION, MULTIPLICATION, DIVISION, REMAINDER_DIVISION }

        public string Calculate(double value)
        {
            string result = value.ToString();
            isOperation = true;
            switch (operationNumber)
            {
                case (int)MathOperation.ADDITION:
                    result = (oldNumber + value).ToString();
                    break;
                case (int)MathOperation.SUBTRACTION:
                    result = (oldNumber - value).ToString();
                    break;
                case (int)MathOperation.MULTIPLICATION:
                    result = (oldNumber * value).ToString();
                    break;
                case (int)MathOperation.DIVISION:
                    if (value != 0)
                        result = (oldNumber / value).ToString();
                    else
                    {
                        result = "Деление на нуль запрещено!";
                        invalidOperation = true;
                    }
                    break;
                case (int)MathOperation.REMAINDER_DIVISION:
                    if (value != 0)
                        result = (oldNumber % value).ToString();
                    else
                    {
                        result = "Деление на нуль запрещено!";
                        invalidOperation = true;
                    }
                    break;
            }
            return result;
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MCButton_Click(object sender, RoutedEventArgs e)
        {
            if (!invalidOperation)
                memoryNumber = 0;
        }

        private void MRButton_Click(object sender, RoutedEventArgs e)
        {
            if (!invalidOperation)
                resultView.Text = memoryNumber.ToString();
        }

        private void MSButton_Click(object sender, RoutedEventArgs e)
        {
            if (!invalidOperation)
                memoryNumber = Convert.ToDouble(resultView.Text);
        }

        private void MPlusButton_Click(object sender, RoutedEventArgs e)
        {
            if (!invalidOperation)
                memoryNumber += Convert.ToDouble(resultView.Text);
        }

        private void MMinusButton_Click(object sender, RoutedEventArgs e)
        {
            if (!invalidOperation)
                memoryNumber -= Convert.ToDouble(resultView.Text);
        }

        private void BackspaceButton_Click(object sender, RoutedEventArgs e)
        {
            if (!invalidOperation)
                resultView.Text = resultView.Text.Length > 1? resultView.Text.Remove(resultView.Text.Length - 1, 1): "0";
        }

        private void CEButton_Click(object sender, RoutedEventArgs e)
        {
            if (!invalidOperation)
                resultView.Text = "0";
            else
                CButton_Click(sender, e);
        }

        private void CButton_Click(object sender, RoutedEventArgs e)
        {
            oldNumber = 0;
            memoryNumber = 0;
            resultView.Text = oldNumber.ToString();
            isOperation = false;
            operationNumber = -1;
            invalidOperation = false;
        }

        private void PowButton_Click(object sender, RoutedEventArgs e)
        {
            if (!invalidOperation)
                resultView.Text = (Math.Pow(Convert.ToDouble(resultView.Text), 2)).ToString();
        }

        private void SqrtButton_Click(object sender, RoutedEventArgs e)
        {
            if (!invalidOperation)
                resultView.Text = (Math.Sqrt(Convert.ToDouble(resultView.Text))).ToString();
        }

        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            resultView.Text = resultView.Text == "0" || isOperation? ((Button)e.OriginalSource).Content.ToString() : resultView.Text + ((Button)e.OriginalSource).Content;
            isOperation = false;
            invalidOperation = false;
        }

        private void OneFractionNumberButton_Click(object sender, RoutedEventArgs e)
        {
            if (!invalidOperation)
            {
                if (Convert.ToDouble(resultView.Text) != 0)
                    resultView.Text = (1 / Convert.ToDouble(resultView.Text)).ToString();
                else
                {
                    resultView.Text = "Деление на нуль запрещено!";
                    oldNumber = 0;
                    isOperation = true;
                    invalidOperation = true;
                }
            }
        }

        private void DivisionRemainderButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                resultView.Text = Calculate(Convert.ToDouble(resultView.Text));
                oldNumber = Convert.ToDouble(resultView.Text);
                operationNumber = (int)MathOperation.REMAINDER_DIVISION;
            }
            catch (Exception)
            {
                oldNumber = 0;
                operationNumber = -1;
            }
        }

        private void DivisionButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                resultView.Text = Calculate(Convert.ToDouble(resultView.Text));
                oldNumber = Convert.ToDouble(resultView.Text);
                operationNumber = (int)MathOperation.DIVISION;
            }
            catch (Exception)
            {
                oldNumber = 0;
                operationNumber = -1;
            }
        }

        private void MultiplicationButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                resultView.Text = Calculate(Convert.ToDouble(resultView.Text));
                oldNumber = Convert.ToDouble(resultView.Text);
                operationNumber = (int)MathOperation.MULTIPLICATION;
            }
            catch (Exception)
            {
                oldNumber = 0;
                operationNumber = -1;
            }
        }

        private void MinusButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                resultView.Text = Calculate(Convert.ToDouble(resultView.Text));
                oldNumber = Convert.ToDouble(resultView.Text);
                operationNumber = (int)MathOperation.SUBTRACTION;
            }
            catch (Exception)
            {
                oldNumber = 0;
                operationNumber = -1;
            }
        }

        private void ResultButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                resultView.Text = Calculate(Convert.ToDouble(resultView.Text));
                oldNumber = Convert.ToDouble(resultView.Text);
                operationNumber = -1;
            }
            catch (Exception)
            {
                oldNumber = 0;
                operationNumber = -1;
            }
        }

        private void CommaButton_Click(object sender, RoutedEventArgs e)
        {
            if (!resultView.Text.Contains(",") && !invalidOperation)
                resultView.Text += ",";
        }

        private void ChangeSignButton_Click(object sender, RoutedEventArgs e)
        {
            if (!invalidOperation)
                resultView.Text = (-Convert.ToDouble(resultView.Text)).ToString();
        }

        private void PlusButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                resultView.Text = Calculate(Convert.ToDouble(resultView.Text));
                oldNumber = Convert.ToDouble(resultView.Text);
                operationNumber = (int)MathOperation.ADDITION;
            }
            catch (Exception)
            {
                oldNumber = 0;
                operationNumber = -1;
            }
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            if ((e.Key >= Key.D0 && e.Key <= Key.D9) || (e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9))
            {
                if (e.Key == Key.D8 && (e.KeyboardDevice.Modifiers & ModifierKeys.Shift) == ModifierKeys.Shift)
                    MultiplicationButton_Click(sender, e);
                else
                {
                    if (e.Key == Key.D5 && (e.KeyboardDevice.Modifiers & ModifierKeys.Shift) == ModifierKeys.Shift)
                        DivisionRemainderButton_Click(sender, e);
                    else
                    {
                        resultView.Text = resultView.Text == "0" || isOperation ? e.Key.ToString()[e.Key.ToString().Length - 1].ToString() : resultView.Text + e.Key.ToString()[e.Key.ToString().Length - 1];
                        isOperation = false;
                        invalidOperation = false;
                    }
                }
            }
            switch (e.Key)
            {
                case Key.Back:
                    BackspaceButton_Click(sender, e);
                    break;
                case Key.Delete:
                    CEButton_Click(sender, e);
                    break;
                case Key.Escape:
                    CButton_Click(sender, e);
                    break;
                case Key.OemQuestion:
                    if ((e.KeyboardDevice.Modifiers & ModifierKeys.Shift) == ModifierKeys.Shift)
                        DivisionButton_Click(sender, e);
                    break;
                case Key.Divide:
                    DivisionButton_Click(sender, e);
                    break;
                case Key.Multiply:
                    MultiplicationButton_Click(sender, e);
                    break;
                case Key.OemMinus:
                    MinusButton_Click(sender, e);
                    break;
                case Key.Subtract:
                    MinusButton_Click(sender, e);
                    break;
                case Key.OemPlus:
                    if ((e.KeyboardDevice.Modifiers & ModifierKeys.Shift) == ModifierKeys.Shift)
                        PlusButton_Click(sender, e);
                    else
                        ResultButton_Click(sender, e);
                    break;
                case Key.Return:
                    ResultButton_Click(sender, e);
                    break;
                case Key.OemComma:
                    CommaButton_Click(sender, e);
                    break;
                case Key.Add:
                    PlusButton_Click(sender, e);
                    break;
            }
        }
    }
}