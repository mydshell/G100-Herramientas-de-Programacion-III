using System;
using System.Globalization;
using System.Windows.Forms;
using MaterialSkin.Controls;

namespace Pantallas_Sistema_facturación
{
    public partial class frmEditarFactura : MaterialForm
    {
        private readonly Cls_Gestion_Negocio _accesoDatos = new Cls_Gestion_Negocio();
        private readonly int _idFactura;

        public frmEditarFactura() : this(0)
        {
        }

        public frmEditarFactura(int idFactura)
        {
            InitializeComponent();
            _idFactura = idFactura;
        }

        private void frmEditarFactura_Load(object sender, EventArgs e)
        {
            CargarClientes();
            CargarEmpleados();
            CargarEstados();

            if (_idFactura <= 0)
            {
                lblTitulo.Text = "INGRESO NUEVA FACTURA";
                btnActualizar.Text = "GUARDAR";
                Text = "Nueva Factura";
                txtIdFactura.Text = "0";
                dtpFechaFactura.Value = DateTime.Today;
                return;
            }

            lblTitulo.Text = "MODIFICAR FACTURA";
            btnActualizar.Text = "ACTUALIZAR";
            Text = "Actualizar Factura";
            CargarFactura();
        }

        private void CargarClientes()
        {
            try
            {
                var dt = _accesoDatos.ListarClientesBasico();
                cmbCliente.DataSource = dt;
                cmbCliente.DisplayMember = "NombreCliente";
                cmbCliente.ValueMember = "IdCliente";
                cmbCliente.DropDownStyle = ComboBoxStyle.DropDownList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No fue posible cargar clientes.\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
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
                    "No fue posible cargar empleados.\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void CargarEstados()
        {
            try
            {
                var dt = _accesoDatos.ListarEstadosFactura();
                cmbEstadoFactura.DataSource = dt;
                cmbEstadoFactura.DisplayMember = "EstadoFactura";
                cmbEstadoFactura.ValueMember = "IdEstado";
                cmbEstadoFactura.DropDownStyle = ComboBoxStyle.DropDownList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No fue posible cargar estados de factura.\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void CargarFactura()
        {
            try
            {
                var factura = _accesoDatos.ObtenerFacturaPorId(_idFactura);
                if (factura == null)
                {
                    MessageBox.Show(
                        "No se encontró la factura seleccionada.",
                        "Aviso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    DialogResult = DialogResult.Cancel;
                    Close();
                    return;
                }

                txtIdFactura.Text = factura.IdFactura.ToString();
                txtNumeroFactura.Text = factura.NumeroFactura ?? string.Empty;
                txtDescuento.Text = factura.Descuento ?? string.Empty;
                txtTotalIva.Text = factura.TotalIva ?? string.Empty;
                txtTotalFactura.Text = factura.TotalFactura ?? string.Empty;
                txtDetallesProducto.Text = factura.DetallesProducto ?? string.Empty;
                dtpFechaFactura.Value = factura.FechaFactura == default(DateTime) ? DateTime.Today : factura.FechaFactura;
                cmbCliente.SelectedValue = factura.IdCliente;
                cmbEmpleado.SelectedValue = factura.IdEmpleado;
                if (factura.IdEstado > 0)
                {
                    cmbEstadoFactura.SelectedValue = factura.IdEstado;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No fue posible cargar la factura.\n" + ex.Message,
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

            if (string.IsNullOrWhiteSpace(txtNumeroFactura.Text))
            {
                errorProvider1.SetError(txtNumeroFactura, "El número de factura es obligatorio.");
                ok = false;
            }

            if (cmbCliente.SelectedValue == null)
            {
                errorProvider1.SetError(cmbCliente, "Debe seleccionar un cliente.");
                ok = false;
            }

            if (cmbEmpleado.SelectedValue == null)
            {
                errorProvider1.SetError(cmbEmpleado, "Debe seleccionar un empleado.");
                ok = false;
            }

            if (cmbEstadoFactura.SelectedValue == null)
            {
                errorProvider1.SetError(cmbEstadoFactura, "Debe seleccionar un estado.");
                ok = false;
            }

            if (!EsDecimal(txtDescuento.Text))
            {
                errorProvider1.SetError(txtDescuento, "Descuento inválido.");
                ok = false;
            }

            if (!EsDecimal(txtTotalIva.Text))
            {
                errorProvider1.SetError(txtTotalIva, "IVA inválido.");
                ok = false;
            }

            if (!EsDecimal(txtTotalFactura.Text))
            {
                errorProvider1.SetError(txtTotalFactura, "Total inválido.");
                ok = false;
            }

            return ok;
        }

        private static bool EsDecimal(string valor)
        {
            decimal parsed;
            return decimal.TryParse((valor ?? string.Empty).Trim(), NumberStyles.Any, CultureInfo.CurrentCulture, out parsed) ||
                   decimal.TryParse((valor ?? string.Empty).Trim(), NumberStyles.Any, CultureInfo.InvariantCulture, out parsed);
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            int idCliente;
            int idEmpleado;
            int idEstado;
            if (!int.TryParse(Convert.ToString(cmbCliente.SelectedValue), out idCliente) || idCliente <= 0 ||
                !int.TryParse(Convert.ToString(cmbEmpleado.SelectedValue), out idEmpleado) || idEmpleado <= 0 ||
                !int.TryParse(Convert.ToString(cmbEstadoFactura.SelectedValue), out idEstado) || idEstado <= 0)
            {
                MessageBox.Show("Debe seleccionar valores válidos para cliente, empleado y estado.");
                return;
            }

            var entidad = new Factura
            {
                IdFactura = _idFactura,
                NumeroFactura = txtNumeroFactura.Text.Trim(),
                IdCliente = idCliente,
                IdEmpleado = idEmpleado,
                FechaFactura = dtpFechaFactura.Value.Date,
                IdEstado = idEstado,
                EstadoFactura = Convert.ToString(cmbEstadoFactura.Text),
                Descuento = txtDescuento.Text.Trim(),
                TotalIva = txtTotalIva.Text.Trim(),
                TotalFactura = txtTotalFactura.Text.Trim(),
                DetallesProducto = txtDetallesProducto.Text.Trim()
            };

            try
            {
                var filas = _accesoDatos.GuardarFactura(entidad, Environment.UserName);
                if (filas > 0)
                {
                    DialogResult = DialogResult.OK;
                    Close();
                    return;
                }

                MessageBox.Show("No se guardó información de la factura.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No fue posible guardar la factura.\n" + ex.Message,
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

        private void txtNumeroFactura_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtNumeroFactura, string.Empty);
        }

        private void cmbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(cmbCliente, string.Empty);
        }

        private void cmbEmpleado_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(cmbEmpleado, string.Empty);
        }

        private void cmbEstadoFactura_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(cmbEstadoFactura, string.Empty);
        }
    }
}


