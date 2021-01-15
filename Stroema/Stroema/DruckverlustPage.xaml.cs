using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

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



        private double _bezugsGeschwindigkeit;

        private double _volumenstrom;

        private double _durchmesser;

        private double _reynoldsZahl;

        private double _rohrreibungsbeiwert;

        private double _druckdifferenz;

        private double _dichte;

        private void DichteTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9.]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        
    }
}
