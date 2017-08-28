using ESBX_db.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ESBX_db.DAL
{
    public class MContext : DbContext
    {
        //Open connection on database
        public MContext() : base("connectionDb")
        {
        }

        public DbSet<Dobavljaci> Dobavljaci { get; set; }

        public DbSet<Drzava> Drzave { get; set; }

        public DbSet<Grad> Gradovi { get; set; }

        public DbSet<NagradnaIgra> NagradnaIgra { get; set; }

        public DbSet<Korisnici> Korisnici { get; set; }

        public DbSet<KorisniciUloge> KorisniciUloge { get; set; }

        public DbSet<Korpa> Korpa { get; set; }

        public DbSet<KorpaStavke> KorpaStavke { get; set; }

        public DbSet<OcjeneKomentari> OcjeneKomentari { get; set; }

     

        public DbSet<Racun> Racun { get; set; }

        public DbSet<SalataStavke> SalataStavke { get; set; }

        public DbSet<Salate> Salate { get; set; }

        public DbSet<Sastojci> Sastojci { get; set; }

        public DbSet<Slike> Slike { get; set; }

        public DbSet<StavkaUlaza> StavkaUlaza { get; set; }

        public DbSet<UlazZaliha> UlazZaliha { get; set; }

        public DbSet<Uloge> Uloge { get; set; }

        public DbSet<VrstaSastojka> VrstaSastojka { get; set; }

        //Remove cascade
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}