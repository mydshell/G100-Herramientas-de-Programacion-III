using MaterialSkin.Controls;
using System;
using System.Windows.Forms;

namespace Pantallas_Sistema_facturación
{
    public partial class frmEditarRolEmpleado : MaterialForm
    {
        private readonly Cls_Gestion_Negocio _accesoDatos = new Cls_Gestion_Negocio();
        private readonly int _idRol;

        public frmEditarRolEmpleado() : this(0)
        {
        }

        public frmEditarRolEmpleado(int idRol)
        {
            InitializeComponent();
            _idRol = idRol;
            Load += frmEditarRolEmpleado_Load;
        }

        private void frmEditarRolEmpleado_Load(object sender, EventArgs e)
        {
            if (_idRol <= 0)
            {
                btnActualizar.Text = "GUARDAR";
                Text = "Nuevo Rol";
                txtIdRol.Text = "0";
                txtNombreRol.Text = string.Empty;
                txtDetallesRol.Text = string.Empty;
                return;
            }

            btnActualizar.Text = "ACTUALIZAR";
            Text = "Actualizar Rol";
            CargarRol();
        }

        private void CargarRol()
        {
            try
            {
                var rol = _accesoDatos.ObtenerRolPorId(_idRol);
                if (rol == null)
                {
                    MessageBox.Show(
                        "No se encontró el rol seleccionado.",
                        "Aviso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    DialogResult = DialogResult.Cancel;
                    Close();
                    return;
                }

                txtIdRol.Text = rol.IdRolEmpleado.ToString();
                txtNombreRol.Text = rol.NombreRol ?? string.Empty;
                txtDetallesRol.Text = rol.DetallesRol ?? string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No fue posible cargar el rol.\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                DialogResult = DialogResult.Cancel;
                Close();
            }
        }

        private bool ValidarCampos()
        {
            errorProvider1.Clear();
            var ok = true;

            if (string.IsNullOrWhiteSpace(txtNombreRol.Text))
            {
                errorProvider1.SetError(txtNombreRol, "El nombre del rol es obligatorio.");
                ok = false;
            }

            return ok;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            var entidad = new RolEmpleado
            {
                IdRolEmpleado = _idRol,
                NombreRol = txtNombreRol.Text.Trim(),
                DetallesRol = (txtDetallesRol?.Text ?? string.Empty).Trim()
            };

            try
            {
                var filas = _accesoDatos.GuardarRol(entidad, Environment.UserName);
                if (filas > 0)
                {
                    DialogResult = DialogResult.OK;
                    Close();
                    return;
                }

                MessageBox.Show("No se guardó información del rol.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No fue posible guardar el rol.\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void txtNombreRol_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtNombreRol, string.Empty);
        }
    }
}


