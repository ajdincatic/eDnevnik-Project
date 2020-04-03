using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eDnevnik.data.Models;
using eDnevnik.data.ViewModels;
using Microsoft.AspNetCore.Mvc;
using SeminarskiRS1.Model;

namespace eDnevnik.Interfaces
{
    public interface INastavnoOsobljeService
    {
        NastavnikDetaljiVM GetById(int Id);
        IEnumerable<NastavnikPrikazVM> GetList();
        NastavnoOsoblje Add(NastavnikDodajVM model);
        NastavnoOsoblje Update(NastavnikDodajVM model);
        NastavnoOsoblje Delete(int Id);
        NastavnikDodajVM Edit(int Id);
        NastavnikDodajVM PripremiCmbVMStavke(NastavnikDodajVM ulazniModel);
        Tuple<string, byte[]> DownloadFile(int KorisnikId);
    }
}
