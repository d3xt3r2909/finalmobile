using ESBX_db.DAL;
using ESBX_db.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;

namespace ESBX_API.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using ExpressSaladBarDataDB.Models;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<UlazZaliha>("UlazZalihas");
    builder.EntitySet<Dobavljaci>("Dobavljaci"); 
    builder.EntitySet<StavkaUlaza>("StavkaUlaza"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class pomazeMi_NeDiraj : ODataController
    {
        private MContext db = new MContext();

        // GET: odata/UlazZalihas
        [EnableQuery]
        public IQueryable<UlazZaliha> GetUlazZalihas()
        {
            return db.UlazZaliha;
        }

        // GET: odata/UlazZalihas(5)
        [EnableQuery]
        public SingleResult<UlazZaliha> GetUlazZaliha([FromODataUri] int key)
        {
            return SingleResult.Create(db.UlazZaliha.Where(ulazZaliha => ulazZaliha.Id == key));
        }

        // PUT: odata/UlazZalihas(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<UlazZaliha> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            UlazZaliha ulazZaliha = db.UlazZaliha.Find(key);
            if (ulazZaliha == null)
            {
                return NotFound();
            }

            patch.Put(ulazZaliha);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UlazZalihaExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(ulazZaliha);
        }

        // POST: odata/UlazZalihas
        public IHttpActionResult Post(UlazZaliha ulazZaliha)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.UlazZaliha.Add(ulazZaliha);
            db.SaveChanges();

            return Created(ulazZaliha);
        }

        // PATCH: odata/UlazZalihas(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<UlazZaliha> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            UlazZaliha ulazZaliha = db.UlazZaliha.Find(key);
            if (ulazZaliha == null)
            {
                return NotFound();
            }

            patch.Patch(ulazZaliha);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UlazZalihaExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(ulazZaliha);
        }

        // DELETE: odata/UlazZalihas(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            UlazZaliha ulazZaliha = db.UlazZaliha.Find(key);
            if (ulazZaliha == null)
            {
                return NotFound();
            }

            db.UlazZaliha.Remove(ulazZaliha);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/UlazZalihas(5)/Dobavljaci
        [EnableQuery]
        public SingleResult<Dobavljaci> GetDobavljaci([FromODataUri] int key)
        {
            return SingleResult.Create(db.UlazZaliha.Where(m => m.Id == key).Select(m => m.Dobavljaci));
        }

        // GET: odata/UlazZalihas(5)/StavkaUlaza
        [EnableQuery]
        public IQueryable<StavkaUlaza> GetStavkaUlaza([FromODataUri] int key)
        {
            return db.UlazZaliha.Where(m => m.Id == key).SelectMany(m => m.StavkaUlaza);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UlazZalihaExists(int key)
        {
            return db.UlazZaliha.Count(e => e.Id == key) > 0;
        }
    }
}
