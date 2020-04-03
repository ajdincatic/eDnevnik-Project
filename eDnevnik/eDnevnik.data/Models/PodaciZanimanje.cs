namespace SeminarskiRS1.Model
{
    public class PodaciZanimanje
    {
        public int PodaciZanimanjeID { get; set; }
        public string ZavrsenaSkola { get; set; }
        public string ZavrsenFakultet { get; set; }
        public string ZavrsenoZanimanje { get; set; }
        public string BrojDiplome { get; set; }
        public StrucnaSprema StrucnaSprema { get; set; }
        public int StrucnaSpremaID { get; set; }
        public bool DrzavniIspit { get; set; }

    }
}