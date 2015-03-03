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
        }

        private void SurveyClick(object sender, RoutedEventArgs e)
        {
        }

        private void TestClick(object sender, RoutedEventArgs e)
        {
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
