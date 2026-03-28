using MaterialSkin.Controls;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Pantallas_Sistema_facturación
{
    public partial class frmEditarSeguridad : MaterialForm
    {
        private readonly Cls_Gestion_Negocio _accesoDatos = new Cls_Gestion_Negocio();
        private readonly int _idEmpleadoEdicion;

        public frmEditarSeguridad() : this(0)
        {
        }

        public frmEditarSeguridad(int idEmpleado)
        {
            InitializeComponent();
            _idEmpleadoEdicion = idEmpleado;
        }

        private void frmEditarSeguridad_Load(object sender, EventArgs e)
        {
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;

            CargarEmpleados();

            if (_idEmpleadoEdicion <= 0)
            {
                btnActualizar.Text = "GUARDAR";
                Text = "Nuevo Usuario";
                txtIdSeguridad.Text = "0";
                txtUsuario.Text = string.Empty;
                txtClave.Text = string.Empty;
                return;
            }

            btnActualizar.Text = "ACTUALIZAR";
            Text = "Actualizar Usuario";
            CargarUsuarioEdicion();
        }

        private void CargarEmpleados()
        {
            try
            {
                var dt = _accesoDatos.ListarEmpleadosBasico();
                cmbEmpleado.DataSource = dt;
                cmbEmpleado.DisplayMember = "NombreEmpleado";
                cmbEmpleado.ValueMember = "IdEmpleado";
                cmbEmpleado.DropDownStyle = ComboBoxStyle.DropDownList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No fue posible consultar empleados.\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                DialogResult = DialogResult.Cancel;
                Close();
            }
        }

        private void CargarUsuarioEdicion()
        {
            try
            {
                var usuario = _accesoDatos.ObtenerSeguridadPorEmpleado(_idEmpleadoEdicion);
                if (usuario == null)
                {
                    MessageBox.Show(
                        "No se encontró el usuario seleccionado.",
                        "Aviso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    DialogResult = DialogResult.Cancel;
                    Close();
                    return;
                }

                txtIdSeguridad.Text = usuario.IdSeguridad.ToString();
                txtUsuario.Text = usuario.Usuario ?? string.Empty;
                txtClave.Text = usuario.Clave ?? string.Empty;
                cmbEmpleado.SelectedValue = usuario.IdEmpleado;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No fue posible cargar el usuario.\n" + ex.Message,
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

            if (cmbEmpleado.SelectedItem == null)
            {
                errorProvider1.SetError(cmbEmpleado, "Debe seleccionar un empleado.");
                ok = false;
            }

            if (string.IsNullOrWhiteSpace(txtUsuario.Text))
            {
                errorProvider1.SetError(txtUsuario, "El usuario es obligatorio.");
                ok = false;
            }

            if (string.IsNullOrWhiteSpace(txtClave.Text))
            {
                errorProvider1.SetError(txtClave, "La clave es obligatoria.");
                ok = false;
            }

            if (!ok) return false;

            int idEmpleadoActual = 0;
            int.TryParse(Convert.ToString(cmbEmpleado.SelectedValue), out idEmpleadoActual);

            if (_accesoDatos.ExisteUsuarioSeguridad(txtUsuario.Text.Trim(), idEmpleadoActual))
            {
                errorProvider1.SetError(txtUsuario, "Ese usuario ya existe. Use otro.");
                return false;
            }

            return true;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            int idEmpleado;
            if (!int.TryParse(Convert.ToString(cmbEmpleado.SelectedValue), out idEmpleado) || idEmpleado <= 0)
            {
                MessageBox.Show("Debe seleccionar un empleado válido.");
                return;
            }

            var entidad = new SeguridadUsuario
            {
                IdEmpleado = idEmpleado,
                Usuario = txtUsuario.Text.Trim(),
                Clave = txtClave.Text.Trim()
            };

            try
            {
                var filas = _accesoDatos.GuardarSeguridad(entidad, Environment.UserName);
                if (filas > 0)
                {
                    DialogResult = DialogResult.OK;
                    Close();
                    return;
                }

                MessageBox.Show("No se guardó información del usuario.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No fue posible guardar el usuario.\n" + ex.Message,
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

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {
        }

        private void cmbEmpleado_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(cmbEmpleado, string.Empty);
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtUsuario, string.Empty);
        }

        private void txtClave_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtClave, string.Empty);
        }
    }
}


