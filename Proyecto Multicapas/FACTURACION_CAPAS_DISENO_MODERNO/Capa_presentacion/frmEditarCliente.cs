using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MaterialSkin.Controls;

namespace Pantallas_Sistema_facturación
{
    public partial class frmEditarCliente : MaterialForm
    {
        private readonly Cls_Gestion_Negocio _accesoDatos = new Cls_Gestion_Negocio();
        private readonly int _idCliente;

        public frmEditarCliente() : this(0)
        {
        }

        public frmEditarCliente(int idCliente)
        {
            InitializeComponent();
            _idCliente = idCliente;
        }

        private void frmEditarCliente_Load(object sender, EventArgs e)
        {
            if (_idCliente <= 0)
            {
                lblTitulo.Text = "INGRESO NUEVO CLIENTE";
                txtIdCliente.Text = "0";
                btnActualizar.Text = "GUARDAR";
                Text = "Nuevo Cliente";
                return;
            }

            lblTitulo.Text = "MODIFICAR CLIENTE";
            btnActualizar.Text = "ACTUALIZAR";
            Text = "Actualizar Cliente";
            CargarCliente();
        }

        private void CargarCliente()
        {
            try
            {
                var cliente = _accesoDatos.ObtenerClientePorId(_idCliente);
                if (cliente == null)
                {
                    MessageBox.Show(
                        "No se encontró el cliente seleccionado.",
                        "Aviso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    DialogResult = DialogResult.Cancel;
                    Close();
                    return;
                }

                txtIdCliente.Text = cliente.IdCliente.ToString();
                txtNombreCliente.Text = cliente.NombreCliente ?? string.Empty;
                txtDocumento.Text = cliente.Documento ?? string.Empty;
                txtDireccion.Text = cliente.Direccion ?? string.Empty;
                txtTelefono.Text = cliente.Telefono ?? string.Empty;
                txtEmail.Text = cliente.Email ?? string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No fue posible cargar el cliente.\n" + ex.Message,
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
            var valido = true;

            if (string.IsNullOrWhiteSpace(txtNombreCliente.Text))
            {
                errorProvider1.SetError(txtNombreCliente, "El nombre es obligatorio.");
                valido = false;
            }

            if (string.IsNullOrWhiteSpace(txtDocumento.Text))
            {
                errorProvider1.SetError(txtDocumento, "El documento es obligatorio.");
                valido = false;
            }
            else if (!Regex.IsMatch(txtDocumento.Text.Trim(), @"^\d+$"))
            {
                errorProvider1.SetError(txtDocumento, "El documento debe ser numérico.");
                valido = false;
            }

            if (string.IsNullOrWhiteSpace(txtDireccion.Text))
            {
                errorProvider1.SetError(txtDireccion, "La dirección es obligatoria.");
                valido = false;
            }

            if (string.IsNullOrWhiteSpace(txtTelefono.Text))
            {
                errorProvider1.SetError(txtTelefono, "El teléfono es obligatorio.");
                valido = false;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                errorProvider1.SetError(txtEmail, "El email es obligatorio.");
                valido = false;
            }
            else if (!Regex.IsMatch(txtEmail.Text.Trim(), @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                errorProvider1.SetError(txtEmail, "Email inválido.");
                valido = false;
            }

            return valido;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            var cliente = new Cliente
            {
                IdCliente = _idCliente,
                NombreCliente = txtNombreCliente.Text.Trim(),
                Documento = txtDocumento.Text.Trim(),
                Direccion = txtDireccion.Text.Trim(),
                Telefono = txtTelefono.Text.Trim(),
                Email = txtEmail.Text.Trim()
            };

            try
            {
                var filas = _accesoDatos.GuardarCliente(cliente, Environment.UserName);
                if (filas > 0)
                {
                    DialogResult = DialogResult.OK;
                    Close();
                    return;
                }

                MessageBox.Show("No se guardó información del cliente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No fue posible guardar el cliente.\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void txtNombreCliente_TextChanged(object sender, EventArgs e) => errorProvider1.SetError(txtNombreCliente, string.Empty);
        private void txtDocumento_TextChanged(object sender, EventArgs e) => errorProvider1.SetError(txtDocumento, string.Empty);
        private void txtDireccion_TextChanged(object sender, EventArgs e) => errorProvider1.SetError(txtDireccion, string.Empty);
        private void txtTelefono_TextChanged(object sender, EventArgs e) => errorProvider1.SetError(txtTelefono, string.Empty);
        private void txtEmail_TextChanged(object sender, EventArgs e) => errorProvider1.SetError(txtEmail, string.Empty);

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void txtDocumento_Click(object sender, EventArgs e)
        {
        }
    }
}


