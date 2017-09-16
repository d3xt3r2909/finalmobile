using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ESBX_db.DAL;
using ESBX_db.Models;
using ESBX_db.ViewModel;

namespace ESBX_db.Helper
{
    public class KorpaHelper
    {
        public static KorpaVm GetAllAboutKorpa(int korpaId, bool aktivna, bool zavrsena)
        {
            MContext ctx = new MContext();
            Expression<Func<KorpaStavke, bool>> whereClause;
            Korpa isExistsKorpa = null;

            if (korpaId == 0)
            {
                // Ukoliko smo proslijedili specificnu korpu, onda je potrebno napraviti i query za to
                whereClause = a => a.Korpa.Aktivna == !zavrsena && a.Korpa.Zavrsena == zavrsena;
            }
            else
            {
                isExistsKorpa = ctx.Korpa.FirstOrDefault(x => x.Id == korpaId);

                if (isExistsKorpa == null)
                    return null;

                whereClause =
                    x =>
                        x.Korpa.Id == korpaId && x.Korpa.Aktivna == aktivna && x.Korpa.Zavrsena == zavrsena;

            }

            KorpaVm korpaModel = new KorpaVm();

            korpaModel.ListSalate = ctx.KorpaStavke.Where(whereClause)
                .Select(x => new KorpaIndexRow
                {
                    KorpaId = x.KorpaId,
                    SalataId = x.SalataId,
                    Kolicina = x.Kolicina,
                    Napomena = x.Salata.Napomena,
                    DatumKreiranja = x.Salata.DatumKreiranja,
                    Komentar = x.Salata.OcjeneKomentari == null ? "" : x.Salata.OcjeneKomentari.Komentar,
                    Ocjena = x.Salata.OcjeneKomentari == null ? 0 : x.Salata.OcjeneKomentari.Ocjena,
                    GlavniSastojak =
                        ctx.SalataStavke.Where(
                                y =>
                                    y.SalataId == x.SalataId &&
                                    y.Sastojak.VrstaSastojka.Naziv == Constants.SastojakGlavni)
                            .Select(y => new SastojciRow
                            {
                                SalataId = y.SalataId,
                                SastojakId = y.SastojakId,
                                Naziv = y.Sastojak.Naziv,
                                Vrsta = y.Sastojak.VrstaSastojka.Naziv,
                                Cijena = y.Sastojak.Cijena,
                                Gramaza = y.Sastojak.Gramaza,
                                BrojKalorija = y.Sastojak.BrojKalorija
                            }).FirstOrDefault(),
                    DresingSastojak =
                        ctx.SalataStavke.Where(
                                y =>
                                    y.SalataId == x.SalataId &&
                                    y.Sastojak.VrstaSastojka.Naziv == Constants.SastojakDresing)
                            .Select(y => new SastojciRow
                            {
                                SalataId = y.SalataId,
                                SastojakId = y.SastojakId,
                                Naziv = y.Sastojak.Naziv,
                                Vrsta = y.Sastojak.VrstaSastojka.Naziv,
                                Cijena = y.Sastojak.Cijena,
                                Gramaza = y.Sastojak.Gramaza,
                                BrojKalorija = y.Sastojak.BrojKalorija
                            }).FirstOrDefault(),
                    ListSastojciSporedni =
                        ctx.SalataStavke.Where(
                                y =>
                                    y.SalataId == x.SalataId &&
                                    y.Sastojak.VrstaSastojka.Naziv == Constants.SastojakSporedni)
                            .Select(y => new SastojciRow
                            {
                                SalataId = y.SalataId,
                                SastojakId = y.SastojakId,
                                Naziv = y.Sastojak.Naziv,
                                Vrsta = y.Sastojak.VrstaSastojka.Naziv,
                                Cijena = y.Sastojak.Cijena,
                                Gramaza = y.Sastojak.Gramaza,
                                BrojKalorija = y.Sastojak.BrojKalorija
                            }).ToList(),
                    CijenaSalate =
                        ctx.SalataStavke.Where(y => y.SalataId == x.SalataId)
                            .Select(y => y.Sastojak.Cijena)
                            .ToList()
                            .Sum(),
                    UkupnaCijena =
                        ctx.SalataStavke.Where(y => y.SalataId == x.SalataId).Select(y => y.Sastojak.Cijena).Sum() *
                        x.Kolicina
                }).ToList();


            korpaModel.Korisnik = isExistsKorpa.Korisnik;

            // Racunanje broja salata, njihove cijene kao i broja stavki salate
            korpaModel.UkupnoSalata = 0;
            korpaModel.UkupnaCijena = 0.0;
            korpaModel.KorpaStavke = korpaModel.ListSalate?.Count() ?? 0;

            if (korpaModel.ListSalate != null)
                foreach (KorpaIndexRow item in korpaModel.ListSalate)
                {
                    korpaModel.UkupnoSalata += item.Kolicina;
                    korpaModel.UkupnaCijena += item.UkupnaCijena;
                }

            // Ukoliko je korpa prazna, oznaciti je kao takvu
            if (korpaModel.UkupnoSalata == 0)
            {
                korpaModel.EmptyBasket = true;
            }

            return korpaModel;
        }

