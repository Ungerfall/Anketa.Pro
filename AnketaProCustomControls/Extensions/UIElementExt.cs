using System.Windows;
using System.Windows.Controls;

namespace AnketaProCustomControls.Extensions
{
    internal static class UiElementExt
    {
        internal static void AddToGrid(this UIElement element, Panel parent, int row, int column = 0)
        {
            parent.Children.Add(element);
            Grid.SetRow(element, row);
            Grid.SetColumn(element, column);
        }
    }
}