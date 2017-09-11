using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using ESBX_API.Helper;
using ESBX_API.ViewModels;
using iTextSharp.text;
using iTextSharp.text.pdf;
using ESBX_db.ViewModel;
using ESBX_db.Helper;
using ESBX_db.Models;
namespace ESBX_API.Controllers
{
    public class KorpaController : ApiController
    {
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route(WebApiRoutes.GET_OSOBLJE_KORPA + "{id?}/{aktivne?}")]
        public HttpResponseMessage GetNarucene(int? id, bool aktivne = true)
        {
            List<KorpaForDgRow> korpaModel = KorpaHelper.GetNaruzbe(id, aktivne);

            if (!ModelState.IsValid)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            if (korpaModel.Count == 0)
                return Request.CreateResponse(HttpStatusCode.NoContent); 

            return Request.CreateResponse(HttpStatusCode.OK, korpaModel);
        }

        [System.Web.Http.Route(WebApiRoutes.GET_AKTIVNA_KORPA + "{KorisnikId}")]
        public IHttpActionResult GetAktivnaKorpa(int KorisnikId) {

            Korpa aktivnaKorpa = KorpaHelper.GetAktivnaByKorisnikId(KorisnikId);

            if (aktivnaKorpa == null)
                return NotFound();

            List<KorpaForDgRow> listNarudzbe = KorpaHelper.GetNaruzbe(aktivnaKorpa.Id, aktivne: true);

            if (listNarudzbe.Count == 0)
                return NotFound();

            #region
            // Ako napravimo da vraca posebno za klijenta a posebno za inace
            List<KorpaMobileVm> response = new List<KorpaMobileVm>();
            foreach (KorpaForDgRow item in listNarudzbe)
            {
                KorpaMobileVm tmp = new KorpaMobileVm(); 
                tmp.Sastojci = item.GlavniSastojak + ", " + item.SporedniSastojak + ", " + item.DresingSastojak;
                tmp.KorpaId = item.Id;
                tmp.Kolicina = item.Kolicina;
                tmp.Cijena = item.CijenaSalate;

                response.Add(tmp);
            }

            if (response.Count <= 0)
                return NotFound();

            #endregion
            return Ok(response);
        }
        [System.Web.Http.HttpPut]
        [System.Web.Http.Route(WebApiRoutes.PUT_OSOBLJE_KORPA_STATUS + "{id}/{aktivne?}")]
        public HttpResponseMessage PutNarudzbeStatus(int id, bool status = true)
        {
             HttpStatusCode response = KorpaHelper.ChangeStatus(id, status);

            if (response == HttpStatusCode.NotFound)
                return Request.CreateResponse(HttpStatusCode.NotFound);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route(WebApiRoutes.GET_KORISNICI_KORPA + "{id}")]
        public HttpResponseMessage GetKorpaById(int id)
        {
            Korpa response = KorpaHelper.GetKorpaById(id);

            if (response == null)
                return Request.CreateResponse(HttpStatusCode.NotFound);

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        /**
       * Poziva se ukoliko gost dodje
       * 
       * Salje racun na email korisnika 
       * Korpa se oznacava finaliziranom 
       **/
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route(WebApiRoutes.POST_ZAVRSI_NARUDZBU)]
        public HttpResponseMessage ZavrsiNarudzbu(IzdajRacunVm post)
        {
            HttpStatusCode response = KorpaHelper.IzdajRacun(post.KorpaId, post.KuponKod);

            if(response == HttpStatusCode.Gone)
                return Request.CreateResponse(HttpStatusCode.Gone, "Nagradni kod je istekao!");
            if(response == HttpStatusCode.Conflict)
                return Request.CreateResponse(HttpStatusCode.Conflict, "Ne postoji nagradni kod ili je iskoristen!");
            if (response == HttpStatusCode.NotFound)
                return Request.CreateResponse(HttpStatusCode.NotFound, "Narudzba nije pronadjena");

            return Request.CreateResponse(HttpStatusCode.OK);
        }


        [System.Web.Http.HttpGet]
        [System.Web.Http.Route(WebApiRoutes.POST_DOWNLOAD_RACUN + "{id}")]
        public IHttpActionResult DownloadPdf(int id)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                KorpaVm korpaVm = KorpaHelper.GetAllAboutKorpa(id, false, true);

                Document doc = new Document(PageSize.A4, 88f, 88f, 10f, 10f);
                Font NormalFont = FontFactory.GetFont("Arial", 12, BaseColor.BLUE);
                PdfWriter writer = PdfWriter.GetInstance(doc, ms);
                doc.Open();

