using System;
using System.Collections.Generic;
using System.Windows;

namespace projektbazydanych
{
    public partial class KlientWindow : Window
    {
        // Klasa pojazdu
        public class Pojazd
        {
            public string Model { get; set; }
            public int Rok { get; set; }
            public double CenaZaGodzine { get; set; }
            public string Status { get; set; }
        }

        // Klasa historii wypożyczeń
        public class Wypozyczenie
        {
            public string Model { get; set; }
            public double Czas { get; set; }
            public double Koszt { get; set; }
        }

        private List<Pojazd> pojazdy = new List<Pojazd>();
        private List<Wypozyczenie> historia = new List<Wypozyczenie>();

        // aktywne wypożyczenie
        private Pojazd aktywnyPojazd = null;
        private double aktywnyCzas;
        private double aktywnyKoszt;

        public KlientWindow()
        {
            InitializeComponent();

            // przykładowe dane pojazdów
            pojazdy.Add(new Pojazd { Model = "Toyota Corolla", Rok = 2020, CenaZaGodzine = 20, Status = "Wolny" });
            pojazdy.Add(new Pojazd { Model = "Ford Focus", Rok = 2019, CenaZaGodzine = 18, Status = "Wolny" });
            pojazdy.Add(new Pojazd { Model = "Skoda Octavia", Rok = 2022, CenaZaGodzine = 25, Status = "Wypozyczony" });

            PojazdyGrid.ItemsSource = pojazdy;
        }

        private void Wypozycz_Click(object sender, RoutedEventArgs e)
        {
            if (aktywnyPojazd != null)
            {
                MessageBox.Show("Najpierw zakoncz aktualne wypozyczenie.");
                return;
            }

            if (PojazdyGrid.SelectedItem is Pojazd selected && selected.Status == "Wolny")
            {
                if (double.TryParse(CzasTextBox.Text, out double czas))
                {
                    double koszt = czas * selected.CenaZaGodzine;
                    PodsumowanieTextBlock.Text = $"Model: {selected.Model}, Czas: {czas} h, Koszt: {koszt} zl";

                    selected.Status = "Wypozyczony";
                    aktywnyPojazd = selected;
                    aktywnyCzas = czas;
                    aktywnyKoszt = koszt;

                    PojazdyGrid.Items.Refresh();
                    ZakonczBtn.IsEnabled = true;
                }
                else
                {
                    MessageBox.Show("Wprowadz poprawny czas (liczba).");
                }
            }
            else
            {
                MessageBox.Show("Wybierz pojazd ze statusem 'Wolny'.");
            }
        }

        private void Zakoncz_Click(object sender, RoutedEventArgs e)
        {
            if (aktywnyPojazd != null)
            {
                aktywnyPojazd.Status = "Wolny";
                historia.Add(new Wypozyczenie
                {
                    Model = aktywnyPojazd.Model,
                    Czas = aktywnyCzas,
                    Koszt = aktywnyKoszt
                });

                PodsumowanieTextBlock.Text = "";
                PojazdyGrid.Items.Refresh();

                HistoriaGrid.ItemsSource = null;
                HistoriaGrid.ItemsSource = historia;

                aktywnyPojazd = null;
                aktywnyCzas = 0;
                aktywnyKoszt = 0;
                ZakonczBtn.IsEnabled = false;
            }
        }

        private void Wyloguj_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }
    }
}