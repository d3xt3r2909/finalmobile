using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ESBX_db.Models
{
    public class KorisniciUloge
    {
        [Key,Column(Order = 0)]
        public int KorisnikId { get; set; }
        public virtual Korisnici Korisnik { get; set; }

        [Key,Column(Order = 1)]
        public int UlogaId { get; set; }
        public virtual Uloge Uloga { get; set; }

        [Required]
        public DateTime DatumDodjele { get; set; }
    }
}