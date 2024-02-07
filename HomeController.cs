using AppData.Models;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace AppData.Controllers
{
    public class HomeController : Controller
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-5IJUAB9\\SQLEXPRESS01;Initial Catalog=MyDatabase;User ID=sa;Password=NovaLozinka77//");

        private List<MyModel> MojiPodaciIzBaze;

        private void DisplayData(string searchString)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM [MyDatabase].[dbo].[Artikli] WHERE Naziv = @searchString", con);
                cmd.Parameters.AddWithValue("@searchString", searchString);
                SqlDataReader rdr = cmd.ExecuteReader();
                MojiPodaciIzBaze = new List<MyModel>();

                while (rdr.Read())
                {
                    MojiPodaciIzBaze.Add(new MyModel
                    {
                        ID = Convert.ToInt32(rdr["ID"]),
                        Naziv = rdr["Naziv"].ToString(),
                        Opis = rdr["Opis"].ToString(),
                        Cena = Convert.ToInt32(rdr["Cena"]),
                        Kolicina = Convert.ToInt32(rdr["Kolicina"]),
                        Proizvodjac = rdr["Proizvodjac"].ToString(),
                        DatumDodavanja = Convert.ToDateTime(rdr["DatumDodavanja"])
                    });
                }

                Console.WriteLine("Number of rows loaded: " + MojiPodaciIzBaze.Count);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading data: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        public IActionResult Index(string searchString)
        {
            if (!String.IsNullOrEmpty(searchString))
            {
                DisplayData(searchString);
            }

            if (MojiPodaciIzBaze == null)
            {
                return View(new List<MyModel>());
            }

            return View(MojiPodaciIzBaze);
        }

       

        public IActionResult Privacy()
        {
            // Logika za Privacy akciju
            return View();
        }
    }
}
