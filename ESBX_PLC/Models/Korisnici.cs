using System;
using System.Collections.Generic;
using ExpressSaladBarDataDB.Helper;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpressSaladBarDataDB.Models
{
    public class Korisnici: IEntity, IAccount
    {
        public int Id { get; set; }

        [Required]
        public string LozinkaSalt { get; set; }

        [Required]
        public string LozinkaHash { get; set; }

        [Required]
        [StringLength(450)]
        [Index(IsUnique = true)]
        public string Email { get; set; }

        [Required]
        public string Ime  {get;set;}

        [Required]
        public string Prezime {get;set;}

        [Required]
        public string BrojTelefona {get;set;}

        [Required]
        public string  Adresa {get;set;}

        [Required]
        [DefaultValue(true)]
        public bool Povjerljiv {get;set;}

        [Required]
        public DateTime DatumKreiranja {get;set;}

        [Required]
        public DateTime DatumRodjenja { get; set; }

        [DefaultValue(false)]
        public bool Aktivan { get; set; }

        public int GradId { get; set; }
        public virtual Grad Grad { get; set; }

        public virtual ICollection<KorisniciUloge> KorisniciUloge { get; set; }

    }
}