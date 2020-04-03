using eDnevnik.data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeminarskiRS1.Model
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> x) : base(x)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<PredavaciPredmetiOdjeljenje>().HasKey(pp => new
            {
                pp.NastavnoOsobljeID,
                pp.PredmetiID,
                pp.odjeljenjeID

            });
      
            modelBuilder.Entity<SekcijeUcenici>().HasKey(su => new
            {
                su.skolskeSekcijeID,
                su.uceniciID
            });

            modelBuilder.Entity<UceniciOdjeljenje>().HasKey(su => new
            {
                su.odjeljenjeID,
                su.uceniciID
            });
            modelBuilder.Entity<SlusaPredmet>().HasKey(su => new
            {
                su.NastavnoOsobljeID,
                su.PredmetID,
                su.OdjeljenjeID,
                su.UceniciID
            });



        }

        public DbSet<NastavnoOsoblje> nastavnoOsoblje{ get; set; }
        public DbSet<Odjeljenje> odjeljenje { get; set; }
        public DbSet<OstaliPodaci> ostaliPodaci{ get; set; }
        public DbSet<PodaciRodjenje> podaciRodjenje { get; set; }
        public DbSet<PodaciStanovanje> podaciStanovanje { get; set; }
        public DbSet<PodaciZanimanje> podaciZanimanje { get; set; }
        public DbSet<PodaciZavrsniIspit> podaciZavrsniIspit{ get; set; }
        public DbSet<Porodica>  porodica{ get; set; }
        public DbSet<PredavaciPredmetiOdjeljenje> PredavaciPredmetiOdjeljenje { get; set; }
        public DbSet<Predmeti> predmeti{ get; set; }
        public DbSet<Roditelj> roditelj { get; set; }
        public DbSet<SekcijeUcenici> sekcijeUcenici { get; set; }
        public DbSet<SkolskaGodina> skolskaGodina { get; set; }
        public DbSet<SkolskeSekcije> skolskeSekcije { get; set; }
        public DbSet<StrucnaSprema> strucnaSprema{ get; set; }
        public DbSet<Ucenici> ucenici { get; set; }
        public DbSet<Zaposlenje> zaposlenje { get; set; }
        public DbSet<UceniciOdjeljenje> uceniciOdjeljenje{ get; set; }
        public DbSet<SlusaPredmet> slusaPredmet{ get; set; }
        public DbSet<Drzava> drzava{ get; set; }
        public DbSet<Grad> grad{ get; set; }
        public DbSet<OstaliPodaciNastavnoOsoblje> ostaliPodaciNastavnoOsoblje{ get; set; }
        public DbSet<Administrator> administrator{ get; set; }
        public DbSet<Login> login{ get; set; }
        public DbSet<AutorizacijskiToken> AutorizacijskiToken { get; set; }

    }
}
