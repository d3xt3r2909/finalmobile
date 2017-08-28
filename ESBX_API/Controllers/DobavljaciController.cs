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
    public class DobavljaciController : ApiController
    {
        MContext ctx = new MContext();
        [HttpGet]
        public List<Dobavljaci> GetDobavljaci(string naziv = "")
        {
            

            return naziv == "" ? ctx.Dobavljaci.ToList() : ctx.Dobavljaci.Where(x => x.Status == true && x.Naziv.StartsWith(naziv)).ToList();
        }
        
    }
}
