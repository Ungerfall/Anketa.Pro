using System.Windows;
using System.Windows.Controls;

namespace AnketaProCustomControls
{
    public class ApQuestionBase : TextBox
    {
        public static readonly DependencyProperty AnketaModeProperty = DependencyProperty.Register(
           "AnketaMode", typeof(AnketaMode), typeof(ApQuestionBase), new PropertyMetadata(AnketaMode.Constructor));

        public AnketaMode AnketaMode
        {
            get { return (AnketaMode)GetValue(AnketaModeProperty); }
            set { SetValue(AnketaModeProperty, value); }
        }

        public static readonly DependencyProperty QuestionTextProperty = DependencyProperty.Register(
            "QuestionText", typeof(string), typeof(ApQuestionBase), new PropertyMetadata(default(string)));

        public string QuestionText
        {
            get { return (string)GetValue(QuestionTextProperty); }
            set { SetValue(QuestionTextProperty, value); }
        }

        private static readonly DependencyProperty IsMouseDoubleClickProperty = DependencyProperty.Register(
            "IsMouseDoubleClick", typeof(bool), typeof(ApQuestionBase), new PropertyMetadata(false));

        public bool IsMouseDoubleClick
        {
            get { return (bool) GetValue(IsMouseDoubleClickProperty); }
            set { SetValue(IsMouseDoubleClickProperty, value); }
        }
    }
}