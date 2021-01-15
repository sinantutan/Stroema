using System.Windows.Controls;

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

            DruckverlustBerechnenButton.IsEnabled = false;
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
    }
}
