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

        [HttpPost]
        [Route(WebApiRoutes.GET_NABAVKE)]
        public HttpResponseMessage GetNabavke(UlazZalihaRequestVM request)
        {
            //treba ljepse osmisliti
            List<PregledDobavljaciForDg> listResponse = new List<PregledDobavljaciForDg>();
            if (request == null)
            {
               listResponse = ctx.UlazZaliha
                              .Select(x => new PregledDobavljaciForDg
                              {

                                  UlazZalihaId = x.Id,
                                  Napomena = x.Napomena,
                                  NabavkaDate = x.Datum,
                                  DobavljacId = x.DobavljaciId,
                                  DobavljacNaziv = x.Dobavljaci.Naziv,
                                  DobavljacTelefon = x.Dobavljaci.BrojTelefona,
                                  DobavljacAdresa = x.Dobavljaci.Adresa,
                                  DobavljacEmail = x.Dobavljaci.Email,
                                  DobavljacRacun = x.Dobavljaci.Ziroracun,
                                  SastojciList = x.StavkaUlaza.Where(k => k.UlazZalihaId == x.Id).Select(z => new SastojciForGridVM
                                  {
                                      SastojakId = z.SastojakId,
                                      Cijena = z.Cijena,
                                      Naziv = z.Sastojak.Naziv,
                                      Kolicina = z.Kolicina
                                  })
                                  .ToList()

                              }).OrderByDescending(y => y.NabavkaDate).Take(10).ToList();
            }
            else
            {
                //POPRAVIS SVE OVO
                int rG = request.DatumFilter.Year;
                int rM= request.DatumFilter.Month;
                int rD = request.DatumFilter.Day;
                listResponse = ctx.UlazZaliha.Where(l=>
                       (l.DobavljaciId==request.DobavljacIdFilter  || request.DobavljacIdFilter == 0)
                    &&( (rG == DateTime.Now.Year && rM == DateTime.Now.Month && rD == DateTime.Now.Day) 
                       || (rG == 1 && rM == 1 && rD == 1)
                       || (l.Datum.Year == rG && l.Datum.Month == rM && l.Datum.Day == rD)
                       )
                    )
                              .Select(x => new PregledDobavljaciForDg
                              {

                                  UlazZalihaId = x.Id,
                                  Napomena = x.Napomena,
                                  NabavkaDate = x.Datum,
                                  DobavljacId = x.DobavljaciId,
                                  DobavljacNaziv = x.Dobavljaci.Naziv,
                                  DobavljacTelefon = x.Dobavljaci.BrojTelefona,
                                  DobavljacAdresa = x.Dobavljaci.Adresa,
                                  DobavljacEmail = x.Dobavljaci.Email,
                                  DobavljacRacun = x.Dobavljaci.Ziroracun,
                                  SastojciList = x.StavkaUlaza.Where(k => k.UlazZalihaId == x.Id).Select(z => new SastojciForGridVM
                                  {
                                      SastojakId = z.SastojakId,
                                      Cijena = z.Cijena,
                                      Naziv = z.Sastojak.Naziv,
                                      Kolicina = z.Kolicina
                                  })
                                  .ToList()

                              }).OrderByDescending(y => y.NabavkaDate).ToList();
            }


            return Request.CreateResponse(HttpStatusCode.OK, listResponse);
        }
    }
}
