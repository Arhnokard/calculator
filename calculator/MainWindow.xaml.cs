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

namespace calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string number1 = "";
        string number2 = "";
        string operation = "";
        bool finishCalc = false;
        bool sign = false;
        bool comma = false;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_numbers_Click(object sender, RoutedEventArgs e)
        {
            Button button =(Button)sender;
            
            if (operation == "")
            {
                if (finishCalc)
                {
                    number1 = button.Content.ToString();
                    finishCalc = false;
                    display.Text = number1;
                }
                else
                {
                    number1 += button.Content.ToString();
                    display.Text = number1;
                }
            }
            else
            {
                
                number2 += button.Content.ToString();
                display.Text = number1 + operation + number2;
            }
        }

        private void Button_addition_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            if (button.Content.ToString() == "x^y")
            {
                operation = "^";
            }
            else 
            {
                operation = button.Content.ToString();
            }
            display.Text = number1 + operation;
            comma = false;
        }

        private void Button_result_Click(object sender, RoutedEventArgs e)
        {
            double result = 0;
            display.Text = display.Text + '=' + "\n";
            if (number2 != "")
            {
                switch (operation)
                {
                    case "+":
                        {
                            result=double.Parse(number1) + double.Parse(number2);
                            break;
                        }
                    case "-": 
                        {
                            result = double.Parse(number1) - double.Parse(number2);
                            break;
                        }
                    case "*":
                        {
                            result = double.Parse(number1) * double.Parse(number2);
                            break;
                        }
                    case "/":
                        {
                            result = double.Parse(number1) / double.Parse(number2);
                            break;
                        }
                    case "^":
                        {
                            result = double.Parse(number1);
                            for (int i = 0; i < int.Parse(number2)-1; i++)
                            {
                                result *= double.Parse(number1);
                            }
                            break;
                        }
                    case "avg":
                        {
                            result = double.Parse(number1) + double.Parse(number2) /2;
                            break;
                        }
                    case "min":
                        {
                            if (double.Parse(number1) < double.Parse(number2)) result = double.Parse(number1);
                            else result = double.Parse(number2);
                            break;
                        }
                    case "max":
                        {
                            if (double.Parse(number1) > double.Parse(number2)) result = double.Parse(number1);
                            else result = double.Parse(number2);
                            break;
                        }


                    default:
                        break;
                }
                display.Text += result.ToString();
                number1 = result.ToString();
                operation = "";
                number2 = "";
                finishCalc = true;
                comma = false;
            }
        }

        private void Button_reset_Click(object sender, RoutedEventArgs e)
        {
            number1 = "";
            number2 = "";
            operation = "";
            display.Text = "";
            bool finishCalc = false;
        }

        private void Button_erase_Click(object sender, RoutedEventArgs e)
        {
            if (operation == "")
            {
                number1 = "";
                display.Text = number1;
            }
            else
            {
                number2 = "";
                display.Text = number1 + operation + number2;
            }
        }

        private void Button_back_Click(object sender, RoutedEventArgs e)
        {
            if (operation == "")
            {
                number1 = number1.Remove(number1.Length-1);
                display.Text = number1;
            }
            else
            {
                number2 = number2.Remove(number2.Length - 1);
                display.Text = number1 + operation + number2;
            }
        }

        private void Button_sign_Click(object sender, RoutedEventArgs e)
        {
            
            if (operation == "")
            {
                if (sign)
                {
                    number1 = number1.Trim('-');
                    display.Text =number1;
                    sign = false;
                }
                else
                {
                    number1 = number1.Insert(0, "-");
                    display.Text = number1;
                    sign = true;
                }
            }
            else
            {
                if (sign)
                {
                    number2 = number2.Trim('-');
                    display.Text = number1 + operation + number2;
                    sign = false;
                }
                else
                {
                    
                    number2 =number2.Insert(0,"-");
                    display.Text = number1 + operation + number2;
                    sign = true;
                } 
            }
        }

        private void Button_comma_Click(object sender, RoutedEventArgs e)
        {
            if (comma==false)
            {
                Button button = (Button)sender;
                if (operation == "")
                {
                    number1 += button.Content.ToString();
                    display.Text = number1;
                    comma = true;
                }
                else if (number2 == "")
                {
                    number2 = "0,";
                    display.Text = number1 + operation + number2;
                    comma = true;
                }
                else
                {
                    number2 += button.Content.ToString();
                    display.Text = number1 + operation + number2;
                    comma = true;
                }
            }
            

        }
    }
}
