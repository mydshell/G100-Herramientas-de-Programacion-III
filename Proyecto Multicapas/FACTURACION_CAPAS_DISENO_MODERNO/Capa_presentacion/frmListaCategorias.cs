using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace Pantallas_Sistema_facturación
{
    public partial class frmListaCategorias : Form
    {
        private readonly Cls_Gestion_Negocio _accesoDatos = new Cls_Gestion_Negocio();
        private readonly BindingSource _bsCategorias = new BindingSource();
        private bool _cargado;

        public frmListaCategorias()
        {
            InitializeComponent();
        }

        private void frmListaCategorias_Load(object sender, EventArgs e)
        {
            if (_cargado) return;
            _cargado = true;

            dgCategorias.AutoGenerateColumns = false;
            dgCategorias.Columns["Id_Categoria"].DataPropertyName = "IdCategoria";
            dgCategorias.Columns["strCategoria"].DataPropertyName = "NombreCategoria";

            CargarCategorias();
        }

        private void CargarCategorias()
        {
            try
            {
                var filtro = (txtBuscar?.Text ?? string.Empty).Trim();
                var tabla = _accesoDatos.ListarCategorias(filtro);
                _bsCategorias.DataSource = tabla;
                dgCategorias.DataSource = _bsCategorias;
                dgCategorias.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No fue posible consultar categorías.\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (!_cargado) return;
            CargarCategorias();
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
            using (var frm = new frmEditarCategoriaProducto())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    CargarCategorias();
                }
            }
        }

        private void dgCategorias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            var rowView = dgCategorias.Rows[e.RowIndex].DataBoundItem as DataRowView;
            if (rowView == null) return;

            int idCategoria;
            if (!int.TryParse(Convert.ToString(rowView["IdCategoria"]), out idCategoria) || idCategoria <= 0)
            {
                MessageBox.Show("No se pudo identificar la categoría seleccionada.");
                return;
            }

            var colName = dgCategorias.Columns[e.ColumnIndex].Name;
            if (colName == "btnBorrar")
            {
                var totalProductos = _accesoDatos.ContarProductosPorCategoria(idCategoria);
                if (totalProductos > 0)
                {
                    MessageBox.Show(
                        string.Format(
                            "No se puede eliminar esta categoría porque tiene {0} producto(s) asociado(s). Primero reasigne o elimine esos productos.",
                            totalProductos),
                        "Categoría en uso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                if (MessageBox.Show(
                    "¿Está seguro de eliminar esta categoría?",
                    "Confirmación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    return;
                }

                try
                {
                    var filas = _accesoDatos.EliminarCategoria(idCategoria);
                    MessageBox.Show(filas > 0 ? "Categoría eliminada." : "No se eliminó ningún registro.");
                    CargarCategorias();
                }
                catch (SqlException ex) when (ex.Number == 547)
                {
                    MessageBox.Show(
                        "No se puede eliminar la categoría porque está relacionada con otros registros. Quite esas referencias e intente de nuevo.",
                        "Categoría en uso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "No fue posible eliminar la categoría.\n" + ex.Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }

                return;
            }

            if (colName == "btnEditar")
            {
                using (var frm = new frmEditarCategoriaProducto(idCategoria))
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        CargarCategorias();
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

