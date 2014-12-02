using System.Windows;
using System.Windows.Controls;

namespace AnketaProCustomControls
{
    public class ApOneFromSetQuestion : ApQuestionBase
    {
        #region Constructors

        static ApOneFromSetQuestion()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof (ApOneFromSetQuestion),
                new FrameworkPropertyMetadata(typeof (ApOneFromSetQuestion)));
        }

        #endregion

        #region Properties

        #endregion

        #region Events


        #endregion

        #region Methods

        private void AddButtonClick(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
        }

        #endregion
    }
}
