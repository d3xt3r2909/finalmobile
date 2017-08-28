using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ESBX_db.Models
{
    public class StavkaUlaza
    {
        [Key,Column(Order = 0)]
        public int SastojakId { get; set; }
        public virtual Sastojci Sastojak { get; set; }

        [Key,Column(Order = 1)]
        public int UlazZalihaId { get; set; }
        public virtual UlazZaliha UlazZaliha { get; set; }

        [Required]
        public int Kolicina { get; set; }

        [Required]
        public float Cijena { get; set; }
    }
}