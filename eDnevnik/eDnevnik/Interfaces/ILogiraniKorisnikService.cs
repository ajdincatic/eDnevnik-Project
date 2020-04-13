using eDnevnik.data.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eDnevnik.Interfaces
{
    public interface ILogiraniKorisnikService
    {
        NastavnikDetaljiVM GetByIdDetalji(int LoginId);
        IFormFile UploadFile(IFormFile model, int KorisnikId);
        Tuple<string, byte[]> DownloadFile(int KorisnikId);
        bool UpdateLozinka(int KorisnikId, UserPromjenaLozinkeVM model);
    }
}
