using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ESBX_db.Helper;

namespace ESBX_db.Models
{
    public class UlazZaliha: IEntity
    {
        public int Id { get; set; }

        [Required]
        public DateTime Datum { get; set; }

        public string Napomena { get; set; }

        public virtual ICollection<StavkaUlaza> StavkaUlaza { get; set; }

        public int DobavljaciId { get; set; }
        public virtual Dobavljaci Dobavljaci { get; set; }

    }
}