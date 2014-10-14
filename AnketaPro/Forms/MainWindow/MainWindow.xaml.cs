using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using AnketaPro.Tools.AnketaProSerializer;
using System.IO;

namespace AnketaPro.Forms.MainWindow
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        #region Fields
        #endregion

        public MainWindow()
        {
            InitializeComponent();
        }

        //скрытие OverflowGrid и MainPanelBorder
        private void ToolBar_Loaded(object sender, RoutedEventArgs e)
        {
            var toolBar = sender as ToolBar;
            if (toolBar != null)
            {
                var overflowGrid = toolBar.Template.FindName("OverflowGrid", toolBar) as FrameworkElement;
                if (overflowGrid != null)
                {
                    overflowGrid.Visibility = Visibility.Collapsed;
                }
            }

            if (toolBar == null) return;
            var mainPanelBorder =  toolBar.Template.FindName("MainPanelBorder", toolBar) as FrameworkElement;
            if (mainPanelBorder != null)
            {
                mainPanelBorder.Margin = new Thickness(0);
            }
        }

        //скрытие OverflowGrid и MainPanelBorder
        private void ToolBar_Loaded_1(object sender, RoutedEventArgs e)
        {
            var toolBar = sender as ToolBar;
            if (toolBar != null)
            {
                var overflowGrid = toolBar.Template.FindName("OverflowGrid", toolBar) as FrameworkElement;
                if (overflowGrid != null)
                {
                    overflowGrid.Visibility = Visibility.Collapsed;
                }
            }

            if (toolBar == null) return;
            var mainPanelBorder = toolBar.Template.FindName("MainPanelBorder", toolBar) as FrameworkElement;
            if (mainPanelBorder != null)
            {
                mainPanelBorder.Margin = new Thickness(0);
            }
        }

        private void MenuItemExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void TextButton_Click(object sender, RoutedEventArgs e)
        {
            var stackpanel = new StackPanel
            {
                Name = "Text",
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(0, 5, 0, 5)
            };
            var question = new TextBox
            {
                Width = ScrollViewer.ActualWidth,
                Text = "Вопрос",
                AcceptsReturn = true
            };
            var answer = new TextBox
            {
                Text = "Ответ",
                AcceptsReturn = true
            };
            stackpanel.Children.Add(question);
            stackpanel.Children.Add(answer);
            MainStackPanel.Children.Add(stackpanel);
            question.SelectAll();
            question.Focus();
        }

        private void OneAnswer_Click(object sender, RoutedEventArgs e)
        {
            var grid = new Grid
            {
                Name = "OneFromList",
                Margin = new Thickness(0, 5, 0, 5)
            };
            grid.ColumnDefinitions.Add(new ColumnDefinition {Width = GridLength.Auto});
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.RowDefinitions.Add(new RowDefinition());
            grid.RowDefinitions.Add(new RowDefinition());
            grid.RowDefinitions.Add(new RowDefinition());
            var question = new TextBox
            {
                Width = ScrollViewer.ActualWidth,
                Text = "Вопрос",
                AcceptsReturn = true
            };
            question.SetBinding(WidthProperty, new Binding
            {
                ElementName = "ScrollViewer",
                Path = new PropertyPath(ActualWidthProperty)
            });
            var radio = new RadioButton {VerticalAlignment = VerticalAlignment.Center};
            var answer = new TextBox {AcceptsReturn = true};
            var addvariant = new Button {Content = "Добавить вариант", HorizontalAlignment = HorizontalAlignment.Center};
            addvariant.Click += (o, args) =>
            {
                var button = (Button) o;
                var currentrow = Grid.GetRow(button);
                grid.RowDefinitions.Add(new RowDefinition());
                var newradio = new RadioButton { VerticalAlignment = VerticalAlignment.Center };
                var newanswer = new TextBox { AcceptsReturn = true };
                Grid.SetRow(button, currentrow + 1);
                grid.Children.Add(newradio);
                Grid.SetColumn(newradio, 0);
                Grid.SetRow(newradio, currentrow);
                grid.Children.Add(newanswer);
                Grid.SetColumn(newanswer, 1);
                Grid.SetRow(newanswer, currentrow);
                newanswer.Focus();
            };
            grid.Children.Add(question);
            Grid.SetRow(question, 0);
            Grid.SetColumn(question, 0);
            Grid.SetColumnSpan(question, 2);
            grid.Children.Add(radio);
            Grid.SetColumn(radio, 0);
            Grid.SetRow(radio, 1);
            grid.Children.Add(answer);
            Grid.SetColumn(answer, 1);
            Grid.SetRow(answer, 1);
            grid.Children.Add(addvariant);
            Grid.SetRow(addvariant, 2);
            Grid.SetColumn(addvariant, 0);
            Grid.SetColumnSpan(addvariant, 2);
            MainStackPanel.Children.Add(grid);
            question.SelectAll();
            question.Focus();
            radio.IsChecked = true;
        }

        private void ManyAnswers_Click(object sender, RoutedEventArgs e)
        {
            var grid = new Grid
            {
                Name = "SeveralFromList",
                Margin = new Thickness(0, 5, 0, 5)
            };
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.RowDefinitions.Add(new RowDefinition());
            grid.RowDefinitions.Add(new RowDefinition());
            grid.RowDefinitions.Add(new RowDefinition());
            var question = new TextBox
            {
                Width = ScrollViewer.ActualWidth,
                Text = "Вопрос",
                AcceptsReturn = true
            };
            question.SetBinding(WidthProperty, new Binding
            {
                ElementName = "ScrollViewer",
                Path = new PropertyPath(ActualWidthProperty)
            });
            var check = new CheckBox { VerticalAlignment = VerticalAlignment.Center };
            var answer = new TextBox { AcceptsReturn = true };
            var addvariant = new Button { Content = "Добавить вариант", HorizontalAlignment = HorizontalAlignment.Center };
            addvariant.Click += (o, args) =>
            {
                var button = (Button)o;
                var currentrow = Grid.GetRow(button);
                grid.RowDefinitions.Add(new RowDefinition());
                var newcheck = new CheckBox { VerticalAlignment = VerticalAlignment.Center };
                var newanswer = new TextBox { AcceptsReturn = true };
                Grid.SetRow(button, currentrow + 1);
                grid.Children.Add(newcheck);
                Grid.SetColumn(newcheck, 0);
                Grid.SetRow(newcheck, currentrow);
                grid.Children.Add(newanswer);
                Grid.SetColumn(newanswer, 1);
                Grid.SetRow(newanswer, currentrow);
                newanswer.Focus();
            };
            grid.Children.Add(question);
            Grid.SetRow(question, 0);
            Grid.SetColumn(question, 0);
            Grid.SetColumnSpan(question, 2);
            grid.Children.Add(check);
            Grid.SetColumn(check, 0);
            Grid.SetRow(check, 1);
            grid.Children.Add(answer);
            Grid.SetColumn(answer, 1);
            Grid.SetRow(answer, 1);
            grid.Children.Add(addvariant);
            Grid.SetRow(addvariant, 2);
            Grid.SetColumn(addvariant, 0);
            Grid.SetColumnSpan(addvariant, 2);
            MainStackPanel.Children.Add(grid);
            question.SelectAll();
            question.Focus();
        }

        private void Image_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var dlg = new Microsoft.Win32.OpenFileDialog
                {
                    DefaultExt = ".png",
                    Filter =
                        "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif"
                };
                var result = dlg.ShowDialog();
                if (result != true) return;
                var filename = dlg.FileName;
                var bitmap = new BitmapImage();
                var img = new Image
                {
                    Name = "Image",
                    Width = 150,
                    Height = 150,
                    Stretch = Stretch.Fill,
                    Source = bitmap
                };
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(filename);
                bitmap.EndInit();
                MainStackPanel.Children.Add(img);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void PageBreakClick(object sender, RoutedEventArgs e)
        {
            var rectangle = new Rectangle
            {
                Name = "PageBreak",
                Fill = Brushes.DimGray,
                Height = 10
            };
            var binding = new Binding
            {
                ElementName = "ScrollViewer",
                Path = new PropertyPath(ActualWidthProperty)
            };
            rectangle.SetBinding(WidthProperty, binding);
            MainStackPanel.Children.Add(rectangle);
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            MainStackPanel.Children.Clear();
        }
        
        private void SaveSurveyClick(object sender, RoutedEventArgs e)
        {
            var dlg = new Microsoft.Win32.SaveFileDialog
            {
                FileName = "Опрос",
                DefaultExt = ".anktpro",
                Filter = "AnketaProSurvey documents (.anktpro)|*.anktpro",
                InitialDirectory = AppDomain.CurrentDomain.BaseDirectory + "Surveys\\",
                RestoreDirectory = true
            };
            Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "Surveys");
            var result = dlg.ShowDialog();

            if (result != true) return;
            var serial = AnketaProSerializer.Serialize(MainStackPanel.Children);
            using (var sw = new StreamWriter(dlg.FileName, false, Encoding.UTF8))
                sw.Write(serial);
        }

        private void CallAnketaSurvey(object sender, RoutedEventArgs e)
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
                var sp = AnketaProSerializer.DeSerialize(sr.ReadToEnd(), DeserializeType.Survey);
            }
        }
    }
}
