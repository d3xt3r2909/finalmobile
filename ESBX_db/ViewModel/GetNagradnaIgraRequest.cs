using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESBX_db.ViewModel
{
    public class GetNagradnaIgraRequest
    {
        public bool GetAll { get; set; }
        public int? KorisnikId { get; set; }
        public string KorisnikImePrezime { get; set; }
        public DateTime DatumStart { get; set; }
        public DateTime DatumEnd { get; set; }
        public string KuponKod { get; set; }
        public bool Status { get; set; }
    }
}
