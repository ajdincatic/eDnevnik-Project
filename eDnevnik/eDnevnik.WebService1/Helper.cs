using eDnevnik.WebService1.Properties;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    public class Predmet
    {
        public string Naziv { get; set; }
    }

    public class Odjeljenje
    {
        public string Oznaka { get; set; }
    }

    public class Helper
    {
        public static List<Predmet> GetPredmetiByNastavnik(int Id)
        {
            var predmeti = new List<Predmet>();
            SqlConnection con = new SqlConnection(Resources.ConnectionString);
            string command = @"select Naziv
                                from [eDnevnikBaza].[eDnevnikBaza].[predmeti] 
                                where PredavacID = " + Id;
            SqlCommand cmd = new SqlCommand(command, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                predmeti.Add(new Predmet { Naziv = dr["Naziv"].ToString() });
            }

            dr.Close();
            con.Close();

            return predmeti;
        }

        public static Odjeljenje GetOdjeljenjeByRazrednik(int Id)
        {
            List<Odjeljenje> odjeljenje = new List<Odjeljenje>();
            SqlConnection con = new SqlConnection(Resources.ConnectionString);
            string command = @"SELECT [Oznaka]
                              FROM [eDnevnikBaza].[eDnevnikBaza].[odjeljenje]
                              WHERE [RazrednikID]= " + Id;
            SqlCommand cmd = new SqlCommand(command, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                odjeljenje.Add(new Odjeljenje { Oznaka = dr["Oznaka"].ToString() });
            }

            dr.Close();
            con.Close();

            return odjeljenje.FirstOrDefault();
        }
    }
}