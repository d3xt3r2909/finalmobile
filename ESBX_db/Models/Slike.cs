using System.ComponentModel.DataAnnotations;
using ESBX_db.Helper;

namespace ESBX_db.Models
{
    public class Slike: IEntity
    {
        public int Id { get; set; }

        [Required]
        public string UrlSlike { get; set; }

        public byte[] Slika { get; set; }

        public string Opis { get; set; }

        public string Naziv { get; set; }

        public int SastojakId { get; set; }
        public virtual Sastojci Sastojak { get; set; }
    }
}