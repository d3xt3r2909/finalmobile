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
        public static List<SastojciPregledVm> GetSastojci(string naziv = "")
        {
            MContext ctx = new MContext();

            List<SastojciPregledVm> sastojci = new List<SastojciPregledVm>();

            if (naziv == "")
                sastojci = ctx.Sastojci.Where(x => x.IsDeleted == false).Select(y => new SastojciPregledVm
                {
                    BrojKalorija = y.BrojKalorija,
                    Cijena = y.Cijena,
                    Gramaza = y.Gramaza,
                    Id = y.Id,
                    Naziv = y.Naziv,
                    VrstaSastojka = y.VrstaSastojka.Naziv,
                    Stanje = y.Stanje
                }).ToList(); 
            else
                sastojci = ctx.Sastojci.Where(x => x.IsDeleted == false && x.Naziv.StartsWith(naziv)).Select(y => new SastojciPregledVm
                {
                    BrojKalorija = y.BrojKalorija,
                    Cijena = y.Cijena,
                    Gramaza = y.Gramaza,
                    Id = y.Id,
                    Naziv = y.Naziv,
                    VrstaSastojka = y.VrstaSastojka.Naziv,
                    Stanje = y.Stanje
                }).ToList();

            return sastojci;
        }

        public static List<Sastojci> GetOmiljeni(string vrstaSastojka = "")
        {
            MContext ctx = new MContext();

            return vrstaSastojka == "" ? ctx.Sastojci.Where(x => x.IsDeleted == false).ToList() : ctx.Sastojci.Where(x => x.IsDeleted == false && x.VrstaSastojka.Naziv.ToLower() == vrstaSastojka.ToLower()).ToList();
        }

        public static HttpStatusCode AddSastojci(SastojciPostWithImage ns)
        {
            MContext ctx = new MContext();

            Sastojci isExists = ctx.Sastojci.FirstOrDefault(x => x.Naziv == ns.Naziv && x.IsDeleted == false);

            if (isExists != null)
                return HttpStatusCode.Conflict;

            Sastojci noviSastojak = new Sastojci();
            noviSastojak.BrojKalorija = ns.BrojKalorija;
            noviSastojak.Cijena = ns.Cijena;
            noviSastojak.Gramaza = ns.Gramaza;
            noviSastojak.IsDeleted = false;
            noviSastojak.Napomena = ns.Napomena;
            noviSastojak.Naziv = ns.Naziv;
            noviSastojak.VrstaSastojkaId = ns.VrstaSastojkaId;

            ctx.Sastojci.Add(noviSastojak);

            ctx.SaveChanges();

            if (ns.Slika != null)
            {
                Slike novaSlika = new Slike();
                novaSlika.UrlSlike = "/";
                novaSlika.Slika = ns.Slika;
                novaSlika.SastojakId = noviSastojak.Id;
                ctx.Slike.Add(novaSlika);
                ctx.SaveChanges();
            }

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
