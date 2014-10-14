using System;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace AnketaPro.Tools.AnketaProSerializer
{
    public enum DeserializeType
    {
        Constructor = 0,
        Survey
    }

    public static class AnketaProSerializer
    {
        private const char StringDivider = (char) 0x00D8;
        private const char ToolsDivider = (char) 0x0298;

        public static StringBuilder Serialize(UIElementCollection items)
        {
            var apSerializedText = new StringBuilder();
            items.RemoveAt(0);
            foreach (var item in items)
            {
                int answerIndex;
                int cbIndex;
                var fwElement = (FrameworkElement) item;
                switch (fwElement.Name)
                {
                    case "Text":
                        apSerializedText.Append("Text:");
                        foreach (TextBox textbox in ((StackPanel) item).Children)
                        {
                            apSerializedText.Append(textbox.Text);
                            apSerializedText.Append(StringDivider);
                        }
                        apSerializedText.Length--;
                        apSerializedText.Append(ToolsDivider);
                        break;
                    case "OneFromList":
                        cbIndex = 0;
                        apSerializedText.Append("OneFromList::");
                        answerIndex = apSerializedText.Length - 1;
                        foreach (var griditem in ((Grid) item).Children)
                        {
                            if (griditem.GetType() == typeof (TextBox))
                            {
                                apSerializedText.Append(((TextBox)griditem).Text);
                                apSerializedText.Append(StringDivider);
                            }
                            else if (griditem.GetType() == typeof (RadioButton))
                            {
                                cbIndex++;
                                if (((RadioButton)griditem).IsChecked == true)
                                    apSerializedText.Insert(answerIndex, cbIndex);
                            }
                        }
                        apSerializedText.Length--;
                        apSerializedText.Append(ToolsDivider);
                        break;
                    case "SeveralFromList":
                        cbIndex = 0;
                        apSerializedText.Append("SeveralFromList::");
                        answerIndex = apSerializedText.Length - 1;
                        foreach (var griditem in ((Grid) item).Children)
                        {
                            if (griditem.GetType() == typeof(TextBox))
                            {
                                apSerializedText.Append(((TextBox)griditem).Text);
                                apSerializedText.Append(StringDivider);
                            }
                            else if (griditem.GetType() == typeof(CheckBox))
                            {
                                cbIndex++;
                                if (((CheckBox) griditem).IsChecked != true) continue;
                                apSerializedText.Insert(answerIndex, string.Format("{0},", cbIndex));
                                answerIndex += (int)Math.Floor(Math.Log10(cbIndex) + 1) + 1;
                            }
                        }
                        apSerializedText.Remove(answerIndex - 1, 1);
                        apSerializedText.Length--;
                        apSerializedText.Append(ToolsDivider);
                        break;
                    case "Image":
                        break;
                    case "PageBreak":
                        apSerializedText.Append("PageBreak");
                        apSerializedText.Append(ToolsDivider);
                        break;
                }
            }
            apSerializedText.Length--;
            return apSerializedText;
        }

        public static StackPanel DeSerialize(String apSerializedText, DeserializeType dType)
        {
            var spItems = new StackPanel();
            var tokens = apSerializedText.Split(ToolsDivider);
            foreach (var item in tokens)
            {
                var type = item.Substring(0, item.IndexOf(':'));
                switch (type)
                {

                }
            }
            return spItems;
        }
    }
}
