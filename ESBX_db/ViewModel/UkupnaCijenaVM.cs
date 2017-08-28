using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESBX_db.ViewModel
{
    public class UkupnaCijenaVM
    {
        public List<ListaVrijednostiVM> listaSalataId { get; set; }
    }
    public class ListaVrijednostiVM
    {
        public int SalataId { get; set; }

        public int Kolicina { get; set; }
    }
}
