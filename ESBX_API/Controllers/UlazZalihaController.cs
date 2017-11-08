using ESBX_API.Helper;
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

        [HttpGet]
        [Route(WebApiRoutes.GET_NABAVKE)]
        public HttpResponseMessage GetNabavke()
        {
            // &&  stavka.UlazZaliha.Dobavljaci.Status == false
            List<PregledDobavljaciForDg> listResponse =
                ctx.StavkaUlaza.Where(stavka => stavka.Sastojak.IsDeleted == false)
                               .Select(stavkaUlaza => new PregledDobavljaciForDg {

                                   SastojakId = stavkaUlaza.SastojakId,
                                   SastojakNaziv = stavkaUlaza.Sastojak.Naziv,
                                   NabavkaKolicina = stavkaUlaza.Kolicina,
                                   NabavkaCijena = stavkaUlaza.Cijena,
                                   NabavkaDate = stavkaUlaza.UlazZaliha.Datum,
                                   DobavljacId = stavkaUlaza.UlazZaliha.DobavljaciId,
                                   DobavljacNaziv = stavkaUlaza.UlazZaliha.Dobavljaci.Naziv,
                                   DobavljacTelefon = stavkaUlaza.UlazZaliha.Dobavljaci.BrojTelefona,
                                   DobavljacAdresa = stavkaUlaza.UlazZaliha.Dobavljaci.Adresa,
                                   DobavljacEmail = stavkaUlaza.UlazZaliha.Dobavljaci.Email,
                                   DobavljacRacun = stavkaUlaza.UlazZaliha.Dobavljaci.Ziroracun

                               }).ToList(); 
                                                    

            return Request.CreateResponse(HttpStatusCode.OK, listResponse);
        }
    }
}
