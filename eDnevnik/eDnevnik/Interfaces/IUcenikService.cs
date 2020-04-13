using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eDnevnik.data.ViewModels;
using SeminarskiRS1.Model;

namespace eDnevnik.Interfaces
{
    public interface IUcenikService
    {

        IEnumerable<UcenikPrikaziVM> GetList(int UserID);
        UcenikDodajVM PripremiCmbVMStavke(UcenikDodajVM ulazniModel);
        Ucenici Add(UcenikDodajVM model, int UserID);
        UcenikDodajVM Edit(int UcenikID);
        UcenikDodajVM GetById(int Id);

    }
}