        public static HttpStatusCode DeleteKorpaItem(int korpaId, int salataId)
        {
            MContext ctx = new MContext();

            KorpaStavke ks = ctx.KorpaStavke.FirstOrDefault(x => x.SalataId == salataId && x.KorpaId == korpaId);
            if (ks != null) ctx.KorpaStavke.Remove(ks);
            else return HttpStatusCode.NoContent;
            ctx.SaveChanges();

            //// Brisanje stavki salate
            //List<SalataStavke> lss = ctx.SalataStavke.Where(x => x.SalataId == salataId).ToList();
            //if (lss.Count == 0)
            //    return HttpStatusCode.NoContent;
            //ctx.SalataStavke.RemoveRange(lss);
            //ctx.SaveChanges();

            //// Brisanje ocjena i komentara
            //OcjeneKomentari ok = ctx.OcjeneKomentari.FirstOrDefault(x => x.SalataId == salataId);
            //if (ok != null) ctx.OcjeneKomentari.Remove(ok);
            //ctx.SaveChanges();

            //// Brisanje salate
            //Salate s = ctx.Salate.FirstOrDefault(x => x.Id == salataId);
            //if (s != null) ctx.Salate.Remove(s);
            //else return HttpStatusCode.NoContent;
            //ctx.SaveChanges();

            return HttpStatusCode.OK; 
        }

        public static Korpa GetAktivnaByKorisnikId(int KorisnikId)
        {
            MContext ctx = new MContext();

            return ctx.Korpa.FirstOrDefault(korpa => korpa.KorisnikId == KorisnikId && korpa.Aktivna == true && korpa.Zavrsena == false);
        }

        public static List<KorpaForDgRow> GetNaruzbe(int? id, bool aktivne = true)
        {
            MContext ctx = new MContext();
            Expression<Func<KorpaStavke, bool>> whereClause;
            KorpaForDg narudzbe = new KorpaForDg();

            if (id == 0)
                whereClause = ks => ks.Korpa.Aktivna == false && ks.Korpa.Zavrsena == !aktivne;
            else
                whereClause = ks => ks.KorpaId == id;


            narudzbe.ListSalate = ctx.KorpaStavke
                .Where(whereClause)
                .Select(x => new KorpaForDgRow
                {
                   Id = x.KorpaId,
                   SalataId = x.SalataId,
                   Kolicina = x.Kolicina,
                   VrijemeDolaska = x.Korpa.VrijemeDolaska,
                   Korisnik = x.Korpa.Korisnik.Ime + " " + x.Korpa.Korisnik.Prezime + "; " + x.Korpa.Korisnik.Email + "; " + x.Korpa.Korisnik.BrojTelefona,
                   GlavniSastojak = ctx.SalataStavke.Where(
                       y =>
                           y.SalataId == x.SalataId &&
                           y.Sastojak.VrstaSastojka.Naziv == Constants.SastojakGlavni).Select(sastojak => sastojak.Sastojak.Naziv).FirstOrDefault(),
                   DresingSastojak = ctx.SalataStavke.Where(
                       y =>
                           y.SalataId == x.SalataId &&
                           y.Sastojak.VrstaSastojka.Naziv == Constants.SastojakDresing).Select(sastojak => sastojak.Sastojak.Naziv).FirstOrDefault(),
                   CijenaSalate = ctx.SalataStavke.Where(y => y.SalataId == x.SalataId)
                            .Select(y => y.Sastojak.Cijena)
                            .ToList()
                            .Sum(),

                }).ToList();

            foreach (KorpaForDgRow item in narudzbe.ListSalate)
            {
                List<string> listaSporednih = ctx.SalataStavke.Where(
                        y =>
                            y.SalataId == item.SalataId &&
                            y.Sastojak.VrstaSastojka.Naziv.Equals(Constants.SastojakSporedni))
                    .Select(sastojak => sastojak.Sastojak.Naziv).ToList();

                foreach (string naziv in listaSporednih)
                    item.SporedniSastojak += naziv + ", ";

                if(item.SporedniSastojak != null && item.SporedniSastojak != "" && item.SporedniSastojak.Length != 0)
                     item.SporedniSastojak = item.SporedniSastojak.Remove(item.SporedniSastojak.Length - 2, 2);
            }

            return narudzbe.ListSalate;
        }

