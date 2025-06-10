using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projektbazydanych.Models
{
    public class Wypozyczenie
    {
        public int Id { get; set; }  // Klucz główny
        public string Klient { get; set; }
        public string Pojazd { get; set; }
        public string DataStart { get; set; }
        public int Czas { get; set; }
        public string Status { get; set; }
        public double Koszt { get; set; }

    }
}
