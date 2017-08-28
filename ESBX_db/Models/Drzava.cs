using System.ComponentModel.DataAnnotations;
using ESBX_db.Helper;

namespace ESBX_db.Models
{
    public class Drzava: IEntity
    {
        public int Id { get; set; }

        [Required]
        public string Naziv { get; set; }

        [Required]
        public string Oznaka { get; set; }

        public string PozivniBroj { get; set; }
    }
}