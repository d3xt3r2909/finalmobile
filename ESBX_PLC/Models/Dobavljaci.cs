using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressSaladBarDataDB.Models
{
    public class Dobavljaci
    {
        public int Id { get; set; }

        [Required]
        public string Naziv { get; set; }

        public string Adresa { get; set; }

        [Required]
        public string BrojTelefona { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(450)]
        [Index(IsUnique = true)]
        public string Email { get; set; }

        public string Ziroracun { get; set; }

        public bool Status { get; set; }
    }
}
