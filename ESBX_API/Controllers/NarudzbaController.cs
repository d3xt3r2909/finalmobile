using ESBX_API.Helper;
using ESBX_db.DAL;
using ESBX_db.Helper;
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
    public class NarudzbaController : ApiController
    {
        MContext ctx = new MContext();

        [HttpGet]
        [Route("api/Narudzba/GetTrenutneNarudzbe/{KorisnikId}")]
        public IHttpActionResult GetTrenutneNarudzbe(string KorisnikId)
        {
            int korId = Convert.ToInt32(KorisnikId);
            List<NarudzbeVM> listSalata = new List<NarudzbeVM>();

            int KorpaId = ctx.Korpa.Where(x => x.KorisnikId == korId && x.Aktivna == false && x.Zavrsena == false && x.Finilizirana == false).Select(x => x.Id).FirstOrDefault();
            UkupnaCijenaVM model = new UkupnaCijenaVM();
            model.listaSalataId = ctx.KorpaStavke.Where(y => y.KorpaId == KorpaId).Select(p => new ListaVrijednostiVM
            {
                SalataId = p.SalataId,
                Kolicina = p.Kolicina
            }).ToList();

            foreach (var i in model.listaSalataId)
            {
                NarudzbeVM n = new NarudzbeVM();
                n.SalataId = i.SalataId;
                n.Kolicina = i.Kolicina.ToString();
                List<String> nazivi = ctx.SalataStavke.Where(x => x.SalataId == i.SalataId).Select(y => y.Sastojak.Naziv).ToList();
                foreach (var k in nazivi)
                {
                    n.Sastojci += k + ",";
                }
                n.Sastojci = n.Sastojci.Remove(n.Sastojci.Length - 1, 1);
                List<float> cijene = ctx.SalataStavke.Where(x => x.SalataId == i.SalataId).Select(y => y.Sastojak.Cijena).ToList();
                float UkupnoOdSastojaka = 0;
                foreach (var k in cijene)
                {
                    UkupnoOdSastojaka += k;
                }
                n.Cijena = (UkupnoOdSastojaka * i.Kolicina).ToString();
                listSalata.Add(n);
            }


            return Ok(listSalata);
        }


        //GetHistorijaNarudzbe
        [HttpGet]
        [Route("api/Narudzba/GetHistorijaNarudzbe/{KorisnikId}")]
        public IHttpActionResult GetHistorijaNarudzbe(string KorisnikId)
        {
            int korId = Convert.ToInt32(KorisnikId);
            List<NarudzbeVM> listSalata = new List<NarudzbeVM>();

            List<int> korpaIds = ctx.Korpa.Where(x => x.KorisnikId == korId && x.Aktivna == false && x.Zavrsena == true && x.Finilizirana == true).Select(x => x.Id).ToList();

            foreach (var korpaId in korpaIds)
            {
                List<KorpaStavke> ks = ctx.KorpaStavke.Where(y => y.KorpaId == korpaId).ToList();

                foreach (KorpaStavke item in ks)
                {
                    NarudzbeVM n = new NarudzbeVM();
                    n.SalataId = item.SalataId;
                    n.KorpaId = item.KorpaId;
                    n.KorisnikId = korId;
                    // Ukoliko je narudzba vec komentirana treba postaviti u view model kako bi mogli iskoristiti u listi na client strani
                    OcjeneKomentari tmp = ctx.OcjeneKomentari.FirstOrDefault(ok => ok.SalataId == item.SalataId && ok.KorisnikId == korId);

                    if (tmp == null)
                        n.Komentirana = false;
                    else
                        n.Komentirana = true;

                    List<String> nazivi = ctx.SalataStavke.Where(x => x.SalataId == item.SalataId).Select(y => y.Sastojak.Naziv).ToList();
                    foreach (var k in nazivi)
                    {
                        n.Sastojci += k + ",";
                    }
                    n.Sastojci = n.Sastojci.Remove(n.Sastojci.Length - 1, 1);
                    List<float> cijene = ctx.SalataStavke.Where(x => x.SalataId == item.SalataId).Select(y => y.Sastojak.Cijena).ToList();
                    float UkupnoOdSastojaka = 0;
                    foreach (var k in cijene)
                    {
                        UkupnoOdSastojaka += k;
                    }
                    n.Cijena = UkupnoOdSastojaka.ToString();
                    listSalata.Add(n);
                }

            }

            return Ok(listSalata);
        }

        [HttpPost]
        public IHttpActionResult PostSalata(NarudzbeVM Salata)
        {
            int saladId = Convert.ToInt32(Salata.SalataId);
            if (Salata != null)
            {
                #region DodavanjeSalateUKorpu

                // Pretraga za korpom, da li korpa korisnika vec postoji i da li je ona aktivna 
                Korpa k = ctx.Korpa.FirstOrDefault(x => x.Aktivna && x.Korisnik.Id == Salata.KorisnikId);

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

        [HttpPost]
        [Route(WebApiRoutes.POST_KOMENTAR_SALATA)]
        public HttpResponseMessage PostKomentar(KomentarVm komentar)
        {
            if (!ModelState.IsValid)
                return Request.CreateResponse(HttpStatusCode.MethodNotAllowed, "Polja koja ste unjeli nisu validna");

            OcjeneKomentari ocjenaKomentar = ctx.OcjeneKomentari.FirstOrDefault(ocjkom => ocjkom.KorisnikId == komentar.KorisnikId && ocjkom.SalataId == komentar.SalataId);


            if (ocjenaKomentar == null)
            {
                OcjeneKomentari ok = new OcjeneKomentari();

                ok.KorisnikId = komentar.KorisnikId;
                ok.SalataId = komentar.SalataId;
                ok.Komentar = komentar.Komentar;
                ok.Ocjena = komentar.Ocjena;
                ok.Datum = DateTime.Now;

                ctx.OcjeneKomentari.Add(ok);
            }
            else
            {
                ocjenaKomentar.Komentar = komentar.Komentar;
                ocjenaKomentar.Ocjena = komentar.Ocjena;
            }

            ctx.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, "Uspjesno ste postavili komentar");
        }

        [HttpGet]
        [Route(WebApiRoutes.GET_KOMENTAR + "{SalataId}/korisnik/{KorisnikId}")]
        public HttpResponseMessage GetKomentar(int SalataId, int KorisnikId)
        {
            KomentarResponseVm ocjenaKomentar = ctx.OcjeneKomentari.Select(item => new KomentarResponseVm {

                Datum = item.Datum,
                Komentar = item.Komentar,
                KorisnikId = item.KorisnikId,
                Ocjena = item.Ocjena,
                SalataId = item.SalataId
            }).FirstOrDefault(ocjkom => ocjkom.KorisnikId == KorisnikId && ocjkom.SalataId == SalataId);

            if (ocjenaKomentar != null)
                return Request.CreateResponse(HttpStatusCode.OK, ocjenaKomentar);
            else
                return Request.CreateResponse(HttpStatusCode.NotFound, "Salata ne sadrzi komentar.");

        }
    }
}
