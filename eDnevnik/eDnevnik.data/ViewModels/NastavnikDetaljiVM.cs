using System;
using System.Collections.Generic;
using System.Text;

namespace eDnevnik.data.ViewModels
{
    public class NastavnikDetaljiVM
    {
        public int NastavnoOsobljeId { get; set; }
        public string Ime { get;  set; }
        public string Prezime { get; set; }
        public string ImeRoditelja { get; set; }
        public string Pol { get; set; }
        public string JMBG { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public string OpcinaRodjenja { get; set; }
        public string NazivMjestaRodjenja { get; set; }
        public string NazivDrzaveRodjenja { get; set; }
        public string NazivMjestaStanovanja { get; set; }
        public string NazivDrzaveStanovanja { get; set; }
        public string AdresaStanovanja { get; set; }
        public string OpcinaStanovanja { get; set; }
        public string BrojTelefona { get; set; }
        public string Email { get; set; }
        public string Drzavljanstvo { get; set; }
        public string Nacionalnost { get; set; }
        public string ZavrsenaSkola { get; set; }
        public string Fakultet { get; set; }
        public string ZavrsenoZanimanje { get; set; }
        public string BrojDiplome { get; set; }
        public string StrucnaSprema { get; set; }
        public bool PosjedujeDrzavniIspit { get; set; }
        public string PhotoPath { get; set; }
    }
}
