using System;
using projektbazydanych.Data;
using projektbazydanych.Models;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace projektbazydanych
{
    public partial class KlientWindow : Window
    {
        private WypozyczalniaContext db = new WypozyczalniaContext();

        private Pojazd aktywnyPojazd = null;
        private double aktywnyCzas;
        private double aktywnyKoszt;

        public KlientWindow()
        {
            InitializeComponent();

            PojazdyGrid.ItemsSource = db.Pojazdy.ToList();
            HistoriaGrid.ItemsSource = db.Wypozyczenia.ToList();
        }

        private void Wypozycz_Click(object sender, RoutedEventArgs e)
        {
            if (aktywnyPojazd != null)
            {
                MessageBox.Show("Najpierw zakończ aktualne wypożyczenie.");
                return;
            }

            if (PojazdyGrid.SelectedItem is Pojazd selected && selected.Status == "Wolny")
            {
                if (double.TryParse(CzasTextBox.Text, out double czas))
                {
                    double koszt = czas * selected.CenaZaGodzine;

                    PodsumowanieTextBlock.Text = $"Model: {selected.Model}, Czas: {czas} h, Koszt: {koszt} zł";

                    selected.Status = "Wypozyczony";
                    db.Pojazdy.Update(selected);

                    aktywnyPojazd = selected;
                    aktywnyCzas = czas;
                    aktywnyKoszt = koszt;

                    db.SaveChanges();
                    PojazdyGrid.ItemsSource = db.Pojazdy.ToList();
                    ZakonczBtn.IsEnabled = true;
                }
                else
                {
                    MessageBox.Show("Wprowadź poprawny czas (liczba).");
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
                db.Pojazdy.Update(aktywnyPojazd);

                db.Wypozyczenia.Add(new Wypozyczenie
                {
                    Klient = "Użytkownik", // Można rozbudować o logowanie
                    Pojazd = aktywnyPojazd.Model,
                    DataStart = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm"),
                    Czas = (int)aktywnyCzas,
                    Status = "Zakonczone",
                    Koszt = aktywnyKoszt
                });

                db.SaveChanges();

                PodsumowanieTextBlock.Text = "";
                PojazdyGrid.ItemsSource = db.Pojazdy.ToList();
                HistoriaGrid.ItemsSource = db.Wypozyczenia.ToList();

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