using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESBX_db.ViewModel
{
    public class KomentarVm
    {
        [Required]
        public int KorisnikId { get; set; }
        [Required]
        public int KorpaId { get; set; }
        [Required]
        public int SalataId { get; set; }
        [Required]
        public string Komentar { get; set; }
        [Required]
        public int Ocjena { get; set; }
    }
}
