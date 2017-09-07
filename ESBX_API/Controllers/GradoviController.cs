using ESBX_API.Helper;
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
    public class GradoviController : ApiController
    {

        MContext ctx = new MContext();

        [HttpGet]
        [Route(WebApiRoutes.GET_GRADOVI)]
        public List<Grad> GetGradovi()
        {
            return ctx.Gradovi.ToList();
        }
    }
}
