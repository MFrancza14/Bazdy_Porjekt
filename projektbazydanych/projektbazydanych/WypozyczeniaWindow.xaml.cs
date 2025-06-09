using System;
using System.Collections.Generic;
using System.Windows;

namespace projektbazydanych
{
    public partial class WypozyczeniaWindow : Window
    {
        public class Wypozyczenie
        {
            public string Klient { get; set; }
            public string Pojazd { get; set; }
            public string DataStart { get; set; }
            public int Czas { get; set; }
            public string Status { get; set; }
        }

        private List<Wypozyczenie> wypozyczenia = new List<Wypozyczenie>();

        public WypozyczeniaWindow()
        {
            InitializeComponent();

            wypozyczenia.Add(new Wypozyczenie
            {
                Klient = "Jan Kowalski",
                Pojazd = "Toyota Corolla",
                DataStart = "2025-06-01 10:00",
                Czas = 48,
                Status = "Aktywne"
            });

            wypozyczenia.Add(new Wypozyczenie
            {
                Klient = "Anna Nowak",
                Pojazd = "Ford Focus",
                DataStart = "2025-05-28 08:30",
                Czas = 72,
                Status = "Zakonczone"
            });

            WypozyczeniaGrid.ItemsSource = wypozyczenia;
        }

        private void DodajWypozyczenie_Click(object sender, RoutedEventArgs e)
        {
            wypozyczenia.Add(new Wypozyczenie
            {
                Klient = "Tymczasowy Klient",
                Pojazd = "Skoda Octavia",
                DataStart = DateTime.Now.ToString("yyyy-MM-dd HH:mm"),
                Czas = 24,
                Status = "Aktywne"
            });

            WypozyczeniaGrid.Items.Refresh();
        }
    }
}
