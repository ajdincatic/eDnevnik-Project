using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using eDnevnik.Controllers;
using eDnevnik.data.ViewModels;
using eDnevnik.Helper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Data.SqlClient.Server;
using Nexmo.Api;
using SeminarskiRS1.Model;

namespace WelcomePage.Controllers
{
    public class LoginController : Controller
    {
        private DataBaseContext _db;
  

        public LoginController(DataBaseContext db)
        {
            _db = db;
        }
       
        public IActionResult Index()
        {

            return View();
        }

        public IActionResult Prijava(LoginVM input)
        {
            Login korisnik =
                _db.login.SingleOrDefault(x => x.Username == input.username && x.Password == input.password);

            if (korisnik == null)
            {
                TempData["errorMessage"] = "Pogrešan username ili password";
                return View("Index", input);
            }

            HttpContext.SetLogiraniKorisnik(korisnik, input.ZapamtiPassword);
            return _db.nastavnoOsoblje.Any(s => s.LoginID == korisnik.LoginID) ? RedirectToAction("HomePageUser", "User") : RedirectToAction("HomePageAdmin", "Admin");
        }



        public IActionResult Odjava()
        {
            return RedirectToAction("Index");
        }
    }
}


