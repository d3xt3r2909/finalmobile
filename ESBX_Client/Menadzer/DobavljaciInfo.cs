using ESBX_db.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ESBX_Client.Menadzer
{
    public partial class DobavljaciInfo : Form
    {
        private PregledDobavljaciForDg stavka = null;
        public DobavljaciInfo(PregledDobavljaciForDg stavka)
        {
            this.stavka = stavka; 
            InitializeComponent();
        }

        private void DobavljaciInfo_Load(object sender, EventArgs e)
        {
            lblDobavljaciNaziv.Text = stavka.DobavljacNaziv;
            lblDobavljaciAdresa.Text = stavka.DobavljacAdresa;
            lblDobavljaciEmail.Text = stavka.DobavljacEmail;
            lblDobavljaciZiroRacun.Text = stavka.DobavljacRacun;
            lblDobavljaciKontaktTelefon.Text = stavka.DobavljacTelefon;
        }
    }
}
