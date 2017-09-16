using ESBX_API.Helper;
using ESBX_Client.Util;
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

namespace ESBX_Client.Menadzer
{
    public partial class OsobljePrikazForm : Form
    {
        private WebAPIHelper KorisniciService = new WebAPIHelper(WebApiRoutes.URL_ROUTE, "api/Korisnici");
        private WebAPIHelper OsobljeService = new WebAPIHelper(WebApiRoutes.URL_ROUTE, "api/Osoblje");

        public OsobljePrikazForm()
        {
            InitializeComponent();
        }

        private void DodajUposlenikBtn_Click(object sender, EventArgs e)
        {
            AddOsobljeForm f = new AddOsobljeForm();
            f.ShowDialog();
        }

        private void TraziBtn_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        private void BindGrid()
        {
            HttpResponseMessage response = KorisniciService.GetActionResponse("SearchKorisnici", PretragaImePtxt.Text.Trim());
            if (response.IsSuccessStatusCode)
            {
                List<Korisnici_OsobljeResult> korisnici = response.Content.ReadAsAsync<List<Korisnici_OsobljeResult>>().Result;
                KorisniciGrid.DataSource = korisnici;
             


            }
            else
            {
                MessageBox.Show("Error Code" + response.StatusCode + " : Message - " + response.ReasonPhrase);

            }
         
        }

        private void KorisniciGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
                
                    int id = Convert.ToInt32(KorisniciGrid.Rows[e.RowIndex].Cells[0].Value);
                HttpResponseMessage response = KorisniciService.GetResponse(id);
                Korisnici k = response.Content.ReadAsAsync<Korisnici>().Result;

                //Put response nije dobar 
                HttpResponseMessage responseTwo = OsobljeService.PutResponse(k.Id, k);
                if (responseTwo.IsSuccessStatusCode)
                {
                    MessageBox.Show("Uspješno ste izmjenili aktivnost korisnika.");

                }
                else
                {
                    MessageBox.Show("Promjena aktivnosti korisnika nije uspjela.");
                }

              

        }

        private void OsobljePrikazForm_Load(object sender, EventArgs e)
        {

        }
    }
}
