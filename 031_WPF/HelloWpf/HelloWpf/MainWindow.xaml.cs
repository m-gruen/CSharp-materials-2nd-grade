using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HelloWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MakeNewStuff;
        }

        private void MakeNewStuff(object sender, RoutedEventArgs e)
        {
            ResultTextBox.Text = "";

            var operation = Random.Shared.Next(0, 3) switch
            {
                0 => "+",
                1 => "-",
                _ => "*",
            };

            NumberOne.Text = Random.Shared.Next(1, 51).ToString();
            NumberTwo.Text = Random.Shared.Next(1, 51).ToString();
            Opperation.Text = operation;
        }

        private void OnCheck(object sender, RoutedEventArgs e)
        {
            var input = ResultTextBox.Text;

            var number1 = int.Parse(NumberOne.Text);
            var number2 = int.Parse(NumberTwo.Text);

            int result = Opperation.Text switch
            {
                "+" => number1 + number2,
                "-" => number1 - number2,
                "*" => number1 * number2,
                _ => 0,
            };

            if (!int.TryParse(input, out var number))
            {
                MessageBox.Show("Please enter a valid number.");
            }
            else if (number == result)
            {
                MessageBox.Show("You guessed the correct number!");
                MakeNewStuff(sender, e);
            }
            else
            {
                MessageBox.Show("Sorry, you guessed the wrong number.");
            }
        }
    }
}