                Paragraph header1 = new Paragraph("Express Salad Bar");
                header1.Alignment = Element.ALIGN_CENTER;
                doc.Add(header1);

                Paragraph header2 = new Paragraph("Racun za " + korpaVm.Korisnik.Ime + " " + korpaVm.Korisnik.Prezime);
                header2.Alignment = Element.ALIGN_CENTER;
                doc.Add(header2);

                doc.Add(new Paragraph("Vase narudzbe: "));

                PdfPTable table = new PdfPTable(5);
                table.TotalWidth = 400f;
                //fix the absolute width of the table
                table.LockedWidth = true;

                //relative col widths in proportions - 1/3 and 2/3
                float[] widths = new float[] { 5f, 5f, 5f, 5f, 5f };
                table.SetWidths(widths);
                table.HorizontalAlignment = 0;
                //leave a gap before and after the table
                table.SpacingBefore = 20f;
                table.SpacingAfter = 30f;

                Font bold = new Font(Font.FontFamily.HELVETICA, 12, Font.BOLD);

                Phrase headerGlavni = new Phrase("Glavni sastojak", bold);
                Phrase headerSporedni = new Phrase("Sporedni sastojci", bold);
                Phrase headerDresing = new Phrase("Dresing", bold);
                Phrase headerKolicina = new Phrase("Kolicina", bold);
                Phrase headerCijena = new Phrase("Cijena salate", bold);
                PdfPCell cell1 = new PdfPCell(headerGlavni);
                PdfPCell cell2 = new PdfPCell(headerSporedni);
                PdfPCell cell3 = new PdfPCell(headerDresing);
                PdfPCell cell4 = new PdfPCell(headerKolicina);
                PdfPCell cell5 = new PdfPCell(headerCijena);

                table.AddCell(cell1);
                table.AddCell(cell2);
                table.AddCell(cell3);
                table.AddCell(cell4);
                table.AddCell(cell5);

                foreach (KorpaIndexRow item in korpaVm.ListSalate)
                {
                    table.AddCell(item.GlavniSastojak.Naziv + " ("+ item.GlavniSastojak.Cijena+" KM)");

                    string sporedni = "";
                    float sporedniCijena = 0;
                    foreach (SastojciRow element in item.ListSastojciSporedni)
                    {
                        sporedni += element.Naziv + ",";
                        sporedniCijena += element.Cijena;
                    }
                    table.AddCell(sporedni + " (" + sporedniCijena  + " KM)");
                    table.AddCell(item.DresingSastojak.Naziv + " ("+ item.DresingSastojak.Cijena+" KM)");
                    table.AddCell(item.Kolicina.ToString());
                    table.AddCell(item.CijenaSalate.ToString(CultureInfo.InvariantCulture));
                }
                doc.Add(table);

                Paragraph header4 = new Paragraph("Potpis konobara: ");
                header4.Alignment = Element.ALIGN_RIGHT;
                doc.Add(header4);

                Paragraph header5 = new Paragraph("_______________________");
                header5.Alignment = Element.ALIGN_RIGHT;
                doc.Add(header5);

                Paragraph header3 = new Paragraph("Hvala Vam najljepsa, dodjite nam!");
                header3.Alignment = Element.ALIGN_RIGHT;
                doc.Add(header3);

                doc.Close();
                byte[] bytes = ms.ToArray();
                ms.Close();

               // return File(bytes, "application/pdf", DateTime.Now.Second + ".pdf");

