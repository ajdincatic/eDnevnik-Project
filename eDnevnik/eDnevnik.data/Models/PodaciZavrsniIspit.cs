using System;
using System.Collections.Generic;
using System.Text;

namespace SeminarskiRS1.Model
{
    public class PodaciZavrsniIspit
    {
        public int ID { get; set; }
        public DateTime DatumPolaganja { get; set; }
        public int OcjenaZavrsnogRada { get; set; }
        public int OcjenaZavrsnogIspita { get; set; }
        public int OcjenaOdbrane { get; set; }

    }
}
