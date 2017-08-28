using ESBX_db.DAL;
using ESBX_db.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ESBX_API.Controllers
{
    public class StatistikaZaradeController : ApiController
    {

        MContext ctx = new MContext();

        
        public List<PregledStatistikeVM> GetStatistikaZarada()
        {
            List<PregledStatistikeVM> zarada = new List<PregledStatistikeVM>();
            
                for(int i=1; i<13; i++)
                {
                   PregledStatistikeVM k = new PregledStatistikeVM();
                    if (i == 1) k.Mjesec = "Januar";
                    if (i == 2) k.Mjesec = "Februar";
                    if (i == 3) k.Mjesec = "Mart";
                    if (i == 4) k.Mjesec = "April";
                    if (i == 5) k.Mjesec = "Maj";
                    if (i == 6) k.Mjesec = "Juni";
                    if (i == 7) k.Mjesec = "Juli";
                    if (i == 8) k.Mjesec = "August";
                    if (i == 9) k.Mjesec = "Septembar";
                    if (i == 10) k.Mjesec = "Oktobar";
                    if (i == 11) k.Mjesec = "Novembar";
                    if (i == 12) k.Mjesec = "Decembar";
                    k.Zarada= ctx.Racun.Where(x => x.Datum.Year == DateTime.Now.Year && x.Datum.Month == i).Sum(y => (float?)y.UkupnaCijena) ?? 0;
                   k.BrojNarudzbi = ctx.Korpa.Where(x => x.Zavrsena == true && x.VrijemeNarucivanja.Year == DateTime.Now.Year && x.VrijemeNarucivanja.Month == i).Count();
                   k.RedniBroj = i;
                   zarada.Add(k);
                }
            return zarada;
        }
    }
}
