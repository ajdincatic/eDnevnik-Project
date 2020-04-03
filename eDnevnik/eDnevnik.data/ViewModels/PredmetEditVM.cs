using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using SeminarskiRS1.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace eDnevnik.data.ViewModels
{
    public class PredmetEditVM
    {
        public int PredmetID { get; set; }
        public string Razred { get; set; }
        public string Naziv { get; set; }
        public int PredavacID { get; set; }
        public string Predavac { get; set; }
        public bool Izborni { get; set; }
        public List<SelectListItem> Predavaci { get; set; }
        public IFormFile Photo { get; set; }
        public string PhotoPath { get; set; }
    }
}
