using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ESBX_API.Helper
{
    public static class WebApiRoutes
    {
        public const string URL_ROUTE = "http://localhost:58050/";
        public const string LOGIN_ROUTE = "api/account/login";
        public const string POST_REGISTER = "api/account/Registration";
        public const string GET_ULOGA_BY_KORISNIK = "api/account/uloge/";
        public const string GET_VRSTE_SASTOJAKA = "api/sastojci/vrstesastojaka/";
        public const string DELETE_VRSTE_SASTOJAKA = "api/sastojci/deletebyid/";
        public const string GET_STANJE_SASTOJAKA = "api/sastojci/stanje/";
        public const string GET_SASTOJCI = "api/sastojci/";
        public const string POST_SASTOJCI = "api/sastojci/addSastojak";
        public const string GET_OSOBLJE_KORPA = "api/korpa/narudzbe/";
        public const string PUT_OSOBLJE_KORPA_STATUS = "api/korpa/status/";
        public const string GET_KORISNICI_KORPA = "api/korpa/getKorpaById/";
        public const string PUT_KORISNICI_POVJERLJIVOST = "api/promjenapovjerljivosti/status/";
        public const string GET_REPORT_PREGLED_DANA = "api/narudzbe/GetPregledDana/";
        public const string POST_ZAVRSI_NARUDZBU = "api/narudzbe/zavrsi/";
        public const string POST_DOWNLOAD_RACUN = "api/korpa/downloadracun/";
        public const string GET_GRADOVI = "api/gradovi";

    }
}