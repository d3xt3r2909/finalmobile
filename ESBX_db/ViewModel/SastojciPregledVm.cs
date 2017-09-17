using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESBX_db.ViewModel
{
    public class SastojciPregledVm
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public float Gramaza { get; set; }
        public float Cijena { get; set; }
        public float BrojKalorija { get; set; }
        public string VrstaSastojka { get; set; }
        public float Stanje { get; set; }
    }
}
