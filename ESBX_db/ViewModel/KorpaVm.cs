using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESBX_db.Models;

namespace ESBX_db.ViewModel
{
    public class SastojciRow
    {
        public int SalataId { get; set; }
        public int SastojakId { get; set; }
        public string Naziv { get; set; }
        public string Vrsta { get; set; }
        public float Cijena { get; set; }
        public float Gramaza { get; set; }
        public float BrojKalorija { get; set; }
    }

    public class KorpaIndexRow
    {
        public Korisnici Korisnik { get; set; }
        public SastojciRow DresingSastojak { get; set; }
        public SastojciRow GlavniSastojak { get; set; }
        public List<SastojciRow> ListSastojciSporedni { get; set; }
        public DateTime VrijemeDolaska { get; set; }
        public int KorpaId { get; set; }
        public int Kolicina { get; set; }
        public int SalataId { get; set; }
        public string Napomena { get; set; }
        public DateTime DatumKreiranja { get; set; }
        public string Komentar { get; set; }
        public int Ocjena { get; set; }
        public float CijenaSalate { get; set; }
        public float UkupnaCijena { get; set; }
    }

    public class KorpaVm
    {
        public List<KorpaIndexRow> ListSalate { get; set; }
        public bool EmptyBasket { get; set; }
        public int UkupnoSalata { get; set; }
        public double UkupnaCijena { get; set; }
        public int KorpaStavke { get; set; }
        public int KorpaId { get; set; }
        public Korisnici Korisnik { get; set; }

    }
}
