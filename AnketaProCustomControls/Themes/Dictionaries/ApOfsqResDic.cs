using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace AnketaProCustomControls.Themes.Dictionaries
{
    public partial class ApOfsqResDic
    {
        private void AddButtonClick(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var row = Grid.GetRow(button);
            var grid = VisualTreeHelper.GetParent(button) as Grid;
            if (grid == null) return;
            grid.RowDefinitions.Add(new RowDefinition());
            var radio = new RadioButton { VerticalAlignment = VerticalAlignment.Center };
            var answer = new TextBox { AcceptsReturn = true };
            Grid.SetRow(button, row + 1);
            radio.AddToGrid(grid, row);
            answer.AddToGrid(grid, row, 1);
            answer.Focus();
        }
    }
}