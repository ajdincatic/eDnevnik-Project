using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eDnevnik.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace eDnevnik.Controllers
{
    public class ErrorController : Controller
    {
        private readonly ILogger<ErrorController> logger;

        public ErrorController(ILogger<ErrorController>logger)
        {
            this.logger = logger;
        }

        [Route("/Error/{statusCode}")]
        public IActionResult HttpStatusCodeHandler(int statusCode)
        {
            var statusCodeResult = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();

            switch (statusCode)
            {
                case 404:
                    ViewBag.ErrorMessage = "Traženi resurs nije pronađen";
                    logger.LogInformation($"404 error. Putanja: {statusCodeResult.OriginalPath}");
                    break;
            }

            return View("NotFound");
        }
    }
}