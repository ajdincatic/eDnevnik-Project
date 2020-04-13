using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eDnevnik.data.ViewModels;
using eDnevnik.Helper;
using eDnevnik.Interfaces;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace eDnevnik.Controllers
{
    public class UcenikController : Controller
    {
        private readonly IUcenikService _service;

        public UcenikController(IUcenikService service)
        {
            _service = service;
        }


        public IActionResult Prikazi(int? page) => View(_service.GetList(HttpContext.GetLogiraniKorisnik().LoginID).ToPagedList(page ?? 1, 8));
        public IActionResult Dodaj() => View(_service.PripremiCmbVMStavke(new UcenikDodajVM()));
        public IActionResult Uredi(int UcenikID) => View("Dodaj",_service.Edit(UcenikID));
        public IActionResult Detalji(int UcenikID) => View(_service.GetById(UcenikID));


        public IActionResult Snimi(UcenikDodajVM ucenik)
        {
            _service.Add(ucenik, HttpContext.GetLogiraniKorisnik().LoginID);
            return RedirectToAction("Prikazi");
        }


    }
}