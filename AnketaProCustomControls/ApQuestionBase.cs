﻿using System.Windows;
using System.Windows.Controls;

namespace AnketaProCustomControls
{
    public class ApQuestionBase : TextBox
    {
        public static readonly DependencyProperty AnketaModeProperty = DependencyProperty.Register(
           "AnketaMode", typeof(AnketaMode), typeof(ApQuestionBase), new PropertyMetadata(AnketaMode.Constructor));

        public AnketaMode AnketaMode
        {
            get { return (AnketaMode)GetValue(AnketaModeProperty); }
            set { SetValue(AnketaModeProperty, value); }
        }

        private static readonly DependencyProperty IsMouseDoubleClickProperty = DependencyProperty.Register(
            "IsMouseDoubleClick", typeof(bool), typeof(ApQuestionBase), new PropertyMetadata(false));

        public bool IsMouseDoubleClick
        {
            get { return (bool) GetValue(IsMouseDoubleClickProperty); }
            set { SetValue(IsMouseDoubleClickProperty, value); }
        }

        public static readonly DependencyProperty ApMarginProperty = DependencyProperty.Register(
            "ApMargin", typeof(Thickness), typeof(ApQuestionBase), new PropertyMetadata(default(Thickness)));

        public Thickness ApMargin
        {
            get { return (Thickness)GetValue(ApMarginProperty); }
            set { SetValue(ApMarginProperty, value); }
        }
    }
}