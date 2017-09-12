using ESBX_db.DAL;
using ESBX_db.Helper;
using ESBX_db.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ESBX_API.Controllers
{
    public class AddSaladMobileController : ApiController
    {
        MContext ctx = new MContext();

        [HttpPost]
        [Route("api/AddSaladMobile")]
        public IHttpActionResult DodajSalata(int Salata)
        {
            int saladId = Convert.ToInt32(Salata);
            if (saladId != 0)
            {
                #region DodavanjeSalateUKorpu

                // Pretraga za korpom, da li korpa korisnika vec postoji i da li je ona aktivna 
                Korpa k = ctx.Korpa.FirstOrDefault(x => x.Aktivna && x.Korisnik.Email == System.Web.HttpContext.Current.User.Identity.Name);

                // Ukoliko korisnik nema korpu, potrebno je kreirati novu i aktivirati je
                if (k == null)
                {
                    // Inicijalizacija nove korpe
                    k = new Korpa
                    {
                        KorisnikId = 10,
                        //VRATI
                        //AccountHelper.GetUserId(System.Web.HttpContext.Current.User.Identity.Name),
                        Zavrsena = false,
                        Aktivna = true,
                        VrijemeDolaska = DateTime.Now,
                        VrijemeNarucivanja = DateTime.Now,
                        Sifra = Constants.GenerateUniqueKod(9)
                    };
                    ctx.Korpa.Add(k);
                    // Spasavanje promijena
                    ctx.SaveChanges();
                }



                KorpaStavke ks = new KorpaStavke
                {
                    KorpaId = k.Id,
                    SalataId = saladId,
                    Kolicina = 1
                };

                // Dodavanje u tabelu stavki korpe 
                ctx.KorpaStavke.Add(ks);

                // Snimanje promijena
                ctx.SaveChanges();

                #endregion

                return Ok();
            }
            else
            {
                return BadRequest();
            }


        }
    }
}
