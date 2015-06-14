using AnketaPro.ViewModel;

namespace AnketaPro.View
{
    /// <summary>
    /// Interaction logic for OpenForm.xaml
    /// </summary>
    public partial class OpenFormWindow
    {
        private OpenFormViewModel openFormContext;

        public OpenFormWindow()
        {
            InitializeComponent();
            openFormContext = new OpenFormViewModel();
            DataContext = openFormContext;
        }
    }
}
