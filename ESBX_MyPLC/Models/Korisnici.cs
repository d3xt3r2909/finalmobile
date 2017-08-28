using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESBX_MyPLC.Models
{
    public class Korisnici
    {
        public int Id { get; set; }

        public string LozinkaSalt { get; set; }

        public string LozinkaHash { get; set; }

        public string Email { get; set; }

        public string Ime { get; set; }

        public string Prezime { get; set; }

        public string BrojTelefona { get; set; }

        public string Adresa { get; set; }

        public DateTime DatumRodjenja { get; set; }

        public int GradId { get; set; }
    }
}
