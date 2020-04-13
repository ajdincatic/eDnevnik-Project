using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SeminarskiRS1.Model
{
    public class Administrator
    {
        public int AdministratorID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Pol { get; set; }
        public string JMBG { get; set; }
        public PodaciStanovanje podaciStanovanje { get; set; }
        public int podaciStanovanjeID { get; set; }
        public PodaciRodjenje PodaciRodjenje { get; set; }
        public int PodaciRodjenjeID { get; set; }
        public StrucnaSprema StrucnaSprema { get; set; }
        public int StrucnaSpremaID { get; set; }
        [ForeignKey(nameof(Login))]

        public int? LoginID { get; set; }
        public Login login { get; set; }
    }
}
