using Microsoft.EntityFrameworkCore;
using SignalDataApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SignalDataApp.Data
{
    public class SignalDataDBContext : DbContext
    {
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Signal> Signals { get; set; }
        public DbSet<SignalValue> SignalValues { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(@"Data Source=DESKTOP-C58154B;Initial Catalog=SignalDataDB3;Integrated Security=True");
        }
    }
}
