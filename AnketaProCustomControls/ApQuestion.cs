using System.Windows;

namespace AnketaProCustomControls
{
    public class ApQuestion : ApQuestionBase
    {
        static ApQuestion()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof (ApQuestion),
                new FrameworkPropertyMetadata(typeof (ApQuestion)));
        }

        public static readonly DependencyProperty AnswerTextProperty = DependencyProperty.Register(
            @"AnswerText", typeof(string), typeof(ApQuestion), new PropertyMetadata(default(string)));

        public string AnswerText
        {
            get { return (string)GetValue(AnswerTextProperty); }
            set { SetValue(AnswerTextProperty, value); }
        }
        
        public static readonly DependencyProperty GapProperty = DependencyProperty.Register(
            @"Gap", typeof (double), typeof (ApQuestion), new PropertyMetadata(default(double)));

        public double Gap
        {
            get { return (double) GetValue(GapProperty); }
            set { SetValue(GapProperty, value); }
        }
    }
}
