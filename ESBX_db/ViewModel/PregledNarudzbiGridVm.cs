using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESBX_db.ViewModel
{
    public class SalataItem {

        public int SalataId { get; set; }
        public string GlavniSastojak { get; set; }
        public string SporedniSastojak { get; set; }
        public string DresingSastojak { get; set; }
        public int Kolicina { get; set; }
        public float CijenaSalate { get; set; }
    }
    public class PregledNarudzbiGridVm
    {
        public int NarudzbaId { get; set; }
        public DateTime VrijemeDolaska { get; set; }

        public List<SalataItem> Salate { get; set; }
        public string Korisnik { get; set; }
    }
}
