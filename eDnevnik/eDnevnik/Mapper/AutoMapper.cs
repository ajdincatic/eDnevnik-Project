using AutoMapper;
using eDnevnik.data.ViewModels;
using SeminarskiRS1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eDnevnik.Mapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<NastavnoOsoblje, NastavnikDodajVM>();
            CreateMap<NastavnoOsoblje, NastavnikDetaljiVM>();
        }
    }
}
