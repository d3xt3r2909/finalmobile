using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ESBX_API.Helper
{
    public static class WebApiRoutes
    {
        // public const string URL_ROUTE = "http://hci148.app.fit.ba/";
        // public const string URL_ROUTE = "http://localhost:63541/";

        public const string URL_ROUTE = "http://192.168.100.100/";

        public const string LOGIN_ROUTE = "api/account/login";
        public const string POST_REGISTER = "api/account/Registration";
        public const string GET_VRSTE_ULOGA = "api/uloge/getvrsteuloga/";
        public const string GET_ULOGA_BY_KORISNIK = "api/account/uloge/";
        public const string GET_VRSTE_SASTOJAKA = "api/sastojci/vrstesastojaka/";
        public const string DELETE_VRSTE_SASTOJAKA = "api/sastojci/deletebyid/";
        public const string GET_STANJE_SASTOJAKA = "api/sastojci/stanje/";
        public const string GET_SASTOJCI = "api/sastojci/";
        public const string GET_SASTOJCI_LIST_OMILJENI = "api/sastojci/omiljeni/";
        public const string POST_DODAJ_OMILJENE = "api/sastojci/omiljeni/";
        public const string POST_SASTOJCI = "api/sastojci/addSastojak";
        public const string GET_OSOBLJE_KORPA = "api/korpa/narudzbe/";
        public const string PUT_OSOBLJE_KORPA_STATUS = "api/korpa/status/";
        public const string GET_KORISNICI_KORPA = "api/korpa/getKorpaById/";
        public const string PUT_KORISNICI_POVJERLJIVOST = "api/promjenapovjerljivosti/status/";
        public const string GET_REPORT_PREGLED_DANA = "api/narudzbe/GetPregledDana/";
        public const string POST_ZAVRSI_NARUDZBU = "api/narudzbe/zavrsi/";
        public const string DELETE_ITEM_KORPA = "api/korpa/";
        public const string POST_DOWNLOAD_RACUN = "api/korpa/downloadracun/";
        public const string GET_GRADOVI = "api/gradovi";
        public const string GET_AKTIVNA_KORPA = "api/korpa/GetAktivnaKorpa/";
        public const string POST_NARUCI_KORPU = "api/korpa/naruci/";
        public const string POST_KOMENTAR_SALATA = "api/narudzbe/komentar/";
        public const string GET_KOMENTAR = "api/narudzbe/komentar/";
    }
}