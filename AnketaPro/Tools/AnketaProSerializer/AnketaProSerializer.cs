using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace AnketaPro.Tools.AnketaProSerializer
{
    public class AnketaProSerializer
    {
        private const char StringDivider = (char) 0x00D8;
        private const char ToolsDivider = (char) 0x0298;

        public static void Serialize(UIElementCollection items)
        {
            var correctIndex = 0;
            var text = new StringBuilder();
            items.RemoveAt(0);
            foreach (var item in items)
            {
                var fwElement = (FrameworkElement) item;
                switch (fwElement.Name)
                {
                    case "Text":
                        text.Append("Text:");
                        foreach (TextBox textbox in ((StackPanel) item).Children)
                        {
                            text.Append(textbox.Text);
                            text.Append(StringDivider);
                        }
                        text.Length--;
                        text.Append(ToolsDivider);
                        break;
                    case "OneFromList":
                        text.Append("OneFromList:");
                        foreach (var griditem in ((Grid) item).Children)
                        {
                            if (griditem.GetType() == typeof (TextBox)
                        }
                        break;
                    case "SeveralFromList":
                        break;
                    case "Image":
                        break;
                    case "PageBreak":
                        break;
                }
            }
        }

        public void DeSerialize()
        {
        }
    }
}
