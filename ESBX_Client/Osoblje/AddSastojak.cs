using ESBX_API.Helper;
using ESBX_Client.Util;
using ESBX_db.Models;
using ESBX_db.ViewModel;
using ExpressSaladBarDesktop_Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using ESBX_db.Helper;

namespace ESBX_Client.Osoblje
{
    public partial class frmUnosSastojka : Form
    {
        WebAPIHelper _sastojci = new WebAPIHelper(WebApiRoutes.URL_ROUTE, WebApiRoutes.POST_SASTOJCI);
        private SastojciPostWithImage noviSastojak;

        public frmUnosSastojka()
        {
            noviSastojak = new SastojciPostWithImage();
            InitializeComponent();
            // this.AutoValidate = AutoValidate.Disable;
        }

        private void AddSastojak_Load(object sender, EventArgs e)
        {
            HttpResponseMessage response = _sastojci.GetCustomRouteResponse(WebApiRoutes.GET_VRSTE_SASTOJAKA);

            if (response.IsSuccessStatusCode)
            {
                List<VrstaSastojka> vrsteSastojaka = response.Content.ReadAsAsync<List<VrstaSastojka>>().Result;
                cmbAddSasVrsta.DataSource = vrsteSastojaka;
                cmbAddSasVrsta.DisplayMember = "Naziv";
                cmbAddSasVrsta.ValueMember = "Id";
            }
            else
            {
                MessageBox.Show("Error code: ", response.StatusCode + "Message: " + response.ReasonPhrase);
            }
        }

        private void btnAddSasSacuvaj_Click(object sender, EventArgs e)
        {

                if (!txtAddSasKalorije.Text.All(char.IsDigit) &&
                !txtAddSasKalorije.Text.All(char.IsDigit) &&
                !txtAddSasKalorije.Text.All(char.IsDigit))
                {
                    MessageBox.Show("Polja kao sto su cijena, gramaza i kalorije, moraju biti brojevi samo!", "Upozorenje!");
                }
                else
                {
                    noviSastojak.Naziv = txtAddSasNaziv.Text;
                    noviSastojak.Cijena = (float)Convert.ToDecimal(txtAddSasCijena.Text);
                    noviSastojak.Gramaza = (float)Convert.ToDecimal(txtAddSasGramaza.Text);
                    noviSastojak.BrojKalorija = (float)Convert.ToDecimal(txtAddSasKalorije.Text);
                    noviSastojak.IsDeleted = false;
                    noviSastojak.Napomena = txtAddSasNapomena.Text;
                    noviSastojak.VrstaSastojkaId = Convert.ToInt32(cmbAddSasVrsta.SelectedValue);

                    HttpResponseMessage response = _sastojci.PostResponse(noviSastojak);

                    if (response.IsSuccessStatusCode)
                    {
                        DialogResult = DialogResult.OK;
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Error: " + response.StatusCode);
                    }
            }
        }

        

        private void txtAddSasNaziv_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtAddSasNaziv.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(txtAddSasNaziv, Messages.naziv_sastojak_req);
            }
            else
            {
                errorProvider.SetError(txtAddSasNaziv, null);
            }
        }

        private void btnName_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtInputImage.Text = openFileDialog.FileName;

                Image orginalImage = Image.FromFile(openFileDialog.FileName);
                MemoryStream ms = new MemoryStream();

                orginalImage.Save(ms, ImageFormat.Jpeg);

                // ovo je u bytovima  
                noviSastojak.Slika = ms.ToArray();
                int resizedImageWidth = Convert.ToInt32(ConfigurationManager.AppSettings["resizedImageWidth"]);
                int resizedImageHeight = Convert.ToInt32(ConfigurationManager.AppSettings["resizedImageHeight"]);
                int cropedImageWidth = Convert.ToInt32(ConfigurationManager.AppSettings["cropedImageWidth"]);
                int cropedImageHeight = Convert.ToInt32(ConfigurationManager.AppSettings["cropedImageHeight"]);

                if (orginalImage.Width > resizedImageWidth)
                {
                    Image resizedImage = Util.UIHelper.ResizeImage(orginalImage, new Size(resizedImageHeight, resizedImageHeight));
                    Image croppedImage = resizedImage;

                    if (resizedImage.Width >= cropedImageWidth && resizedImage.Height >= cropedImageHeight)
                    {
                        int croppedXPosition = (resizedImageWidth - cropedImageWidth) / 2;
                        int croppedYPosition = (resizedImageHeight - cropedImageHeight) / 2;

                        croppedImage = Util.UIHelper.CropImage(resizedImage, new Rectangle(croppedXPosition, croppedYPosition, cropedImageWidth, cropedImageHeight));

                        if (croppedImage != null)
                        {
                            ms = new MemoryStream();
                            croppedImage.Save(ms, ImageFormat.Jpeg);
                            noviSastojak.Slika = ms.ToArray();

                            imgBox.Image = croppedImage;
                        }
                        else
                        {
                            MessageBox.Show("Slika nije validnog formata, podrzani format je .jpg!", "Upozorenje!");
                        }
                    }
                }
                else
                {
                    imgBox.Image = orginalImage;
                }

            }
        }

      
    }
}
