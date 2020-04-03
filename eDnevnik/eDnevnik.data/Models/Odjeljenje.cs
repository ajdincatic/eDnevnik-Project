using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SeminarskiRS1.Model
{
    public class Odjeljenje
    {
        public int OdjeljenjeID { get; set; }
        public int Razred { get; set; }
        public string Oznaka { get; set; }
        public string Opis { get; set; }
        public NastavnoOsoblje Razrednik { get; set; }
        public int RazrednikID { get; set; }
        public int PredsjednikID { get; set; }
        public Ucenici Predsjednik { get; set; }
        public int BlagajnikID { get; set; }
        public Ucenici Blagajnik { get; set; }
        public string Smjena { get; set; }
        public SkolskaGodina skolskaGodina { get; set; }
        public int skolskaGodinaID { get; set; }
    }
}
