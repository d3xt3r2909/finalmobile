using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESBX_db.ViewModel
{
    public class PregledDobavljaciForDg
    {
        public int UlazZalihaId { get; set; }
        public string Napomena { get; set; }
        public string NabavkaDate { get; set; }
        public int DobavljacId { get; set; }
        public string DobavljacNaziv { get; set; }
        public string DobavljacTelefon { get; set; }
        public string DobavljacAdresa { get; set; }
        public string DobavljacEmail { get; set; }
        public string DobavljacRacun { get; set; }
        public List<SastojciForGridVM> SastojciList { get; set; }
    }
}
