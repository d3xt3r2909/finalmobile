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
    public class UlazZalihaController : ApiController
    {
        MContext ctx = new MContext();

        [HttpPost]
        public IHttpActionResult PostNabavka(UlazZaliha ulazZaliha)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            UlazZaliha z = new UlazZaliha();
            z.Datum = ulazZaliha.Datum;
            z.DobavljaciId = ulazZaliha.DobavljaciId;
            z.Dobavljaci= ctx.Dobavljaci.Where(x => x.Id == ulazZaliha.DobavljaciId).FirstOrDefault();
            z.Napomena = ulazZaliha.Napomena;
            ctx.UlazZaliha.Add(z);
            ctx.SaveChanges();

            UlazZaliha u= ctx.UlazZaliha.OrderByDescending(x => x.Id).FirstOrDefault();
            foreach (var i in ulazZaliha.StavkaUlaza)
            {
                StavkaUlaza su = new StavkaUlaza();
                su.Cijena = i.Cijena;
                su.Kolicina = i.Kolicina;
                su.SastojakId = i.SastojakId;
                su.Sastojak = ctx.Sastojci.Where(x => x.Id == i.SastojakId).FirstOrDefault();
                su.UlazZalihaId = u.Id;
                ctx.StavkaUlaza.Add(su);
                Sastojci s = ctx.Sastojci.Where(k => k.Id == su.SastojakId).FirstOrDefault();
                s.Stanje += su.Kolicina;
            }
            ctx.SaveChanges();

            return Ok(ulazZaliha);
        }

    }
}
