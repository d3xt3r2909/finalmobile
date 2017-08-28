using System.ComponentModel.DataAnnotations;
using ESBX_db.Helper;

namespace ESBX_db.Models
{
    public class Grad: IEntity
    {
        public int Id { get; set; }

        [Required]
        public string Naziv { get; set; }
        
        public string PostanskiBroj { get; set; }

        public int DrzavaId { get; set; }
        public virtual Drzava Drzava { get; set; }
    }
}