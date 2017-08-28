using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ESBX_db.DAL;
using ESBX_db.Models;
using ESBX_db.ViewModel;

namespace ESBX_db.Helper
{
    public class SastojciHelper
    {
        public static List<Sastojci> GetSastojci(string naziv = "")
        {
            MContext ctx = new MContext();

            return naziv == "" ? ctx.Sastojci.Where(x => x.IsDeleted == false).ToList() : ctx.Sastojci.Where(x => x.IsDeleted == false && x.Naziv.StartsWith(naziv)).ToList();
        }

        public static HttpStatusCode AddSastojci(Sastojci ns)
        {
            MContext ctx = new MContext();

            Sastojci isExists = ctx.Sastojci.FirstOrDefault(x => x.Naziv == ns.Naziv && x.IsDeleted == false);

            if (isExists != null)
                return HttpStatusCode.Conflict;

            ctx.Sastojci.Add(ns);

            ctx.SaveChanges(); 

            return HttpStatusCode.OK;
        }

        public static HttpStatusCode DeleteById(int id)
        {
            MContext ctx = new MContext();

            Sastojci isExists = ctx.Sastojci.FirstOrDefault(x => x.Id == id);

            if (isExists == null)
                return HttpStatusCode.NotFound;

            isExists.IsDeleted = true; 

            ctx.SaveChanges();

            return HttpStatusCode.OK;
        }
    }
}
