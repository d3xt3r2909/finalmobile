using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ESBX_API.Helper;
using ESBX_db.DAL;
using ESBX_db.ViewModel;
using ESBX_db.Models;

namespace ESBX_API.Controllers
{
    public class NarudbaReportController : ApiController
    {

        MContext ctx = new MContext();

        [HttpGet]
        //[Route("")]
        [Route("api/NarudbaReport/GetNarudzbe/{datumOdP}/{datumDoP}")]
        public List<Narudzba_ReportResult> GetNarudzbe(string datumOdP, string datumDoP)
        {
            DateTime datumOd = Convert.ToDateTime(datumOdP);
            DateTime datumDo= Convert.ToDateTime(datumDoP);

            int brojac = 1;
            List<Narudzba_ReportResult> narudzbeList = new List<Narudzba_ReportResult>();

            List<Korpa> korpe = ctx.Korpa.Where(x => x.VrijemeNarucivanja >= datumOd && x.VrijemeNarucivanja <= datumDo && x.Aktivna==false && x.Zavrsena==true && x.Finilizirana==true).ToList();
            foreach (var i in korpe)
            {
                Narudzba_ReportResult n = new Narudzba_ReportResult();

                n.RedniBroj = brojac;
                brojac++;
                if(i.Racun != null)
                     n.CijenaNarudzbe = i.Racun.CijenaSaPopustom;
                n.DatumNarudzbe = i.VrijemeNarucivanja.ToString("MM/dd/yyyy");
                narudzbeList.Add(n);
            }
            return narudzbeList;
        }


        [HttpGet]
        [Route(WebApiRoutes.GET_REPORT_PREGLED_DANA)]
        public IHttpActionResult GetPregledDana()
        {
            List<PregledDanaRepVm> response = ctx.Korpa
                .Where(x => x.Racun.Datum.Year == DateTime.Now.Year &&
                            x.Racun.Datum.Day == DateTime.Now.Day)
                .Select(item => new PregledDanaRepVm
                {
                    Id = item.Id,
                    Datum = DateTime.Now,
                    BrojSalata = ctx.KorpaStavke.Where(stavka => stavka.KorpaId == item.Id).Sum(suma => suma.Kolicina), 
                    Cijena = item.Racun.UkupnaCijena,
                    Sifra = item.Sifra,
                }).ToList();

            return Ok(response);
        }
    }
}
