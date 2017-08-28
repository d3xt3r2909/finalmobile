using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESBX_Client.Util.ViewModel
{
    public class IstekZalihaVm
    {
        public int SastojakId { get; set; }
        public string Naziv { get; set; }
        public float Stanje { get; set; }
        public string VrstaSastojka { get; set; }
    }
}
