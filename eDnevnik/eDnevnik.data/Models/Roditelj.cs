using System;
using System.Collections.Generic;
using System.Text;

namespace SeminarskiRS1.Model
{
    public class Roditelj
    {
        public int RoditeljID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public StrucnaSprema StrucnaSprema { get; set; }
        public int StrucnaSpremaID { get; set; }
        public string Zanimanje { get; set; }
        public Zaposlenje Zaposlenje { get; set; }
        public int ZaposlenjeID { get; set; }
        public PodaciStanovanje PodaciStanovnaje{ get; set; }
        public int PodaciStanovanjeID { get; set; }
    }
}
