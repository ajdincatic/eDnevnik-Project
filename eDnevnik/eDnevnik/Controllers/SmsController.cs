using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nexmo.Api;
using eDnevnik.data.ViewModels;
using eDnevnik.Helper;

namespace eDnevnik.Controllers
{
    [Autorizacija(true,true)]
    public class SmsController : Controller
    {
      
        public IActionResult Index()
        {
            
            return View();
        }

       [HttpPost]
        public IActionResult Index(SmsSaljiSMSVM model)
        {
  
            var client = new Client(creds: new Nexmo.Api.Request.Credentials
            {
                ApiKey = "c18ac50c",
                ApiSecret = "XEFVwhHB4K43j1L4"
            });

            var results = client.SMS.Send(new SMS.SMSRequest
            {
                from = model.posiljaoc,
                to="38762919807",
                text =model.tekstPoruke
            });

            TempData["porukaUspjesno"] = "Poruka poslana!";

            return RedirectToAction("Index");
        }
    }
}