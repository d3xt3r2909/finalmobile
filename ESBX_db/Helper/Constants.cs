using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESBX_db.Helper
{
    public class Constants
    {
        public static readonly string ULOGA_OSOBLJE = "Osoblje"; 
        public static readonly string ULOGA_ADMIN = "Administrator"; 
        public static readonly string ULOGA_MENADZER = "Menadzer"; 
        public static readonly string ULOGA_KORISNIK = "Korisnik";

        /* SASTOJCI VRSTA */
        public static string SastojakGlavni = "Glavni";
        public static string SastojakSporedni = "Sporedni";
        public static string SastojakDresing = "Dresing";

        /**
        * Generisanje jedinstvenog koda
        */

        public static string GenerateUniqueKod(int kodLength)
        {
            string tmpSifra, realSifra;

            var rnd = new Random(DateTime.Now.Millisecond);
            var rDouble = rnd.NextDouble() * 1000000000000;
            var tmpTmp = Math.Round(rDouble);
            tmpSifra = tmpTmp.ToString(CultureInfo.InvariantCulture);
            realSifra = tmpSifra.Substring(0, kodLength);

            return realSifra;
        }
    }
}
