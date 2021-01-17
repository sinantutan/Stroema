using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Input;

namespace Stroema
{
    /// <summary>
    /// Interaktionslogik für RohrdurchmesserPage.xaml
    /// </summary>
    public partial class RohrdurchmesserPage : Page
    {
        public RohrdurchmesserPage()
        {
            InitializeComponent();

            RohrdurchmesserBerechnenButton.IsEnabled = false;
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9,]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void RohrdurchmesserBerechnenButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            double volumenstromValue;
            double.TryParse(VolumenstromTextBox.Text, out volumenstromValue);

            
        }
    }
}
