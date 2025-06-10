using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using projektbazydanych.Models;

namespace projektbazydanych.Data
{
    public class WypozyczalniaContext : DbContext
    {
        public DbSet<Pojazd> Pojazdy { get; set; }
        public DbSet<Kierowca> Kierowcy { get; set; }
        public DbSet<Serwis> Serwisy { get; set; }
        public DbSet<Wypozyczenie> Wypozyczenia { get; set; }
        public DbSet<KontoPracownika> KontaPracownikow { get; set; }
        public DbSet<KontoKlienta> KontaKlientow { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Wypozyczalnia;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False;");
        }
    }
}
