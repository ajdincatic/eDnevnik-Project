using eDnevnik.data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeminarskiRS1.Model
{
    public class PodaciStanovanje
    {
        public int PodaciStanovanjeID { get; set; }
        public Grad Grad { get; set; }
        public int GradID { get; set; }
        public Drzava Drzava { get; set; }
        public int DrzavaID { get; set; }
        public string Adresa { get; set; }
        public string OpćinaPrebivalista { get; set; }
        public string BrojTelefona { get; set; }
        public string Email { get; set; }
    }
}
