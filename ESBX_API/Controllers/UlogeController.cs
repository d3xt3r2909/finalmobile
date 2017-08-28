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

namespace ESBX_API.Controllers
{
    public class UlogeController : ApiController
    {
        MContext ctx = new MContext();
        public IHttpActionResult Post(KorisniciUloge k)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
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
    }
}
