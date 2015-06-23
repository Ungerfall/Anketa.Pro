using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace AnketaProCustomControls
{
    /// <summary>
    /// Follow steps 1a or 1b and then 2 to use this custom control in a XAML file.
    ///
    /// Step 1a) Using this custom control in a XAML file that exists in the current project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:AnketaProCustomControls"
    ///
    ///
    /// Step 1b) Using this custom control in a XAML file that exists in a different project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:AnketaProCustomControls;assembly=AnketaProCustomControls"
    ///
    /// You will also need to add a project reference from the project where the XAML file lives
    /// to this project and Rebuild to avoid compilation errors:
    ///
    ///     Right click on the target project in the Solution Explorer and
    ///     "Add Reference"->"Projects"->[Browse to and select this project]
    ///
    ///
    /// Step 2)
    /// Go ahead and use your control in the XAML file.
    ///
    ///     <MyNamespace:Question/>
    ///
    /// </summary>
    public class Question : Control
    {
        static Question()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Question), new FrameworkPropertyMetadata(typeof(Question)));
        }

        public static readonly DependencyProperty QuestionProperty = DependencyProperty.Register(
            "QuestionText", typeof (string), typeof (Question), new PropertyMetadata(default(string)));

        public string QuestionText
        {
            get { return (string) GetValue(QuestionProperty); }
            set { SetValue(QuestionProperty, value); }
        }

        public static readonly DependencyProperty QuestionAnswerProperty = DependencyProperty.Register(
            "QuestionAnswer", typeof (string), typeof (Question), new PropertyMetadata(default(string)));

        public string QuestionAnswer
        {
            get { return (string) GetValue(QuestionAnswerProperty); }
            set { SetValue(QuestionAnswerProperty, value); }
        }

        public static readonly DependencyProperty IsSelectedProperty = DependencyProperty.Register(
            "IsSelected", typeof (bool), typeof (Question), new PropertyMetadata(default(bool)));

        public bool IsSelected
        {
            get { return (bool) GetValue(IsSelectedProperty); }
            set { SetValue(IsSelectedProperty, value); }
        }

        protected override void OnMouseDoubleClick(MouseButtonEventArgs e)
        {
            base.OnMouseDoubleClick(e);
            IsSelected = true;
        }
    }
}
