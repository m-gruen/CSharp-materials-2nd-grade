using System.IO;
using System.Security.RightsManagement;
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

namespace Wordle
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Loaded += OnLoaded;

            _wordToGuess = SeclectRandomWord();
        }

        private string _wordToGuess;
        private WordleField _wordleField = new WordleField();
        private int _currentRow = 0;
        private int _currentColumn = 0;
        private bool _won = false;

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            for (var i = 0; i < 6; i++)
            {
                var stackPanel = new StackPanel
                {
                    Orientation = Orientation.Horizontal,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    Margin = new Thickness(0, 2, 0, 2)

                };

                Grid.SetRow(stackPanel, i);

                for (var j = 0; j < 5; j++)
                {
                    _wordleField.Textblocks[i, j] = new TextBlock
                    {
                        HorizontalAlignment = HorizontalAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Center,
                        FontSize = 32,
                    };

                    _wordleField.Borders[i, j] = new Border
                    {
                        BorderBrush = Brushes.Gray,
                        BorderThickness = new Thickness(1),
                        Width = 65,
                        Height = 65,
                        Margin = new Thickness(2, 0, 2, 0),
                        CornerRadius = new CornerRadius(5),
                        Child = _wordleField.Textblocks[i, j]
                    };

                    stackPanel.Children.Add(_wordleField.Borders[i, j]);
                }

                WordleBoard.Children.Add(stackPanel);
            }

            var firstRow = new string[] { "Q", "W", "E", "R", "T", "Y", "U", "I", "O", "P" };
            var secondRow = new string[] { "A", "S", "D", "F", "G", "H", "J", "K", "L" };
            var thirdRow = new string[] { "Z", "X", "C", "V", "B", "N", "M" };
            var fourthRow = new string[] { "SEND", "Ü", "Ö", "Ä", "ß", "⌫" };

            for (var i = 0; i < 4; i++)
            {
                var stackPanel = new StackPanel
                {
                    Orientation = Orientation.Horizontal,
                    HorizontalAlignment = HorizontalAlignment.Center
                };

                Grid.SetRow(stackPanel, i);

                foreach (var letter in i switch
                {
                    0 => firstRow,
                    1 => secondRow,
                    2 => thirdRow,
                    3 => fourthRow,
                    _ => new string[] { }
                })
                {
                    var button = new Button
                    {
                        BorderBrush = Brushes.Gray,
                        BorderThickness = new Thickness(1),
                        Margin = new Thickness(1),
                        Background = Brushes.LightGray,
                        FontSize = 18,
                        Content = letter,
                        HorizontalAlignment = HorizontalAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Center,
                        Padding = new Thickness(15, 5, 15, 5),
                    };

                    button.Click += KeyPress;
                    stackPanel.Children.Add(button);
                }

                KeyBoard.Children.Add(stackPanel);
            }


        }

        private void KeyPress(object sender, RoutedEventArgs e)
        {
            if (_won) { return; }

            var letter = ((Button)sender).Content.ToString();

            if (letter == "⌫")
            {
                if (_currentColumn > 0)
                {
                    _currentColumn--;
                    _wordleField.Textblocks[_currentRow, _currentColumn].Text = "";
                }
            }
            else if (letter == "SEND")
            {
                if (_currentColumn != 5)
                {
                    MessageBox.Show("Please fill the row first");
                    return;
                }

                var word = new StringBuilder();
                for (var i = 0; i < 5; i++) { word.Append(_wordleField.Textblocks[_currentRow, i].Text); }


                if (!File.ReadAllLines("available-words-de.txt").Select(x => x.Replace("\"", "").Replace(",", "")).ToArray().Contains(word.ToString()))
                {
                    MessageBox.Show("This word is not available");
                    return;
                }
                else
                {
                    ChangeColorBoard(word.ToString());
                    ChangeColorKeyBoard(word.ToString());
                }

                if (word.ToString() == _wordToGuess)
                {
                    MessageBox.Show("You won!");
                    _won = true;
                }

                _currentRow++;
                _currentColumn = 0;

                if (_currentRow == 6)
                {
                    MessageBox.Show("You lost!");
                    _won = true;
                }

                MessageBox.Show(_wordToGuess);
            }
            else
            {
                if (_currentColumn < 5 && !_won)
                {
                    _wordleField.Textblocks[_currentRow, _currentColumn].Text = letter;
                    _currentColumn++;
                }
            }

        }

        private void ChangeColorBoard(string word)
        {
            // Clolor definition:
            // Gray: Letter is not in the word
            // Yellow: Letter is in the word but not in the right position
            // Green: Letter is in the word and in the right position

            var wordToGuess = _wordToGuess.ToCharArray();
            var wordToCheck = word.ToCharArray();

            for (var i = 0; i < 5; i++)
            {
                if (wordToGuess.Contains(wordToCheck[i]))
                {
                    if (wordToGuess[i] == wordToCheck[i])
                    {
                        _wordleField.Borders[_currentRow, i].Background = _wordleField.Borders[_currentRow, i].BorderBrush = Brushes.Green;
                    }
                    else
                    {
                        _wordleField.Borders[_currentRow, i].Background = _wordleField.Borders[_currentRow, i].BorderBrush = Brushes.Yellow;

                    }
                }
                else
                {
                    _wordleField.Borders[_currentRow, i].Background = _wordleField.Borders[_currentRow, i].BorderBrush = Brushes.Gray;
                }
            }
        }

        private void ChangeColorKeyBoard(string word)
        {
            // Clolor definition:
            // Gray: Letter is not in the word
            // Yellow: Letter is in the word but not in the right position
            // Green: Letter is in the word and in the right position

            var wordToGuess = _wordToGuess.ToCharArray();
            var wordToCheck = word.ToCharArray();

            for (var i = 0; i < 5; i++)
            {
                if (wordToGuess.Contains(wordToCheck[i]))
                {
                    if (wordToGuess[i] == wordToCheck[i])
                    {
                        ChageLetterColor(wordToCheck[i].ToString(), Brushes.Green);
                    }
                    else
                    {
                        ChageLetterColor(wordToCheck[i].ToString(), Brushes.Yellow);
                    }
                }
                else
                {
                    ChageLetterColor(wordToCheck[i].ToString(), Brushes.Gray);
                }
            }

            void ChageLetterColor(string letter, Brush color)
            {
                foreach (var stackPanel in KeyBoard.Children)
                {
                    foreach (var button in ((StackPanel)stackPanel).Children)
                    {
                        if (((Button)button).Content.ToString() == letter)
                        {
                            ((Button)button).Background = color;
                        }
                    }
                }
            }
        }

        private string SeclectRandomWord()
        {
            var words = File.ReadAllLines("words-to-guess-de.txt").Select(x => x.Replace("\"", "").Replace(",", "")).ToArray();
            var random = Random.Shared.Next(0, words.Length);
            return words[random];
        }
    }

    public class WordleField
    {
        // Fied Board
        public TextBlock[,] Textblocks = new TextBlock[6, 5];
        public Border[,] Borders = new Border[6, 5];

        // Key Board
        // TODO: Implement Key Board
    }
}