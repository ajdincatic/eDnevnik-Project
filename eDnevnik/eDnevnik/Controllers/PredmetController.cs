using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using eDnevnik.data.ViewModels;
using eDnevnik.Helper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Hosting.Internal;
using SeminarskiRS1.Model;
using X.PagedList;

namespace eDnevnik.Controllers
{
    [Autorizacija(true, false)]
    public class PredmetController : Controller
    {
        private DataBaseContext _db;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public PredmetController(DataBaseContext db, IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            this._hostingEnvironment = webHostEnvironment;
        }

        public IActionResult OverviewPredmet(int? page)
        {
            IEnumerable<PredmetEditVM> model = _db.predmeti.Select(p => new PredmetEditVM
            {
                PredmetID = p.PredmetiID,
                PredavacID=p.PredavacID,
                Predavac = p.Predavac.Ime + ' ' + p.Predavac.Prezime,
                Razred = p.Razred,
                Izborni = p.Izborni,
                Naziv = p.Naziv
            }).ToPagedList(page ?? 1, 8);

            return View(model);
        }


        public IActionResult Add()
        {
            PredmetEditVM model = new PredmetEditVM();
            model.Predavaci = _db.nastavnoOsoblje.Select(p => new SelectListItem(p.Ime + ' ' + p.Prezime, p.NastavnoOsobljeID.ToString())).ToList();
            return View("EditPredmet",model);
        }

        public IActionResult EditPredmet(int PredmetID)
        {
            Predmeti p = _db.predmeti.Find(PredmetID);
            if (p==null)
            {
                return View("ObjectNotFound",PredmetID);  
            }
            
            PredmetEditVM model = new PredmetEditVM();
            model.Predavaci = _db.nastavnoOsoblje.Select(p => new SelectListItem(p.Ime + ' ' + p.Prezime, p.NastavnoOsobljeID.ToString())).ToList();

            model.PredmetID = p.PredmetiID;
            model.PredavacID = p.PredavacID;
            model.Razred = p.Razred;
            model.Naziv = p.Naziv;
            model.Izborni = p.Izborni;
            model.PhotoPath = p.PhotoPath;

            return View(model);
        }

        public IActionResult Save(PredmetEditVM inputi)
        {
            Predmeti x;
            if (inputi.PredmetID == 0)
            {
                x = new Predmeti();
                _db.Add(x);
            }
            else
            {
                x = _db.predmeti.Find(inputi.PredmetID);
            }
            x.PredmetiID = inputi.PredmetID;
            x.PredavacID = inputi.PredavacID;
            x.Razred = inputi.Razred;
            x.Izborni = inputi.Izborni;
            x.Naziv = inputi.Naziv;
            x.PhotoPath = FileUploadDelete.Upload(_hostingEnvironment, inputi.Photo, "imageUpload");
            _db.SaveChanges();

            TempData["porukaUspjesno"] = "Uspjesno dodan predmet!";
            return RedirectToAction("OverviewPredmet");
        }

        public IActionResult Delete(int PredmetID)
        {
            Predmeti p = _db.predmeti.Find(PredmetID);
            _db.Remove(p);
            _db.SaveChanges();
            TempData["porukaUspjesno"] = "Uspjesno obrisan predmet!";
            return RedirectToAction("OverviewPredmet");
        }
    }
}