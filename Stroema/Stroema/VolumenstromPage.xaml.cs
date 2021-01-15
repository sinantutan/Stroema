using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Stroema
{
    /// <summary>
    /// Interaktionslogik für VolumenstromPage.xaml
    /// </summary>
    public partial class VolumenstromPage : Page
    {
        public VolumenstromPage()
        {
            InitializeComponent();

            VolumenstromBerechnenButton.IsEnabled = false;

        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9.]+");
            e.Handled = regex.IsMatch(e.Text);
        }


    }
}
