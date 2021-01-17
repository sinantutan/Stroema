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
            volumenstromValue = volumenstromValue / 3600;

            double druckverlustValue;
            double.TryParse(DruckverlustTextBox.Text, out druckverlustValue);
            druckverlustValue = druckverlustValue * 1E5;

            double rohrlaengeValue;
            double.TryParse(RohrlaengeTextBox.Text, out rohrlaengeValue);

            double gHohenunterschiedValue;
            double.TryParse(GHohenunterschiedTextBox.Text, out gHohenunterschiedValue);

            double wandrauhigkeitValue;
            double.TryParse(WandrauhigkeitTextBox.Text, out wandrauhigkeitValue);
            wandrauhigkeitValue = wandrauhigkeitValue / 1000000;

            double dichteValue;
            double.TryParse(DichteTextBox.Text, out dichteValue);

            double viskositaetValue;
            double.TryParse(ViskositaetTextBox.Text, out viskositaetValue);
            viskositaetValue = viskositaetValue * 1E-06;

            double druckverlustbeiwertValue;
            double.TryParse(DruckverlustbeiwertTextBox.Text, out druckverlustbeiwertValue);


        }
    }
}
