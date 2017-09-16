using ESBX_db.DAL;
using ESBX_db.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ExpressSaladBarDesktop_API.Util;
using ESBX_API.Helper;

namespace ESBX_API.Controllers
{
    public class UlogeController : ApiController
    {
        MContext ctx = new MContext();

        [HttpPost]
        public IHttpActionResult Post(KorisniciUloge k)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                k.UlogaId = ctx.Uloge.Where(x => x.Naziv == k.Uloga.Naziv).Select(y => y.Id).FirstOrDefault();
                ctx.KorisniciUloge.Add(k);
                ctx.SaveChanges();
            }
            catch (Exception e)
            {
                SqlException ex = e.InnerException.InnerException as SqlException;
            
                HttpResponseMessage msg =
                    ExceptionHandler.CreatedHttpResponseException(ExceptionHandler.HandleException(ex),
                        HttpStatusCode.Conflict);

                throw new HttpResponseException(msg);
            }

            return Ok(k);
        }

        [HttpGet]
        [Route(WebApiRoutes.GET_VRSTE_ULOGA)]
        public HttpResponseMessage GetVrsteUloga()
        {
            return Request.CreateResponse(HttpStatusCode.OK, ctx.Uloge.ToList());
        }
    }
}
