using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ESBX_db.Helper;

namespace ESBX_db.Models
{
    public class Korpa: IEntity
    {
        public int Id { get; set; }
       
        public string Napomena { get; set; }

        [Required]
        public DateTime VrijemeDolaska { get; set; }

        [Required]
        public DateTime VrijemeNarucivanja { get; set; }
       
        [StringLength(450)]
        [Index(IsUnique = true)]
        public string Sifra { get; set; }

        // Kada kuhar kaze da je gotova 
        public bool Zavrsena { get; set; }

        // Kada konobar kaze da je dosao / nije dosao gost
        public bool Finilizirana { get; set; }

        // Trenutna korisnikova korpa 
        public bool Aktivna { get; set; }

        public int? RacunId { get; set; }
        public  virtual Racun Racun { get; set; }

        public int KorisnikId { get; set; }
        public virtual Korisnici Korisnik { get; set; }

        public virtual ICollection<KorpaStavke> KorpaStavke { get; set; }
    }

}