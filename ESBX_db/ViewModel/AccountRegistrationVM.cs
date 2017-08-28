using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESBX_db.Models;

namespace ESBX_db.ViewModel
{
    public class AccountRegistrationVm
    {
        [Required(ErrorMessage = "Ime je obavezno polje.")]
        [StringLength(1000, MinimumLength = 2, ErrorMessage = "Ime mora sadržavati minimalno dva karaktera.")]
        public string Ime { get; set; }

        [Required(ErrorMessage = "Prezime je obavezno polje.")]
        [StringLength(1000, MinimumLength = 2, ErrorMessage = "Prezime mora sadržavati minimalno dva karaktera.")]
        public string Prezime { get; set; }

        [Required(ErrorMessage = "Email je obavezno polje.")]
        [StringLength(1000, MinimumLength = 5, ErrorMessage = "Email mora sadržavati minimalno pet karaktera.")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Uneseni email nije ispravnog formata.")]
        public string EmailAdresa { get; set; }

        [Required(ErrorMessage = "Adresa je obavezno polje.")]
        [StringLength(1000, MinimumLength = 5, ErrorMessage = "Adresa mora sadržavati minimalno pet karaktera.")]
        public string Adresa { get; set; }

        [Required(ErrorMessage = "Broj telefona je obavezno polje.")]
        [StringLength(1000, MinimumLength = 9, ErrorMessage = "Broj telefona mora sadržavati minimalno devet karaktera.")]
        public string Telefon { get; set; }


        [Required(ErrorMessage = "Lozinka je obavezno polje.")]
        [StringLength(1000, MinimumLength = 6, ErrorMessage = "Lozinka mora sadržavati minimalno šest karaktera.")]
        [DataType(DataType.Password)]
        public string Lozinka { get; set; }

        [DisplayName("Datum rodjenja")]
        //[DataType(DataType.Date, ErrorMessage = "Današnji datum ne može biti odabran kao datum Vašeg rođenja.")]
        public DateTime DatumRodjenja { get; set; }

        public List<Grad> Gradovi { get; set; }
        public int GradId { get; set; }

    }
}
