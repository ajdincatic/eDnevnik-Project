using System;
using System.Linq;
using eDnevnik.data.ViewModels;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;
using eDnevnik.Helper;
using eDnevnik.Interfaces;

namespace eDnevnik.Controllers
{
    [Autorizacija(true, false)]
    public class NastavnikController : Controller
    {
        private readonly INastavnoOsobljeService _service;

        public NastavnikController(INastavnoOsobljeService nastavnoOsoblje) => this._service = nastavnoOsoblje;

        public IActionResult Prikaz(int? page) => View(_service.GetList().ToPagedList(page ?? 1, 8));

        public IActionResult Dodaj() => View(_service.PripremiCmbVMStavke(new NastavnikDodajVM()));

        public IActionResult Detalji(int nastavnoOsobljeId) => View(_service.GetById(nastavnoOsobljeId));

        public IActionResult Uredi(int nastavnoOsobljeId) => View("Dodaj", _service.Edit(nastavnoOsobljeId));

        public IActionResult Obrisi(int nastavnoOsobljeId)
        {
            if (_service.Delete(nastavnoOsobljeId) != null)
                TempData["porukaUspjesno"] = "Uspješno obrisan nastavnik!";
            else
                TempData["porukaNeuspjesno"] = "Ne možete obrisat nastavnika koji je pridružen razredu/predmetu!";
            return RedirectToAction("Prikaz");
        }

        [ValidateAntiForgeryToken]
        public IActionResult Snimi(NastavnikDodajVM nastavnik)
        {
            if (!ModelState.IsValid)
                return View("DodajNastavnika", _service.PripremiCmbVMStavke(nastavnik));
            if (nastavnik.NastavnoOsobljeID == 0)
            {
                _service.Add(nastavnik);
                TempData["porukaUspjesno"] = "Uspješno dodan nastavnik!";
            }
            else
            {
                _service.Update(nastavnik);
                TempData["porukaUspjesno"] = "Uspješno uređen nastavnik!";
            }
            return RedirectToAction("Prikaz");
        }

        public IActionResult Pretraga(string key)
        {
            if (!string.IsNullOrEmpty(key))
            {
                IPagedList<NastavnikPrikazVM> model =
                    _service.GetList().Where(x => (x.Ime + " " + x.Prezime).ToLower().Contains(key.ToLower())).ToPagedList();
                if (model.Count() == 0)
                    TempData["porukaNeuspjesno"] = "Nema rezultata!";
                return View("Prikaz", model);
            }
            return RedirectToAction("Prikaz");
        }

        public ActionResult DownloadDocumentAdmin(int Id)
        {
            var x = _service.DownloadFile(Id);
            if (x != null)
                return File(x.Item2, "application/force-download", x.Item1);
            TempData["porukaNeuspjesno"] = "Nastavnik nije postavio dokument!";
            return Redirect("/Nastavnik/Detalji?nastavnoOsobljeId=" + Id);
        }

    }
}