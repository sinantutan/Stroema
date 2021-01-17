using System;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using Stroemung;

namespace Stroema
{
    /// <summary>
    /// Interaktionslogik für DruckverlustPage.xaml
    /// </summary>
    public partial class DruckverlustPage : Page
    {
        public DruckverlustPage()
        {
            InitializeComponent();


        }



        private void DichteTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9,]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void DruckverlustBerechnenButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            double volumenstromValue;
            double.TryParse(VolumenstromTextBox.Text,out volumenstromValue);
            volumenstromValue = volumenstromValue / 3600;

            double rohrdurchmesserValue;
            double.TryParse(RohrdurchmesserTextBox.Text, out rohrdurchmesserValue);

            double rohrLaengeValue;
            double.TryParse(RohrlaengeTextBox.Text, out rohrLaengeValue);

            double wandrauhigkeitValue;
            double.TryParse(WandrauhigkeitTextBox.Text, out wandrauhigkeitValue);
            wandrauhigkeitValue = wandrauhigkeitValue / 1000000;

            double geoHohenunterschiedValue;
            double.TryParse(GHohenunterschiedTextBox.Text, out geoHohenunterschiedValue);

            double dichteValue;
            double.TryParse(DichteTextBox.Text, out dichteValue);

            double viskositaetValue;
            double.TryParse(ViskositaetTextBox.Text, out viskositaetValue);
            viskositaetValue = viskositaetValue * 1E-06;

            double druckverlustBeiwertValue;
            double.TryParse(DruckverlustbeiwertTextBox.Text, out druckverlustBeiwertValue);

            Druckverlust druckverlust = new Druckverlust(volumenstromValue, rohrdurchmesserValue, rohrLaengeValue, wandrauhigkeitValue, geoHohenunterschiedValue,dichteValue, viskositaetValue,druckverlustBeiwertValue);

            DruckverlustErgebnisTextBox.Text = druckverlust.value.ToString();
        }
    }
}
