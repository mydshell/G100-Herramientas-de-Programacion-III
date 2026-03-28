using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Pantallas_Sistema_facturación
{
    public partial class frmListaProductos : Form
    {
        private readonly Cls_Gestion_Negocio _accesoDatos = new Cls_Gestion_Negocio();
        private readonly BindingSource _bsProductos = new BindingSource();
        private bool _cargado;

        public frmListaProductos()
        {
            InitializeComponent();
        }

        private void frmListaProductos_Load(object sender, EventArgs e)
        {
            if (_cargado) return;
            _cargado = true;

            dgProductos.AutoGenerateColumns = false;
            dgProductos.Columns["Id_Producto"].DataPropertyName = "IdProducto";
            dgProductos.Columns["strProducto"].DataPropertyName = "NombreProducto";
            dgProductos.Columns["strCodigo"].DataPropertyName = "Codigo";
            dgProductos.Columns["strCategoria"].DataPropertyName = "Categoria";
            dgProductos.Columns["strPrecioCompra"].DataPropertyName = "PrecioCompra";
            dgProductos.Columns["strPrecioVenta"].DataPropertyName = "PrecioVenta";
            dgProductos.Columns["strStock"].DataPropertyName = "Stock";

            CargarProductos();
        }

        private void CargarProductos()
        {
            try
            {
                var filtro = (txtBuscar?.Text ?? string.Empty).Trim();
                var tabla = _accesoDatos.ListarProductos(filtro);
                _bsProductos.DataSource = tabla;
                dgProductos.DataSource = _bsProductos;
                dgProductos.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No fue posible consultar productos.\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (!_cargado) return;
            CargarProductos();
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnBuscar_Click(sender, EventArgs.Empty);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            using (var frm = new frmEditarProducto())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    CargarProductos();
                }
            }
        }

        private void dgProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            var rowView = dgProductos.Rows[e.RowIndex].DataBoundItem as DataRowView;
            if (rowView == null) return;

            int idProducto;
            if (!int.TryParse(Convert.ToString(rowView["IdProducto"]), out idProducto) || idProducto <= 0)
            {
                MessageBox.Show("No se pudo identificar el producto seleccionado.");
                return;
            }

            var colName = dgProductos.Columns[e.ColumnIndex].Name;
            if (colName == "btnBorrar")
            {
                if (MessageBox.Show(
                    "¿Está seguro de eliminar este producto?",
                    "Confirmación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    return;
                }

                try
                {
                    var filas = _accesoDatos.EliminarProducto(idProducto);
                    MessageBox.Show(filas > 0 ? "Producto eliminado." : "No se eliminó ningún registro.");
                    CargarProductos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "No fue posible eliminar el producto.\n" + ex.Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }

                return;
            }

            if (colName == "btnEditar")
            {
                using (var frm = new frmEditarProducto(idProducto))
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        CargarProductos();
                    }
                }
            }
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


