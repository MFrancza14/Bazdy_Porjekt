using System.Collections.Generic;
using System.Windows;

namespace projektbazydanych
{
    public partial class PojazdyWindow : Window
    {
        public class Pojazd
        {
            public string NumerRejestracyjny { get; set; }
            public string Marka { get; set; }
            public string Model { get; set; }
            public int RokProdukcji { get; set; }
            public string Status { get; set; }
        }

        private List<Pojazd> pojazdy = new List<Pojazd>();

        public PojazdyWindow()
        {
            InitializeComponent();

            // przykładowe dane
            pojazdy.Add(new Pojazd { NumerRejestracyjny = "SK12345", Marka = "Toyota", Model = "Corolla", RokProdukcji = 2018, Status = "Wolny" });
            pojazdy.Add(new Pojazd { NumerRejestracyjny = "KR98765", Marka = "Ford", Model = "Focus", RokProdukcji = 2020, Status = "Wypozyczony" });

            PojazdyGrid.ItemsSource = pojazdy;
        }

        private void DodajPojazd_Click(object sender, RoutedEventArgs e)
        {
            // dodanie przykładowego pojazdu
            pojazdy.Add(new Pojazd
            {
                NumerRejestracyjny = "WW00011",
                Marka = "Skoda",
                Model = "Octavia",
                RokProdukcji = 2022,
                Status = "Wolny"
            });

            PojazdyGrid.Items.Refresh();
        }

        private void UsunPojazd_Click(object sender, RoutedEventArgs e)
        {
            if (PojazdyGrid.SelectedItem is Pojazd selected)
            {
                if (MessageBox.Show($"Czy na pewno chcesz usunac pojazd {selected.Marka} {selected.Model}?",
                                    "Potwierdzenie",
                                    MessageBoxButton.YesNo,
                                    MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    pojazdy.Remove(selected);
                    PojazdyGrid.Items.Refresh();
                }
            }
            else
            {
                MessageBox.Show("Wybierz pojazd do usuniecia.", "Brak wyboru", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
