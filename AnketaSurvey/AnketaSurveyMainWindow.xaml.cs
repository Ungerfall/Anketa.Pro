using System;
using System.IO;
using System.Text;
using System.Windows;
using AnketaPro.Tools.AnketaProSerializer;

namespace AnketaSurvey
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class AnketaSurveyMainWindow
    {
        public AnketaSurveyMainWindow()
        {
            InitializeComponent();
        }

        private void LoadSurvey(object sender, RoutedEventArgs e)
        {
            var dlg = new Microsoft.Win32.OpenFileDialog
            {
                DefaultExt = ".anktpro",
                Filter = "AnketaProSurvey documents (.anktpro)|*.anktpro",
                InitialDirectory = AppDomain.CurrentDomain.BaseDirectory + "Surveys\\",
                RestoreDirectory = true
            };
            var result = dlg.ShowDialog();
            if (result != true) return;
            using (var sr = new StreamReader(dlg.FileName, Encoding.UTF8))
            {
                var sp = AnketaProSerializer.DeSerialize(sr.ReadToEnd());
            }
        }
    }
}
