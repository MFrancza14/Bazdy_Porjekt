using System.Windows;

namespace projektbazydanych
{
    public partial class PracownikWindow : Window
    {
        public PracownikWindow()
        {
            InitializeComponent();
        }

        private void OtworzPojazdy_Click(object sender, RoutedEventArgs e)
        {
            PojazdyWindow pojazdyWindow = new PojazdyWindow();
            pojazdyWindow.Show();
        }

        private void OtworzWypozyczenia_Click(object sender, RoutedEventArgs e)
        {
            WypozyczeniaWindow win = new WypozyczeniaWindow();
            win.Show();
        }

        private void OtworzSerwis_Click(object sender, RoutedEventArgs e)
        {
            SerwisWindow serwisWindow = new SerwisWindow();
            serwisWindow.Show();
        }
        private void OtworzKierowcow_Click(object sender, RoutedEventArgs e)
        {
            KierowcyWindow kierowcyWindow = new KierowcyWindow();
            kierowcyWindow.Show();
        }


    }
}
