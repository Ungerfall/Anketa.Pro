﻿using System;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using AnketaProSerializer;

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
                ApSerializer.Deserialize(ref AsMainStackPanel, sr.ReadToEnd(), DeserializeType.Survey);
            }
        }
    }
}