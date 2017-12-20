using ESBX_db.DAL;
using ESBX_db.Models;
using ESBX_db.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ESBX_API.Controllers
{
    public class KomentariController : ApiController
    {

        MContext ctx = new MContext();

        [HttpGet]
        [Route("api/Komentari")]
        public IHttpActionResult GetKomentari()
        {
            List<OcjeneKomentari> komentari = ctx.OcjeneKomentari.OrderByDescending(x => x.Datum).Take(10).ToList();

            List<KomentariMobileVM> kom = new List<KomentariMobileVM>();
            foreach(var i in komentari)
            {
                KomentariMobileVM k = new KomentariMobileVM();
                k.EmailKorisnika = i.Korisnik.Email;
                k.Ocjena = i.Ocjena;
                k.Komentar = i.Komentar;
                k.Vrijeme = Razlika(i.Datum).ToString();
                kom.Add(k);
            }
                
            return Ok(kom);
        }

        public string Razlika(DateTime datum)
        {
            DateTime danas = DateTime.Now;
            double raz = Math.Round((danas - datum).TotalMinutes, 0);
            string rezultat;

            if (raz > 60)
            {
                raz = Math.Round((danas - datum).TotalHours, 0);
                rezultat = raz.ToString() + " h";
                if (raz > 24)
                {
                    raz = Math.Round((danas - datum).TotalDays, 0);
                    rezultat = raz.ToString() + " d";
                }
            }
            else
            {
                rezultat = raz.ToString() + " min";
            }
            
            return "prije " + rezultat;
        }
    }
}
