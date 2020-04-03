using System;
using System.Collections.Generic;
using System.Text;
using X.PagedList;


namespace eDnevnik.data.ViewModels
{
    public class OdjeljenjePrikaziVM
    {
        public int OdjeljenjeID { get; set; }
        public int Razred { get; set; }
        public string Oznaka { get; set; }
        public string Razrednik { get; set; }
        public string SkolskaGodina { get; set; }
        public string Smjena { get; set; }

    }
}
