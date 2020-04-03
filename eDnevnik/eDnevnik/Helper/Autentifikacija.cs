using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eDnevnik.data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using SeminarskiRS1.Model;

namespace eDnevnik.Helper
{
    public static class Autentifikacija
    {
        private const string LogiraniKorisnik = "logirani_korisnik";

        public static void SetLogiraniKorisnik(this HttpContext context, Login korisnik, bool snimiUCookie = false)
        {

            DataBaseContext db = context.RequestServices.GetService<DataBaseContext>();

            string stariToken = context.Request.GetCookieJson<string>(LogiraniKorisnik);
            if (stariToken != null)
            {
                AutorizacijskiToken obrisati = db.AutorizacijskiToken.FirstOrDefault(x => x.Vrijednost == stariToken);
                if (obrisati != null)
                {
                    db.AutorizacijskiToken.Remove(obrisati);
                    db.SaveChanges();
                }
            }

            if (korisnik != null)
            {

                string token = Guid.NewGuid().ToString();
                db.AutorizacijskiToken.Add(new AutorizacijskiToken
                {
                    Vrijednost = token,
                    LoginId = korisnik.LoginID,
                    VrijemeEvidentiranja = DateTime.Now
                });
                db.SaveChanges();
                context.Response.SetCookieJson(LogiraniKorisnik, token);
            }
        }

        public static string GetTrenutniToken(this HttpContext context)
        {
            return context.Request.GetCookieJson<string>(LogiraniKorisnik);
        }

        public static Login GetLogiraniKorisnik(this HttpContext context)
        {
            DataBaseContext db = context.RequestServices.GetService<DataBaseContext>();

            string token = context.Request.GetCookieJson<string>(LogiraniKorisnik);
            if (token == null)
                return null;

            return db.AutorizacijskiToken
                .Where(x => x.Vrijednost == token)
                .Select(s => s.User)
                .SingleOrDefault();

        }
    }
}
