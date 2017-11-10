using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESBX_db.ViewModel
{
    public class GetNagradnaIgraResponse
    {
        public int KorisnikId { get; set; }
        public string KorisnikImePrezime { get; set; }
        public string KorisnikEmail { get; set; }
        public string KuponKod { get; set; }
        public bool Iskoristen { get; set; }
        public string IskoristenOpis { get {
                if (Iskoristen) return "DA";
                else return "NE";
            } }
        public float Popust { get; set; }
        public DateTime VaziDo { get; set; }
    }
}
