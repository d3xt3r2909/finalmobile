using ESBX_db.DAL;
using ESBX_db.Helper;
using ESBX_db.Models;
using ESBX_db.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace ESBX_API.Controllers
{
    public class KreiranjeSalateController : ApiController
    {
        MContext ctx = new MContext();

        [HttpGet]
        [Route("api/KreiranjeSalate/getsastojci/{vrstanaziv}")]
        public IHttpActionResult GetSastojci(string vrstanaziv)
        {
            List<SastojciMobileVM> list = ctx.Sastojci.Where(x => x.VrstaSastojka.Naziv == vrstanaziv && x.IsDeleted == false).Select(y => new SastojciMobileVM
            {
                Id = y.Id,
                Naziv = y.Naziv
            }).ToList();

            return Ok(list);
        }


        [HttpPost]
        [Route("api/KreiranjeSalate")]
        public IHttpActionResult PostSnimi(KreiranaSalataVM Salata)
        {
            if (Salata != null)
            {
                // Kreiranje nove salate - trenutni datum i note
                Salate s = new Salate
                {
                    DatumKreiranja = DateTime.Now,
                    Napomena = Salata.Napomena
                };

                ctx.Salate.Add(s);
                ctx.SaveChanges();

                // Povezivanje novokreirane salate sa stavkama salate 
                SalataStavke ss;
                // Spajanje salate sa odabranim sastojcima
                foreach(int i in Salata.listaIzabranih)
                {
                    ss = new SalataStavke
                    {
                        SalataId = s.Id,
                        SastojakId = i
                    };

                    ctx.SalataStavke.Add(ss);
                };

                // Snimanje promijena
                // Rezultat je da bi trebala postojati nova salata i biti spojena sa svim odabranim sastojcima 
                ctx.SaveChanges();

                #region DodavanjeSalateUKorpu

                // Pretraga za korpom, da li korpa korisnika vec postoji i da li je ona aktivna 
                var k = ctx.Korpa.FirstOrDefault(x => x.Aktivna && x.Korisnik.Id == Salata.KorisnikId);

                // Ukoliko korisnik nema korpu, potrebno je kreirati novu i aktivirati je
                if (k == null)
                {
                    // Inicijalizacija nove korpe
                    k = new Korpa
                    {
                        KorisnikId = Salata.KorisnikId,
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

                // Potrebno je uvezati korisnicku korpu sa stavkama, odnosno sa salatama 
                KorpaStavke ks = new KorpaStavke
                {
                    KorpaId = k.Id,
                    SalataId = s.Id,
                    Kolicina = Salata.Kolicina
                };

                // Dodavanje u tabelu stavki korpe 
                ctx.KorpaStavke.Add(ks);
            
                // Snimanje promijena
                ctx.SaveChanges();

                #endregion
                return Ok();
            }

            return NotFound();
        }
    }
}
