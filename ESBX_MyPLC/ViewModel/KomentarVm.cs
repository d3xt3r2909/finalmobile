using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESBX_MyPLC.ViewModel
{
    public class KomentarVm
    {
        public int KorisnikId { get; set; }
        public int KorpaId { get; set; }
        public int SalataId { get; set; }
        public string Komentar { get; set; }
        public int Ocjena { get; set; }
    }
}