        public static Korpa GetKorpaById(int id)
        {
            MContext ctx = new MContext();
            return ctx.Korpa.FirstOrDefault(x => x.Id == id);
        }

        public static HttpStatusCode ChangeStatus(int id, bool status)
        {
            MContext ctx = new MContext();
            Korpa isExist = ctx.Korpa.FirstOrDefault(x => x.Id == id);

            if(isExist == null)
                return HttpStatusCode.NotFound;

            isExist.Zavrsena = status;
            isExist.Finilizirana = status;

            ctx.SaveChanges();

            return  HttpStatusCode.OK;
        }

        public static HttpStatusCode IzdajRacun(int korpaId, string popust = "")
        {
            MContext ctx = new MContext();

            // Dohvacanje korpe / narudzbe za koju se izdaje racun
            Korpa korpa = ctx.Korpa.FirstOrDefault(x => x.Id == korpaId);
            NagradnaIgra igra = null; 

            if (popust != "")
            {
                igra = ctx.NagradnaIgra.FirstOrDefault(item => item.KuponKod == popust && item.Iskoristen == false);

                if (igra == null)
                    return HttpStatusCode.Conflict;

                if (DateTime.Now > igra.VaziDo)
                    return HttpStatusCode.Gone;
            }

            // Provjera da li korpa postoji
            if (korpa != null)
            {
                #region Slanje racuna na email

                // Dohvatit sve podatke o korpi u svrhu formiranja racuna
                KorpaVm korpaVm = GetAllAboutKorpa(korpaId, false, false);

                string body = "";

                // Pohrana racuna u bazu podataka
                Racun racun = new Racun
                {
                    KorpaId = korpaVm.KorpaId,
                    Datum = DateTime.Now,
                    UkupnaCijena = (float)korpaVm.UkupnaCijena,

                };

                // Ukoliko korisnik ima kupon sa sifrom
                if (igra != null)
                {
                    racun.Popust = igra.Popust;
                    racun.CijenaSaPopustom = racun.UkupnaCijena - racun.UkupnaCijena * (igra.Popust / 100);
                    igra.Iskoristen = true;
                }
                else
                    racun.CijenaSaPopustom = racun.UkupnaCijena;

                racun.Korpa = korpa; 
                ctx.Racun.Add(racun);

                korpa.Racun = racun;
                korpa.RacunId = racun.KorpaId; 
                ctx.SaveChanges();

                // Kreiranje body dijela za slanje emaila
                body = "Poštovani " + korpaVm.Korisnik.Ime + " " + korpaVm.Korisnik.Prezime + ", <br/><br/>" +
                       "Naručeno: " + korpaVm.UkupnoSalata + " salata, <br/><b>Ukupan iznos: </b>" + racun.UkupnaCijena + " KM<br/>";

                body += igra != null ? "<b>Cijena sa popustom:</b> " + racun.CijenaSaPopustom + " KM (" + igra.Popust + " % popusta)<br/><br/><br/>" : "";

                string bodyDetail = "";
                int counter = 0;
                foreach (var item in korpaVm.ListSalate)
                {
                    counter++;
                    string bodySastojciSporedni = "";

                    foreach (var sastojak in item.ListSastojciSporedni)
                    {
                        bodySastojciSporedni += sastojak.Naziv + ", ";
                    }
                    bodyDetail += "<hr/>" + counter + ".)" + " Glavni sastojak: " + item.GlavniSastojak.Naziv +
                                  "<br/>Sporedni: " +
                                  bodySastojciSporedni + "<br/>Dressing: " + item.DresingSastojak.Naziv + "<br/>Količina: " +
                                  item.Kolicina + " komada<br/>Cijena salate: " + item.UkupnaCijena + " KM";

                }

                body += "<br/>================Detalji narudžbe===============<br/>" + bodyDetail;

                // Salje se racun u obliku emaila, korisniku koji je narucio 
                AccountHelper.Sendemail(new EmailVm
                {
                    To = korpaVm.Korisnik.Email,
                    Body = body,
                    Subject = "Express Salad Bar racun"
                });

                #endregion

                // Oznacavanje korpe finiliziranom, sada korisnik moze komentarisati svoju narudzbu 
                korpa.Finilizirana = true;
                korpa.Zavrsena = true;

                // Snimanje promijena 
                ctx.SaveChanges();

                return HttpStatusCode.OK;
            }

            return HttpStatusCode.NotFound;
        }
    }
}
