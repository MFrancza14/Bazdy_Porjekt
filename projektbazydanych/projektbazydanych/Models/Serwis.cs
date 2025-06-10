using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projektbazydanych.Models
{
    public class Serwis
    {
        public int Id { get; set; }  // Klucz główny
        public string Pojazd { get; set; }
        public string Opis { get; set; }
        public string Data { get; set; }
        public double Koszt { get; set; }
    }
}
