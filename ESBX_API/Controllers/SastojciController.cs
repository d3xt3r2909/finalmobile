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
        public HttpResponseMessage Sastojci(Sastojci ns)
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
        public List<Sastojci> GetSastojci(string naziv = "")
        {
            return SastojciHelper.GetSastojci(naziv);
        }

        [HttpGet]
        [Route("api/Sastojci/GetSastojak/{id?}")]
        public IHttpActionResult GetSastojak(string id)
        {
            int ID = Convert.ToInt32(id);
            Sastojci s = _ctx.Sastojci.FirstOrDefault(x => x.Id==ID);

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
    }
}
