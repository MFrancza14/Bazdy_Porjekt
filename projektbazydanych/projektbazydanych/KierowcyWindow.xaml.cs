using System.Collections.Generic;
using System.Windows;

namespace projektbazydanych
{
    public partial class KierowcyWindow : Window
    {
        public class Kierowca
        {
            public string Imie { get; set; }
            public string Nazwisko { get; set; }
            public string Pesel { get; set; }
            public string Telefon { get; set; }
        }

        private List<Kierowca> kierowcy = new List<Kierowca>();

        public KierowcyWindow()
        {
            InitializeComponent();

            kierowcy.Add(new Kierowca
            {
                Imie = "Jan",
                Nazwisko = "Kowalski",
                Pesel = "90010112345",
                Telefon = "123-456-789"
            });

            kierowcy.Add(new Kierowca
            {
                Imie = "Anna",
                Nazwisko = "Nowak",
                Pesel = "88051267890",
                Telefon = "987-654-321"
            });

            KierowcyGrid.ItemsSource = kierowcy;
        }

        private void DodajKierowce_Click(object sender, RoutedEventArgs e)
        {
            kierowcy.Add(new Kierowca
            {
                Imie = "Tomasz",
                Nazwisko = "Zielinski",
                Pesel = "85032233444",
                Telefon = "555-123-777"
            });

            KierowcyGrid.Items.Refresh();
        }
    }
}
