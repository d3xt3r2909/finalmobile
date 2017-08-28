using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ESBX_db.Models
{
    public class OcjeneKomentari
    {

        [Key, ForeignKey("Salata")]
        public int SalataId { get; set; }
        public virtual Salate Salata{ get; set; }

        public int Ocjena { get; set; }

        public string Komentar { get; set; }

        public DateTime Datum { get; set; }

        public int KorisnikId { get; set; }
        public virtual Korisnici Korisnik { get; set; }
    }
}