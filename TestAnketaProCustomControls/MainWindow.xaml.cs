using System.Windows;
using AnketaProCustomControls;

namespace TestAnketaProCustomControls
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ConstructorClick(object sender, RoutedEventArgs e)
        {
            ApQuestion.AnketaMode = AnketaMode.Constructor;
        }

        private void SurveyClick(object sender, RoutedEventArgs e)
        {
            ApQuestion.AnketaMode = AnketaMode.Survey;
        }

        private void TestClick(object sender, RoutedEventArgs e)
        {
            ApQuestion.AnketaMode = AnketaMode.Test;
        }

        private void NewApQuestion(object sender, RoutedEventArgs e)
        {
            var aQuest = new ApQuestion
            {
                Text = "вопdfgdsdрос",
                AnswerText = "ответ"
            };
            StackPanel.Children.Add(aQuest);
        }
    }
}
