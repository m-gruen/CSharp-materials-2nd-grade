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

namespace TickTackToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private TicTacToeField Field { get; set; } = new();

        private bool _turn = false;
        public MainWindow()
        {
            InitializeComponent();

            Loaded += OnLoaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            for (var i = 0; i < 3; i++)
            {
                RowCombo.Items.Add(i + 1);
                ColumnCombo.Items.Add(i + 1);
            }

            RowCombo.SelectedItem = 1;
            ColumnCombo.SelectedItem = 1;

            for (int row = 0; row < 3; row++)
            {
                var rowPanel = new StackPanel { Orientation = Orientation.Horizontal };
                for (int col = 0; col < 3; col++)
                {
                    Field.Cells[row, col] = new TextBlock();
                    var cellBorder = new Border { Child = Field.Cells[row, col] };
                    Field.Border[row, col] = cellBorder;
                    rowPanel.Children.Add(cellBorder);
                }
                TicTacToePanel.Children.Add(rowPanel);
            }
        }

        private void OnSet(object sender, RoutedEventArgs e)
        {
            var row = (int)RowCombo.SelectedItem - 1;
            var column = (int)ColumnCombo.SelectedItem - 1;

            if (Field.Cells[row, column].Text != "")
            {
                MessageBox.Show("Cell is already set");
            }
            else
            {
                Field.Cells[row, column].Text = (_turn = !_turn) ? "X" : "O";

                if (CheckWin() || CheckDraw())
                {
                    var outputText = new TextBlock
                    {
                        Text = CheckWin() ? $"{(_turn ? "X" : "O")} wins!" : "Draw!",
                        FontSize = 24,
                        HorizontalAlignment = HorizontalAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Center,
                        FontFamily = new FontFamily("Arial Black")
                    };

                    BottomRow.Children.Clear();
                    BottomRow.Children.Add(outputText);
                }
            }
        }

        private bool CheckWin()
        {
            for (int i = 0; i < 3; i++)
            {
                if (Field.Cells[i, 0].Text == Field.Cells[i, 1].Text && Field.Cells[i, 1].Text == Field.Cells[i, 2].Text && Field.Cells[i, 0].Text != "")
                {
                    SetBackgroundToRed(Field.Border[i, 0], Field.Border[i, 1], Field.Border[i, 2]);
                    return true;
                }
                if (Field.Cells[0, i].Text == Field.Cells[1, i].Text && Field.Cells[1, i].Text == Field.Cells[2, i].Text && Field.Cells[0, i].Text != "")
                {
                    SetBackgroundToRed(Field.Border[0, i], Field.Border[1, i], Field.Border[2, i]);
                    return true;
                }
            }

            if (Field.Cells[0, 0].Text == Field.Cells[1, 1].Text && Field.Cells[1, 1].Text == Field.Cells[2, 2].Text && Field.Cells[0, 0].Text != "")
            {
                SetBackgroundToRed(Field.Border[0, 0], Field.Border[1, 1], Field.Border[2, 2]);
                return true;
            }

            if (Field.Cells[0, 2].Text == Field.Cells[1, 1].Text && Field.Cells[1, 1].Text == Field.Cells[2, 0].Text && Field.Cells[0, 2].Text != "")
            {
                SetBackgroundToRed(Field.Border[0, 2], Field.Border[1, 1], Field.Border[2, 0]);
                return true;
            }

            return false;
        }

        private bool CheckDraw()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (Field.Cells[i, j].Text == "")
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private void SetBackgroundToRed(Border b1, Border b2, Border b3) => b1.Background = b2.Background = b3.Background = Brushes.Red;
    }

    public class TicTacToeField
    {
        public TextBlock[,] Cells { get; set; } = new TextBlock[3, 3];
        public Border[,] Border { get; set; } = new Border[3, 3];
    }

}