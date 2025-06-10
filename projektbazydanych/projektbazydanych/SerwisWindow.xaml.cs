using System;
using System.Collections.Generic;
using projektbazydanych.Data;
using projektbazydanych.Models;
using System;
using System.Linq;
using System.Windows;

namespace projektbazydanych
{
    public partial class SerwisWindow : Window
    {
        private WypozyczalniaContext db = new WypozyczalniaContext();

        public SerwisWindow()
        {
            InitializeComponent();
            WczytajSerwisy();
        }

        private void WczytajSerwisy()
        {
            SerwisGrid.ItemsSource = db.Serwisy.ToList();
        }

        private void DodajSerwis_Click(object sender, RoutedEventArgs e)
        {
            var nowy = new Serwis
            {
                Pojazd = "Skoda Octavia",
                Opis = "Przegląd techniczny",
                Data = DateTime.Now.ToString("yyyy-MM-dd"),
                Koszt = 300.00
            };

            db.Serwisy.Add(nowy);
            db.SaveChanges();
            WczytajSerwisy();
        }
        private void UsunRekord_Click(object sender, RoutedEventArgs e)
        {
            if (SerwisGrid.SelectedItem is Serwis selected)
            {
                var result = MessageBox.Show($"Czy usunąć serwis pojazdu {selected.Pojazd}?", "Potwierdzenie", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    db.Serwisy.Remove(selected);
                    db.SaveChanges();
                    WczytajSerwisy();
                }
            }
            else
            {
                MessageBox.Show("Zaznacz rekord do usunięcia.");
            }
        }
    }
}