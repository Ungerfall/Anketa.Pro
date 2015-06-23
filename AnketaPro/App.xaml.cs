using System.Windows;
using AnketaPro.Service;
using AnketaPro.Service.FrameworkDialogs.OpenFile;
using AnketaPro.View;
using AnketaPro.ViewModel;

namespace AnketaPro
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            ServiceLocator.RegisterSingleton<IDialogService, DialogService>();
            ServiceLocator.RegisterSingleton<IWindowViewModelMappings, WindowViewModelMappings>();
            ServiceLocator.Register<IOpenFileDialog, OpenFileDialogViewModel>();

            var view = new MainWindow {DataContext = new MainWindowViewModel()};
            view.Show();
        }
    }
}
