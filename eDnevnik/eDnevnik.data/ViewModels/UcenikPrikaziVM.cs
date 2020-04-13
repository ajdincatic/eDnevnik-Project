using System;
using System.Collections.Generic;
using System.Text;

namespace eDnevnik.data.ViewModels
{
    public class UcenikPrikaziVM
    {
        public int UceniciID { get; set; }
        public string Ime { get; set; }
        public string ImeRoditelja { get; set; }
        public string Prezime { get; set; }
        public string Pol { get; set; }
        public string JMBG { get; set; }
        public int BrojUDnevniku { get; set; }
    }
}
