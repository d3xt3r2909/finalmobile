using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ESBX_db.DAL;
using ESBX_db.Models;
using ESBX_db.Helper;
using ESBX_API.Helper;
using ESBX_db.ViewModel;

namespace ESBX_API.Controllers
{
    public class SastojciController : ApiController
    {

        private readonly MContext _ctx = new MContext();

        /// <summary>
        /// API route za dodavanje novih sastojaka u bazu podataka
        /// </summary>
        /// <param name="ns"></param>
        /// <returns></returns>
        [HttpPost]
        [Route(WebApiRoutes.POST_SASTOJCI)]
        public HttpResponseMessage Sastojci(SastojciPostWithImage ns)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            HttpStatusCode response = SastojciHelper.AddSastojci(ns);

            if (HttpStatusCode.Conflict == response)
                return Request.CreateResponse(HttpStatusCode.Conflict, ns);

            return Request.CreateResponse(HttpStatusCode.OK, ns);
        }

        /// <summary>
        /// API route za dobivanje svih sastojaka. Ukoliko proslijedimo i parametar naziv
        /// tada cemo filtrirati sastojke sa ovom vrijednoscu
        /// </summary>
        /// <param name="naziv"></param>
        /// <returns></returns>
        [HttpGet]
        [Route(WebApiRoutes.GET_SASTOJCI + "{naziv?}")]
        public HttpResponseMessage GetSastojci(string naziv = "")
        {
            List<SastojciPregledVm> response = SastojciHelper.GetSastojci(naziv);
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [HttpGet]
        [Route(WebApiRoutes.GET_SASTOJCI_LIST_OMILJENI + "{vrstasastojka?}")]
        public HttpResponseMessage GetListOmiljeni(string vrstasastojka = "")
        {
            List<Sastojci> listSastojci = SastojciHelper.GetOmiljeni(vrstasastojka);
            List<OmiljeniSastojci> sastojci = new List<OmiljeniSastojci>();
            foreach (Sastojci item in listSastojci) {

                OmiljeniSastojci tmp = new OmiljeniSastojci();
                tmp.SastojakId = item.Id;
                tmp.Naziv = item.Naziv;
                byte[] slikaSastojka = _ctx.Slike.Where(slika => slika.SastojakId == item.Id).Select(x => x.Slika).FirstOrDefault();

                if (slikaSastojka != null)
                {
                    tmp.SlikaThumb = slikaSastojka;
                }

                sastojci.Add(tmp);
            }

            return Request.CreateResponse(HttpStatusCode.OK, sastojci);
        }

        [HttpGet]
        [Route("api/Sastojci/GetSastojak/{id?}")]
        public IHttpActionResult GetSastojak(string id)
        {
            int ID = Convert.ToInt32(id);
            SastojciPregledVm s = _ctx.Sastojci.Select(item => new SastojciPregledVm {
                BrojKalorija = item.BrojKalorija,
                Cijena = item.Cijena,
                Gramaza = item.Gramaza,
                Id = item.Id,
                Naziv = item.Naziv,
                Stanje = item.Stanje,
                VrstaSastojka = item.VrstaSastojka.Naziv
            }).FirstOrDefault(x => x.Id==ID);

            if (s == null)
                return NotFound();

            return Ok(s);
        }

        [HttpGet]
        [Route(WebApiRoutes.GET_VRSTE_SASTOJAKA)]
        public IHttpActionResult GetVrstaSastojka()
        {
            List<VrstaSastojka> vrsteSastojaka = _ctx.VrstaSastojka.ToList();

            if (vrsteSastojaka.Count == 0)
                return NotFound();

            return Ok(vrsteSastojaka);
        }

        [HttpDelete]
        [Route(WebApiRoutes.DELETE_VRSTE_SASTOJAKA + "{id}")]
        public IHttpActionResult DeleteById(int id)
        {
            HttpStatusCode response = SastojciHelper.DeleteById(id);

            if (response == HttpStatusCode.NotFound)
                return NotFound();

            return Ok();
        }

        [HttpPost]
        [Route(WebApiRoutes.POST_DODAJ_OMILJENE)]
        public IHttpActionResult PostOmiljeni(KorisnikSastojciVm ks)
        {

            KorisnikSastojci korSas = new KorisnikSastojci();
            korSas.KorisnikId = ks.KorisnikId;
            korSas.SastojakId = ks.SastojakId;
            _ctx.KorisnikSastojci.Add(korSas);
            _ctx.SaveChanges();

            return Ok();
        }

    }
}
