using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace TickTackToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private FourWinsField Field { get; set; } = new();

        private bool _turn = false;
        public MainWindow()
        {
            InitializeComponent();

            Loaded += OnLoaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            for (var i = 0; i < 7; i++)
            {
                ColumnCombo.Items.Add(i + 1);
            }

            ColumnCombo.SelectedItem = 1;

            for (var row = 0; row < 6; row++)
            {
                var rowPanel = new StackPanel { Orientation = Orientation.Horizontal };
                for (var col = 0; col < 7; col++)
                {
                    Field.Cells[row, col] = new TextBlock();
                    var cellBorder = new Border { Child = Field.Cells[row, col] };
                    Field.Border[row, col] = cellBorder;
                    rowPanel.Children.Add(cellBorder);
                }
                FourWinsPanel.Children.Add(rowPanel);
            }

        }

        private void OnSet(object sender, RoutedEventArgs e)
        {
            var col = (int)ColumnCombo.SelectedItem - 1;
            var row = Field.GetRow(col);

            if (row == -1)
            {
                MessageBox.Show("Column is full");
                return;
            }

            Field.Cells[row, col].Text = _turn ? "X" : "O";
            Field.Cells[row, col].Foreground = _turn ? Brushes.Red : Brushes.Blue;

            if (Field.CheckWin() || Field.CheckDraw())
            {
                var outputText = new TextBlock
                {
                    Text = Field.CheckWin() ? $"{(_turn ? "X" : "O")} wins!" : "Draw!",
                    FontSize = 24,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    FontFamily = new FontFamily("Arial Black")
                };

                BottomRow.Children.Clear();
                BottomRow.Children.Add(outputText);
            }
            _turn = !_turn;
        }

    }

    public class FourWinsField
    {
        public TextBlock[,] Cells { get; set; } = new TextBlock[6, 7];
        public Border[,] Border { get; set; } = new Border[6, 7];

        public int GetRow(int col)
        {
            for (var row = 5; row >= 0; row--)
            {
                if (Cells[row, col].Text == "")
                {
                    return row;
                }
            }
            return -1;
        }

        public bool CheckWin()
        {
            for (var row = 0; row < 6; row++)
            {
                for (var col = 0; col < 7; col++)
                {
                    if (Cells[row, col].Text == "") { continue; }

                    if (CheckCell(row, col, Cells[row, col].Text)) { return true; }
                }
            }

            return false;
        }

        private bool CheckCell(int row, int col, string typ, int direction = 0, int count = 0)
        {
            /*
             * 0 is nothing
             * 1 is top
             * 2 is top right
             * 3 is right
             * 4 is bottom right
             * 5 is bottom
             * 6 is bottom left
             * 7 is left
             * 8 is top left          
             */

            if (row < 0 || row >= 6 || col < 0 || col >= 7) { return false; }
            else if (Cells[row, col].Text != typ) { return false; }
            else if (count == 4) { return true; }
            count++;

            return direction switch
            {
                0 => CheckCell(row, col, typ, 1, count) ||
                     CheckCell(row, col, typ, 2, count) ||
                     CheckCell(row, col, typ, 3, count) ||
                     CheckCell(row, col, typ, 4, count) ||
                     CheckCell(row, col, typ, 5, count) ||
                     CheckCell(row, col, typ, 6, count) ||
                     CheckCell(row, col, typ, 7, count) ||
                     CheckCell(row, col, typ, 8, count),
                1 => CheckCell(row - 1, col, typ, 1, count),
                2 => CheckCell(row - 1, col + 1, typ, 2, count),
                3 => CheckCell(row, col + 1, typ, 3, count),
                4 => CheckCell(row + 1, col + 1, typ, 4, count),
                5 => CheckCell(row + 1, col, typ, 5, count),
                6 => CheckCell(row + 1, col - 1, typ, 6, count),
                7 => CheckCell(row, col - 1, typ, 7, count),
                8 => CheckCell(row - 1, col - 1, typ, 8, count),
                _ => false,
            };
        }

        public bool CheckDraw()
        {
            for (var row = 0; row < 6; row++)
            {
                for (var col = 0; col < 7; col++)
                {
                    if (Cells[row, col].Text == "")
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }

}