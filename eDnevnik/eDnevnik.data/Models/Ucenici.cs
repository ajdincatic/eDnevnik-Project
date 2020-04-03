using System;
using System.Collections.Generic;
using System.Text;

namespace SeminarskiRS1.Model
{
    public class Ucenici
    {

        public int UceniciID { get; set; }
        public string Ime  { get; set; }
        public string ImeRoditelja { get; set; }
        public string Prezime  { get; set; }
        public string Pol { get; set; }
        public string JMBG { get; set; }
        public DateTime DatumUpisa { get; set; }
        public PodaciRodjenje PodaciRodjenje { get; set; }
        public int PodaciRodjenjeID { get; set; }
        public PodaciStanovanje PodaciStanovnaje { get; set; }
        public int PodaciStanovanjeID { get; set; }
        public OstaliPodaci OstaliPodaci { get; set; }
        public int OstaliPodaciID { get; set; }
        public PodaciZavrsniIspit ZavrsniIspit{ get; set; }
        public int? ZavrsniIspitID { get; set; }

    }
}
