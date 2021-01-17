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

        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9,]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void VolumenstromBerechnenButton_Click(object sender, RoutedEventArgs e)
        {
            //Druckabfall, Rohrdurchmesser, Rohrlänge, Geodätischer Höhenunterschied,Wandrauhigkeit,
            //Dichte, Viskosität und Druckverlustbeiwert der Einbauteile (Durchströmteile) -35%

            double rohrdurchmesserValue;
            double.TryParse(RohrdurchmesserTextBox.Text, out rohrdurchmesserValue);

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
