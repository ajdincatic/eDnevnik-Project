using AutoMapper;
using eDnevnik.data.ViewModels;
using eDnevnik.Helper;
using eDnevnik.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SeminarskiRS1.Model;
using System;
using System.IO;
using System.Linq;

namespace eDnevnik.Services
{
    public class LogiraniKorisnikService : ILogiraniKorisnikService
    {
        private readonly DataBaseContext _context;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IMapper _mapper;
        private readonly IOptions<SmsConfig> _SmsOptions;
        private readonly IOptions<SmtpConfig> _SmtpOptions;

        public LogiraniKorisnikService(DataBaseContext context, IWebHostEnvironment hostingEnvironment, IMapper mapper, IOptions<SmsConfig> Smsoptions, IOptions<SmtpConfig> Smtpoption)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
            _mapper = mapper;
            _SmsOptions = Smsoptions;
            _SmtpOptions = Smtpoption;
        }

        private NastavnoOsoblje GetLogirani(int LoginId)
        {
            return _context.nastavnoOsoblje
                .Include(y => y.PodaciRodjenje).Include(y => y.PodaciRodjenje.Drzava).Include(y => y.PodaciRodjenje.Grad)
                .Include(y => y.PodaciStanovanje).Include(y => y.PodaciStanovanje.Drzava).Include(y => y.PodaciStanovanje.Grad)
                .Include(y => y.podaciZanimanje).Include(y => y.podaciZanimanje.StrucnaSprema)
                .Include(y => y.OstaliPodaciNastavnoOsoblje)
                .Where(y => y.LoginID == LoginId)
                .SingleOrDefault();
        }

        public NastavnikDetaljiVM GetByIdDetalji(int LoginId)
        {
            NastavnoOsoblje model = GetLogirani(LoginId);
            if (model != null)
            {
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
            else
                return null;
        }

        public IFormFile UploadFile(IFormFile model, int KorisnikId)
        {
            NastavnoOsoblje x = GetLogirani(KorisnikId);
            if (model != null)
            {
                x.NppFilePath = FileUploadDelete.Upload(_hostingEnvironment, model, "fileUpload", x.NppFilePath);
                SmsSend.Send(_SmsOptions, "38762738460",
                    "Nastavnik " + x.Ime + " " + x.Prezime + " je postavio dokument");
                _context.SaveChanges();
            }
            return model;
        }

        public Tuple<string, byte[]> DownloadFile(int KorisnikId)
        {
            NastavnoOsoblje x = GetLogirani(KorisnikId);

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

        public bool UpdateLozinka(int KorisnikId, UserPromjenaLozinkeVM model)
        {
            NastavnoOsoblje x = GetLogirani(KorisnikId);
            if (x.login.Password == model.StaraLozinka)
            {
                x.login.Password = model.NovaLozinka;
                _context.SaveChanges();
                // zbog potrebe testiranja koristimo zadani mail
                //MailSend.Send(_SmtpOptions, x.Ime + " " + x.Prezime, x.PodaciStanovanje.Email, "Uspjesno ste promijenjenili vašu lozinku.");
                MailSend.Send(_SmtpOptions, x.Ime + " " + x.Prezime, "ajdincatic70230@gmail.com", "Uspješno ste promijenjenili vašu lozinku.");
                return true;
            }
            return false;
        }
    }
}
