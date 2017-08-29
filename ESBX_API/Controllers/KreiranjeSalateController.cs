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
    public class KreiranjeSalateController : ApiController
    {
        MContext ctx = new MContext();

        [HttpGet]
        [Route("api/KreiranjeSalate/{vrstaId}")]
        public IHttpActionResult GetSastojci(int vrstaId)
        {
            List<SastojciMobileVM> list = ctx.Sastojci.Where(x => x.VrstaSastojkaId == vrstaId && x.IsDeleted == false).Select(y => new SastojciMobileVM
            {
                Id = y.Id,
                Naziv = y.Naziv
            }).ToList();

            return Ok(list);
        }
    }
}
