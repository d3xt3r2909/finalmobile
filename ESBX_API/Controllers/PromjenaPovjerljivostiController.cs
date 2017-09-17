using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ESBX_db.DAL;
using ESBX_db.Models;
using ESBX_db.ViewModel;
using ESBX_db.Helper;
using ESBX_API.Helper;

namespace ESBX_API.Controllers
{

    public class PromjenaPovjerljivostiController : ApiController
    {
        MContext ctx = new MContext();

        [HttpPut]
        [Route(WebApiRoutes.PUT_KORISNICI_POVJERLJIVOST)]
        public IHttpActionResult PutPromjenaPovjerljivosti(PromjenaPovjerljivostiVm povjerljivost)
        {
            Korisnici k = ctx.Korisnici.FirstOrDefault(x => x.Id == povjerljivost.KorisnikId);

            if (k == null)
                return StatusCode(HttpStatusCode.NotFound); 

            // Promijena povjerljivosti korisnika
            k.Povjerljiv = povjerljivost.Status;
            ctx.SaveChanges();

            // Pronalazak korpe korisnika kako bi se azurirao racun
            // Samo u slucaju da se povjerljivost mijenja iz FALSE u TRUE
            if (povjerljivost.Status)
            {
                Korpa korpa = ctx.Korpa.FirstOrDefault(x => x.KorisnikId == povjerljivost.KorisnikId && x.Racun == null);

                if (korpa == null)
                    return StatusCode(HttpStatusCode.NotFound);

                Racun racun = new Racun();
                ctx.Racun.Add(racun);
                racun.Datum = DateTime.Now;
                racun.KorpaId = korpa.Id;
                racun.UkupnaCijena = UkupanDug(povjerljivost.KorisnikId);
                korpa.Racun = racun;

                ctx.SaveChanges();
            }

            return StatusCode(HttpStatusCode.OK);
        }

        [HttpGet]
        [Route("api/PromjenaPovjerljivosti/SearchNepovjerljivi/{parametar?}")]
        public List<Korisnici_NepovjerljiviResult> SearchNepovjerljivi(string parametar = "")
        {
            List<Korisnici_NepovjerljiviResult> nepovjerljivi = new List<Korisnici_NepovjerljiviResult>();
            if (parametar == "")
            {
                List<int> korisniciIds = ctx.KorisniciUloge.Where(x => x.Uloga.Naziv==Constants.ULOGA_KORISNIK).Select(y => y.KorisnikId).ToList();
                foreach (int i in korisniciIds)
                {
                    Korisnici z = ctx.Korisnici.Where(y => y.Id == i && y.Povjerljiv == false).FirstOrDefault();
                    if (z != null)
                    {
                        Korisnici_NepovjerljiviResult nepovjerljiv = new Korisnici_NepovjerljiviResult();
                        nepovjerljiv.KorisnikId = z.Id;
                        nepovjerljiv.Korisnik = z.Ime + " " + z.Prezime;
                        nepovjerljiv.Telefon = z.BrojTelefona;
                        nepovjerljiv.Email = z.Email;
                        nepovjerljiv.UkupanDug = UkupanDug(i);
                        nepovjerljivi.Add(nepovjerljiv);
                    }
                }

            }
            else
            {
                List<int> korisniciIds = ctx.KorisniciUloge.Where(x => x.Uloga.Naziv == Constants.ULOGA_KORISNIK).Select(y => y.KorisnikId).ToList();
                foreach (int i in korisniciIds)
                {
                    Korisnici z = ctx.Korisnici.Where(y => y.Id == i && y.Povjerljiv == false &&
                    ((y.Ime + " " + y.Prezime).ToLower().StartsWith(parametar.ToLower()) || (y.Prezime + " " + y.Ime).ToLower().StartsWith(parametar.ToLower()))
                    ).FirstOrDefault();
                    if (z != null)
                    {
                        Korisnici_NepovjerljiviResult nepovjerljiv = new Korisnici_NepovjerljiviResult();
                        nepovjerljiv.KorisnikId = z.Id;
                        nepovjerljiv.Korisnik = z.Ime + " " + z.Prezime;
                        nepovjerljiv.Telefon = z.BrojTelefona;
                        nepovjerljiv.Email = z.Email;
                        nepovjerljiv.UkupanDug = UkupanDug(i);
                        nepovjerljivi.Add(nepovjerljiv);
                    }

                }

            }
            return nepovjerljivi;

        }

        //PROMJENI POVJERLJIVOST ODREDENOG KORISNIKA
        public float UkupanDug(int KorisnikId)
        {
            //ukupno za racun
            float UkupnaCijena = 0;
            float cijenaSalate = 0;
            Korpa korpa = ctx.Korpa.Where(x => x.KorisnikId == KorisnikId && x.Racun == null).FirstOrDefault();

            if (korpa == null) return 0;
            UkupnaCijenaVM model = new UkupnaCijenaVM();
            model.listaSalataId = ctx.KorpaStavke.Where(y => y.KorpaId == korpa.Id).Select(p => new ListaVrijednostiVM
            {
                SalataId = p.SalataId,
                Kolicina = p.Kolicina
            }).ToList();

            foreach (ListaVrijednostiVM h in model.listaSalataId)
            {
                cijenaSalate =
                    ctx.SalataStavke.Where(f => f.SalataId == h.SalataId).Select(s => s.Sastojak.Cijena).Sum();
                UkupnaCijena += cijenaSalate * h.Kolicina;
            }

            return UkupnaCijena;
        }
    }
}
