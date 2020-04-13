using System;
using System.Collections.Generic;
using System.Text;

namespace SeminarskiRS1.Model
{
    public class SkolskeSekcije
    {
        public int SkolskeSekcijeID { get; set; }
        public NastavnoOsoblje Predavaci { get; set; }
        public string NazivSekcije { get; set; }

    }
}
