using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace MathPyramid;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }
    private int _width = 0;
    private List<List<TextBox>> _pyramid = [];

    private void CheckClick(object sender, RoutedEventArgs e)
    {
        // The pyramid works like this:
        // You start from the bottom and go up, 
        // You add the neighboring numbers and put the result in the upper number.
        // At the end, you should have only one number at the top of the pyramid.

        // Now we want to check if the user has done it correctly.
        // If the field is incorrect, we will color it red, otherwise we leave it as it is.
        // If all the fields are correct, we will color the whole pyramid (the StackPanel) green.

        Pyramid.Background = Brushes.Transparent;

        bool isCorrect = true;

        for (int i = 1; i < _width; i++)
        {
            for (int j = 0; j < _pyramid[i].Count; j++)
            {
                bool[] isValid =
                [
                    int.TryParse(_pyramid[i][j].Text, out int current),
                    int.TryParse(_pyramid[i - 1][j].Text, out int left),
                    int.TryParse(_pyramid[i - 1][j + 1].Text, out int right),
                ];

                if (isValid.All(x => x) && current == left + right)
                {
                    _pyramid[i][j].Background = Brushes.White;
                }
                else
                {
                    _pyramid[i][j].Background = Brushes.Red;
                    isCorrect = false;
                }
            }
        }

        if (isCorrect)
        {
            Pyramid.Background = Brushes.Lime;
        }
    }

    private void GenerateClick(object sender, RoutedEventArgs e)
    {
        _ = int.TryParse(WidthTextBox.Text, out _width);
        _ = int.TryParse(DigitsTextBox.Text, out int digits);

        if (_width < 2 || _width > 10 || digits < 1 || digits > 3)
        {
            MessageBox.Show("Number of digits in base must be between 1 and 3, width of base must be between 2 and 10.");
            return;
        }

        Pyramid.Children.Clear();
        _pyramid.Clear();
        Pyramid.Background = Brushes.Transparent;

        for (int i = 0; i < _width; i++) { _pyramid.Add([]); }

        int rows = _width;
        for (int i = rows - 1; i >= 0; i--)
        {
            var row = new StackPanel
            {
                Orientation = Orientation.Horizontal
            };

            for (int j = 0; j < _width - i; j++)
            {
                var textBlock = new TextBox
                {
                    Text = $"{(i == 0 ? GenerateNumber(digits).ToString() : "")}",
                    IsReadOnly = i == 0,
                    Width = 60,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    TextAlignment = TextAlignment.Center,
                };

                _pyramid[i].Add(textBlock);

                row.Children.Add(textBlock);
            }
            Pyramid.Children.Add(row);
        }


    }

    private int GenerateNumber(int digits)
    {
        return Random.Shared.Next(0, (int)Math.Pow(10, digits));
    }
}
