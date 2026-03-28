using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pantallas_Sistema_facturación
{
    public partial class frmListaAyuda : Form
    {
        public frmListaAyuda()
        {
            InitializeComponent();
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void frmListaAyuda_Load(object sender, EventArgs e)
        {
            // Se esconden los errores de javascript en el WebBrowser porque la pagina de microsoft usa codigo que no es compatible con el WebBroswer renderizador
            webBrowserAyuda.ScriptErrorsSuppressed = true;
            webBrowserAyuda.Navigate("https://support.microsoft.com/es-es");
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            var principal = Application.OpenForms.OfType<FrmPrincipal>().FirstOrDefault();
            if (principal != null)
            {
                principal.Close();
            }
            else
            {
                var login = Application.OpenForms.OfType<FrmLogin>().FirstOrDefault();
                if (login == null) login = new FrmLogin();
                login.Show();
                login.BringToFront();
                login.Activate();
            }

            this.Close();
        }
    }
}
