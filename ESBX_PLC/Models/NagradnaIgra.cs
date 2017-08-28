using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressSaladBarDataDB.Models
{
    public class NagradnaIgra
    {
        public int id { get; set; }

        [Required]
        public DateTime VaziDo { get; set; }

        [Required]
        public float Popust { get; set; }

        public bool Iskoristen { get; set; }

        public string Napomena { get; set; }

        public int KorisniciId { get; set; }

        public string KuponKod { get; set; }

        public virtual Korisnici Korisnici { get; set; }
    }
}
