using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SeminarskiRS1.Model
{
    public class SlusaPredmet
    {

        public int NastavnoOsobljeID { get; set; }
        public int PredmetID{ get; set; }

        [ForeignKey("NastavnoOsobljeID, PredmetID,OdjeljenjeID")]
        public PredavaciPredmetiOdjeljenje predavaciPredmetiOdjeljenje { get; set; }

        public int UceniciID { get; set; }
        public int OdjeljenjeID { get; set; }

        [ForeignKey("UceniciID,OdjeljenjeID")]
        public UceniciOdjeljenje uceniciOdjeljenje { get; set; }

        public int ZaključnaOcjena { get; set; }
    }
}
