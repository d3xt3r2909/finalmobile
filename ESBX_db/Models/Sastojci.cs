using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ESBX_db.Helper;

namespace ESBX_db.Models
{
    public class Sastojci: IEntity
    {
        public int Id { get; set; }

        [Required]
        public string Naziv { get; set; }

        [Required]
        public float Cijena{ get; set; }

        [Required]
        public float Gramaza{ get; set; }

        [DefaultValue(0)]
        public float Stanje { get; set; }

        [Required]
        public float BrojKalorija { get; set; }

        public string Napomena  { get; set; }

        public bool IsDeleted { get; set; }

        public virtual ICollection<SalataStavke> SalataStavke { get; set; }

        public virtual ICollection<StavkaUlaza> StavkaUlaza { get; set; }

        public int VrstaSastojkaId { get; set; }
        public virtual VrstaSastojka VrstaSastojka { get; set; }

    }
}