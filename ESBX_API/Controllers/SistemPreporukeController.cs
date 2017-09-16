using ESBX_db.DAL;
using ESBX_db.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ESBX_API.Controllers
{
    public class SistemPreporukeController : ApiController
    {
        MContext ctx = new MContext();

        List<int> salateSaIstimSastojcima = new List<int>();
        List<int> sastojciKojeNemaTrenutni = new List<int>();
        List<int> sastojciKojePredlazemo = new List<int>();
        [HttpPost]
        public IHttpActionResult PostPreporuka(KreiranaSalataVM SalataTrenutnog)
        {
            int KorisnikTrenutni = SalataTrenutnog.KorisnikId;

            //poredi se koje su to salate koje imaju iste sastojke kao korisnikova salata
            List<int> sastojciTrenutni = SalataTrenutnog.listaIzabranih;


            foreach (int Id in ctx.Salate.Select(x => x.Id).ToList())
            {
                List<int> stavkeIds = ctx.SalataStavke.Where(y => y.SalataId == Id).Select(z => z.SastojakId).ToList();
                Uporedi(sastojciTrenutni, stavkeIds, Id);

            }


            //da li korisnik ima kreiranih salata koje sadrze neke od izdvojenih sastojaka a da je tu salatu ocjenio s >3
            List<int> SalataIds = ctx.OcjeneKomentari.Where(x => x.KorisnikId == KorisnikTrenutni && x.Ocjena > 3).Select(y => y.SalataId).ToList();
            if (SalataIds != null)
            {
                foreach (var i in SalataIds)
                {
                    List<int> sastojci = ctx.SalataStavke.Where(x => x.SalataId == i).Select(v => v.SastojakId).ToList();
                    foreach (var n in sastojci)
                    {
                        if (sastojciKojeNemaTrenutni.Contains(n))
                        {
                            if (!sastojciKojePredlazemo.Contains(n))
                            {
                                sastojciKojePredlazemo.Add(n);
                            }
                        }
                    }

                }


            }

            //rjesavanje cold starta, tj ako nemamo nista nakono provjere da predlozimo, trazimo korisnikove omiljene sastojke
            //ideja da u sastojke koje predlazemo dodamo one iz liste omiljenih kojih nema u trenutoj salati
            if (sastojciKojePredlazemo.Count() == 0)
            {
                List<int> omiljeni = ctx.KorisnikSastojci.Where(x => x.KorisnikId == KorisnikTrenutni).Select(y => y.SastojakId).ToList();

                foreach (var n in omiljeni.Except(SalataTrenutnog.listaIzabranih))
                {

                    if (!sastojciKojeNemaTrenutni.Contains(n))
                    {
                        if (ctx.Sastojci.Where(x => x.Id == n).Select(y => y.VrstaSastojkaId).FirstOrDefault() != 1)
                            sastojciKojeNemaTrenutni.Add(n);
                    }

                }
            }



            List<SastojciMobileVM> listsastojciKojePredlazemo = new List<SastojciMobileVM>();
            foreach (var i in sastojciKojePredlazemo)
            {
                SastojciMobileVM m = new SastojciMobileVM();
                m.Id = i;
                m.Naziv = ctx.Sastojci.Where(x => x.Id == i).Select(y => y.Naziv).FirstOrDefault();
                listsastojciKojePredlazemo.Add(m);
            }

            return Ok(listsastojciKojePredlazemo);
        }

        public void Uporedi(List<int> trenutnaS, List<int> novaS, int NovaId)
        {
           
            List<int> istiSastojci=new List<int>();
            //intersect vraca sastojkeIds koji se ponavljaju u trenutnoj i novoj za poredenje salati
            foreach(var i in trenutnaS.Intersect(novaS))
            {
                istiSastojci.Add(i);
            }
            //ako salata koji je korisnik kreirao upravo i neka iz baze salata imaju sve iste sastojke, dodaj tu salatu u listu
            if (istiSastojci.Count() == trenutnaS.Count())
            {
                salateSaIstimSastojcima.Add(NovaId);
                //except vraca sastojke koje trenutna salata nema
                foreach(var n in novaS.Except(trenutnaS))    
                {

                    if (!sastojciKojeNemaTrenutni.Contains(n))
                    {
                        if(ctx.Sastojci.Where(x=>x.Id==n).Select(y=>y.VrstaSastojkaId).FirstOrDefault()!=1)
                        sastojciKojeNemaTrenutni.Add(n);
                    }
                   
                }
                
            }

            

        }
    }
}
