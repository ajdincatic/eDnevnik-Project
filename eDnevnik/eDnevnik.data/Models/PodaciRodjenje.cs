using eDnevnik.data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeminarskiRS1.Model
{
   public class PodaciRodjenje
    {
        public int PodaciRodjenjeID { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public string OpćinaRođenja { get; set; }
        public Grad Grad { get; set; }
        public int GradID { get; set; }
        public Drzava Drzava { get; set; }
        public int DrzavaID { get; set; }
    }
}
