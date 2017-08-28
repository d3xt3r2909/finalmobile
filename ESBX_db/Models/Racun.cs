using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ESBX_db.Models
{
    public class Racun
    {
        [Key, ForeignKey("Korpa")]
        public int KorpaId { get; set; }

        [Required]
        public DateTime Datum { get; set; }

        [Required]
        public float UkupnaCijena { get; set; }

        public float CijenaSaPopustom { get; set; }

        public float Popust { get; set; }

        public virtual Korpa Korpa { get; set; }
    }
}