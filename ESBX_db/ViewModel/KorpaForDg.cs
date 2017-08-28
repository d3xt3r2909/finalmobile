using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESBX_db.ViewModel
{

    public class KorpaForDgRow
    {
        public int Id { get; set; }

        // Pohranjuje se ime + prezime i broj telefona
        public string Korisnik { get; set; }

        // Pohranjuje se samo naziv glavnog sastojka
        public string GlavniSastojak { get; set; }

        // Pohranjuju se nazivi sporednih sastojaka odvojenih zarezom
        public string SporedniSastojak { get; set; }

        // Pohranjuje se samo naziv dresing sastojka
        public string DresingSastojak { get; set; }

        // Pohranjuje se samo naziv dresing sastojka
        public DateTime VrijemeDolaska { get; set; }
    }

    public class KorpaForDg
    {
        public List<KorpaForDgRow> ListSalate { get; set; }
    }
}
