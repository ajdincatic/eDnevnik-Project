using System;
using System.Collections.Generic;
using System.Text;

namespace SeminarskiRS1.Model
{
    public class SekcijeUcenici
    {
        public SkolskeSekcije skolskeSekcije{ get; set; }
        public int skolskeSekcijeID { get; set; }
        public Ucenici ucenici { get; set; }
        public int uceniciID { get; set; }
    }
}
