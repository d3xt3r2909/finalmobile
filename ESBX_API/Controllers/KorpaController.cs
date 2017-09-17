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
using ESBX_db.DAL;

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
                tmp.StavkaId = item.SalataId;
                tmp.KorpaId = item.Id;
                tmp.Kolicina = item.Kolicina.ToString();
                tmp.Cijena = item.CijenaSalate.ToString();

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
            List<string> errors = new List<string>();
            if (response == HttpStatusCode.Gone)
                errors.Add("Nagradni kod je istekao!");
            if (response == HttpStatusCode.Conflict)
                errors.Add("Ne postoji nagradni kod ili je iskoristen!");
            if (response == HttpStatusCode.NotFound)
                errors.Add("Narudzba nije pronadjena");
            if (errors.Count > 0)
            {
               return Request.CreateResponse(HttpStatusCode.NotFound, "Narudzba nije pronadjena");
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpDelete]
        [Route(WebApiRoutes.DELETE_ITEM_KORPA + "{KorpaId}/stavke/{SalataId}")]
        public HttpResponseMessage DeleteNarudzbaItem(int KorpaId, int SalataId)
        {
            HttpStatusCode response = KorpaHelper.DeleteKorpaItem(KorpaId, SalataId); 

            if(response == HttpStatusCode.NoContent)
                return Request.CreateResponse(HttpStatusCode.NoContent, "Trazena salata unutar korpe nije pronadjena");

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

        /**
        * Metoda ima zadatak da provjeri odredjene stvari, te ukoliko je sve ispravno
        * tada ce se generisati sifra narudžbe, te ista poslati na korisnikov email,
        * takodjer ce se zabiljeziti vrijeme zakazivanja narudzbe, kao i to da trenutno aktivna korpa prestaje biti aktivna 
        * 
        * Provjere: validno zakazano vrijeme, povjerljivost korisnika, postojanje korpe, stavki korpe
        * Generisanje sifra
        * Vremena dolaska
        * Trenutni status trenutne korpe je potrebno promijeniti u false 
        **/
        [System.Web.Http.HttpPost]
        [Route(WebApiRoutes.POST_NARUCI_KORPU)]

        public HttpResponseMessage Naruci(NaruciVm naruci)
        {
            Korisnici isUserExists = AccountHelper.GetKorisnikById(naruci.KorisnikId);

            if (isUserExists == null)
                return Request.CreateResponse(HttpStatusCode.NotFound, "Korisnik nije pronadjen");

            // Provjera korisnika da li je on povjerljiv, ukoliko nije ispisati odgovarajucu poruku o nepovjerljivosti
            if (!isUserExists.Povjerljiv)
            {
                return Request.CreateResponse(HttpStatusCode.Forbidden, "Nepovjerljiv korisnik");

            }

            

            MContext ctx = new MContext();

            List<KorpaStavke> conditionKs = ctx.KorpaStavke.Where(ks => ks.Korpa.Aktivna == true && ks.Korpa.KorisnikId == naruci.KorisnikId).ToList();
            // Provjera da li je korisnicka korpa prazna - radi sigurnosti na server strani
            if (conditionKs.Count <= 0)
                return Request.CreateErrorResponse(HttpStatusCode.NotAcceptable, "Korisnicka korpa je prazna!");

            // Dobavljanje aktivne korpe korisnika 
            Korpa korisnikKorpa = ctx.Korpa.FirstOrDefault(x => x.Aktivna && x.KorisnikId == naruci.KorisnikId);

            // korisnikKorpa.Sifra = KorpaHelper.GetSifra();

            // Preuzimanje zakazanog vremena dolaska  
            korisnikKorpa.VrijemeDolaska = naruci.DatumDolaska;

            // Promijeniti status korpe u false
            korisnikKorpa.Aktivna = false;

            // oduzmi sastojcima na stanju
            List<int> SalataIds = ctx.KorpaStavke.Where(x => x.KorpaId == korisnikKorpa.Id).Select(y => y.SalataId).ToList();
            foreach(var i in SalataIds)
            {
                List<int> sastojciIds = ctx.SalataStavke.Where(x => x.SalataId == i).Select(y => y.SastojakId).ToList();
                foreach (var n in sastojciIds)
                {
                    Sastojci s = ctx.Sastojci.Where(x => x.Id == n).FirstOrDefault();
                    float g = s.Gramaza;
                    s.Stanje = s.Stanje - g;
                    ctx.SaveChanges();
                }
            }
            

            // Snimiti promjene
            ctx.SaveChanges();

            /* Ukoliko je sve proslo uredu, potrebno je korisniku poslati email sa sifrom narudzbe */

            EmailVm mailVm = new EmailVm();
            mailVm.Body = "Postovani, </br>Uspjesno ste narucali isto. Vasa sifra narudzbe je: " + korisnikKorpa.Sifra;
            mailVm.Subject = "Express Salad Bar";
            mailVm.To = isUserExists.Email; 
            // Slanje emaila sa sfirom narudjbe i odredjenim detaljima narudzbe
            AccountHelper.Sendemail(mailVm);

            return Request.CreateErrorResponse(HttpStatusCode.OK, "Narudzba je uspjesno realizovana, provjerite Vas email");
        }
    }
}
