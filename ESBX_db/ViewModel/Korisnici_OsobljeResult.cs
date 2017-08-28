using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESBX_db.ViewModel
{
    public class Korisnici_OsobljeResult
    {
        public int UposlenikId { get; set; }
        public string Uposlenik { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public DateTime DatumZaposlenja { get; set; }
        public bool Aktivan { get; set; }

    }
}
