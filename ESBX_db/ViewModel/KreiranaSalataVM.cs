using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESBX_db.ViewModel
{
    public class KreiranaSalataVM
    {
        public int KorisnikId { get; set; }
        public List<int> listaIzabranih { get; set; }

        public int Kolicina { get; set; }

        public string Napomena { get; set; }
    }
}
