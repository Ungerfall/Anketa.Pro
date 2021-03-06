﻿using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using AnketaSurvey;
using Microsoft.Win32;

namespace AnketaPro.View
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
            var mainPanelBorder = toolBar.Template.FindName("MainPanelBorder", toolBar) as FrameworkElement;
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
            var question = new TextBox
            {
                Name = "Text",
                Text = "Вопрос",
                AcceptsReturn = true,
                Margin = new Thickness(0, 5, 0, 5)
            };
            MainStackPanel.Children.Add(question);
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
                Text = "Вопрос",
                AcceptsReturn = true
            };
            var radio = new RadioButton {VerticalAlignment = VerticalAlignment.Center};
            var answer = new TextBox {AcceptsReturn = true};
            var addvariant = new Button {Content = "Добавить вариант", HorizontalAlignment = HorizontalAlignment.Center};
            addvariant.Click += (o, args) =>
            {
                var button = (Button) o;
                var currentrow = Grid.GetRow(button);
                grid.RowDefinitions.Add(new RowDefinition());
                var newradio = new RadioButton {VerticalAlignment = VerticalAlignment.Center};
                var newanswer = new TextBox {AcceptsReturn = true};
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
            grid.ColumnDefinitions.Add(new ColumnDefinition {Width = GridLength.Auto});
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.RowDefinitions.Add(new RowDefinition());
            grid.RowDefinitions.Add(new RowDefinition());
            grid.RowDefinitions.Add(new RowDefinition());
            var question = new TextBox
            {
                Text = "Вопрос",
                AcceptsReturn = true
            };
            var check = new CheckBox {VerticalAlignment = VerticalAlignment.Center};
            var answer = new TextBox {AcceptsReturn = true};
            var addvariant = new Button {Content = "Добавить вариант", HorizontalAlignment = HorizontalAlignment.Center};
            addvariant.Click += (o, args) =>
            {
                var button = (Button) o;
                var currentrow = Grid.GetRow(button);
                grid.RowDefinitions.Add(new RowDefinition());
                var newcheck = new CheckBox {VerticalAlignment = VerticalAlignment.Center};
                var newanswer = new TextBox {AcceptsReturn = true};
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
                var dlg = new OpenFileDialog
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
            MainStackPanel.Children.Add(rectangle);
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            MainStackPanel.Children.Clear();
        }

        private void SaveSurveyClick(object sender, RoutedEventArgs e)
        {
            var dlg = new SaveFileDialog
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
            /*var serial = ApSerializer.Serialize(MainStackPanel.Children);
            using (var sw = new StreamWriter(dlg.FileName, false, Encoding.UTF8))
                sw.Write(serial);*/
        }

        private void CallAnketaSurvey(object sender, RoutedEventArgs e)
        {
            var survey = new AnketaSurveyMainWindow();
            survey.ShowDialog();
        }
    }
}
