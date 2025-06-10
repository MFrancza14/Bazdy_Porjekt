using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projektbazydanych.Models
{
    public class Pojazd
    {
        public int Id { get; set; } // Klucz główny
        public string NumerRejestracyjny { get; set; }
        public string Marka { get; set; }
        public string Model { get; set; }
        public int RokProdukcji { get; set; }
        public string Status { get; set; }
        public double CenaZaGodzine { get; set; }

    }
}
