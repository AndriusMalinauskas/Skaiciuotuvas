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

namespace Skaiciuotuvas
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public double PirmasDemuo { get; set; }
        public double AntrasDemuo { get; set; }
        public double Rezultatas { get; set; }
        public string MathAction { get; set; }
        public string Input { get; set; }
        public string CountingIput { get; set; }
        public List<string> Counting { get; set; } = new List<string>();

        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void Button0_Click(object sender, RoutedEventArgs e)
        {
            ValueButtons('0');
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            ValueButtons('1');
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            ValueButtons('2');;
        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            ValueButtons('3');
        }

        private void Button4_Click(object sender, RoutedEventArgs e)
        {
            ValueButtons('4');
        }

        private void Button5_Click(object sender, RoutedEventArgs e)
        {
            ValueButtons('5');
        }

        private void Button6_Click(object sender, RoutedEventArgs e)
        {
            ValueButtons('6');
        }

        private void Button7_Click(object sender, RoutedEventArgs e)
        {
            ValueButtons('7');
        }

        private void Button8_Click(object sender, RoutedEventArgs e)
        {
            ValueButtons('8');
        }

        private void Button9_Click(object sender, RoutedEventArgs e)
        {
            ValueButtons('9');
        }

        private void ButtonComma_Click(object sender, RoutedEventArgs e)
        {
            if (!Screen.Text.Contains("."))
            {
                ValueButtons('.');
            }
            
        }

        private void PlusButton_Click(object sender, RoutedEventArgs e)
        {
            ActionButton("+");
        }

        private void MinusButton_Click(object sender, RoutedEventArgs e)
        {
            ActionButton("-"); ;
        }

        private void MultiplyButton_Click(object sender, RoutedEventArgs e)
        {
            ActionButton("*");
        }

        private void DevideButton_Click(object sender, RoutedEventArgs e)
        {
            ActionButton("/");
        }
  
        private void EqualButton_Click(object sender, RoutedEventArgs e)
        {
            if (Screen.Text != "" && PirmasDemuo != null)
            {
                CountingIput = Input;
                CountingIput += Screen.Text;
                AntrasDemuo = double.Parse(Screen.Text);
                switch (MathAction)
                {
                    case "+":
                        Rezultatas = PirmasDemuo + AntrasDemuo;
                        Screen.Text = $"{Rezultatas}";
                        PirmasDemuo = Rezultatas;
                        break;
                    case "-":
                        Rezultatas = PirmasDemuo - AntrasDemuo;
                        Screen.Text = $"{Rezultatas}";
                        PirmasDemuo = Rezultatas;
                        break;
                    case "*":
                        Rezultatas = PirmasDemuo * AntrasDemuo;
                        Screen.Text = $"{Rezultatas}";
                        PirmasDemuo = Rezultatas;
                        break;
                    case "/":
                        Rezultatas = PirmasDemuo / AntrasDemuo;
                        Screen.Text = $"{Rezultatas}";
                        PirmasDemuo = Rezultatas;
                        break;
                    default:
                        break;

                }              
                Input += '=';
                Input += $"{Rezultatas}";
                History.Text = Input;
                Screen.Text = $"{Rezultatas}";
                PirmasDemuo = Rezultatas;
                MathAction = null;
                Input = $" {History.Text} \n {Rezultatas}";
            }
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            PirmasDemuo = 0;
            AntrasDemuo = 0;
            Screen.Text = "";
            MathAction = "";
            Input = $" {History.Text} \n";

        }
       
        private void ActionButton(string mathaction)
        {
            if (Screen.Text != "")
            {
                if (Input.Last() == '+' || Input.Last() == '-' || Input.Last() == '*' || Input.Last() == '/')
                {
                    Input = Input.TrimEnd(Input.Last());
                    Input += mathaction;
                    History.Text = Input;
                    MathAction = $"{mathaction}";                  
                }
                else
                {
                    Input += $"{mathaction}";
                    PirmasDemuo = double.Parse(Screen.Text);
                    MathAction = $"{mathaction}";
                    History.Text = Input;
                }
               
            }
           
        }
       
        private void ValueButtons(char numberButton)
        {
            if (Screen.Text == "")
            {
                if (Screen.Text == "" && numberButton != '.')
                {
                    Screen.Text = $"{Screen.Text}{numberButton}";
                    Input += numberButton;
                }
                else
                {
                    Screen.Text = $"0.";
                    Input += "0.";
                }
            }
            else
            {
                if (Input.Last() == '+' || Input.Last() == '-' || Input.Last() == '*' || Input.Last() == '/')
                {
                   PirmasDemuo = double.Parse(Screen.Text);
                    Screen.Text = "";
                    Screen.Text = $"{numberButton}";
                    Input += numberButton;
                }
                else
                {
                    if (Screen.Text == "0" && numberButton != '.')
                    {
                        Screen.Text = $"{numberButton}";
                        Input = Input.TrimEnd(Input.Last());
                        Input += numberButton;
                        History.Text = Input;
                    }
                    else
                    {
                        Screen.Text = $"{Screen.Text}{numberButton}";
                        Input += numberButton;
                    }  
                }        
            }
            History.Text = Input;
        }      
    }
}
