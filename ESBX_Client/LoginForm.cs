using ESBX_API.Helper;
using ESBX_Client;
using ESBX_Client.Util;
using ESBX_db.Models;
using ESBX_db.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExpressSaladBarDesktop_Client
{
    public partial class frmLogin : Form
    {
        private readonly WebAPIHelper _accountService = new WebAPIHelper(WebApiRoutes.URL_ROUTE, WebApiRoutes.LOGIN_ROUTE);

        public frmLogin()
        {
            InitializeComponent();
            AutoValidate = AutoValidate.Disable;
        }

        private void btnLoginPrijava_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                Cursor.Current = Cursors.WaitCursor;

                AccountLoginVm account = new AccountLoginVm
                {
                    UserName = txtLoginUsername.Text,
                    Lozinka = txtLoginPassword.Text
                };

                HttpResponseMessage response = _accountService.PostResponse(account);

                if (response.IsSuccessStatusCode)
                {
                    DialogResult = DialogResult.OK;
                    Global.prijavljeniKorisnik = response.Content.ReadAsAsync<Korisnici>().Result;
                    Close();
                }
                else
                {
                    switch (response.StatusCode)
                    {
                        case HttpStatusCode.Unauthorized:
                            MessageBox.Show(Messages.login_password_incorrect);
                            break;
                        default:
                            MessageBox.Show("Error code: " + response.StatusCode);
                            break;
                    }
                }
            }
        }

        private void txtLoginUsername_Validating(object sender, CancelEventArgs e)
        {
            string validation = null;
            if (String.IsNullOrEmpty(txtLoginUsername.Text))
                validation = "login_username_req";
            if (txtLoginUsername.Text.Length <= 3)
                validation = "login_username_length";

            if (!String.IsNullOrEmpty(validation))
            {
                e.Cancel = true;
                errProviderLogin.SetError(txtLoginUsername, Messages.ResourceManager.GetString(validation));
            }
        }

        private void txtLoginPassword_Validating(object sender, CancelEventArgs e)
        {
            string validation = null;
            if (String.IsNullOrEmpty(txtLoginPassword.Text))
                validation = "login_password_req";
            if (txtLoginUsername.Text.Length <= 3)
                validation = "login_password_length";

            if (!String.IsNullOrEmpty(validation))
            {
                e.Cancel = true;
                errProviderLogin.SetError(txtLoginPassword, Messages.ResourceManager.GetString(validation));
            }
        }
    }
}
