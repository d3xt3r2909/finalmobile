using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ESBX_db.Helper;

namespace ESBX_db.Models
{
    public class Salate: IEntity
    {
        public int Id { get; set; }

        public string Napomena { get; set; }

        [Required]
        public DateTime DatumKreiranja { get; set; }
                    
        public int? OcjeneKomentariId { get; set; }
        public virtual OcjeneKomentari OcjeneKomentari { get; set; }

        public virtual ICollection<KorpaStavke> KorpaStavke { get; set; }

        public virtual ICollection<SalataStavke> SalataStavke { get; set; }
    }
}