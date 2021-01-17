using System.Windows;

namespace Stroema
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            PagesFrame.Content = new DruckverlustPage();
        }

        private void DruckverlustPageButton_Click(object sender, RoutedEventArgs e)
        {
            PagesFrame.Content = new DruckverlustPage();
        }

        private void VolumentstromPageButton_Click(object sender, RoutedEventArgs e)
        {
            PagesFrame.Content = new VolumenstromPage();
        }

        private void RohrdurchmesserPageButton_Click(object sender, RoutedEventArgs e)
        {
            PagesFrame.Content = new RohrdurchmesserPage();
        }

        private void AboutPageButton_Click(object sender, RoutedEventArgs e)
        {
            PagesFrame.Content = new  AboutPage();
        }
    }
}
