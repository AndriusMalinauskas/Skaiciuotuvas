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
        public double Rezultatas { get; set; }
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
            if (Screen.Text != "")
            {                      
                Counting = Sequence(CountingInput);
                Rezultatas = double.Parse(Rezult(Counting));
                History.Text += '=';
                History.Text += Rezultatas;
                History.Text += $"\n{Rezultatas}";
                Screen.Text = $"{Rezultatas}";   
                CountingInput = $"{Rezultatas}";
            }
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            Screen.Text = "";
            History.Text = $"{History.Text}\n";
            CountingInput = "";
        }

        private void ActionButton(string mathaction)
        {
            if (Screen.Text != "")
            {
                if (CountingInput.Last() == '+' || CountingInput.Last() == '-' || CountingInput.Last() == '*' || CountingInput.Last() == '/')
                {
                    History.Text = History.Text.TrimEnd(History.Text.Last());
                    History.Text += mathaction;
                    CountingInput = CountingInput.TrimEnd(CountingInput.Last());
                    CountingInput += mathaction;
                }
                else
                {
                    History.Text += mathaction;
                    CountingInput += mathaction;
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
                    History.Text += numberButton;
                    CountingInput += numberButton;
                }
                else
                {
                    Screen.Text = $"0.";
                    History.Text += "0.";
                    CountingInput += "0.";
                }
            }
            else
            {
                if (CountingInput.Last() == '+' || CountingInput.Last() == '-' || CountingInput.Last() == '*' || CountingInput.Last() == '/')
                {
                    Screen.Text = "";
                    Screen.Text = $"{numberButton}";
                    History.Text += numberButton;
                    CountingInput += numberButton;
                }
                else
                {
                    if (Screen.Text == "0" && numberButton != '.')
                    {
                        Screen.Text = $"{numberButton}";
                        History.Text = History.Text.TrimEnd(History.Text.Last());
                        CountingInput = CountingInput.TrimEnd(CountingInput.Last());
                        History.Text += numberButton;
                        CountingInput += numberButton;
                    }
                    else
                    {
                        Screen.Text = $"{Screen.Text}{numberButton}";
                        History.Text += numberButton;
                        CountingInput += numberButton;
                    }
                }
            }
        }

        private List<string> Sequence(string countingSequence)
        {
            if (countingSequence.Last() == '+' || countingSequence.Last() == '-' || countingSequence.Last() == '*' || countingSequence.Last() == '/')
            {
                countingSequence += Screen.Text;
             
            }
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
                if (!(CountingInput.Last() == '+' || CountingInput.Last() == '-' || CountingInput.Last() == '*' || CountingInput.Last() == '/'))
                {
                    CountingInput = CountingInput.Substring(0, CountingInput.Length-1);
                    History.Text = History.Text.Substring(0, History.Text.Length - 1);
                    Screen.Text = Screen.Text.Substring(0, Screen.Text.Length - 1);
                    if (Screen.Text == "-")
                    {
                        Screen.Text = "";
                        CountingInput = CountingInput.Substring(0, CountingInput.Length - 1);
                        History.Text = History.Text.Substring(0, History.Text.Length - 1);
                    }
                }
            }
        }
    }
}
