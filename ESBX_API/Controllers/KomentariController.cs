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
    public class KomentariController : ApiController
    {


        MContext ctx = new MContext();

        [HttpGet]
        [Route("api/Komentari")]
        public IHttpActionResult GetKomentari()
        {
            
            List<KomentariMobileVM> komentari = ctx.OcjeneKomentari.OrderByDescending(x => x.Datum).Take(10).Select(y => new KomentariMobileVM
            {
                EmailKorisnika = y.Korisnik.Email,
                Ocjena = y.Ocjena,
                Komentar = y.Komentar,
                Vrijeme = (DateTime.Now - y.Datum).ToString("TT-hh-ss")

            }).ToList();

            return Ok(komentari);
        }
    }
}
