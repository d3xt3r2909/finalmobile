using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESBX_MyPLC.ViewModel
{
    public class AccountRegistrationVm
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string EmailAdresa { get; set; }
        public string Adresa { get; set; }
        public string Telefon { get; set; }
        public string Lozinka { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public int GradId { get; set; }
    }
}
