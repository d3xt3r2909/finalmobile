using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ESBX_db.Models
{
    public class SalataStavke
    {
        [Key, Column(Order = 0)]
        public int SalataId { get; set; }
        public virtual Salate Salata { get; set; }

        [Key, Column(Order = 1)]
        public int SastojakId { get; set; }
        public virtual Sastojci Sastojak { get; set; }

        public float Gramaza { get; set; }

        public float Cijena { get; set; }
    }
}