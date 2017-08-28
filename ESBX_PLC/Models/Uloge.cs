using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ExpressSaladBarDataDB.Helper;

namespace ExpressSaladBarDataDB.Models
{
    public class Uloge: IEntity
    {
        public int Id { get; set; }

        [Required]
        public string Naziv { get; set; }

        public string Opis { get; set; }

        public virtual ICollection<KorisniciUloge> KorisniciUloge { get; set; }
    }
}