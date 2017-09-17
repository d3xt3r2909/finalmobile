using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESBX_db.ViewModel
{
    public class KorpaModel
    {
        public int Id { get; set; }

        public string Napomena { get; set; }

        public DateTime VrijemeDolaska { get; set; }

        public DateTime VrijemeNarucivanja { get; set; }
        
        public string Sifra { get; set; }

        // Kada kuhar kaze da je gotova 
        public bool Zavrsena { get; set; }

        // Kada konobar kaze da je dosao / nije dosao gost
        public bool Finilizirana { get; set; }
        
        public bool Aktivna { get; set; }

        public int? RacunId { get; set; }

        public int KorisnikId { get; set; }
    }
}
