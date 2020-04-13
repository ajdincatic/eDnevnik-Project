using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eDnevnik.data.ViewModels
{
    public class UserPromjenaLozinkeVM
    {
        [Required(ErrorMessage ="Obavezno polje!")]
        public string StaraLozinka { get; set; }
        [Required(ErrorMessage = "Obavezno polje!")]
        [MinLength(6,ErrorMessage ="Minimalna dužina je 6 karaktera!")]
        public string NovaLozinka { get; set; }
        [Required(ErrorMessage = "Obavezno polje!")]
        [Compare("NovaLozinka",ErrorMessage ="Lozinke se ne poklapaju!")]
        public string NovaLozinkaPotvrda { get; set; }
    }
}
