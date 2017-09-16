namespace ESBX_db.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class intial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Dobavljacis",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naziv = c.String(nullable: false),
                        Adresa = c.String(),
                        BrojTelefona = c.String(nullable: false),
                        Email = c.String(nullable: false, maxLength: 450),
                        Ziroracun = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Email, unique: true);
            
            CreateTable(
                "dbo.Drzavas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naziv = c.String(nullable: false),
                        Oznaka = c.String(nullable: false),
                        PozivniBroj = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Grads",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naziv = c.String(nullable: false),
                        PostanskiBroj = c.String(),
                        DrzavaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Drzavas", t => t.DrzavaId)
                .Index(t => t.DrzavaId);
            
            CreateTable(
                "dbo.Korisnicis",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LozinkaSalt = c.String(nullable: false),
                        LozinkaHash = c.String(nullable: false),
                        Email = c.String(nullable: false, maxLength: 450),
                        Ime = c.String(nullable: false),
                        Prezime = c.String(nullable: false),
                        BrojTelefona = c.String(nullable: false),
                        Adresa = c.String(nullable: false),
                        Povjerljiv = c.Boolean(nullable: false),
                        DatumKreiranja = c.DateTime(nullable: false),
                        DatumRodjenja = c.DateTime(nullable: false),
                        Aktivan = c.Boolean(nullable: false),
                        GradId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Grads", t => t.GradId)
                .Index(t => t.Email, unique: true)
                .Index(t => t.GradId);
            
            CreateTable(
                "dbo.KorisniciUloges",
                c => new
                    {
                        KorisnikId = c.Int(nullable: false),
                        UlogaId = c.Int(nullable: false),
                        DatumDodjele = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.KorisnikId, t.UlogaId })
                .ForeignKey("dbo.Korisnicis", t => t.KorisnikId)
                .ForeignKey("dbo.Uloges", t => t.UlogaId)
                .Index(t => t.KorisnikId)
                .Index(t => t.UlogaId);
            
            CreateTable(
                "dbo.Uloges",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naziv = c.String(nullable: false),
                        Opis = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.KorisnikSastojcis",
                c => new
                    {
                        KorisnikId = c.Int(nullable: false),
                        SastojakId = c.Int(nullable: false),
                        Korisnici_Id = c.Int(),
                        Sastojci_Id = c.Int(),
                    })
                .PrimaryKey(t => new { t.KorisnikId, t.SastojakId })
                .ForeignKey("dbo.Korisnicis", t => t.Korisnici_Id)
                .ForeignKey("dbo.Sastojcis", t => t.Sastojci_Id)
                .Index(t => t.Korisnici_Id)
                .Index(t => t.Sastojci_Id);
            
            CreateTable(
                "dbo.Sastojcis",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naziv = c.String(nullable: false),
                        Cijena = c.Single(nullable: false),
                        Gramaza = c.Single(nullable: false),
                        Stanje = c.Single(nullable: false),
                        BrojKalorija = c.Single(nullable: false),
                        Napomena = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        VrstaSastojkaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.VrstaSastojkas", t => t.VrstaSastojkaId)
                .Index(t => t.VrstaSastojkaId);
            
            CreateTable(
                "dbo.SalataStavkes",
                c => new
                    {
                        SalataId = c.Int(nullable: false),
                        SastojakId = c.Int(nullable: false),
                        Gramaza = c.Single(nullable: false),
                        Cijena = c.Single(nullable: false),
                    })
                .PrimaryKey(t => new { t.SalataId, t.SastojakId })
                .ForeignKey("dbo.Salates", t => t.SalataId)
                .ForeignKey("dbo.Sastojcis", t => t.SastojakId)
                .Index(t => t.SalataId)
                .Index(t => t.SastojakId);
            
            CreateTable(
                "dbo.Salates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Napomena = c.String(),
                        DatumKreiranja = c.DateTime(nullable: false),
                        OcjeneKomentariId = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.KorpaStavkes",
                c => new
                    {
                        KorpaId = c.Int(nullable: false),
                        SalataId = c.Int(nullable: false),
                        Kolicina = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.KorpaId, t.SalataId })
                .ForeignKey("dbo.Korpas", t => t.KorpaId)
                .ForeignKey("dbo.Salates", t => t.SalataId)
                .Index(t => t.KorpaId)
                .Index(t => t.SalataId);
            
            CreateTable(
                "dbo.Korpas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Napomena = c.String(),
                        VrijemeDolaska = c.DateTime(nullable: false),
                        VrijemeNarucivanja = c.DateTime(nullable: false),
                        Sifra = c.String(maxLength: 450),
                        Zavrsena = c.Boolean(nullable: false),
                        Finilizirana = c.Boolean(nullable: false),
                        Aktivna = c.Boolean(nullable: false),
                        RacunId = c.Int(),
                        KorisnikId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Korisnicis", t => t.KorisnikId)
                .Index(t => t.Sifra, unique: true)
                .Index(t => t.KorisnikId);
            
            CreateTable(
                "dbo.Racuns",
                c => new
                    {
                        KorpaId = c.Int(nullable: false),
                        Datum = c.DateTime(nullable: false),
                        UkupnaCijena = c.Single(nullable: false),
                        CijenaSaPopustom = c.Single(nullable: false),
                        Popust = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.KorpaId)
                .ForeignKey("dbo.Korpas", t => t.KorpaId)
                .Index(t => t.KorpaId);
            
            CreateTable(
                "dbo.OcjeneKomentaris",
                c => new
                    {
                        SalataId = c.Int(nullable: false),
                        Ocjena = c.Int(nullable: false),
                        Komentar = c.String(),
                        Datum = c.DateTime(nullable: false),
                        KorisnikId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SalataId)
                .ForeignKey("dbo.Korisnicis", t => t.KorisnikId)
                .ForeignKey("dbo.Salates", t => t.SalataId)
                .Index(t => t.SalataId)
                .Index(t => t.KorisnikId);
            
            CreateTable(
                "dbo.StavkaUlazas",
                c => new
                    {
                        SastojakId = c.Int(nullable: false),
                        UlazZalihaId = c.Int(nullable: false),
                        Kolicina = c.Int(nullable: false),
                        Cijena = c.Single(nullable: false),
                    })
                .PrimaryKey(t => new { t.SastojakId, t.UlazZalihaId })
                .ForeignKey("dbo.Sastojcis", t => t.SastojakId)
                .ForeignKey("dbo.UlazZalihas", t => t.UlazZalihaId)
                .Index(t => t.SastojakId)
                .Index(t => t.UlazZalihaId);
            
            CreateTable(
                "dbo.UlazZalihas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Datum = c.DateTime(nullable: false),
                        Napomena = c.String(),
                        DobavljaciId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Dobavljacis", t => t.DobavljaciId)
                .Index(t => t.DobavljaciId);
            
            CreateTable(
                "dbo.VrstaSastojkas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naziv = c.String(nullable: false),
                        Opis = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.NagradnaIgras",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        VaziDo = c.DateTime(nullable: false),
                        Popust = c.Single(nullable: false),
                        Iskoristen = c.Boolean(nullable: false),
                        Napomena = c.String(),
                        KorisniciId = c.Int(nullable: false),
                        KuponKod = c.String(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Korisnicis", t => t.KorisniciId)
                .Index(t => t.KorisniciId);
            
            CreateTable(
                "dbo.Slikes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UrlSlike = c.String(nullable: false),
                        Slika = c.Binary(),
                        Opis = c.String(),
                        Naziv = c.String(),
                        SastojakId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sastojcis", t => t.SastojakId)
                .Index(t => t.SastojakId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Slikes", "SastojakId", "dbo.Sastojcis");
            DropForeignKey("dbo.NagradnaIgras", "KorisniciId", "dbo.Korisnicis");
            DropForeignKey("dbo.KorisnikSastojcis", "Sastojci_Id", "dbo.Sastojcis");
            DropForeignKey("dbo.Sastojcis", "VrstaSastojkaId", "dbo.VrstaSastojkas");
            DropForeignKey("dbo.StavkaUlazas", "UlazZalihaId", "dbo.UlazZalihas");
            DropForeignKey("dbo.UlazZalihas", "DobavljaciId", "dbo.Dobavljacis");
            DropForeignKey("dbo.StavkaUlazas", "SastojakId", "dbo.Sastojcis");
            DropForeignKey("dbo.SalataStavkes", "SastojakId", "dbo.Sastojcis");
            DropForeignKey("dbo.SalataStavkes", "SalataId", "dbo.Salates");
            DropForeignKey("dbo.OcjeneKomentaris", "SalataId", "dbo.Salates");
            DropForeignKey("dbo.OcjeneKomentaris", "KorisnikId", "dbo.Korisnicis");
            DropForeignKey("dbo.KorpaStavkes", "SalataId", "dbo.Salates");
            DropForeignKey("dbo.Racuns", "KorpaId", "dbo.Korpas");
            DropForeignKey("dbo.KorpaStavkes", "KorpaId", "dbo.Korpas");
            DropForeignKey("dbo.Korpas", "KorisnikId", "dbo.Korisnicis");
            DropForeignKey("dbo.KorisnikSastojcis", "Korisnici_Id", "dbo.Korisnicis");
            DropForeignKey("dbo.KorisniciUloges", "UlogaId", "dbo.Uloges");
            DropForeignKey("dbo.KorisniciUloges", "KorisnikId", "dbo.Korisnicis");
            DropForeignKey("dbo.Korisnicis", "GradId", "dbo.Grads");
            DropForeignKey("dbo.Grads", "DrzavaId", "dbo.Drzavas");
            DropIndex("dbo.Slikes", new[] { "SastojakId" });
            DropIndex("dbo.NagradnaIgras", new[] { "KorisniciId" });
            DropIndex("dbo.UlazZalihas", new[] { "DobavljaciId" });
            DropIndex("dbo.StavkaUlazas", new[] { "UlazZalihaId" });
            DropIndex("dbo.StavkaUlazas", new[] { "SastojakId" });
            DropIndex("dbo.OcjeneKomentaris", new[] { "KorisnikId" });
            DropIndex("dbo.OcjeneKomentaris", new[] { "SalataId" });
            DropIndex("dbo.Racuns", new[] { "KorpaId" });
            DropIndex("dbo.Korpas", new[] { "KorisnikId" });
            DropIndex("dbo.Korpas", new[] { "Sifra" });
            DropIndex("dbo.KorpaStavkes", new[] { "SalataId" });
            DropIndex("dbo.KorpaStavkes", new[] { "KorpaId" });
            DropIndex("dbo.SalataStavkes", new[] { "SastojakId" });
            DropIndex("dbo.SalataStavkes", new[] { "SalataId" });
            DropIndex("dbo.Sastojcis", new[] { "VrstaSastojkaId" });
            DropIndex("dbo.KorisnikSastojcis", new[] { "Sastojci_Id" });
            DropIndex("dbo.KorisnikSastojcis", new[] { "Korisnici_Id" });
            DropIndex("dbo.KorisniciUloges", new[] { "UlogaId" });
            DropIndex("dbo.KorisniciUloges", new[] { "KorisnikId" });
            DropIndex("dbo.Korisnicis", new[] { "GradId" });
            DropIndex("dbo.Korisnicis", new[] { "Email" });
            DropIndex("dbo.Grads", new[] { "DrzavaId" });
            DropIndex("dbo.Dobavljacis", new[] { "Email" });
            DropTable("dbo.Slikes");
            DropTable("dbo.NagradnaIgras");
            DropTable("dbo.VrstaSastojkas");
            DropTable("dbo.UlazZalihas");
            DropTable("dbo.StavkaUlazas");
            DropTable("dbo.OcjeneKomentaris");
            DropTable("dbo.Racuns");
            DropTable("dbo.Korpas");
            DropTable("dbo.KorpaStavkes");
            DropTable("dbo.Salates");
            DropTable("dbo.SalataStavkes");
            DropTable("dbo.Sastojcis");
            DropTable("dbo.KorisnikSastojcis");
            DropTable("dbo.Uloges");
            DropTable("dbo.KorisniciUloges");
            DropTable("dbo.Korisnicis");
            DropTable("dbo.Grads");
            DropTable("dbo.Drzavas");
            DropTable("dbo.Dobavljacis");
        }
    }
}
