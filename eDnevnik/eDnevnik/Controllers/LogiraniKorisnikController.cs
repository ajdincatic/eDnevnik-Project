using eDnevnik.data.ViewModels;
using eDnevnik.Helper;
using eDnevnik.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eDnevnik.Controllers
{
    [Autorizacija(false, true)]
    public class LogiraniKorisnikController : Controller
    {
        private readonly ILogiraniKorisnikService _service;

        public LogiraniKorisnikController(ILogiraniKorisnikService logiraniKorisnikService) => this._service = logiraniKorisnikService;

        public IActionResult UserPodaci() => View("~/Views/Nastavnik/Detalji.cshtml", _service.GetByIdDetalji(HttpContext.GetLogiraniKorisnik().LoginID));

        public IActionResult AddFile(IFormFile model)
        {
            _service.UploadFile(model, HttpContext.GetLogiraniKorisnik().LoginID);
            TempData["porukaUspjesno"] = "Uspješno dodan dokument!";
            return RedirectToAction("UserPodaci");
        }

        public IActionResult PromjenaLozinke(UserPromjenaLozinkeVM model) => View(model);

        public ActionResult DownloadDocument()
        {
            var x = _service.DownloadFile(HttpContext.GetLogiraniKorisnik().LoginID);
            if (x != null) 
                return File(x.Item2, "application/force-download", x.Item1);
            TempData["porukaNeuspjesno"] = "Niste postavili dokument!";
            return Redirect("UserPodaci");
        }

        public IActionResult UpdateLozinka(UserPromjenaLozinkeVM model)
        {
            if (ModelState.IsValid)
            {
                if (_service.UpdateLozinka(HttpContext.GetLogiraniKorisnik().LoginID, model))
                    return RedirectToAction("HomePageUser", "User");
            }
            TempData["poruka"] = "Pokušajte ponovo!";
            return View("PromjenaLozinke", model);
        }
    }
}