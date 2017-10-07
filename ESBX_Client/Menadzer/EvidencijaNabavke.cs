using ESBX_db.Models;
using ESBX_db.ViewModel;
using ESBX_Client.Util;
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
using ExpressSaladBarDesktop_Client;
using ESBX_API.Helper;
using ESBX_Client.Util.ViewModel;
using ESBX_Client.Reports;

namespace ESBX_Client.Menadzer
{
    public partial class EvidencijaNabavke : Form
    {
        private WebAPIHelper DobavljaciService = new WebAPIHelper(WebApiRoutes.URL_ROUTE, "api/Dobavljaci");
        private WebAPIHelper SastojciService = new WebAPIHelper(WebApiRoutes.URL_ROUTE, "api/Sastojci");
        private WebAPIHelper UlazZalihaService = new WebAPIHelper(WebApiRoutes.URL_ROUTE, "api/UlazZaliha");
        private WebAPIHelper _service = new WebAPIHelper(WebApiRoutes.URL_ROUTE, WebApiRoutes.GET_SASTOJCI);

        private readonly List<IstekZalihaVm> _istek = null;

        List<StavkaUlaza> stavkeUlaza = new List<StavkaUlaza>();
        private UlazZaliha ulazZaliha = new UlazZaliha();

        public EvidencijaNabavke(List<IstekZalihaVm> istekZaliha = null)
        {
         
            InitializeComponent();
            if (istekZaliha == null)
            {
                List<SastojciPregledVm> listSastojaka = _service.GetResponse().Content.ReadAsAsync<List<SastojciPregledVm>>().Result;

                _istek = listSastojaka.Where(sastojak => sastojak.Stanje < 1000)
                    .Select(x => new IstekZalihaVm
                    {
                        Naziv = x.Naziv,
                        Stanje = x.Stanje,
                        SastojakId = x.Id,
                        VrstaSastojka = x.VrstaSastojka
                    }).ToList();
            }
            else
            {
                _istek = istekZaliha;
            }

            if (_istek == null)
                grpPregledIsteka.Visible = false;
            else
                grpPregledIsteka.Visible = true; 

            SastojciGrid.AutoGenerateColumns = false;
            this.AutoValidate = AutoValidate.Disable;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
            Cursor.Current = Cursors.WaitCursor;
            if (stavkeUlaza.Count() != 0)
            {
                if (Convert.ToInt32(DobavljacCmb.SelectedValue) != 0)
                {
                    ulazZaliha.Datum = DateTime.Now;
                    ulazZaliha.Napomena = NapomenaTxt.Text;
                    ulazZaliha.DobavljaciId = Convert.ToInt32(DobavljacCmb.SelectedValue);

                    ulazZaliha.StavkaUlaza = stavkeUlaza;
                    HttpResponseMessage response = UlazZalihaService.PostResponse(ulazZaliha);
                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Uspješno ste unijeli podatke o nabavci.");
                    }
                }
                else
                {
                    errorProvider.SetError(DobavljacCmb, Messages.dobvaljaci_req);
                }
                
            }
            else
            {
                MessageBox.Show("Nije moguće izvršiti evidenciju nabavke jer niste evidentirali nabavljene sastojke.");
            }
        }

        private void EvidencijaNabavke_Load(object sender, EventArgs e)
        {
            pickerDate.MaxDate = DateTime.Now;
            pickerDate.Text = DateTime.Now.ToString();
            BindSastojci();
            BindDobavljaci();
        }

        private void BindDobavljaci()
        {
            HttpResponseMessage response = DobavljaciService.GetResponse();

            if (response.IsSuccessStatusCode)
            {
                List<Dobavljaci> dob= response.Content.ReadAsAsync<List<Dobavljaci>>().Result;
                //Insert jer add dodaje na kraj
                dob.Insert(0, new Dobavljaci() { Naziv = "Odaberite dobavljaca" });
                DobavljacCmb.DataSource = dob;
                DobavljacCmb.DisplayMember = "Naziv";
                DobavljacCmb.ValueMember = "Id";
            }
        }

        private void BindSastojci()
        {
            HttpResponseMessage response = SastojciService.GetResponse();

            if (response.IsSuccessStatusCode)
            {
                List<SastojciPregledVm> lst  = response.Content.ReadAsAsync<List<SastojciPregledVm>>().Result;
                //Insert jer add dodaje na kraj
                lst.Insert(0, new SastojciPregledVm() { Naziv="Odaberite sastojak"});
                SastojakCmb.DataSource = lst;
                SastojakCmb.DisplayMember = "Naziv";
                SastojakCmb.ValueMember = "Id";
            }
        }


        private void RefreshGrid()
        {
            List<SastojciForGridVM> sourceList = new List<SastojciForGridVM>();
            foreach (var i in stavkeUlaza)
            {
                SastojciForGridVM m = new SastojciForGridVM();
                m.SastojakId = i.SastojakId;
                m.Cijena = i.Cijena;
                m.Kolicina = i.Kolicina;
                m.Naziv = i.Sastojak.Naziv;
                sourceList.Add(m);
            }
            SastojciGrid.DataSource = null;
            SastojciGrid.DataSource = sourceList;
        }
       

        private void DodajBtn_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
            if (this.ValidateChildren())
            {

                string broj = Convert.ToString(SastojakCmb.SelectedValue);
                foreach (var i in stavkeUlaza)
                {
                    if (i.SastojakId == Convert.ToInt32(broj))
                    {
                        i.Kolicina = Convert.ToInt32(KolicinaTxt.Text);
                        i.Cijena = (float)Convert.ToDouble(CijenaTxt.Text);
                        RefreshGrid();
                        MessageBox.Show("Uspješno ste izmjenili podatke o naručenom sastojku.");
                        
                        return;
                    }
                }
                HttpResponseMessage responses = SastojciService.GetActionResponse("GetSastojak", broj);
                if (responses.IsSuccessStatusCode)
                {

                    StavkaUlaza s = new StavkaUlaza();
                    SastojciPregledVm sastojak = responses.Content.ReadAsAsync<SastojciPregledVm>().Result;
                    s.SastojakId = sastojak.Id;
                    s.Sastojak = new Sastojci
                    {
                        Naziv = sastojak.Naziv
                    };
                    s.Kolicina = Convert.ToInt32(KolicinaTxt.Text);
                    s.Cijena = (float)Convert.ToDouble(CijenaTxt.Text);
                    stavkeUlaza.Add(s);
                    RefreshGrid();
                }
                
                else
                    MessageBox.Show("Došlo je do greške");
            }
        }
        

        private void SastojakCmb_Validating(object sender, CancelEventArgs e)
        {
            if (Convert.ToInt32(SastojakCmb.SelectedValue) == 0)
            {
                e.Cancel = true;
                errorProvider.SetError(SastojakCmb, Messages.sastojak_req);
            }

        }

        private void KolicinaTxt_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(KolicinaTxt.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(KolicinaTxt, Messages.kolicina_req);
            }
        }

        private void CijenaTxt_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(CijenaTxt.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(CijenaTxt, Messages.cijena_req);
            }
        }

        private void btnPomocIzvjestaj_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            FormaIstekZaliha frm = new FormaIstekZaliha(_istek);
            frm.ShowDialog();
        }
    }
}
