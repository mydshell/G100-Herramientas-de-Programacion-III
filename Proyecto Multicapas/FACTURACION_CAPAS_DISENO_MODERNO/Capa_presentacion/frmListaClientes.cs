using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Pantallas_Sistema_facturación
{
    public partial class FrmListaClientes : Form
    {
        private readonly Cls_Gestion_Negocio _accesoDatos = new Cls_Gestion_Negocio();
        private readonly BindingSource _bsClientes = new BindingSource();
        private bool _cargado;

        public FrmListaClientes()
        {
            InitializeComponent();
        }

        private void LblTitulo_Click(object sender, EventArgs e)
        {
        }

        private void FrmListaClientes_Load(object sender, EventArgs e)
        {
            if (_cargado) return;
            _cargado = true;

            dgClientes.AutoGenerateColumns = false;
            dgClientes.Columns["Id_Cliente"].DataPropertyName = "IdCliente";
            dgClientes.Columns["strCliente"].DataPropertyName = "NombreCliente";
            dgClientes.Columns["strDocumento"].DataPropertyName = "Documento";
            dgClientes.Columns["strTelefono"].DataPropertyName = "Telefono";

            CargarClientes();
        }

        private void CargarClientes()
        {
            try
            {
                var filtro = (txtBuscar?.Text ?? string.Empty).Trim();
                var tabla = _accesoDatos.ListarClientes(filtro);
                _bsClientes.DataSource = tabla;
                dgClientes.DataSource = _bsClientes;
                dgClientes.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No fue posible consultar clientes.\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            if (!_cargado) return;
            CargarClientes();
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            using (var frm = new frmEditarCliente())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    CargarClientes();
                }
            }
        }

        private void DgClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            var colName = dgClientes.Columns[e.ColumnIndex].Name;
            var valorId = dgClientes.Rows[e.RowIndex].Cells["Id_Cliente"].Value;
            if (valorId == null) return;

            int idCliente;
            if (!int.TryParse(valorId.ToString(), out idCliente) || idCliente <= 0)
            {
                MessageBox.Show("No se pudo identificar el cliente seleccionado.");
                return;
            }

            if (colName == "btnBorrar")
            {
                if (MessageBox.Show(
                    "¿Está seguro de eliminar este cliente?",
                    "Confirmación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    return;
                }

                try
                {
                    var filas = _accesoDatos.EliminarCliente(idCliente);
                    MessageBox.Show(filas > 0 ? "Cliente eliminado." : "No se eliminó ningún registro.");
                    CargarClientes();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "No fue posible eliminar el cliente.\n" + ex.Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }

                return;
            }

            if (colName == "btnEditar")
            {
                using (var frm = new frmEditarCliente(idCliente))
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        CargarClientes();
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


