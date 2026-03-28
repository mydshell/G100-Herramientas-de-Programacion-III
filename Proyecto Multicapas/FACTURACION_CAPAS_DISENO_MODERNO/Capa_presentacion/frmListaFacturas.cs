using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Pantallas_Sistema_facturación
{
    public partial class frmListaFacturas : Form
    {
        private readonly Cls_Gestion_Negocio _accesoDatos = new Cls_Gestion_Negocio();
        private readonly BindingSource _bsFacturas = new BindingSource();
        private bool _cargado;

        public frmListaFacturas()
        {
            InitializeComponent();
        }

        private void frmListaFacturas_Load(object sender, EventArgs e)
        {
            if (_cargado) return;
            _cargado = true;

            dgFacturas.AutoGenerateColumns = false;
            dgFacturas.Columns["Id_Factura"].DataPropertyName = "IdFactura";
            dgFacturas.Columns["strCliente"].DataPropertyName = "ClienteNombreActual";
            dgFacturas.Columns["strNumeroFactura"].DataPropertyName = "NumeroFactura";
            dgFacturas.Columns["strEstadoFactura"].DataPropertyName = "EstadoFactura";
            dgFacturas.Columns["strEmpleado"].DataPropertyName = "EmpleadoNombreActual";
            dgFacturas.Columns["strTotal"].DataPropertyName = "TotalFacturaMostrar";
            dgFacturas.Columns["strIva"].DataPropertyName = "TotalIvaMostrar";
            dgFacturas.Columns["strDescuento"].DataPropertyName = "DescuentoMostrar";

            CargarFacturas();
        }

        private void CargarFacturas()
        {
            try
            {
                var filtro = (txtBuscar?.Text ?? string.Empty).Trim();
                var tabla = _accesoDatos.ListarFacturas(filtro);
                _bsFacturas.DataSource = tabla;
                dgFacturas.DataSource = _bsFacturas;
                dgFacturas.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No fue posible consultar facturas.\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            using (var frm = new frmEditarFactura())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    CargarFacturas();
                }
            }
        }

        private void dgFacturas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            var rowView = dgFacturas.Rows[e.RowIndex].DataBoundItem as DataRowView;
            if (rowView == null) return;

            int idFactura;
            if (!int.TryParse(Convert.ToString(rowView["IdFactura"]), out idFactura) || idFactura <= 0)
            {
                MessageBox.Show("No se pudo identificar la factura seleccionada.");
                return;
            }

            var colName = dgFacturas.Columns[e.ColumnIndex].Name;
            if (colName == "btnBorrar")
            {
                if (MessageBox.Show(
                    "¿Está seguro de eliminar esta factura?",
                    "Confirmación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    return;
                }

                try
                {
                    var filas = _accesoDatos.EliminarFactura(idFactura);
                    MessageBox.Show(filas > 0 ? "Factura eliminada." : "No se eliminó ningún registro.");
                    CargarFacturas();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "No fue posible eliminar la factura.\n" + ex.Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }

                return;
            }

            if (colName == "btnEditar")
            {
                using (var frm = new frmEditarFactura(idFactura))
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        CargarFacturas();
                    }
                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (!_cargado) return;
            CargarFacturas();
        }

        private void btnSalir_Click(object sender, EventArgs e)
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

            Close();
        }
    }
}


