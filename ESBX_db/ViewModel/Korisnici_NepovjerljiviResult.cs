using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESBX_db.ViewModel
{
    public class Korisnici_NepovjerljiviResult
    {
        public int KorisnikId { get; set; }
        public string Korisnik { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public float UkupanDug { get; set; }
       
    }
}
