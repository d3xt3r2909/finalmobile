using ESBX_API.Helper;
using ESBX_Client.Util;
using ESBX_Client.Util.ViewModel;
using ESBX_db.Models;
using ESBX_db.ViewModel;
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

namespace ESBX_Client.Osoblje
{
    public partial class frmNarudzbe : Form
    {
        WebAPIHelper _service = new WebAPIHelper(WebApiRoutes.URL_ROUTE, WebApiRoutes.GET_OSOBLJE_KORPA);
        List<PregledNarudzbiGridVm> listNarudzbeSource = null; 

        public frmNarudzbe()
        {
            InitializeComponent();
            dgNarudzbe.AutoGenerateColumns = false;
            dgPrikazSalata.AutoGenerateColumns = false;

            List<CmbKorpaVm> sourceCombo = new List<CmbKorpaVm>
            {
                new CmbKorpaVm
                {
                    DisplayVerb = "Aktivne narudžbe",
                    Value = true,
                },
                new CmbKorpaVm
                {
                    DisplayVerb = "Historija narudžbi",
                    Value = false,
                }
            };

            cmbNarudzbeStatus.DataSource = sourceCombo;
            cmbNarudzbeStatus.ValueMember = "Value";
            cmbNarudzbeStatus.DisplayMember = "DisplayVerb";
        }

        private void RefreshState(bool? aktivne = true)
        {
            HttpResponseMessage response = _service.GetCustomRouteResponse(WebApiRoutes.GET_OSOBLJE_KORPA, "0/" + aktivne);
            List<KorpaForDgRow> narudzbe = response.Content.ReadAsAsync<List<KorpaForDgRow>>().Result;

            if (narudzbe != null)
            {
                listNarudzbeSource = narudzbe.GroupBy(item => item.Id)
                    .Select(narudzba => new PregledNarudzbiGridVm
                    {
                        NarudzbaId = narudzba.Key,
                        VrijemeDolaska = narudzba.Select(x => x.VrijemeDolaska).FirstOrDefault(),
                        Korisnik = narudzba.Select(x => x.Korisnik).FirstOrDefault(),
                        Salate = narudzba.Select(x => new SalataItem
                        {
                            CijenaSalate = x.CijenaSalate,
                            DresingSastojak = x.DresingSastojak,
                            GlavniSastojak = x.GlavniSastojak,
                            Kolicina = x.Kolicina,
                            SalataId = x.SalataId,
                            SporedniSastojak = x.SporedniSastojak
                        }).ToList()
                    }).ToList();

                dgNarudzbe.DataSource = listNarudzbeSource;
            }

            // dgNarudzbe.DataSource = narudzbe;

        }

        private void frmNarudzbe_Load(object sender, EventArgs e)
        {
            RefreshState(); 
        }


        private void Filtriraj(object sender, EventArgs e)
        {
            CmbKorpaVm item = (CmbKorpaVm)cmbNarudzbeStatus.SelectedItem;

            if (item.Value)
            {
                dgNarudzbe.Columns["Zavrsena"].Visible = true;
                dgNarudzbe.Columns["Nedolazak"].Visible = true;
            }
            else
            {
                dgNarudzbe.Columns["Zavrsena"].Visible = false;
                dgNarudzbe.Columns["Nedolazak"].Visible = false;
            }

            RefreshState(item.Value);
        }

        private void dgNarudzbe_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string narudzbaId = dgNarudzbe.Rows[e.RowIndex].Cells[0].Value + "";

            switch (e.ColumnIndex)
            {
                case 3:

                    List<SalataItem> salate =
                        listNarudzbeSource.Where(item => item.NarudzbaId.ToString() == narudzbaId)
                                          .Select(x => x.Salate).FirstOrDefault();

                    dgPrikazSalata.DataSource = salate;

                    break;
                case 4:
                    Kupon frm = new Kupon(Convert.ToInt32(narudzbaId));
                    frm.ShowDialog();
                    break;
                case 5:

                    DialogResult result = MessageBox.Show("Da li ste sigurni da zelite oznaciti korisnika nepovjerljivim? Ukoliko je korisnik oznacen kao nepovjerljiv, taj korisnik vise nece moci da narucuje preko korisnickog naloga, sve dok menadzer restorana ne promijeni njegovu povjerljivost! ", "Upozorenje", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        HttpResponseMessage korpaResponse =
                        _service.GetCustomRouteResponse(WebApiRoutes.GET_KORISNICI_KORPA, narudzbaId);

                        KorpaModel korpa = korpaResponse.Content.ReadAsAsync<KorpaModel>().Result;

                        HttpResponseMessage response =
                            _service.PutCustomRouteResponse(WebApiRoutes.PUT_KORISNICI_POVJERLJIVOST, new PromjenaPovjerljivostiVm
                            {
                                KorisnikId = korpa.KorisnikId,
                                KorpaId = korpa.Id,
                                Status = false
                            });

                        if (response.IsSuccessStatusCode)
                            RefreshState();
                    }

                    break;

                default:
                    break;
            }

        }

        private void grpPregledIsteka_Enter(object sender, EventArgs e)
        {
            frmHelpDialog frm = new frmHelpDialog();
            frm.ShowDialog(); 

        }

        private void label6_Click(object sender, EventArgs e)
        {
            frmHelpDialog frm = new frmHelpDialog();
            frm.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            frmHelpDialog frm = new frmHelpDialog();
            frm.ShowDialog();
        }
    }
}
