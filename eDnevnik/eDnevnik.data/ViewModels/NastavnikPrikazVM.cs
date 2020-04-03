using System;
using System.Collections.Generic;
using System.Text;
using X.PagedList;

namespace eDnevnik.data.ViewModels
{
    public class NastavnikPrikazVM
    {
        public int ID { get;  set; }
        public string Ime { get;  set; }
        public string Prezime { get; set; }
        public string ImeRoditelja { get; set; }
        public string Pol { get; set; }
        public string BrojTelefona { get; set; }
        public string Email { get; set; }
        public string ZavrsenoZanimanje { get; set; }
    }
}
