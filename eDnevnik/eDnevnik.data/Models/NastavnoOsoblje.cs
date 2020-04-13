using eDnevnik.data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace SeminarskiRS1.Model
{
    public class NastavnoOsoblje
    {
        public int NastavnoOsobljeID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string ImeRoditelja { get; set; }
        public string Pol { get; set; }
        public string JMBG { get; set; }
        public PodaciRodjenje PodaciRodjenje { get; set; }
        public int PodaciRodjenjeID { get; set; }
        public PodaciStanovanje PodaciStanovanje { get; set; }
        public int PodaciStanovanjeID { get; set; }
        public OstaliPodaciNastavnoOsoblje OstaliPodaciNastavnoOsoblje { get; set; }
        public int OstaliPodaciNastavnoOsobljeID { get; set; }
        public int podaciZanimanjeID { get; set; }
        public PodaciZanimanje podaciZanimanje { get; set; }
        [ForeignKey(nameof(Login))]
        public int? LoginID { get; set; }
        public Login login { get; set; }
        public string PhotoPath { get; set; }
        public string NppFilePath { get; set; }
    }
}
