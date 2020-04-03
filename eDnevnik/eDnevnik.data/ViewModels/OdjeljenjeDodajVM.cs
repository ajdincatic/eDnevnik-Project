using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace eDnevnik.data.ViewModels
{
    public class OdjeljenjeDodajVM
    {
        public int OdjeljenjeID { get; set; }
        public int Razred { get; set; }
        public string Oznaka { get; set; }
        public string Opis { get; set; }
        public int RazrednikID { get; set; }
        public List<SelectListItem> Nastavnici { get; set; }
        public int PredsjenikID { get; set; }
        public List<SelectListItem> Ucenici { get; set; }
        public int BlagajnikID { get; set; }
        public int SkolskaGodinaID { get; set; }
        public List<SelectListItem> SkolskeGodine { get; set; }
        public string SkolskaGodina{ get; set; }
        public string Smjena { get; set; }

    }
}
