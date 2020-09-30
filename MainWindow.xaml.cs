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
        public string CountingInput { get; set; }
        public List<string> Counting { get; set; }

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
            ValueButtons('2'); ;
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
                AntrasDemuo = double.Parse(Screen.Text);             
                Counting = Sequence(CountingInput);
                Rezultatas = double.Parse(Rezult(Counting));
                Input += '=';
                Input += $"{Rezultatas}";
                History.Text = Input;
                Input = $" {History.Text} \n {Rezultatas}";
                Screen.Text = $"{Rezultatas}";
                PirmasDemuo = Rezultatas;
                MathAction = null;          
                CountingInput = $"{Rezultatas}";
            }
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            PirmasDemuo = 0;
            AntrasDemuo = 0;
            Screen.Text = "";
            MathAction = "";
            Input = $" {History.Text} \n";
            CountingInput = "";
        }

        private void ActionButton(string mathaction)
        {
            if (Screen.Text != "")
            {
                if (Input.Last() == '+' || Input.Last() == '-' || Input.Last() == '*' || Input.Last() == '/')
                {
                    Input = Input.TrimEnd(Input.Last());
                    Input += mathaction;
                    CountingInput = CountingInput.TrimEnd(CountingInput.Last());
                    CountingInput += mathaction;
                    History.Text = Input;
                    MathAction = $"{mathaction}";
                }
                else
                {
                    Input += $"{mathaction}";
                    CountingInput += $"{mathaction}";
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
                    CountingInput += numberButton;
                }
                else
                {
                    Screen.Text = $"0.";
                    Input += "0.";
                    CountingInput += "0.";
                }
            }
            else
            {
                if (Input.Last() == '+' || Input.Last() == '-' || Input.Last() == '*' || Input.Last() == '/')
                {
                   // PirmasDemuo = double.Parse(Screen.Text);
                    Screen.Text = "";
                    Screen.Text = $"{numberButton}";
                    Input += numberButton;
                    CountingInput += numberButton;
                }
                else
                {
                    if (Screen.Text == "0" && numberButton != '.')
                    {
                        Screen.Text = $"{numberButton}";
                        Input = Input.TrimEnd(Input.Last());
                        CountingInput = CountingInput.TrimEnd(CountingInput.Last());
                        Input += numberButton;
                        CountingInput += numberButton;
                        History.Text = Input;
                    }
                    else
                    {
                        Screen.Text = $"{Screen.Text}{numberButton}";
                        Input += numberButton;
                        CountingInput += numberButton;
                    }
                }
            }
            History.Text = Input;
        }

        private List<string> Sequence(string countingSequence)
        {
            var member = "";
            List<string> Counting = new List<string>();
            foreach (var item in countingSequence)
            {
               
                if (item == '+' || item == '-' || item == '*' || item == '/')
                {
                    Counting.Add(member);
                    Counting.Add($"{ item}");
                    member = "";
                }
                else
                {
                    member += item;
                }
            }       
            Counting.Add(member);
            if (countingSequence[0] == '-')
            {
                Counting.Remove(Counting[0]);
                Counting.Remove(Counting[0]);
                Counting[0] = $"-{Counting[0]}";
            }
            return Counting;

        }

        private string Rezult(List<string> counting)
        {
            while (counting.Count > 1)
            {
                if (counting.Contains("*"))
                {
                    int index = counting.IndexOf(counting.First(a => a.Contains("*")));
                    var rezult = (double.Parse(counting[index - 1]) * double.Parse(counting[index + 1]));
                    counting[index - 1] = $"{rezult}";
                    counting.RemoveRange(index, 2);
                }
                else
                {
                    if (counting.Contains("/"))
                    {
                        int index = counting.IndexOf(counting.First(a => a.Contains("/")));
                        var rezult = (double.Parse(counting[index - 1]) / double.Parse(counting[index + 1]));
                        counting[index - 1] = $"{rezult}";
                        counting.RemoveRange(index, 2);
                    }
                    else
                    {
                        if (counting.Contains("+"))
                        {
                            int index = counting.IndexOf(counting.First(a => a.Contains("+")));
                            var rezult = (double.Parse(counting[index - 1]) + double.Parse(counting[index + 1]));
                            counting[index - 1] = $"{rezult}";
                            counting.RemoveRange(index, 2);
                        }
                        else
                        {
                            if (counting.Contains("-"))
                            {
                                int index = counting.IndexOf(counting.First(a => a == "-"));
                                var rezult = (double.Parse(counting[index - 1]) - double.Parse(counting[index + 1]));
                                counting[index - 1] = $"{rezult}";
                                counting.RemoveRange(index, 2);
                            }
                        }
                    }
                }
            }
            var finalRezult = counting[0];
            return finalRezult;
        }

        private void BackSpaceButton_Click(object sender, RoutedEventArgs e)
        {
            if (Screen.Text != "")
            {
                if (!(Input.Last() == '+' || Input.Last() == '-' || Input.Last() == '*' || Input.Last() == '/'))
                {
                    Input = Input.Substring(0, Input.Length-1);
                    CountingInput = CountingInput.Substring(0, CountingInput.Length-1);
                    History.Text = Input;
                    Screen.Text = Screen.Text.Substring(0, Screen.Text.Length - 1);
                    if (Screen.Text == "-")
                    {
                        Screen.Text = "";
                        Input = Input.Substring(0, Input.Length - 1);
                        CountingInput = CountingInput.Substring(0, CountingInput.Length - 1);
                        History.Text = Input;
                    }
                }
            }
        }
    }
}
