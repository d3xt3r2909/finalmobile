using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESBX_db.ViewModel
{
    public class SastojciPostWithImage
    {
        public int Id { get; set; }

        [Required]
        public string Naziv { get; set; }

        [Required]
        public float Cijena { get; set; }

        [Required]
        public float Gramaza { get; set; }

        [DefaultValue(0)]
        public float Stanje { get; set; }

        [Required]
        public float BrojKalorija { get; set; }

        public string Napomena { get; set; }

        public bool IsDeleted { get; set; }

        public int VrstaSastojkaId { get; set; }

        public byte[] Slika { get; set; }
    }
}
