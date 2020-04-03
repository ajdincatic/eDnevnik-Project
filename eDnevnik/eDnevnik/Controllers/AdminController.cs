using eDnevnik.Helper;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WelcomePage.Controllers
{
    [Autorizacija(true, false)]
    public class AdminController : Controller
    {
        public IActionResult HomePageAdmin()
        {
            return View();
        }
    }
}