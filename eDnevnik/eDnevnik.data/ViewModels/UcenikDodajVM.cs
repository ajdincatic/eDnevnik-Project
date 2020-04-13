using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace eDnevnik.data.ViewModels
{
    public class UcenikDodajVM
    {
        public int UcenikID { get; set; }
        //ucenik osnovni podaci
        public string Ime { get; set; }
        public string ImeRoditelja { get; set; }
        public string Prezime { get; set; }
        public string Pol { get; set; }
        public string JMBG { get; set; }
        public DateTime DatumUpisa { get; set; }
        // uceknik podaci rodjenje
        public DateTime DatumRodjenja { get; set; }
        public string OpćinaRodjenja { get; set; }
        public int GradRodjenjaID { get; set; }
        public int DrzavaRodjenjaID { get; set; }
        // ucenik podaci stanovanje
        public int GradStanovanjaID { get; set; }
        public int DrzavaStanovanjaID { get; set; }
        public string Adresa { get; set; }
        public string OpćinaPrebivalista { get; set; }
        public string BrojTelefona { get; set; }
        public string Email { get; set; }
        // ucenik ostali podaci
        public string Drzavljanstvo { get; set; }
        public string Nacionalnost { get; set; }
        public int PorodicaID { get; set; }

        public List<SelectListItem> Gradovi { get; set; }
        public List<SelectListItem> Drzave { get; set; }
        public List<SelectListItem> Porodica { get; set; }
        // podaci razrednik
        public int RazrednikID { get; set; }
        public int BrojUDenvniku { get; set; }

        //public PodaciZavrsniIspit? ZavrsniIspit { get; set; }
        //public int? ZavrsniIspitID { get; set; }
    }
}
