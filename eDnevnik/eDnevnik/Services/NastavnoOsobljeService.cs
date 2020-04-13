using AutoMapper;
using eDnevnik.data.Models;
using eDnevnik.data.ViewModels;
using eDnevnik.Helper;
using eDnevnik.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SeminarskiRS1.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using X.PagedList;

namespace eDnevnik.Service
{
    public class NastavnoOsobljeService : INastavnoOsobljeService
    {
        private readonly DataBaseContext _context;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IOptions<SmtpConfig> _smtpConfig;
        private readonly IMapper _mapper;

        public NastavnoOsobljeService(DataBaseContext context, IWebHostEnvironment hostingEnvironment, IOptions<SmtpConfig> smtpConfig, IMapper mapper)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
            _smtpConfig = smtpConfig;
            _mapper = mapper;
        }

        private NastavnoOsoblje GetNastavnoOsoblje(int Id)
        {
            return _context.nastavnoOsoblje
                .Include(y => y.PodaciRodjenje).Include(y => y.PodaciRodjenje.Drzava).Include(y => y.PodaciRodjenje.Grad)
                .Include(y => y.PodaciStanovanje).Include(y => y.PodaciStanovanje.Drzava).Include(y => y.PodaciStanovanje.Grad)
                .Include(y => y.podaciZanimanje).Include(y => y.podaciZanimanje.StrucnaSprema)
                .Include(y => y.OstaliPodaciNastavnoOsoblje)
                .Where(y => y.NastavnoOsobljeID == Id)
                .SingleOrDefault();
        }

        public NastavnoOsoblje Add(NastavnikDodajVM model)
        {
            PodaciRodjenje podaciRodjenje = new PodaciRodjenje
            {
                DatumRodjenja = model.DatumRodjenja,
                OpćinaRođenja = model.OpcinaRodjenja,
                GradID = model.MjestoRodjenjaID,
                DrzavaID = model.DrzavaRodjenjaID
            };
            _context.podaciRodjenje.Add(podaciRodjenje);

            PodaciStanovanje podaciStanovanje = new PodaciStanovanje
            {
                GradID = model.GradID,
                DrzavaID = model.DrzavaID,
                OpćinaPrebivalista = model.OpćinaPrebivalista,
                Adresa = model.Adresa,
                BrojTelefona = model.BrojTelefona,
                Email = model.Email
            };
            _context.podaciStanovanje.Add(podaciStanovanje);

            OstaliPodaciNastavnoOsoblje ostaliPodaci = new OstaliPodaciNastavnoOsoblje
            {
                Drzavljanstvo = model.Drzavljanstvo,
                Nacionalnost = model.Nacionalnost
            };
            _context.ostaliPodaciNastavnoOsoblje.Add(ostaliPodaci);

            PodaciZanimanje podaciZanimanje = new PodaciZanimanje
            {
                ZavrsenaSkola = model.ZavrsenaSkola,
                ZavrsenFakultet = model.Fakultet,
                ZavrsenoZanimanje = model.ZavrsenoZanimanje,
                BrojDiplome = model.BrojDiplome,
                StrucnaSpremaID = model.StrucnaSpremaID,
                DrzavniIspit = model.PosjedujeDrzavniIspit
            };
            _context.podaciZanimanje.Add(podaciZanimanje);

            Login log = new Login
            {
                Password = Guid.NewGuid().ToString().Substring(0, 6)
            };

            if (_context.login.Where(x => x.Username == model.Ime.ToLower() + "." + model.Prezime.ToLower()).SingleOrDefault() == null) 
                log.Username = model.Ime.ToLower() + "." + model.Prezime.ToLower();
            else
                log.Username = model.Prezime.ToLower() + "." + model.Ime.ToLower();

            _context.login.Add(log);

            NastavnoOsoblje nastavnoOsoblje = new NastavnoOsoblje
            {
                Ime = model.Ime,
                ImeRoditelja = model.ImeRoditelja,
                Prezime = model.Prezime,
                Pol = model.Pol,
                JMBG = model.JMBG,
                PodaciRodjenje = podaciRodjenje,
                PodaciStanovanje = podaciStanovanje,
                OstaliPodaciNastavnoOsoblje = ostaliPodaci,
                podaciZanimanje = podaciZanimanje,
                login = log,
                PhotoPath = FileUploadDelete.Upload(_hostingEnvironment, model.Photo, "imageUpload")
            };
            
            _context.nastavnoOsoblje.Add(nastavnoOsoblje);
            _context.SaveChanges();

            //MailSend.Send(_smtpConfig, nastavnoOsoblje.Ime + " " + nastavnoOsoblje.Prezime, "ajdincatic70230@gmail.com",
            //    "Dodani ste kao korisnik aplikacije.\nVaši login podaci: \nUsername: " + log.Username + "\nPassword: " + log.Password);

            return nastavnoOsoblje;
        }

