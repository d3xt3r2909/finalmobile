using ESBX_API.Helper;
using ESBX_Client.Menadzer;
using ESBX_Client.Osoblje;
using ESBX_Client.Util;
using ESBX_db.Helper;
using ESBX_db.Models;
using ExpressSaladBarDesktop_Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ESBX_Client
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            WebAPIHelper _service = new WebAPIHelper(WebApiRoutes.URL_ROUTE, WebApiRoutes.GET_ULOGA_BY_KORISNIK);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            frmLogin login = new frmLogin();


            // Ukoliko je uredan login, potrebno je odrediti na koju formu se korisnik prosljedjuje u zavinosti od uloge
            if (login.ShowDialog() == DialogResult.OK)
            {
                // Dobavljanje trenutne uloge logovanog korisnika
                HttpResponseMessage msg = _service.GetResponse(Global.prijavljeniKorisnik.Id);

                // Ukoliko je uloga pronadjena 
                if (msg.IsSuccessStatusCode)
                {
                    Uloge uloga = msg.Content.ReadAsAsync<Uloge>().Result;

                    // Preusmjerenje na glavnu formu osoblja
                    if (uloga.Naziv == Constants.ULOGA_OSOBLJE)
                        Application.Run(new OsobljeForm());

                    // Preusmjerenje na glavnu formu menadzera
                    if (uloga.Naziv == Constants.ULOGA_MENADZER)
                        Application.Run(new MenadzerForm());
                }
            }
        }
    }
}
