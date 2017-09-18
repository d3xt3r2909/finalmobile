namespace ESBX_db.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ESBX_db.DAL.MContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ESBX_db.DAL.MContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.VrstaSastojka.AddOrUpdate(
                new Models.VrstaSastojka { Id = 1, Naziv = "Glavni", Opis = "Ovo je glavni sastojak salate, poput, piletine, lososa i slicno" },
                new Models.VrstaSastojka { Id = 1, Naziv = "Sporedni", Opis = "Ovo je sporedni sastojak salate, poput, graska, kukuruza i slicno" },
                new Models.VrstaSastojka { Id = 1, Naziv = "Dresing", Opis = "Ovo je dresing sastojak salate, poput, kecapa, majoneze i siracu sos i slicno" }
            );

            context.Drzave.AddOrUpdate(
                new Models.Drzava { Id = 1, Naziv = "Bosna i Hercegovina", Oznaka = "BiH", PozivniBroj = "+387" },
                new Models.Drzava { Id = 2, Naziv = "Hrvatska", Oznaka = "HR", PozivniBroj = "+385" },
                new Models.Drzava { Id = 3, Naziv = "Srbija", Oznaka = "SRB", PozivniBroj = "+381" }
            );

            context.Gradovi.AddOrUpdate(
               new Models.Grad { Id = 1, Naziv = "Sarajevo", DrzavaId = 1, PostanskiBroj = "71000" },
               new Models.Grad { Id = 2, Naziv = "Mostar", DrzavaId = 1, PostanskiBroj = "88000" },
               new Models.Grad { Id = 3, Naziv = "Banjaluka", DrzavaId = 1, PostanskiBroj = "78000" }
           );

            context.Uloge.AddOrUpdate(
                new Models.Uloge { Id = 1, Naziv = "Osoblje", Opis = "Opis uloge" },
                new Models.Uloge { Id = 2, Naziv = "Menadzer", Opis = "Opis uloge" },
                new Models.Uloge { Id = 3, Naziv = "Korisnik", Opis = "Opis uloge" }
                );

            //context.Korisnici.AddOrUpdate(
            //    new Models.Korisnici { Id = 1, Ime = "John", Prezime = "Doe", Adresa = "Nepoznata", Aktivan = true, BrojTelefona = "666-666", DatumRodjenja = DateTime.Now, DatumKreiranja = DateTime.Now, Email = "menadzer@gmail.com", GradId = 1, Povjerljiv = true, LozinkaHash = "testtest", LozinkaSalt = "testtest" },
            //    new Models.Korisnici { Id = 2, Ime = "Bread", Prezime = "Doe", Adresa = "Nepoznata", Aktivan = true, BrojTelefona = "666-666", DatumRodjenja = DateTime.Now, DatumKreiranja = DateTime.Now, Email = "osoblje@gmail.com", GradId = 2, Povjerljiv = true, LozinkaHash = "testtest", LozinkaSalt = "testtest" }
            //    );

            //context.KorisniciUloge.AddOrUpdate(
            //    new Models.KorisniciUloge { DatumDodjele = DateTime.Now, KorisnikId = 1, UlogaId = 2 },
            //    new Models.KorisniciUloge { DatumDodjele = DateTime.Now, KorisnikId = 2, UlogaId = 1 }
            //);
        }
    }
}