        public NastavnikDodajVM PripremiCmbVMStavke(NastavnikDodajVM ulazniModel)
        {
            ulazniModel.Gradovi = _context.grad
                    .Select(x => new SelectListItem(x.NazivGrada, x.GradID.ToString())).ToList(); 
            ulazniModel.Drzave = _context.drzava
                    .Select(x => new SelectListItem(x.NazivDrzave,x.DrzavaID.ToString())).ToList(); 
            ulazniModel.StrucneSpreme = _context.strucnaSprema
                    .Select(x => new SelectListItem(x.Naziv, x.StrucnaSpremaID.ToString())).ToList();

            return ulazniModel;
        }

        public NastavnoOsoblje Delete(int Id)
        {
            NastavnoOsoblje ulazniModel = _context.nastavnoOsoblje.Find(Id);
            try
            {
                _context.podaciStanovanje.Remove(_context.podaciStanovanje.Find(ulazniModel.PodaciStanovanjeID));
                _context.podaciRodjenje.Remove(_context.podaciRodjenje.Find(ulazniModel.PodaciRodjenjeID));
                _context.podaciZanimanje.Remove(_context.podaciZanimanje.Find(ulazniModel.podaciZanimanjeID));
                _context.ostaliPodaciNastavnoOsoblje.Remove(_context.ostaliPodaciNastavnoOsoblje.Find(ulazniModel.OstaliPodaciNastavnoOsobljeID));
                _context.login.Remove(_context.login.Find(ulazniModel.LoginID));
                if (_context.AutorizacijskiToken.Where(x => x.LoginId == ulazniModel.LoginID).SingleOrDefault() != null)
                    _context.AutorizacijskiToken.Remove(_context.AutorizacijskiToken.Where(x => x.LoginId == ulazniModel.LoginID).SingleOrDefault());
                _context.nastavnoOsoblje.Remove(ulazniModel);
                _context.SaveChanges();
                if (ulazniModel.PhotoPath != null)
                    FileUploadDelete.Delete(_hostingEnvironment, "imageUpload", ulazniModel.PhotoPath);

                return ulazniModel;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public NastavnikDodajVM Edit(int Id)
        {
            NastavnoOsoblje model = GetNastavnoOsoblje(Id);

            NastavnikDodajVM ulazniModel = new NastavnikDodajVM();

            ulazniModel = _mapper.Map<NastavnikDodajVM>(model);

            ulazniModel.DatumRodjenja = model.PodaciRodjenje.DatumRodjenja;
            ulazniModel.OpcinaRodjenja = model.PodaciRodjenje.OpćinaRođenja;
            ulazniModel.MjestoRodjenjaID = model.PodaciRodjenje.GradID;
            ulazniModel.DrzavaRodjenjaID = model.PodaciRodjenje.DrzavaID;
            ulazniModel.GradID = model.PodaciStanovanje.GradID;
            ulazniModel.DrzavaID = model.PodaciStanovanje.DrzavaID;
            ulazniModel.Adresa = model.PodaciStanovanje.Adresa;
            ulazniModel.OpćinaPrebivalista = model.PodaciStanovanje.OpćinaPrebivalista;
            ulazniModel.BrojTelefona = model.PodaciStanovanje.BrojTelefona;
            ulazniModel.Email = model.PodaciStanovanje.Email;
            ulazniModel.Drzavljanstvo = model.OstaliPodaciNastavnoOsoblje.Drzavljanstvo;
            ulazniModel.Nacionalnost = model.OstaliPodaciNastavnoOsoblje.Nacionalnost;
            ulazniModel.ZavrsenaSkola = model.podaciZanimanje.ZavrsenaSkola;
            ulazniModel.Fakultet = model.podaciZanimanje.ZavrsenFakultet;
            ulazniModel.ZavrsenoZanimanje = model.podaciZanimanje.ZavrsenoZanimanje;
            ulazniModel.BrojDiplome = model.podaciZanimanje.BrojDiplome;
            ulazniModel.StrucnaSpremaID = model.podaciZanimanje.StrucnaSpremaID;
            ulazniModel.PosjedujeDrzavniIspit = model.podaciZanimanje.DrzavniIspit;

            PripremiCmbVMStavke(ulazniModel);
            return ulazniModel;
        }

        public NastavnikDetaljiVM GetById(int Id)
        {
            NastavnoOsoblje model = GetNastavnoOsoblje(Id);
            NastavnikDetaljiVM ulazniModel = new NastavnikDetaljiVM();

            ulazniModel = _mapper.Map<NastavnikDetaljiVM>(model);

            ulazniModel.DatumRodjenja = model.PodaciRodjenje.DatumRodjenja;
            ulazniModel.OpcinaRodjenja = model.PodaciRodjenje.OpćinaRođenja;
            ulazniModel.NazivMjestaRodjenja = model.PodaciRodjenje.Grad.NazivGrada;
            ulazniModel.NazivDrzaveRodjenja = model.PodaciRodjenje.Drzava.NazivDrzave;
            ulazniModel.NazivMjestaStanovanja = model.PodaciStanovanje.Grad.NazivGrada;
            ulazniModel.NazivDrzaveStanovanja = model.PodaciStanovanje.Drzava.NazivDrzave;
            ulazniModel.AdresaStanovanja = model.PodaciStanovanje.Adresa;
            ulazniModel.OpcinaStanovanja = model.PodaciStanovanje.OpćinaPrebivalista;
            ulazniModel.BrojTelefona = model.PodaciStanovanje.BrojTelefona;
            ulazniModel.Email = model.PodaciStanovanje.Email;
            ulazniModel.Drzavljanstvo = model.OstaliPodaciNastavnoOsoblje.Drzavljanstvo;
            ulazniModel.Nacionalnost = model.OstaliPodaciNastavnoOsoblje.Nacionalnost;
            ulazniModel.ZavrsenaSkola = model.podaciZanimanje.ZavrsenaSkola;
            ulazniModel.Fakultet = model.podaciZanimanje.ZavrsenFakultet;
            ulazniModel.ZavrsenoZanimanje = model.podaciZanimanje.ZavrsenoZanimanje;
            ulazniModel.BrojDiplome = model.podaciZanimanje.BrojDiplome;
            ulazniModel.StrucnaSprema = model.podaciZanimanje.StrucnaSprema.Naziv;
            ulazniModel.PosjedujeDrzavniIspit = model.podaciZanimanje.DrzavniIspit;
            ulazniModel.PhotoPath = model.PhotoPath;

            return ulazniModel;
        }

        public IEnumerable<NastavnikPrikazVM> GetList()
        {
            IEnumerable<NastavnikPrikazVM> model = _context.nastavnoOsoblje
                .Select(model => new NastavnikPrikazVM
                {
                    ID = model.NastavnoOsobljeID,
                    Ime = model.Ime,
                    Prezime = model.Prezime,
                    ImeRoditelja = model.ImeRoditelja,
                    Pol = model.Pol,
                    BrojTelefona = _context.podaciStanovanje.Where(y => y.PodaciStanovanjeID == model.PodaciStanovanjeID).SingleOrDefault().BrojTelefona,
                    Email = _context.podaciStanovanje.Where(y => y.PodaciStanovanjeID == model.PodaciStanovanjeID).SingleOrDefault().Email,
                    ZavrsenoZanimanje = _context.podaciZanimanje.Where(y => y.PodaciZanimanjeID == model.podaciZanimanjeID).SingleOrDefault().ZavrsenoZanimanje,
                }).ToList();
            return model.OrderBy(x => (x.Ime + " " + x.Prezime));
        }

        public NastavnoOsoblje Update(NastavnikDodajVM model)
        {
            NastavnoOsoblje osoblje = GetNastavnoOsoblje(model.NastavnoOsobljeID);

            osoblje.Ime = model.Ime;
            osoblje.Prezime = model.Prezime;
            osoblje.ImeRoditelja = model.ImeRoditelja;
            osoblje.Pol = model.Pol;
            osoblje.JMBG = model.JMBG;
            osoblje.PodaciRodjenje.DatumRodjenja = model.DatumRodjenja;
            osoblje.PodaciRodjenje.OpćinaRođenja = model.OpcinaRodjenja;
            osoblje.PodaciRodjenje.GradID = model.MjestoRodjenjaID;
            osoblje.PodaciRodjenje.DrzavaID = model.DrzavaRodjenjaID;
            osoblje.PodaciStanovanje.GradID = model.GradID;
            osoblje.PodaciStanovanje.DrzavaID = model.DrzavaRodjenjaID;
            osoblje.PodaciStanovanje.Adresa = model.Adresa;
            osoblje.PodaciStanovanje.OpćinaPrebivalista = model.OpćinaPrebivalista;
            osoblje.PodaciStanovanje.BrojTelefona = model.BrojTelefona;
            osoblje.PodaciStanovanje.Email = model.Email;
            osoblje.OstaliPodaciNastavnoOsoblje.Drzavljanstvo = model.Drzavljanstvo;
            osoblje.OstaliPodaciNastavnoOsoblje.Nacionalnost = model.Nacionalnost;
            osoblje.podaciZanimanje.ZavrsenaSkola = model.ZavrsenaSkola;
            osoblje.podaciZanimanje.ZavrsenFakultet = model.Fakultet;
            osoblje.podaciZanimanje.ZavrsenoZanimanje = model.ZavrsenoZanimanje;
            osoblje.podaciZanimanje.BrojDiplome = model.BrojDiplome;
            osoblje.podaciZanimanje.StrucnaSpremaID = model.StrucnaSpremaID;
            osoblje.podaciZanimanje.DrzavniIspit = model.PosjedujeDrzavniIspit;
            if (model.Photo != null)
            {
                if (osoblje.PhotoPath != null)
                    FileUploadDelete.Delete(_hostingEnvironment, "imageUpload", osoblje.PhotoPath);
                osoblje.PhotoPath = FileUploadDelete.Upload(_hostingEnvironment, model.Photo, "imageUpload", model.PhotoPath);
            }

            _context.SaveChanges();
            return osoblje;
        }

        public Tuple<string, byte[]> DownloadFile(int KorisnikId)
        {
            NastavnoOsoblje x = GetNastavnoOsoblje(KorisnikId);

            if (!string.IsNullOrEmpty(x.NppFilePath) 
                && File.Exists($"{this._hostingEnvironment.WebRootPath}\\fileUpload\\{x.NppFilePath}"))
            {
                string filePath = Path.Combine($"{this._hostingEnvironment.WebRootPath}\\fileUpload\\{x.NppFilePath}");
                string fileName = x.NppFilePath;
                byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);
                return Tuple.Create(fileName, fileBytes);
            }
            return null;
        }
    }
}