                var result = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new ByteArrayContent(bytes)
                };
                result.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment")
                {
                    FileName = DateTime.Now.Second + ".pdf"
                };
                result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");

                var response = ResponseMessage(result);

                return response;
            }
        }

        ///**
        //* Metoda ima zadatak da provjeri odredjene stvari, te ukoliko je sve ispravno
        //* tada ce se generisati sifra narudžbe, te ista poslati na korisnikov email,
        //* takodjer ce se zabiljeziti vrijeme zakazivanja narudzbe, kao i to da trenutno aktivna korpa prestaje biti aktivna 
        //* 
        //* Provjere: validno zakazano vrijeme, povjerljivost korisnika, postojanje korpe, stavki korpe
        //* Generisanje sifra
        //* Vremena dolaska
        //* Trenutni status trenutne korpe je potrebno promijeniti u false 
        //**/
        //[System.Web.Http.HttpPost]

        //public IHttpActionResult Naruci(NaruciVm naruci)
        //{

        //    Korisnici isUserExists = AccountHelper.GetKorisnikById(naruci.KorisnikId);

        //    if (isUserExists == null)
        //        return NotFound();

        //    // Provjera korisnika da li je on povjerljiv, ukoliko nije ispisati odgovarajucu poruku o nepovjerljivosti
        //    if (!AccountHelper.GetCurrentKorisnikInfo().Povjerljiv)
        //    {
        //        ModelState.AddModelError("korpaError", Constants.ErrorUserTrust);
        //        return View("Index", KorpaHelper.GetUserCart(new KorpaCondition
        //        {
        //            KorpaId = 0,
        //            Aktivna = false,
        //            Zavrsena = false,
        //            Finalizirana = false
        //        }));
        //    }

        //    // Provjeriti da li je zakazano vrijeme odgovarajuce 
        //    double checkTime = date.Subtract(DateTime.Now).TotalMinutes;

        //    // POtrebno je da vrijeme dolaska bude minimalno 60 minuta udaljeno od narucivanja
        //    if (checkTime < 59)
        //    {
        //        ModelState.AddModelError("korpaError", Constants.ErrorOrderTimeWrong);
        //        return View("Index", KorpaHelper.GetUserCart(new KorpaCondition
        //        {
        //            KorpaId = 0,
        //            Aktivna = false,
        //            Zavrsena = false,
        //            Finalizirana = false
        //        }));
        //    }

        //    // Provjera da li je korisnicka korpa prazna - radi sigurnosti na server strani
        //    if (KorpaHelper.GetUserCart(new KorpaCondition
        //    {
        //        KorpaId = 0,
        //        Aktivna = false,
        //        Zavrsena = false,
        //        Finalizirana = false
        //    }).EmptyBasket)
        //    {
        //        ModelState.AddModelError("korpaError", Constants.ErrorEmptyBasket);
        //        return View("Index", KorpaHelper.GetUserCart(new KorpaCondition
        //        {
        //            KorpaId = 0,
        //            Aktivna = false,
        //            Zavrsena = false,
        //            Finalizirana = false
        //        }));
        //    }

        //    // Ukoliko su provjere zadovoljene potrebno je naruciti salatu 

        //    // Dobavljanje trenutnog ID korisnika
        //    int korisnikId = AccountHelper.GetUserId(System.Web.HttpContext.Current.User.Identity.Name);

        //    // Dobavljanje aktivne korpe korisnika 
        //    Korpa korisnikKorpa = _ctx.Korpa.FirstOrDefault(x => x.Aktivna && x.KorisnikId == korisnikId);

        //    // Jos jedna provjera korpe radi sigurnosti 
        //    if (korisnikKorpa == null)
        //    {
        //        ModelState.AddModelError("korpaError", "Nije pronađena Vaša korpa. Ovo se vrlo rijetko događa pa Vas molimo da se obratite Administratoru");
        //        return View("Index", KorpaHelper.GetUserCart(new KorpaCondition
        //        {
        //            KorpaId = 0,
        //            Aktivna = false,
        //            Zavrsena = false,
        //            Finalizirana = false
        //        }));
        //    }

        //    // Generisanje sifre korpe 
        //    korisnikKorpa.Sifra = KorpaHelper.GetSifra();

        //    // Preuzimanje zakazanog vremena dolaska  
        //    korisnikKorpa.VrijemeDolaska = date;

        //    // Promijeniti status korpe u false
        //    korisnikKorpa.Aktivna = false;

        //    // Snimiti promjene
        //    _ctx.SaveChanges();

        //    // Proslijediti odredjene parametre za view
        //    ViewBag.ValidNaruceno = true;
        //    ViewBag.SuccessBodyDate = date.ToString(CultureInfo.InvariantCulture);

        //    /* Ukoliko je sve proslo uredu, potrebno je korisniku poslati email sa sifrom narudzbe */

        //    // Dohvacanje trenutnog korisnika 
        //    var korisnik = _ctx.Korisnici.FirstOrDefault(x => x.Id == korisnikId);

        //    // Slanje emaila sa sfirom narudjbe i odredjenim detaljima narudzbe
        //    AccountHelper.Sendemail(
        //        korisnik,
        //        Constants.GuidForSaladEmailSubject,
        //        Constants.GetGuidSaladBarBody(korisnik,
        //            korisnikKorpa.Sifra,
        //            korisnikKorpa.VrijemeDolaska.ToString(CultureInfo.InvariantCulture))
        //    );

        //    // Prosljedjivanje na view od korpe
        //    return View("Index", KorpaHelper.GetUserCart(new KorpaCondition
        //    {
        //        KorpaId = 0,
        //        Aktivna = false,
        //        Zavrsena = false,
        //        Finalizirana = false
        //    }));
        //}
    }
}
