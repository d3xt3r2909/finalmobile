using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;
using ESBX_db.DAL;
using ESBX_db.Models;
using ESBX_db.Helper;
using ESBX_db.ViewModel;

namespace ESBX_API.Controllers
{
    public class KorisniciController : ApiController
    {
        MContext ctx = new MContext();

        public List<Korisnici> GetKorisnici()
        {
            return AccountHelper.GetKorisnici();
        }

        public Korisnici GetKorisnici(int id)
        {
            return ctx.Korisnici.Where(x => x.Id == id).FirstOrDefault();
        }

        [HttpGet]
        [Route("api/Korisnici/SearchKorisnici/{parametar?}")]
        public List<Korisnici_OsobljeResult> SearchKorisnici(string parametar="")
        {
            List<Korisnici_OsobljeResult> osoblje = new List<Korisnici_OsobljeResult>();
            if (parametar == "")
            {

                List<int> osobljeIds = ctx.KorisniciUloge.Where(x => x.Uloga.Naziv==Constants.ULOGA_OSOBLJE).Select(y => y.KorisnikId).ToList();
                foreach (int i in osobljeIds)
                {
                    Korisnici_OsobljeResult k = ctx.Korisnici.Where(y => y.Id == i).Select(z => new Korisnici_OsobljeResult {
                        UposlenikId = z.Id,
                        Uposlenik = z.Ime + " " + z.Prezime,
                        Telefon = z.BrojTelefona,
                        Email = z.Email,
                        DatumZaposlenja=z.DatumKreiranja,
                        Aktivan=z.Aktivan
                    }).FirstOrDefault();
                    osoblje.Add(k);
                }

            }
           else
           {
                List<int> osobljeIds = ctx.KorisniciUloge.Where(x =>x.Uloga.Naziv==Constants.ULOGA_OSOBLJE).Select(y => y.KorisnikId).ToList();
                foreach (int i in osobljeIds)
                {
                    Korisnici_OsobljeResult k = ctx.Korisnici.Where(y => y.Id == i &&
                    ((y.Ime+" "+y.Prezime).ToLower().StartsWith(parametar.ToLower()) || (y.Prezime + " " + y.Ime).ToLower().StartsWith(parametar.ToLower()))
                    ).Select(z => new Korisnici_OsobljeResult
                        {
                            UposlenikId = z.Id,
                            Uposlenik = z.Ime + " " + z.Prezime,
                            Telefon = z.BrojTelefona,
                            Email = z.Email,
                            DatumZaposlenja = z.DatumKreiranja,
                            Aktivan = z.Aktivan
                        }) .FirstOrDefault();
                    if(k!=null)
                    osoblje.Add(k);
                }

            }
            return osoblje;


        }

        [HttpPut]
        public IHttpActionResult PutKorisnik(int id, Korisnici k)
        {
            //if (!ModelState.IsValid)
            //    return BadRequest(ModelState);

            if (id != k.Id)
                return BadRequest();

            Korisnici kor = ctx.Korisnici.Where(x => x.Id == k.Id).FirstOrDefault();
            kor.Ime = k.Ime;
            kor.Prezime = k.Prezime;
            kor.GradId = k.GradId;
            kor.Email = k.Email;
            kor.Adresa = k.Adresa;
            kor.BrojTelefona = k.BrojTelefona;
            kor.DatumRodjenja = k.DatumRodjenja;
            if (k.LozinkaHash != null)
            {
                kor.LozinkaHash = k.LozinkaHash;
            }

            ctx.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        public IHttpActionResult Post(Korisnici k)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                string tempLozinka = k.LozinkaHash;
                k.LozinkaHash = AccountHelper.GenerateHash(tempLozinka, k.LozinkaSalt);
                ctx.Korisnici.Add(k);
                ctx.SaveChanges();
                EmailVm email = new EmailVm();
                email.To = k.Email;
                email.Subject = "Dobrodošli u Express Salad Bar";
                email.Body =
                "Poštovani " + k.Ime + " " + k.Prezime + ", <br/><br/>" +
                "Želimo Vam srdačnu dobrodošlicu na sistem Express Salad Bar." +
                "<br/>Ukoliko imate bilo kakvih pitanja ili sugestija, molimo Vas da nas kontaktirate putem email adrese: expresssaladbar@gmail.com" +
                "<br/><br/>Podaci sa kojim se prijavljujete na sistem: " +
                "<br/><b>Email:</b> "+k.Email+
                "<br/><b>Lozinka:</b> "+tempLozinka+
                "<br/>Pripadate ulozi: Osoblje"+
                "<br/>Molimo Vas nakon prijave da promijenite Vašu lozinku." +
                "<br/><br/><br/>Lijep pozdrav," +
                "<br/>Vaš Express Salad Bar.";
                AccountHelper.Sendemail(email);
            }
            catch (Exception e)
            {
                SqlException ex = e.InnerException.InnerException as SqlException;

                //HttpResponseMessage error =
                //    ExceptionHandler.CreatedHttpResponseException(ExceptionHandler.HandleException(ex), HttpStatusCode.Conflict);

                // throw new HttpResponseException(error);

                throw e;
            }
           

            return Ok(k) ;
        }
        
    }
}
 
