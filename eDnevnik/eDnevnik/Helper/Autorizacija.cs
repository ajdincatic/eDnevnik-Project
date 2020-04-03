using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using SeminarskiRS1.Model;

namespace eDnevnik.Helper
{
    public class Autorizacija:TypeFilterAttribute
    {
        public Autorizacija(bool admin, bool nastavnici) : base(typeof(AutorizacijaImpl))
        {
            Arguments = new object[] {admin, nastavnici};
        }
    }

    public class  AutorizacijaImpl:IAsyncActionFilter
    {
        private bool _admin;
        private bool _nastavnici;

        public AutorizacijaImpl(bool admin, bool nastavnici)
        {
            _admin = admin;
            _nastavnici = nastavnici;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext filterContext, ActionExecutionDelegate next)
        {
            Login user = filterContext.HttpContext.GetLogiraniKorisnik();

            if (user == null)
            {
                if (filterContext.Controller is Controller controller)
                {
                    controller.TempData["porukaError"] = "Morate se prvo prijaviti!";
                }

                filterContext.Result = new RedirectToActionResult("Index", "Login", new { @area = "" });
                return;
            }

            DataBaseContext db = filterContext.HttpContext.RequestServices.GetService<DataBaseContext>();

            if (_admin && db.administrator.Any(s => s.LoginID == user.LoginID))
            {
                await next(); 
                return;
            }

            if (_nastavnici && db.nastavnoOsoblje.Any(s => s.LoginID ==user.LoginID))
            {
                await next();
                return;
            }

            if (filterContext.Controller is Controller c1)
            {
                c1.TempData["porukaError"] = "Morate se prvo prijaviti!";
            }
            filterContext.Result = new RedirectToActionResult("HomePageAdmin", "Admin", new { @area = ""});
        }
    }
}
