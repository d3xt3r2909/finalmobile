using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESBX_db.ViewModel
{
    public class KomentarResponseVm
    {
        public int SalataId { get; set; }

        public int Ocjena { get; set; }

        public string Komentar { get; set; }

        public DateTime Datum { get; set; }

        public int KorisnikId { get; set; }
    }
}
