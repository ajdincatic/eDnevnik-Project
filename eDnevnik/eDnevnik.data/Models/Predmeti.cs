using System;
using System.Collections.Generic;
using System.Text;

namespace SeminarskiRS1.Model
{
    public class Predmeti
    {
        public int PredmetiID { get; set; }
        public string Naziv { get; set; }
        public NastavnoOsoblje Predavac { get; set; }
        public int PredavacID { get; set; }
        public string Razred { get; set; }
        public bool Izborni { get; set; }
        public string PhotoPath { get; set; }
    }
}
