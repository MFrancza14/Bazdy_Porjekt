using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projektbazydanych.Models
{
    public class Kierowca
    {
        public int Id { get; set; }  // Klucz główny
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Pesel { get; set; }
        public string Telefon { get; set; }
    }
}
