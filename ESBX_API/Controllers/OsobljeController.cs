using ESBX_db.DAL;
using ESBX_db.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ESBX_API.Controllers
{
    public class OsobljeController : ApiController
    {
        MContext ctx = new MContext();

        public IHttpActionResult PutOsobljeAktivan(int id, Korisnici k)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != k.Id)
                return BadRequest();

            Korisnici kor = ctx.Korisnici.Where(x => x.Id == k.Id).FirstOrDefault();
            kor.Aktivan = !kor.Aktivan;

            ctx.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
