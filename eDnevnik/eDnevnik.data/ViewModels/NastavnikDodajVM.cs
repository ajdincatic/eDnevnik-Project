using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eDnevnik.data.ViewModels
{
    public class NastavnikDodajVM
    {
        /// <summary>
        /// Glavna tabela
        /// </summary>
        public int NastavnoOsobljeID { get; set; }
        [Required(ErrorMessage ="Obavezno polje!")]
        public string Ime { get; set; }
        [Required(ErrorMessage = "Obavezno polje!")]
        public string Prezime { get; set; }
        [Required(ErrorMessage = "Obavezno polje!")]
        public string ImeRoditelja { get; set; }
        [Required(ErrorMessage = "Obavezno polje!")]
        [RegularExpression(@"[MmŽž]", ErrorMessage = "Nepravilan unos!")]
        public string Pol { get; set; }
        [Required(ErrorMessage = "Obavezno polje!")]
        [RegularExpression(@"[0-9]{13}", ErrorMessage = "Nepravilan unos!")]
        public string JMBG { get; set; }
        public int PodaciRodjenjeID { get; set; }
        public int PodaciStanovanjeID { get; set; }
        public int OstaliPodaciNastavnoOsobljeID { get; set; }
        public int podaciZanimanjeID { get; set; }
        public int LoginID { get; set; }
        /// <summary>
        // JOIN 1
        /// </summary>
        [Required(ErrorMessage = "Obavezno polje!")]
        public DateTime DatumRodjenja { get; set; }
        public string OpcinaRodjenja { get; set; }
        [Required(ErrorMessage = "Obavezno polje!")]
        public int MjestoRodjenjaID { get; set; }
        public List<SelectListItem> Gradovi { get; set; }
        [Required(ErrorMessage = "Obavezno polje!")]
        public int DrzavaRodjenjaID { get; set; }
        public List<SelectListItem> Drzave { get; set; }
        /// <summary>
        /// JOIN 2
        /// </summary>
        [Required(ErrorMessage = "Obavezno polje!")]
        public int GradID { get; set; }
        [Required(ErrorMessage = "Obavezno polje!")]
        public int DrzavaID { get; set; }
        [Required(ErrorMessage = "Obavezno polje!")]
        public string Adresa { get; set; }
        public string OpćinaPrebivalista { get; set; }
        [Required(ErrorMessage = "Obavezno polje!")]
        [RegularExpression(@"[0-9]{9}", ErrorMessage = "Nepravilan unos!")]
        public string BrojTelefona { get; set; }
        [Required(ErrorMessage = "Obavezno polje!")]
        [EmailAddress(ErrorMessage = "Nepravilan unos!")]
        public string Email { get; set; }
        /// <summary>
        /// JOIN 3
        /// </summary>
        public string Drzavljanstvo { get; set; }
        public string Nacionalnost { get; set; }
        /// <summary>
        /// JOIN 4
        /// </summary>
        [Required(ErrorMessage = "Obavezno polje!")]
        public string ZavrsenaSkola { get; set; }
        [Required(ErrorMessage = "Obavezno polje!")]
        public string Fakultet { get; set; }
        [Required(ErrorMessage = "Obavezno polje!")]
        public string ZavrsenoZanimanje { get; set; }
        public string BrojDiplome { get; set; }
        public int StrucnaSpremaID { get; set; }
        public List<SelectListItem> StrucneSpreme { get; set; }
        public bool PosjedujeDrzavniIspit { get; set; }
        public IFormFile Photo { get; set; }
        public string PhotoPath { get; set; }
    }
}
