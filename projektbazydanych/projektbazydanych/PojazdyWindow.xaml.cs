using System.Collections.Generic;
using System.Windows;
using projektbazydanych.Data;
using projektbazydanych.Models;
using System.Linq;

namespace projektbazydanych
{
    public partial class PojazdyWindow : Window
    {
        private WypozyczalniaContext db = new WypozyczalniaContext();

        public PojazdyWindow()
        {
            InitializeComponent();
            WczytajPojazdy();
        }

        private void WczytajPojazdy()
        {
            PojazdyGrid.ItemsSource = db.Pojazdy.ToList();
        }

        private void DodajPojazd_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(RokTextBox.Text, out int rok) || !double.TryParse(CenaTextBox.Text, out double cena))
            {
                MessageBox.Show("Wprowadź poprawne dane liczbowe (rok, cena).");
                return;
            }

            var nowy = new Pojazd
            {
                NumerRejestracyjny = RejTextBox.Text,
                Marka = MarkaTextBox.Text,
                Model = ModelTextBox.Text,
                RokProdukcji = rok,
                Status = StatusTextBox.Text,
                CenaZaGodzine = cena
            };

            db.Pojazdy.Add(nowy);
            db.SaveChanges();

            WczytajPojazdy(); // odświeżenie widoku
        }

        private void UsunPojazd_Click(object sender, RoutedEventArgs e)
        {
            if (PojazdyGrid.SelectedItem is Pojazd selected)
            {
                var result = MessageBox.Show($"Czy na pewno chcesz usunąć {selected.Marka} {selected.Model}?",
                                             "Potwierdzenie",
                                             MessageBoxButton.YesNo,
                                             MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    db.Pojazdy.Remove(selected);
                    db.SaveChanges();
                    WczytajPojazdy();
                }
            }
            else
            {
                MessageBox.Show("Zaznacz pojazd do usunięcia.", "Brak wyboru", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}