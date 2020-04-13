using System;
using System.Collections.Generic;
using System.Text;

namespace SeminarskiRS1.Model
{
    public class UceniciOdjeljenje
    {
        public Ucenici ucenici { get; set; }
        public int uceniciID { get; set; }
        public Odjeljenje odjeljenje { get; set; }
        public int odjeljenjeID { get; set; }
        public int BrojUDneviku { get; set; }
    }
}
