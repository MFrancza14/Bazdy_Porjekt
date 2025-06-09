using System;
using System.Collections.Generic;
using System.Windows;

namespace projektbazydanych
{
    public partial class SerwisWindow : Window
    {
        public class Serwis
        {
            public string Pojazd { get; set; }
            public string Opis { get; set; }
            public string Data { get; set; }
            public double Koszt { get; set; }
        }

        private List<Serwis> serwisy = new List<Serwis>();

        public SerwisWindow()
        {
            InitializeComponent();

            // Przykładowe dane
            serwisy.Add(new Serwis
            {
                Pojazd = "Toyota Corolla",
                Opis = "Wymiana oleju i filtrów",
                Data = "2025-05-15",
                Koszt = 450.00
            });

            serwisy.Add(new Serwis
            {
                Pojazd = "Ford Focus",
                Opis = "Naprawa układu hamulcowego",
                Data = "2025-06-01",
                Koszt = 820.00
            });

            SerwisGrid.ItemsSource = serwisy;
        }

        private void DodajSerwis_Click(object sender, RoutedEventArgs e)
        {
            serwisy.Add(new Serwis
            {
                Pojazd = "Skoda Octavia",
                Opis = "Przegląd techniczny",
                Data = DateTime.Now.ToString("yyyy-MM-dd"),
                Koszt = 300.00
            });

            SerwisGrid.Items.Refresh();
        }
    }
}
