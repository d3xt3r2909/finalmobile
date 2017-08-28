using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ESBX_db.Models;
using ESBX_Client.Util.ViewModel;
using ESBX_Client.Util;
using ESBX_API.Helper;

namespace ESBX_Client.Menadzer
{
    public partial class IstekZaliha : Form
    {
        private readonly List<IstekZalihaVm> _istek = null;
        private WebAPIHelper _service = new WebAPIHelper(WebApiRoutes.URL_ROUTE, WebApiRoutes.GET_SASTOJCI);
        public IstekZaliha(List<IstekZalihaVm> istekZaliha = null)
        {
            InitializeComponent();

            if (istekZaliha == null)
            {
                List<Sastojci> listSastojaka = _service.GetResponse().Content.ReadAsAsync<List<Sastojci>>().Result;

                _istek = listSastojaka.Where(sastojak => sastojak.Stanje < 1000)
                    .Select(x => new IstekZalihaVm
                    {
                        Naziv = x.Naziv,
                        Stanje = x.Stanje,
                        SastojakId = x.Id,
                        VrstaSastojka = x.VrstaSastojka.Naziv
                    }).ToList();
            }
            else
                _istek = istekZaliha;
        }

        private void IstekZaliha_Load(object sender, EventArgs e)
        {
            dgIstekZaliha.DataSource = _istek; 
        }
    }
}
