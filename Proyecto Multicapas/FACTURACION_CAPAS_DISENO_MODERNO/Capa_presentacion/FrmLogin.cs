using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Pantallas_Sistema_facturación
{
    public partial class FrmLogin : Form
    {
        private readonly Cls_Gestion_Negocio _accesoDatos = new Cls_Gestion_Negocio();

        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnValidar_Click(object sender, EventArgs e)
        {
            var user = (txtUsuario?.Text ?? string.Empty).Trim();
            var pass = (txtPassword?.Text ?? string.Empty).Trim();

            if (string.IsNullOrWhiteSpace(user) || string.IsNullOrWhiteSpace(pass))
            {
                MessageBox.Show(
                    "Debe ingresar usuario y contraseña.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtUsuario.Focus();
                return;
            }

            try
            {
                var empleado = _accesoDatos.ValidarUsuario(user, pass);

                if (!string.IsNullOrWhiteSpace(empleado))
                {
                    var principal = new FrmPrincipal();

                    principal.FormClosed += (s, args) =>
                    {
                        txtUsuario.Clear();
                        txtPassword.Clear();
                        Show();
                        BringToFront();
                        Activate();
                        txtUsuario.Focus();
                    };

                    principal.Show();
                    principal.BringToFront();
                    principal.Activate();
                    Hide();
                    return;
                }

                MessageBox.Show(
                    "Usuario o contraseña incorrectos. Intente nuevamente.",
                    "Error de autenticación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                txtUsuario.Clear();
                txtPassword.Clear();
                txtUsuario.Focus();
            }
            catch (SqlException ex)
            {
                var diagnostico = _accesoDatos.ObtenerDiagnosticoConexion(ex);
                MessageBox.Show(
                    "No fue posible conectar con SQL Server.\n\n" + diagnostico,
                    "Error de conexión",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al validar el usuario.\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void materialLabel1_Click(object sender, EventArgs e)
        {
        }
    }
}



