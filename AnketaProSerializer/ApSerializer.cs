using System;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace AnketaProSerializer
{
    public enum DeserializeType
    {
        Constructor = 0,
        Survey
    }

    public static class ApSerializer
    {
        private const char StringDivider = (char)0x00D8;
        private const char ToolsDivider = (char)0x0298;

        public static StringBuilder Serialize(UIElementCollection items)
        {
            var apSerializedText = new StringBuilder();
            foreach (var item in items)
            {
                int answerIndex;
                int cbIndex;
                var fwElement = (FrameworkElement)item;
                switch (fwElement.Name)
                {
                    case "Text":
                        apSerializedText.Append("Text:");
                        apSerializedText.Append(((TextBox)item).Text);
                        apSerializedText.Append(StringDivider);
                        apSerializedText.Length--;
                        apSerializedText.Append(ToolsDivider);
                        break;
                    case "OneFromList":
                        cbIndex = 0;
                        apSerializedText.Append("OneFromList::");
                        answerIndex = apSerializedText.Length - 1;
                        foreach (var griditem in ((Grid)item).Children)
                        {
                            if (griditem.GetType() == typeof(TextBox))
                            {
                                apSerializedText.Append(((TextBox)griditem).Text);
                                apSerializedText.Append(StringDivider);
                            }
                            else if (griditem.GetType() == typeof(RadioButton))
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
                        foreach (var griditem in ((Grid)item).Children)
                        {
                            if (griditem.GetType() == typeof(TextBox))
                            {
                                apSerializedText.Append(((TextBox)griditem).Text);
                                apSerializedText.Append(StringDivider);
                            }
                            else if (griditem.GetType() == typeof(CheckBox))
                            {
                                cbIndex++;
                                if (((CheckBox)griditem).IsChecked != true) continue;
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

        public static void Deserialize(ref StackPanel stackPanel, String apSerializedText, DeserializeType dType)
        {
            var tokens = apSerializedText.Split(ToolsDivider);
            foreach (var tokenParts in tokens.Select(GetTokensPart))
            {
                switch (tokenParts.Item1)
                {
                    case "Text":
                        var stackpanel = new StackPanel
                        {
                            Name = "Text",
                            VerticalAlignment = VerticalAlignment.Center,
                            HorizontalAlignment = HorizontalAlignment.Center,
                            Margin = new Thickness(0, 5, 0, 5)
                        };
                        var textQuestion = new TextBlock {Text = tokenParts.Item3[0]};
                        textQuestion.SetBinding(FrameworkElement.WidthProperty, new Binding
                        {
                            ElementName = "AsScrollViewer",
                            Path = new PropertyPath(FrameworkElement.ActualWidthProperty)
                        });
                        var textAnswer = new TextBox
                        {
                            Text = "Ответ",
                            AcceptsReturn = true
                        };
                        stackpanel.Children.Add(textQuestion);
                        stackpanel.Children.Add(textAnswer);
                        stackPanel.Children.Add(stackpanel);
                        break;
                    case "OneFromList":
                        var oflGrid = new Grid
                        {
                            Name = "OneFromList",
                            Margin = new Thickness(0, 5, 0, 5)
                        };
                        oflGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
                        oflGrid.ColumnDefinitions.Add(new ColumnDefinition());
                        oflGrid.RowDefinitions.Add(new RowDefinition());
                        var oflQuestion = new TextBlock {Text = tokenParts.Item3[0]};
                        oflGrid.Children.Add(oflQuestion);
                        Grid.SetRow(oflQuestion, 0);
                        Grid.SetColumn(oflQuestion, 0);
                        Grid.SetColumnSpan(oflQuestion, 2);
                        for (var i = 1; i < tokenParts.Item3.Length; i++)
                        {
                            oflGrid.RowDefinitions.Add(new RowDefinition());
                            var radio = new RadioButton { VerticalAlignment = VerticalAlignment.Center };
                            oflGrid.Children.Add(radio);
                            Grid.SetColumn(radio, 0);
                            Grid.SetRow(radio, i);
                            var oflAnswer = new TextBox {AcceptsReturn = true, Text = tokenParts.Item3[i]};
                            oflGrid.Children.Add(oflAnswer);
                            Grid.SetColumn(oflAnswer, 1);
                            Grid.SetRow(oflAnswer, i);
                        }
                        stackPanel.Children.Add(oflGrid);
                        break;
                    case "SeveralFromList":
                        var sflGrid = new Grid
                        {
                            Name = "SeveralFromList",
                            Margin = new Thickness(0, 5, 0, 5)
                        };
                        sflGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
                        sflGrid.ColumnDefinitions.Add(new ColumnDefinition());
                        sflGrid.RowDefinitions.Add(new RowDefinition());
                        var sflQuestion = new TextBlock {Text = tokenParts.Item3[0]};
                        sflGrid.Children.Add(sflQuestion);
                        Grid.SetRow(sflQuestion, 0);
                        Grid.SetColumn(sflQuestion, 0);
                        Grid.SetColumnSpan(sflQuestion, 2);
                        for (var i = 1; i < tokenParts.Item3.Length; i++)
                        {
                            sflGrid.RowDefinitions.Add(new RowDefinition());
                            var check = new CheckBox { VerticalAlignment = VerticalAlignment.Center };
                            sflGrid.Children.Add(check);
                            Grid.SetColumn(check, 0);
                            Grid.SetRow(check, i);
                            var oflAnswer = new TextBox { AcceptsReturn = true, Text = tokenParts.Item3[i] };
                            sflGrid.Children.Add(oflAnswer);
                            Grid.SetColumn(oflAnswer, 1);
                            Grid.SetRow(oflAnswer, i);
                        }
                        stackPanel.Children.Add(sflGrid);
                        break;
                    case "Image":
                        break;
                    case "PageBreak":
                        break;
                }
            }
        }

        private static Tuple<string, string[], string[]> GetTokensPart(string token)
        {
            if (token == "PageBreak") return Tuple.Create(token, new string[0], new string[0]);
            var start = token.IndexOf(':');
            var head = token.Substring(0, start);
            var body = new string[0];
            string[] tail;
            if (head == "OneFromList" || head == "SeveralFromList")
            {
                var end = token.IndexOf(':', start + 1);
                body = token.Substring(start + 1, end - start - 1).Split(',');
                tail = token.Substring(end + 1).Split(StringDivider);
            }
            else
                tail = token.Substring(start + 1).Split(StringDivider);
            return Tuple.Create(head, body, tail);
        }
    }
}
