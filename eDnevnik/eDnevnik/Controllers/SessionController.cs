using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eDnevnik.data.Models;
using eDnevnik.data.ViewModels;
using eDnevnik.Helper;
using Microsoft.AspNetCore.Mvc;
using SeminarskiRS1.Model;

namespace eDnevnik.Controllers
{
    [Autorizacija(true,false)]

    public class SessionController : Controller
    {
        private DataBaseContext _db;

        public SessionController(DataBaseContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            SessionIndexVM model = new SessionIndexVM
            {
                Rows = _db.AutorizacijskiToken.Select(s => new SessionIndexVM.Row
                {
                    VrijemeLogiranja = s.VrijemeEvidentiranja, token = s.Vrijednost,
                }).ToList(),
                TrenutniToken = HttpContext.GetTrenutniToken()
            };
            return View(model);
        }

        public IActionResult Obrisi(string token)
        {
            AutorizacijskiToken obrisati = _db.AutorizacijskiToken.FirstOrDefault(x => x.Vrijednost == token);
            if (obrisati != null)
            {
                _db.AutorizacijskiToken.Remove(obrisati);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}