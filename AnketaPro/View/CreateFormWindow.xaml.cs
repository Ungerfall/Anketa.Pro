using AnketaPro.ViewModel;

namespace AnketaPro.View
{
    /// <summary>
    /// Interaction logic for CreateFormWindow.xaml
    /// </summary>
    public partial class CreateFormWindow
    {
        private CreateFormViewModel createFormContext;

        public CreateFormWindow()
        {
            InitializeComponent();
            createFormContext = new CreateFormViewModel();
            DataContext = createFormContext;
        }
    }
}
