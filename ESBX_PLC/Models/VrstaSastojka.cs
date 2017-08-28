using System.ComponentModel.DataAnnotations;
using ExpressSaladBarDataDB.Helper;

namespace ExpressSaladBarDataDB.Models
{
    public class VrstaSastojka: IEntity
    {
        public int Id { get; set; }

        [Required]
        public string Naziv { get; set; }

        public string Opis { get; set; }
    }
}