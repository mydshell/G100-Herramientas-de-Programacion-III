using MaterialSkin.Controls;
using System;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Pantallas_Sistema_facturación
{
    public partial class frmEditarEmpleado : MaterialForm
    {
        private readonly Cls_Gestion_Negocio _accesoDatos = new Cls_Gestion_Negocio();
        private readonly int _idEmpleado;

        public frmEditarEmpleado() : this(0)
        {
        }

        public frmEditarEmpleado(int idEmpleado)
        {
            InitializeComponent();
            _idEmpleado = idEmpleado;
            Load += frmEditarEmpleado_Load;
        }

        private void frmEditarEmpleado_Load(object sender, EventArgs e)
        {
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;

            CargarRoles();

            if (_idEmpleado <= 0)
            {
                lblTitulo.Text = "INGRESO NUEVO EMPLEADO";
                txtIdEmpleado.Text = "0";
                btnActualizar.Text = "GUARDAR";
                Text = "Nuevo Empleado";
                dtpFechaIngreso.Value = DateTime.Today;
                return;
            }

            lblTitulo.Text = "MODIFICAR EMPLEADO";
            btnActualizar.Text = "ACTUALIZAR";
            Text = "Actualizar Empleado";
            CargarEmpleado();
        }

        private void CargarRoles()
        {
            try
            {
                var dt = _accesoDatos.ListarRolesBasico();
                cmbRolEmpleado.DataSource = dt;
                cmbRolEmpleado.DisplayMember = "NombreRol";
                cmbRolEmpleado.ValueMember = "IdRolEmpleado";
                cmbRolEmpleado.DropDownStyle = ComboBoxStyle.DropDownList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No fue posible cargar roles.\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void CargarEmpleado()
        {
            try
            {
                var empleado = _accesoDatos.ObtenerEmpleadoPorId(_idEmpleado);
                if (empleado == null)
                {
                    MessageBox.Show(
                        "No se encontró el empleado seleccionado.",
                        "Aviso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    DialogResult = DialogResult.Cancel;
                    Close();
                    return;
                }

                txtIdEmpleado.Text = empleado.IdEmpleado.ToString();
                txtNombreEmpleado.Text = empleado.NombreEmpleado ?? string.Empty;
                txtDocumento.Text = empleado.Documento ?? string.Empty;
                txtDireccion.Text = empleado.Direccion ?? string.Empty;
                txtTelefono.Text = empleado.Telefono ?? string.Empty;
                txtEmail.Text = empleado.Email ?? string.Empty;
                txtDatoAdicional.Text = empleado.DatoAdicional ?? string.Empty;
                dtpFechaIngreso.Value = empleado.FechaIngreso == default(DateTime) ? DateTime.Today : empleado.FechaIngreso;
                dtpFechaRetiro.Value = empleado.FechaRetiro ?? DateTime.Today;

                if (empleado.IdRolEmpleado > 0)
                {
                    cmbRolEmpleado.SelectedValue = empleado.IdRolEmpleado;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No fue posible cargar el empleado.\n" + ex.Message,
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

            if (string.IsNullOrWhiteSpace(txtNombreEmpleado.Text))
            {
                errorProvider1.SetError(txtNombreEmpleado, "El nombre es obligatorio.");
                ok = false;
            }

            if (!Regex.IsMatch((txtDocumento.Text ?? string.Empty).Trim(), @"^\d+$"))
            {
                errorProvider1.SetError(txtDocumento, "El documento debe ser numérico.");
                ok = false;
            }

            if (cmbRolEmpleado.SelectedValue == null)
            {
                errorProvider1.SetError(cmbRolEmpleado, "Debe seleccionar un rol.");
                ok = false;
            }

            return ok;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            int idRol;
            if (!int.TryParse(Convert.ToString(cmbRolEmpleado.SelectedValue), out idRol) || idRol <= 0)
            {
                MessageBox.Show("Debe seleccionar un rol válido.");
                return;
            }

            var entidad = new Empleado
            {
                IdEmpleado = _idEmpleado,
                NombreEmpleado = txtNombreEmpleado.Text.Trim(),
                Documento = txtDocumento.Text.Trim(),
                Direccion = txtDireccion.Text.Trim(),
                Telefono = txtTelefono.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                IdRolEmpleado = idRol,
                FechaIngreso = dtpFechaIngreso.Value.Date,
                FechaRetiro = dtpFechaRetiro.Value.Date,
                DatoAdicional = txtDatoAdicional.Text.Trim()
            };

            try
            {
                var filas = _accesoDatos.GuardarEmpleado(entidad, Environment.UserName);
                if (filas > 0)
                {
                    DialogResult = DialogResult.OK;
                    Close();
                    return;
                }

                MessageBox.Show("No se guardó información del empleado.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No fue posible guardar el empleado.\n" + ex.Message,
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

        private void txtNombreEmpleado_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtNombreEmpleado, string.Empty);
        }

        private void txtDocumento_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtDocumento, string.Empty);
        }

        private void cmbRolEmpleado_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(cmbRolEmpleado, string.Empty);
        }
    }
}


