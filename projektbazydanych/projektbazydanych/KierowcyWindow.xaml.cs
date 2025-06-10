using System.Collections.Generic;
using projektbazydanych.Data;
using projektbazydanych.Models;
using System.Linq;
using System.Windows;

namespace projektbazydanych
{
    public partial class KierowcyWindow : Window
    {
        private WypozyczalniaContext db = new WypozyczalniaContext();

        public KierowcyWindow()
        {
            InitializeComponent();
            WczytajKierowcow();
        }

        private void WczytajKierowcow()
        {
            KierowcyGrid.ItemsSource = db.Kierowcy.ToList();
        }

        private void DodajKierowce_Click(object sender, RoutedEventArgs e)
        {
            var nowy = new Kierowca
            {
                Imie = "Tomasz",
                Nazwisko = "Zieliński",
                Pesel = "85032233444",
                Telefon = "555-123-777"
            };

            db.Kierowcy.Add(nowy);
            db.SaveChanges();
            WczytajKierowcow();
        }
        private void UsunRekord_Click(object sender, RoutedEventArgs e)
        {
            if (KierowcyGrid.SelectedItem is Kierowca selected)
            {
                var result = MessageBox.Show($"Czy usunąć kierowcę {selected.Imie} {selected.Nazwisko}?", "Potwierdzenie", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    db.Kierowcy.Remove(selected);
                    db.SaveChanges();
                    WczytajKierowcow();
                }
            }
            else
            {
                MessageBox.Show("Zaznacz kierowcę do usunięcia.");
            }
        }
    }
}