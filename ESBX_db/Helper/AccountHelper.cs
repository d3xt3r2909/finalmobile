using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using ESBX_db.DAL;
using ESBX_db.Models;
using ESBX_db.ViewModel;

namespace ESBX_db.Helper
{
    public class AccountHelper
    {

        public static List<Korisnici> GetKorisnici() {
             MContext ctx = new MContext();

            return ctx.Korisnici.ToList();
        }

        public static Korisnici GetKorisnik(AccountLoginVm account)
        {
            MContext ctx = new MContext();

            return ctx.Korisnici.FirstOrDefault(x => x.Email == account.UserName && x.LozinkaHash == account.Lozinka);
        }

        public static Korisnici GetKorisnikById(int korisnikId)
        {
            MContext ctx = new MContext();

            return ctx.Korisnici.FirstOrDefault(x => x.Id == korisnikId);
        }

        public static Korisnici CheckLogin(AccountLoginVm account)
        {
            MContext ctx = new MContext();

            // Pretraga korisnika na osnovu emaila
            Korisnici korisnik = ctx.Korisnici.FirstOrDefault(u => u.Email == account.UserName);

            // Ukoliko je korisnik unio email koji ne postoji potrebno je vratiti null
            if (korisnik == null) return null;

            // Generisanje hasha na osnovu unjete lozinke  i korisnikovog salta  
            string lozinkaHash = GenerateHash(account.Lozinka, korisnik.LozinkaSalt);

            // Provjera da li se lozinke podudaraju
            // Ukoliko lozinka nije uredu vratit null
            if (lozinkaHash != korisnik.LozinkaHash && korisnik.LozinkaHash != account.Lozinka) return null;

            // Ukoliko je sve zadovoljeno vratit logiranog korisnika
            return korisnik;
        }

        public static Uloge GetUlogaByKorisnikId(int KorisnikId)
        {
            MContext ctx = new MContext();;

            KorisniciUloge ku = ctx.KorisniciUloge.FirstOrDefault(x => x.KorisnikId == KorisnikId);

            return ku == null ? null : GetUloge(ku.Uloga.Naziv);
        }

        public static Uloge GetUloge(string naziv)
        {
            MContext ctx = new MContext();

            return ctx.Uloge.FirstOrDefault(x => x.Naziv == naziv); 
        }

        /**
        * Create new user with specified role, 
        * Generate verification code,
        * Generate password salt and hash
        * Also send email to user with activation link 
        * */
        public static HttpStatusCode CreateAccount(AccountRegistrationVm korisnik, Uloge uloga)
        {
            MContext ctx = new MContext();

            // Provjera da li postoji vec email sa tim korisnikom
            if (ctx.Korisnici.FirstOrDefault(k => k.Email == korisnik.EmailAdresa) != null)
                return HttpStatusCode.Conflict;

            Korisnici noviKorisnik = new Korisnici();

            // Generisanje salata - random broj
            noviKorisnik.LozinkaSalt = GenerateSalt();

            // Generisanje hashovane lozinke na osnovu clear text lozinke i salta
            noviKorisnik.LozinkaHash = GenerateHash(korisnik.Lozinka, noviKorisnik.LozinkaSalt);

            // Datum kreiranje se uzima kao trenutno vrijeme
            noviKorisnik.DatumKreiranja = DateTime.Now;
            noviKorisnik.Ime = korisnik.Ime;
            noviKorisnik.Prezime = korisnik.Prezime;
            noviKorisnik.Adresa = korisnik.Adresa;
            noviKorisnik.Aktivan = true;
            noviKorisnik.BrojTelefona = korisnik.Telefon;
            noviKorisnik.Email = korisnik.EmailAdresa;
            noviKorisnik.GradId = korisnik.GradId;
            noviKorisnik.Povjerljiv = true;
            noviKorisnik.DatumRodjenja = korisnik.DatumRodjenja;

            // Dodavanje korisnika u bazu 
            ctx.Korisnici.Add(noviKorisnik);
            ctx.SaveChanges();

            // Dodjeljivanje uloge korisniku 
            KorisniciUloge ku = new KorisniciUloge
            {
                Korisnik = noviKorisnik,
                UlogaId = uloga.Id,
                DatumDodjele = DateTime.Now
            };

            ctx.KorisniciUloge.Add(ku);

            // Snimanje novonastalih promjena
            ctx.SaveChanges();

            // Ukoliko je sve uredu, potrebno je vratiti pozitivan status
            return HttpStatusCode.OK;
        }

        public static string GenerateSalt()
        {
            byte[] arr = new byte[16];
            RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
            crypto.GetBytes(arr);
            return Convert.ToBase64String(arr);
        }

        /**
         * Generate salt with user input for password and salt 
         */
        public static string GenerateHash(string password, string salt)
        {
            byte[] passwordBArray = Encoding.Unicode.GetBytes(password);
            byte[] saltBArray = Convert.FromBase64String(salt);
            byte[] forHash = new byte[passwordBArray.Length + saltBArray.Length + 1];

            Buffer.BlockCopy(passwordBArray, 0, forHash, 0, passwordBArray.Length);
            Buffer.BlockCopy(saltBArray, 0, forHash, passwordBArray.Length, saltBArray.Length);

            HashAlgorithm alg = HashAlgorithm.Create("SHA1");
            if (alg != null)
            {
                byte[] hashed = alg.ComputeHash(forHash);

                return Convert.ToBase64String(hashed);
            }

            return null;
        }

        /**
        * Slanje emaila odredjenom korisniku  
        * Prva tri parametra su obavezni parametri dok cetvrti se salje samo ukoliko se zele poslati podaci 
        * o emailu ili lozinki koja je vezana za registraciju na sistem
        * */
        public static bool Sendemail(EmailVm emailInfo)
        {
            bool condition = true;
            try
            {
            
            using (MailMessage mailMessage = new MailMessage())
            {

                mailMessage.From = new MailAddress("expresssaladbar@gmail.com");
                mailMessage.Subject = emailInfo.Subject;

                /**
                 * Dodavanje slike u email 
                 * */
                //var inlineLogo =
                //    new LinkedResource(System.Web.HttpContext.Current.Server.MapPath("~/Helper/Images/ESB.png"))
                //    {
                //        ContentId = Guid.NewGuid().ToString()
                //    };

                string body = emailInfo.Body;

                var view = AlternateView.CreateAlternateViewFromString(body, null, "text/html");
                //view.LinkedResources.Add(inlineLogo);
                mailMessage.AlternateViews.Add(view);

                //Postavke za email koji ce se slati

                mailMessage.IsBodyHtml = true;
                mailMessage.To.Add(new MailAddress(emailInfo.To));

                SmtpClient smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    EnableSsl = true
                };
                System.Net.NetworkCredential networkCred = new System.Net.NetworkCredential
                {
                    UserName = "expresssaladbar@gmail.com",
                    Password = "nelanihad0112"
                };
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = networkCred;
                smtp.Port = 587;
                smtp.Send(mailMessage);
            }
            }
            catch (Exception)
            {
                condition = false;
            }

            return condition;
        }
    }
}
