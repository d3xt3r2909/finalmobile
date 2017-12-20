using ESBX_API.Helper;
using ESBX_db.DAL;
using ESBX_db.Helper;
using ESBX_db.Models;
using ESBX_db.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ESBX_API.Controllers
{
    public class NagradnaIgraController : ApiController
    {

        MContext ctx = new MContext();

        [HttpPost]
        public IHttpActionResult PostNagradnaIgra(NagradnaIgra ng)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            ng.KuponKod = Constants.GenerateUniqueKod(6);
            ctx.NagradnaIgra.Add(ng);
            ctx.SaveChanges();

            return Ok(ng);
        }

        [HttpGet]
        public IHttpActionResult GetNagradna()
        {
            NagradnaIgraVM model = new NagradnaIgraVM();
            List<Racun> racuni = ctx.Racun.Where(x => x.Datum.Year == DateTime.Now.Year && x.Datum.Month == DateTime.Now.Month).ToList();
            List<Korpa> korpe = new List<Korpa>();
            List<Korisnici> korisnici = new List<Korisnici>() ;
            Korisnici korisnik = new Korisnici();
            float Ukupno = 0;

            foreach (var bill in racuni)
                korpe.Add(ctx.Korpa.Where(x => x.Id == bill.KorpaId).FirstOrDefault());

            foreach (var k in korpe)
            {
                Korisnici kor = ctx.Korisnici.Where(x => x.Id == k.KorisnikId).FirstOrDefault();
                if (korisnici.Where(l => l.Id == kor.Id).FirstOrDefault() == null)
                {
                    korisnici.Add(kor);
                }
                
            }

              

            foreach(var i in korisnici)
            {
                List<Korpa> korp = korpe.Where(x => x.KorisnikId == i.Id).ToList();
                float cijena=0;

                foreach (var l in korp)
                  cijena += racuni.Where(x => x.KorpaId == l.Id).Sum(y => (float?)y.CijenaSaPopustom) ?? 0;

                if (cijena >= Ukupno)
                {
                    Ukupno = cijena;
                    korisnik = ctx.Korisnici.Where(x => x.Id == i.Id).FirstOrDefault();
                }
            }

            model.Korisnik = korisnik.Ime+" "+korisnik.Prezime;
            model.KorisnikId = korisnik.Id;
            model.UkupnoPotroseno = Ukupno;
            model.Telefon = korisnik.BrojTelefona;

            return Ok(model);
        }

        [HttpPost]
        [Route(WebApiRoutes.GET_NAGRADNE_IGRE)]
        public HttpResponseMessage GetNagradnaIgra(GetNagradnaIgraRequest query)
        {
            List<GetNagradnaIgraResponse> result = ctx.NagradnaIgra.Where(
                                   igra => query.GetAll == true 
                                         || 
                                         (
                                         (igra.Iskoristen == query.Status)
                                         &&  (query.KuponKod == "" || query.KuponKod == null || igra.KuponKod == query.KuponKod)
                                         &&  (query.KorisnikId == 0 || query.KorisnikId == null || igra.KorisniciId == query.KorisnikId)
                                         &&  (query.KorisnikImePrezime == "" || query.KorisnikImePrezime == null || (igra.Korisnici.Ime + " " + igra.Korisnici.Prezime).ToLower().Contains(query.KorisnikImePrezime))
                                         &&  (igra.VaziDo > query.DatumStart) && (igra.VaziDo < query.DatumEnd)
                                         )
                                )
                                .Select(item => new GetNagradnaIgraResponse
                                {
                                    KorisnikEmail = item.Korisnici.Email,
                                    KorisnikId = item.KorisniciId,
                                    KorisnikImePrezime = item.Korisnici.Ime + " " + item.Korisnici.Prezime,
                                    KuponKod = item.KuponKod,
                                    Popust = item.Popust,
                                    Iskoristen = item.Iskoristen, 
                                    VaziDo = item.VaziDo
                                }).ToList();

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
        [Route("api/NagradnaIgra/GetKupon/{KorisnikId}")]
        public IHttpActionResult GetKupon(string KorisnikId)
        {
            int korisnikId = Convert.ToInt32(KorisnikId);
            NagradnaVM n = new NagradnaVM();
            NagradnaIgra i = new NagradnaIgra();

            i = ctx.NagradnaIgra.Where(x => x.KorisniciId == korisnikId && x.Iskoristen == false
                  && x.VaziDo > DateTime.Now).FirstOrDefault();

            if(i==null)
            {
                n.imaPopust = "ne";
            }

            else
            {
                n.KorisnikId = i.KorisniciId;
                n.Popust = i.Popust.ToString() + " %";
                n.Sifra = i.KuponKod;
                n.VrijediDo = i.VaziDo.ToString("dd-MM-yyyy");
                n.imaPopust = "da";
            }

            return Ok(n);
        }
    }
}
