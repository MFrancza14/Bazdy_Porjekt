using projektbazydanych.Data;
using projektbazydanych.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows;

namespace projektbazydanych
{
    public partial class WypozyczeniaWindow : Window
    {
        private WypozyczalniaContext db = new WypozyczalniaContext();

        public WypozyczeniaWindow()
        {
            InitializeComponent();
            WczytajWypozyczenia();
        }

        private void WczytajWypozyczenia()
        {
            WypozyczeniaGrid.ItemsSource = db.Wypozyczenia.ToList();
        }

        private void DodajWypozyczenie_Click(object sender, RoutedEventArgs e)
        {
            var nowe = new Wypozyczenie
            {
                Klient = "Tymczasowy Klient",
                Pojazd = "Skoda Octavia",
                DataStart = DateTime.Now.ToString("yyyy-MM-dd HH:mm"),
                Czas = 24,
                Status = "Aktywne"
            };

            db.Wypozyczenia.Add(nowe);
            db.SaveChanges();
            WczytajWypozyczenia();
        }
        private void UsunRekord_Click(object sender, RoutedEventArgs e)
        {
            if (WypozyczeniaGrid.SelectedItem is Wypozyczenie selected)
            {
                var result = MessageBox.Show($"Czy usunąć wypożyczenie pojazdu {selected.Pojazd}?", "Potwierdzenie", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    db.Wypozyczenia.Remove(selected);
                    db.SaveChanges();
                    WczytajWypozyczenia();
                }
            }
            else
            {
                MessageBox.Show("Zaznacz rekord do usunięcia.");
            }
        }
    }
}
