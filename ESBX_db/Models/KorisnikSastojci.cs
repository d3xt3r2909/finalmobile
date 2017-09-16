using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESBX_db.Models
{
    public class KorisnikSastojci
    {
        [Key, Column(Order = 0)]
        public int KorisnikId { get; set; }
        public virtual Korisnici Korisnici { get; set; }

        [Key, Column(Order = 1)]
        public int SastojakId { get; set; }
        public virtual Sastojci Sastojci { get; set; }
    }
}
