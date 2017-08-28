using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpressSaladBarDataDB.Models
{
    public class KorpaStavke
    {
        [Key,Column(Order = 0)]
        public int KorpaId { get; set; }
        public virtual Korpa Korpa { get; set; }

        [Key,Column(Order = 1)]
        public int SalataId { get; set; }
        public virtual Salate Salata { get; set; }

        [Required]
        public int Kolicina { get; set; }
    }
}