using System.Linq;
using eDnevnik.Helper;
using Microsoft.AspNetCore.Mvc;
using SeminarskiRS1.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using eDnevnik.data.ViewModels;
using System.Collections.Generic;

namespace WelcomePage.Controllers
{
    [Autorizacija(false, true)]
    public class UserController : Controller
    {
        private DataBaseContext _context;
        public UserController(DataBaseContext db) => _context = db;

        public IActionResult HomePageUser()
        {
            NastavnoOsoblje x = _context.nastavnoOsoblje
                .Include(y => y.login)
                .Where(y => y.LoginID == HttpContext.GetLogiraniKorisnik().LoginID)
                .SingleOrDefault();
            ViewData["slika"] = x.PhotoPath;
            ViewData["imePrezime"] = x.Ime + " " +x.Prezime;
            return View();
        }

        public IActionResult PredmetiNastavnik()
        {
            List<UserPredmetiPregledVM> model = _context.predmeti.Where(x=>x.Predavac.LoginID==HttpContext.GetLogiraniKorisnik().LoginID).Select(x => new UserPredmetiPregledVM
            {
                nazivPredmeta=x.Naziv,
                izborni=x.Izborni,
                razred=x.Razred
            }).ToList();

            return View(model);
        }
    }
}