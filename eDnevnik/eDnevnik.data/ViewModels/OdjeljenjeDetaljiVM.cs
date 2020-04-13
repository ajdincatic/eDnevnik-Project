using System;
using System.Collections.Generic;
using System.Text;

namespace eDnevnik.data.ViewModels
{
    public class OdjeljenjeDetaljiVM
    {
        public int OdjeljenjeID { get; set; }
        public int Razred { get; set; }
        public string Oznaka { get; set; }
        public string Opis { get; set; }
        public string Razrednik { get; set; }
        public int RazrednikID { get; set; }
        public string Predsjednik { get; set; }
        public string Blagajnik { get; set; }
        public string SkolskaGodina { get; set; }
        public string Smjena { get; set; }

    }
}
