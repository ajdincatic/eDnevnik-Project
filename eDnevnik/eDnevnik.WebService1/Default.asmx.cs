using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Xml;

namespace WebApplication1
{
    /// <summary>
    /// Summary description for Default
    /// </summary>
    [WebService(Namespace = "http://p1859.app.fit.ba/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class Default : System.Web.Services.WebService
    {
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public XmlDocument GetDrzave()
        {
            var url = HttpContext.Current.Server.MapPath("~/XMLfiles/drzave.xml");
            XmlDocument x = new XmlDocument();
            x.Load(url);
            return x;
        }

        [WebMethod]
        public XmlDocument GetGradovi()
        {
            var url = HttpContext.Current.Server.MapPath("~/XMLfiles/gradovi.xml");
            XmlDocument x = new XmlDocument();
            x.Load(url);
            return x;
        }

        [WebMethod]
        public List<Predmet> GetPredmetiByNastavnik(int NastavnikId)
        {
            return Helper.GetPredmetiByNastavnik(NastavnikId);
        }

        [WebMethod]
        public Odjeljenje GetOdjeljenjeByRazrednik(int RazrednikId)
        {
            return Helper.GetOdjeljenjeByRazrednik(RazrednikId);
        }
    }
}
