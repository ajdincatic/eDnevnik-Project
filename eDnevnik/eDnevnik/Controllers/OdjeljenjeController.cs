using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SeminarskiRS1.Model;
using eDnevnik.data.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList;
using eDnevnik.Helper;

namespace eDnevnik.Controllers
{
    [Autorizacija(true, false)]
    public class OdjeljenjeController : Controller
    {
        private DataBaseContext _context;

        public OdjeljenjeController(DataBaseContext context)
        {
            _context = context;
        }

        public IActionResult DodajOdjeljenje()
        {
            OdjeljenjeDodajVM UlazniModel = new OdjeljenjeDodajVM
            {
                Nastavnici = _context.nastavnoOsoblje.Select(n => new SelectListItem
                {
                    Value = n.NastavnoOsobljeID.ToString(),
                    Text = n.Ime + "(" + n.ImeRoditelja + ")" + n.Prezime
                }).ToList(),

                Ucenici = _context.ucenici.Select(n => new SelectListItem
                {
                    Value = n.UceniciID.ToString(),
                    Text = n.Ime + "(" + n.ImeRoditelja + ")" + n.Prezime
                }).ToList(),

                SkolskeGodine = _context.skolskaGodina.Select(n => new SelectListItem
                {
                    Value = n.SkolskaGodinaID.ToString(),
                    Text = n.Naziv
                }).ToList()
            };

            return View(UlazniModel);
        }
        public IActionResult OdjeljenjeUredi(int OID)
        {
            Odjeljenje obj = _context.odjeljenje.Find(OID);
            OdjeljenjeDodajVM UlazniModel = new OdjeljenjeDodajVM
            {
                OdjeljenjeID=obj.OdjeljenjeID,
                Razred=obj.Razred,
                Oznaka=obj.Oznaka,
                Opis=obj.Opis,
                RazrednikID=obj.RazrednikID,
                PredsjenikID=obj.PredsjednikID,
                BlagajnikID=obj.BlagajnikID,
                SkolskaGodinaID=obj.skolskaGodinaID,
                Smjena=obj.Smjena,
                Nastavnici = _context.nastavnoOsoblje.Select(n => new SelectListItem
                {
                    Value = n.NastavnoOsobljeID.ToString(),
                    Text = n.Ime + "(" + n.ImeRoditelja + ")" + n.Prezime
                }).ToList(),

                Ucenici = _context.ucenici.Select(n => new SelectListItem
                {
                    Value = n.UceniciID.ToString(),
                    Text = n.Ime + "(" + n.ImeRoditelja + ")" + n.Prezime
                }).ToList(),

                SkolskeGodine = _context.skolskaGodina.Select(n => new SelectListItem
                {
                    Value = n.SkolskaGodinaID.ToString(),
                    Text = n.Naziv
                }).ToList()
            };

            return View("DodajOdjeljenje", UlazniModel);
        }


        public IActionResult Snimi(OdjeljenjeDodajVM novo)
        {
            if (novo.OdjeljenjeID == 0)
            {
                Odjeljenje n = new Odjeljenje
                {
                    Razred = novo.Razred,
                    Oznaka = novo.Oznaka,
                    Opis = novo.Opis,
                    RazrednikID = novo.RazrednikID,
                    PredsjednikID = novo.PredsjenikID,
                    BlagajnikID = novo.BlagajnikID,
                    skolskaGodinaID = novo.SkolskaGodinaID,
                    Smjena=novo.Smjena
                };
                _context.odjeljenje.Add(n);
            }
            else
            {
                Odjeljenje n = _context.odjeljenje.Find(novo.OdjeljenjeID);
                n.Razred = novo.Razred;
                n.Oznaka = novo.Oznaka;
                n.Opis = novo.Opis;
                n.RazrednikID = novo.RazrednikID;
                n.PredsjednikID = novo.PredsjenikID;
                n.BlagajnikID = novo.BlagajnikID;
                n.skolskaGodinaID = novo.SkolskaGodinaID;
                n.Smjena = novo.Smjena;
            }

            _context.SaveChanges();
            return RedirectToAction("PrikaziOdjeljenja");
        }

        public IActionResult PrikaziOdjeljenja(int? page)
        {
            IPagedList<OdjeljenjePrikaziVM> odjeljenja = _context.odjeljenje.Select(o => new OdjeljenjePrikaziVM
            {
                OdjeljenjeID=o.OdjeljenjeID,
                Razred=o.Razred,
                Oznaka=o.Oznaka,
                Razrednik=_context.nastavnoOsoblje.Where(y=> y.NastavnoOsobljeID== o.RazrednikID).SingleOrDefault().Ime+"("+
                _context.nastavnoOsoblje.Where(y => y.NastavnoOsobljeID == o.RazrednikID).SingleOrDefault().ImeRoditelja+")"+
                _context.nastavnoOsoblje.Where(y => y.NastavnoOsobljeID == o.RazrednikID).SingleOrDefault().Prezime,
                SkolskaGodina=_context.skolskaGodina.Where(sk=> sk.SkolskaGodinaID==o.skolskaGodinaID).SingleOrDefault().Naziv,
                Smjena=o.Smjena,
            }).ToList().ToPagedList(page ?? 1, 5);
            return View(odjeljenja);
        }

        public IActionResult OdjeljenjeDetalji( int OID)
        {
            Odjeljenje o = _context.odjeljenje.Find(OID);

            OdjeljenjeDetaljiVM ulazniModel = new OdjeljenjeDetaljiVM
            {
                OdjeljenjeID = o.OdjeljenjeID,
                Razred = o.Razred,
                Oznaka = o.Oznaka,
                Razrednik = _context.nastavnoOsoblje.Where(y => y.NastavnoOsobljeID == o.RazrednikID).SingleOrDefault().Ime + "(" +
                _context.nastavnoOsoblje.Where(y => y.NastavnoOsobljeID == o.RazrednikID).SingleOrDefault().ImeRoditelja + ")" +
                _context.nastavnoOsoblje.Where(y => y.NastavnoOsobljeID == o.RazrednikID).SingleOrDefault().Prezime,
                SkolskaGodina = _context.skolskaGodina.Where(sk => sk.SkolskaGodinaID == o.skolskaGodinaID).SingleOrDefault().Naziv,
                Blagajnik=_context.ucenici.Where(u=> u.UceniciID==o.BlagajnikID).SingleOrDefault().Ime+"("+
                _context.ucenici.Where(u => u.UceniciID == o.BlagajnikID).SingleOrDefault().ImeRoditelja
                +")"+_context.ucenici.Where(u=> u.UceniciID==o.BlagajnikID).SingleOrDefault().Prezime,
                Predsjednik = _context.ucenici.Where(u => u.UceniciID == o.PredsjednikID).SingleOrDefault().Ime + "(" +
                _context.ucenici.Where(u => u.UceniciID == o.BlagajnikID).SingleOrDefault().ImeRoditelja
                + ")" + _context.ucenici.Where(u => u.UceniciID == o.BlagajnikID).SingleOrDefault().Prezime,
                RazrednikID=o.RazrednikID,
                Smjena=o.Smjena,
                Opis=o.Opis,
            };
            return View(ulazniModel);
        }
        public IActionResult OdjeljenjeObrisi(int OID)
        {
            Odjeljenje obj = _context.odjeljenje.Find(OID);
            _context.Remove(obj);
            _context.SaveChanges();
            return RedirectToAction("PrikaziOdjeljenja");
        }

    }
}


          