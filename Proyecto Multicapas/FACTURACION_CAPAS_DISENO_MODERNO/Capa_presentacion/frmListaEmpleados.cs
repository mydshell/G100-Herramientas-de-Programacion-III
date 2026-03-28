using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Pantallas_Sistema_facturación
{
    public partial class frmListaEmpleados : Form
    {
        private readonly Cls_Gestion_Negocio _accesoDatos = new Cls_Gestion_Negocio();
        private readonly BindingSource _bsEmpleados = new BindingSource();
        private bool _cargado;

        public frmListaEmpleados()
        {
            InitializeComponent();
        }

        private void frmListaEmpleados_Load(object sender, EventArgs e)
        {
            if (_cargado) return;
            _cargado = true;

            dgEmpleados.AutoGenerateColumns = false;
            dgEmpleados.Columns["Id_Empleado"].DataPropertyName = "IdEmpleado";
            dgEmpleados.Columns["strEmpleado"].DataPropertyName = "NombreEmpleado";
            dgEmpleados.Columns["strDocumento"].DataPropertyName = "Documento";
            dgEmpleados.Columns["strTelefono"].DataPropertyName = "Telefono";

            CargarEmpleados();
        }

        private void CargarEmpleados()
        {
            try
            {
                var filtro = (txtBuscar?.Text ?? string.Empty).Trim();
                var tabla = _accesoDatos.ListarEmpleados(filtro);
                _bsEmpleados.DataSource = tabla;
                dgEmpleados.DataSource = _bsEmpleados;
                dgEmpleados.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No fue posible consultar empleados.\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            using (var frm = new frmEditarEmpleado())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    CargarEmpleados();
                }
            }
        }

        private void dgEmpleados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            var rowView = dgEmpleados.Rows[e.RowIndex].DataBoundItem as DataRowView;
            if (rowView == null) return;

            int idEmpleado;
            if (!int.TryParse(Convert.ToString(rowView["IdEmpleado"]), out idEmpleado) || idEmpleado <= 0)
            {
                MessageBox.Show("No se pudo identificar el empleado seleccionado.");
                return;
            }

            var colName = dgEmpleados.Columns[e.ColumnIndex].Name;
            if (colName == "btnBorrar")
            {
                if (MessageBox.Show(
                    "¿Está seguro de eliminar este empleado?",
                    "Confirmación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    return;
                }

                try
                {
                    var filas = _accesoDatos.EliminarEmpleado(idEmpleado);
                    MessageBox.Show(filas > 0 ? "Empleado eliminado." : "No se eliminó ningún registro.");
                    CargarEmpleados();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "No fue posible eliminar el empleado.\n" + ex.Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }

                return;
            }

            if (colName == "btnEditar")
            {
                using (var frm = new frmEditarEmpleado(idEmpleado))
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        CargarEmpleados();
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

        private void lblTitulo_Click(object sender, EventArgs e)
        {
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (!_cargado) return;
            CargarEmpleados();
        }
    }
}


