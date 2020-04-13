using System;
using System.Collections.Generic;
using System.Text;

namespace SeminarskiRS1.Model
{
    public class OstaliPodaci
    {
        public int OstaliPodaciID { get; set; }
        public Porodica Porodica { get; set; }
        public int PorodicaID { get; set; }
        public string Drzavljanstvo { get; set; }
        public string Nacionalnost { get; set; }
    }
}
