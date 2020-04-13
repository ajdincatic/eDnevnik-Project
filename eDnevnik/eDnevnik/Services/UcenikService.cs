using AutoMapper;
using eDnevnik.data.ViewModels;
using eDnevnik.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SeminarskiRS1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eDnevnik.Services
{
    public class UcenikService : IUcenikService
    {
        private readonly DataBaseContext _context;
        private readonly IMapper _mapper;




        public UcenikService( DataBaseContext context , IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        private Ucenici GetUcenik(int Id)
        {
            return _context.ucenici
                .Include(y => y.PodaciRodjenje).Include(y => y.PodaciRodjenje.Drzava).Include(y => y.PodaciRodjenje.Grad)
                .Include(y => y.PodaciStanovanje).Include(y => y.PodaciStanovanje.Drzava).Include(y => y.PodaciStanovanje.Grad)
                .Where(y => y.UceniciID == Id)
                .SingleOrDefault();
        }

        public Ucenici Add(UcenikDodajVM model, int UserID)
        {
            if (model.UcenikID!=null){
                return Update(model);
            }

            PodaciRodjenje podaciRodjenje = new PodaciRodjenje
            {
                DatumRodjenja = model.DatumRodjenja,
                OpćinaRođenja = model.OpćinaRodjenja,
                GradID = model.GradRodjenjaID,
                DrzavaID = model.DrzavaRodjenjaID
            };
            _context.podaciRodjenje.Add(podaciRodjenje);

            PodaciStanovanje podaciStanovanje = new PodaciStanovanje
            {
                GradID = model.GradStanovanjaID,
                DrzavaID = model.DrzavaStanovanjaID,
                OpćinaPrebivalista = model.OpćinaPrebivalista,
                Adresa = model.Adresa,
                BrojTelefona = model.BrojTelefona,
                Email = model.Email
            };
            _context.podaciStanovanje.Add(podaciStanovanje);

            OstaliPodaci ostaliPodaci = new OstaliPodaci
            {
                Drzavljanstvo = model.Drzavljanstvo,
                Nacionalnost = model.Nacionalnost,
                PorodicaID=model.PorodicaID
            };
            _context.ostaliPodaci.Add(ostaliPodaci);

            Ucenici ucenici = new Ucenici
            {
                Ime = model.Ime,
                ImeRoditelja = model.ImeRoditelja,
                Prezime = model.Prezime,
                Pol = model.Pol,
                JMBG = model.JMBG,
                PodaciRodjenje = podaciRodjenje,
                OstaliPodaci = ostaliPodaci,
                PodaciStanovanje = podaciStanovanje
            };
            _context.ucenici.Add(ucenici);

            //MailSend.Send(_smtpConfig, nastavnoOsoblje.Ime + " " + nastavnoOsoblje.Prezime, "ajdincatic70230@gmail.com",
            //    "Dodani ste kao korisnik aplikacije.\nVaši login podaci: \nUsername: " + log.Username + "\nPassword: " + log.Password);


            int razrednikID = _context.nastavnoOsoblje.Where(y => y.LoginID == UserID).FirstOrDefault().NastavnoOsobljeID;
            // doadti provjeru da li se radi o akutelnoj skolskoj godini!!!
            UceniciOdjeljenje uceniciOdjeljenje = new UceniciOdjeljenje
            {
                odjeljenjeID = _context.odjeljenje.Where(x => x.RazrednikID ==razrednikID).FirstOrDefault().OdjeljenjeID,
                ucenici = ucenici,
                BrojUDneviku = _context.uceniciOdjeljenje.Count(x=> x.odjeljenje.RazrednikID==razrednikID)+1
            };
            _context.uceniciOdjeljenje.Add(uceniciOdjeljenje);
            _context.SaveChanges();

            return ucenici;
        }
        public UcenikDodajVM Edit(int UcenikID)
        {

            UcenikDodajVM ucenik = _context.ucenici.Where(x => x.UceniciID == UcenikID).Select(x => new UcenikDodajVM()
            {
                Ime = x.Ime,
                Prezime = x.Prezime,
                ImeRoditelja = x.ImeRoditelja,
                JMBG = x.JMBG,
                Pol = x.Pol,
                DatumUpisa = x.DatumUpisa,
                Adresa = x.PodaciStanovanje.Adresa,
                BrojTelefona=x.PodaciStanovanje.BrojTelefona,
                DrzavaStanovanjaID=x.PodaciStanovanje.DrzavaID,
                OpćinaPrebivalista=x.PodaciStanovanje.OpćinaPrebivalista,
                DatumRodjenja=x.PodaciRodjenje.DatumRodjenja,
                Drzavljanstvo=x.OstaliPodaci.Drzavljanstvo,
                Email=x.PodaciStanovanje.Email,
                Nacionalnost=x.OstaliPodaci.Nacionalnost,
                PorodicaID=x.OstaliPodaci.PorodicaID,
                GradRodjenjaID=x.PodaciRodjenje.GradID,
                GradStanovanjaID=x.PodaciStanovanje.GradID,
                DrzavaRodjenjaID=x.PodaciRodjenje.DrzavaID,
                UcenikID=x.UceniciID
            }).FirstOrDefault();
            PripremiCmbVMStavke(ucenik);
            return ucenik;
        }
        public Ucenici Update(UcenikDodajVM model)
        {
            Ucenici ucenici = _context.ucenici.Include(x=> x.PodaciRodjenje)
                                              .Include(x=> x.PodaciStanovanje)
                                              .Include(x=> x.OstaliPodaci)
                                              .Where(x=> x.UceniciID==model.UcenikID).FirstOrDefault();
            ucenici.Ime = model.Ime;
            ucenici.Prezime = model.Prezime;
            ucenici.ImeRoditelja = model.ImeRoditelja;
            ucenici.Pol = model.Pol;
            ucenici.JMBG = model.JMBG;
            ucenici.PodaciRodjenje.DatumRodjenja = model.DatumRodjenja;
            ucenici.PodaciRodjenje.OpćinaRođenja = model.OpćinaRodjenja;
            ucenici.PodaciRodjenje.GradID = model.GradRodjenjaID;
            ucenici.PodaciRodjenje.DrzavaID = model.DrzavaRodjenjaID;
            ucenici.PodaciStanovanje.GradID = model.GradStanovanjaID;
            ucenici.PodaciStanovanje.DrzavaID = model.DrzavaRodjenjaID;
            ucenici.PodaciStanovanje.Adresa = model.Adresa;
            ucenici.PodaciStanovanje.OpćinaPrebivalista = model.OpćinaPrebivalista;
            ucenici.PodaciStanovanje.BrojTelefona = model.BrojTelefona;
            ucenici.PodaciStanovanje.Email = model.Email;
            ucenici.OstaliPodaci.Drzavljanstvo = model.Drzavljanstvo;
            ucenici.OstaliPodaci.Nacionalnost = model.Nacionalnost;
            ucenici.UceniciID = model.UcenikID;
            
            _context.SaveChanges();
            return ucenici;
        }
        public IEnumerable<UcenikPrikaziVM> GetList(int UserID)
        {
            int razrednikID = _context.nastavnoOsoblje.Where(y => y.LoginID == UserID).FirstOrDefault().NastavnoOsobljeID;

            var ucenici = _mapper.Map<IEnumerable<UcenikPrikaziVM>>
                (_context.ucenici.Except(_context.uceniciOdjeljenje.Where(x => x.odjeljenje.RazrednikID != razrednikID).Select(x => x.ucenici)));
            foreach (var i in ucenici)
            {
                i.BrojUDnevniku = _context.uceniciOdjeljenje.Where(x => x.uceniciID == i.UceniciID).FirstOrDefault().BrojUDneviku;
            }
            return ucenici;
        }
        public UcenikDodajVM PripremiCmbVMStavke(UcenikDodajVM ulazniModel)
        {
            ulazniModel.Gradovi = _context.grad
                    .Select(x => new SelectListItem(x.NazivGrada, x.GradID.ToString())).ToList();

            ulazniModel.Drzave = _context.drzava
                    .Select(x => new SelectListItem(x.NazivDrzave, x.DrzavaID.ToString())).ToList();

            ulazniModel.Porodica = _context.porodica
                    .Select(x => new SelectListItem(x.StatusPorodiceUcenika, x.PorodicaID.ToString())).ToList();
            return ulazniModel;
        }

        public UcenikDodajVM GetById(int Id)
        {
            Ucenici model = GetUcenik(Id);
            UcenikDodajVM ulazniModel = new UcenikDodajVM();

            ulazniModel = _mapper.Map<UcenikDodajVM>(model);

            ulazniModel.DatumRodjenja = model.PodaciRodjenje.DatumRodjenja;
            ulazniModel.OpćinaRodjenja = model.PodaciRodjenje.OpćinaRođenja;
            ulazniModel.GradRodjenjaID = model.PodaciRodjenje.Grad.GradID;
            ulazniModel.DrzavaRodjenjaID = model.PodaciRodjenje.Drzava.DrzavaID;
            ulazniModel.GradStanovanjaID = model.PodaciStanovanje.Grad.GradID;
            ulazniModel.DrzavaStanovanjaID = model.PodaciStanovanje.Drzava.DrzavaID;
            ulazniModel.Adresa = model.PodaciStanovanje.Adresa;
            ulazniModel.OpćinaPrebivalista = model.PodaciStanovanje.OpćinaPrebivalista;
            ulazniModel.BrojTelefona = model.PodaciStanovanje.BrojTelefona;
            ulazniModel.Email = model.PodaciStanovanje.Email;
            ulazniModel.Drzavljanstvo = model.OstaliPodaci.Drzavljanstvo;
            ulazniModel.Nacionalnost = model.OstaliPodaci.Nacionalnost;
            ulazniModel.Pol = model.Pol;
            ulazniModel.JMBG = model.JMBG;
            ulazniModel.PorodicaID = model.OstaliPodaci.Porodica.PorodicaID;
            ulazniModel.UcenikID = model.UceniciID;
            ulazniModel.BrojUDenvniku = _context.uceniciOdjeljenje.Where(x => x.uceniciID == model.UceniciID).FirstOrDefault().BrojUDneviku;
            

            return ulazniModel;
        }
    }
}
