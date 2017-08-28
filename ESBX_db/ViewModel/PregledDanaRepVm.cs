using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESBX_db.ViewModel
{
    public class PregledDanaRepVm
    {
        public int Id { get; set; }
        public DateTime Datum { get; set; }
        public int BrojSalata { get; set; }
        public float Cijena { get; set; }
        public string Sifra { get; set; }
    }
}
