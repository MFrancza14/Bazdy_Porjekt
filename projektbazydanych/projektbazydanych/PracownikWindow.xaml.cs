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
            pojazdyWindow.ShowDialog();
        }

        private void OtworzWypozyczenia_Click(object sender, RoutedEventArgs e)
        {
            WypozyczeniaWindow win = new WypozyczeniaWindow();
            win.ShowDialog();
        }

        private void OtworzSerwis_Click(object sender, RoutedEventArgs e)
        {
            SerwisWindow serwisWindow = new SerwisWindow();
            serwisWindow.ShowDialog();
        }
        private void OtworzKierowcow_Click(object sender, RoutedEventArgs e)
        {
            KierowcyWindow kierowcyWindow = new KierowcyWindow();
            kierowcyWindow.ShowDialog();
        }
        private void Wyloguj_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }


    }
}
