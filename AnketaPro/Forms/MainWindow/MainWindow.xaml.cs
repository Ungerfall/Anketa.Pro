using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Newtonsoft.Json;
using SIO = System.IO;

namespace AnketaPro.Forms.MainWindow
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Condition
        enum Conditions
        {
            Default = 0,
            IsText,
            IsOneAnswer,
            IsManyAnswers,
            IsImage
        };

        private Conditions m_toolbox_cond;
        private bool m_draw_condition;
        #endregion

        #region Fields
        #endregion

        public MainWindow()
        {
            InitializeComponent();
            m_draw_condition = false;
            m_toolbox_cond = Conditions.Default;
        }

        //скрытие OverflowGrid и MainPanelBorder
        private void ToolBar_Loaded(object sender, RoutedEventArgs e)
        {
            ToolBar toolBar = sender as ToolBar;
            var overflowGrid = toolBar.Template.FindName("OverflowGrid", toolBar) as FrameworkElement;
            if (overflowGrid != null)
            {
                overflowGrid.Visibility = Visibility.Collapsed;
            }

            var mainPanelBorder = toolBar.Template.FindName("MainPanelBorder", toolBar) as FrameworkElement;
            if (mainPanelBorder != null)
            {
                mainPanelBorder.Margin = new Thickness(0);
            }
        }

        //скрытие OverflowGrid и MainPanelBorder
        private void ToolBar_Loaded_1(object sender, RoutedEventArgs e)
        {
            ToolBar toolBar = sender as ToolBar;
            var overflowGrid = toolBar.Template.FindName("OverflowGrid", toolBar) as FrameworkElement;
            if (overflowGrid != null)
            {
                overflowGrid.Visibility = Visibility.Collapsed;
            }

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
            if (!m_draw_condition)
            {
                m_draw_condition = true;
                Mouse.OverrideCursor = Cursors.Pen;
                m_toolbox_cond = Conditions.IsText;
            }
        }

        private void ManyAnswers_Click(object sender, RoutedEventArgs e)
        {
            if (!m_draw_condition)
            {
                m_draw_condition = true;
                Mouse.OverrideCursor = Cursors.Pen;
                m_toolbox_cond = Conditions.IsManyAnswers;
            }
        }

        private void OneAnswer_Click(object sender, RoutedEventArgs e)
        {
            if (!m_draw_condition)
            {
                m_draw_condition = true;
                Mouse.OverrideCursor = Cursors.Pen;
                m_toolbox_cond = Conditions.IsOneAnswer;
            }
        }

        private void Image_Click(object sender, RoutedEventArgs e)
        {
            if (!m_draw_condition)
            {
                m_draw_condition = true;
                Mouse.OverrideCursor = Cursors.Pen;
                m_toolbox_cond = Conditions.IsImage;
            }
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            MainCanvas.Children.Clear();
        }

        private void MainCanvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var point = e.GetPosition(MainCanvas);
            #region iftrue
            if (m_draw_condition)
            {
                switch (m_toolbox_cond)
                {
                    case Conditions.IsText:
                        {
                            var _textbox = new TextBox();
                            _textbox.MinWidth = 100;
                            _textbox.VerticalAlignment = System.Windows.VerticalAlignment.Stretch;
                            _textbox.HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;
                            _textbox.AcceptsReturn = true;
                            MainCanvas.Children.Add(_textbox);
                            Canvas.SetLeft(_textbox, point.X);
                            Canvas.SetTop(_textbox, point.Y);
                        }
                        break;
                    case Conditions.IsOneAnswer:
                        {
                            var _textbox = new TextBox();
                            var _radiobtn = new RadioButton();
                            var _dp = new DockPanel();
                            var _btn = new Button();
                            var _txtbox_2 = new TextBox();

                            _textbox.Width = 100;
                            _textbox.Height = 25;
                            _txtbox_2.Width = 100;
                            _txtbox_2.Height = 25;
                            _radiobtn.VerticalAlignment = System.Windows.VerticalAlignment.Center;
                            _dp.Children.Add(_radiobtn);
                            _dp.Children.Add(_txtbox_2);
                            _btn.Content = "Добавить вариант";
                            _btn.Click += new RoutedEventHandler(_btn_Click);

                            MainCanvas.Children.Add(_textbox);
                            Canvas.SetLeft(_textbox, point.X);
                            Canvas.SetTop(_textbox, point.Y);
                            MainCanvas.Children.Add(_dp);
                            Canvas.SetLeft(_dp, point.X);
                            Canvas.SetTop(_dp, point.Y + 30);
                            MainCanvas.Children.Add(_btn);
                            Canvas.SetLeft(_btn, point.X);
                            Canvas.SetTop(_btn, point.Y + 60);
                        }
                        break;
                    case Conditions.IsManyAnswers:
                        {
                            var _textbox = new TextBox();
                            var _checkbox = new CheckBox();
                            var _dp = new DockPanel();
                            var _btn = new Button();
                            var _txtbox_2 = new TextBox();

                            _textbox.Width = 100;
                            _textbox.Height = 25;
                            _txtbox_2.Width = 100;
                            _txtbox_2.Height = 25;
                            _checkbox.VerticalAlignment = System.Windows.VerticalAlignment.Center;
                            _dp.Children.Add(_checkbox);
                            _dp.Children.Add(_txtbox_2);
                            _btn.Content = "Добавить вариант";
                            _btn.Click += new RoutedEventHandler(add_btn_click);

                            MainCanvas.Children.Add(_textbox);
                            Canvas.SetLeft(_textbox, point.X);
                            Canvas.SetTop(_textbox, point.Y);
                            MainCanvas.Children.Add(_dp);
                            Canvas.SetLeft(_dp, point.X);
                            Canvas.SetTop(_dp, point.Y + 30);
                            MainCanvas.Children.Add(_btn);
                            Canvas.SetLeft(_btn, point.X);
                            Canvas.SetTop(_btn, point.Y + 60);
                        }
                        break;
                    case Conditions.IsImage:
                        {
                            try
                            {
                                Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

                                // Set filter for file extension and default file extension 
                                dlg.DefaultExt = ".png";
                                dlg.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";

                                // Display OpenFileDialog by calling ShowDialog method 
                                Nullable<bool> result = dlg.ShowDialog();

                                // Get the selected file name and display in a TextBox 
                                if (result == true)
                                {
                                    // Open document 
                                    string filename = dlg.FileName;
                                    var _img = new Image();
                                    var _bitmap = new BitmapImage();
                                    _bitmap.BeginInit();
                                    _bitmap.UriSource = new Uri(filename);
                                    _bitmap.EndInit();
                                    _img.Width = 150;
                                    _img.Height = 150;
                                    _img.Stretch = Stretch.Fill;
                                    _img.Source = _bitmap;
                                    MainCanvas.Children.Add(_img);
                                    Canvas.SetLeft(_img, point.X);
                                    Canvas.SetTop(_img, point.Y);
                                }
                            }
                            catch (Exception ex)
                            {
                                throw new Exception(ex.Message);
                            }
                        }
                        break;
                }
                Mouse.OverrideCursor = null;
                m_draw_condition = false;
                m_toolbox_cond = Conditions.Default;
            }
            #endregion endif
            else
            {
            }
        }

        void _btn_Click(object sender, RoutedEventArgs e)
        {
            var _btn = sender as Button;
            var left = Canvas.GetLeft(_btn);
            var top = Canvas.GetTop(_btn);
            var _txtbox = new TextBox();
            var _rabiobtn = new RadioButton();
            var _dp = new DockPanel();

            _txtbox.Width = 100;
            _txtbox.Height = 25;
            _rabiobtn.VerticalAlignment = System.Windows.VerticalAlignment.Center;
            _dp.Children.Add(_rabiobtn);
            _dp.Children.Add(_txtbox);

            MainCanvas.Children.Add(_dp);
            Canvas.SetLeft(_dp, left);
            Canvas.SetTop(_dp, top);
            Canvas.SetLeft(_btn, left);
            Canvas.SetTop(_btn, top + 30);
        }

        void add_btn_click(object sender, RoutedEventArgs e)
        {
            var _btn = sender as Button;
            var left = Canvas.GetLeft(_btn);
            var top = Canvas.GetTop(_btn);
            var _txtbox = new TextBox();
            var _checkbox = new CheckBox();
            var _dp = new DockPanel();

            _txtbox.Width = 100;
            _txtbox.Height = 25;
            _checkbox.VerticalAlignment = System.Windows.VerticalAlignment.Center;
            _dp.Children.Add(_checkbox);
            _dp.Children.Add(_txtbox);

            MainCanvas.Children.Add(_dp);
            Canvas.SetLeft(_dp, left);
            Canvas.SetTop(_dp, top);
            Canvas.SetLeft(_btn, left);
            Canvas.SetTop(_btn, top + 30);
        }

        private void SaveSurveyClick(object sender, RoutedEventArgs e)
        {
            
            var dlg = new Microsoft.Win32.SaveFileDialog();
            SIO.Directory.CreateDirectory(System.AppDomain.CurrentDomain.BaseDirectory + "Surveys");
            dlg.FileName = "Опрос";
            dlg.DefaultExt = ".anktpro";
            dlg.Filter = "AnketaProSurvey documents (.anktpro)|*.anktpro";
            dlg.InitialDirectory = System.AppDomain.CurrentDomain.BaseDirectory + "Surveys\\";
            dlg.RestoreDirectory = true;
            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.NullValueHandling = NullValueHandling.Ignore;

                using (SIO.StreamWriter sw = new SIO.StreamWriter(dlg.FileName))
                using (JsonWriter writer = new JsonTextWriter(sw))
                {
                    
                    serializer.Serialize(writer, MainCanvas.Children[0]);
                }
            }
        }
    }
}
