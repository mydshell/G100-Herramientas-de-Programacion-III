using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Pantallas_Sistema_facturación
{
    public partial class frmListaSeguridad : Form
    {
        private readonly Cls_Gestion_Negocio _accesoDatos = new Cls_Gestion_Negocio();
        private readonly BindingSource _bsUsuarios = new BindingSource();
        private bool _cargado;

        public frmListaSeguridad()
        {
            InitializeComponent();
        }

        private void frmListaSeguridad_Load(object sender, EventArgs e)
        {
            if (_cargado) return;
            _cargado = true;

            dgSeguridad.AutoGenerateColumns = false;
            dgSeguridad.Columns["Id_Seguridad"].DataPropertyName = "IdSeguridad";
            dgSeguridad.Columns["strUsuario"].DataPropertyName = "Usuario";

            CargarUsuarios();
        }

        private void CargarUsuarios()
        {
            try
            {
                var filtro = (txtBuscar?.Text ?? string.Empty).Trim();
                var tabla = _accesoDatos.ListarSeguridad(filtro);
                _bsUsuarios.DataSource = tabla;
                dgSeguridad.DataSource = _bsUsuarios;
                dgSeguridad.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No fue posible consultar seguridad.\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            using (var frm = new frmEditarSeguridad())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    CargarUsuarios();
                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (!_cargado) return;
            CargarUsuarios();
        }

        private void dgSeguridad_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            var rowView = dgSeguridad.Rows[e.RowIndex].DataBoundItem as DataRowView;
            if (rowView == null) return;

            int idEmpleado;
            if (!int.TryParse(Convert.ToString(rowView["IdEmpleado"]), out idEmpleado) || idEmpleado <= 0)
            {
                MessageBox.Show("No se pudo identificar el empleado asociado al usuario.");
                return;
            }

            var colName = dgSeguridad.Columns[e.ColumnIndex].Name;
            if (colName == "btnBorrar")
            {
                if (MessageBox.Show(
                    "¿Está seguro de eliminar este usuario de seguridad?",
                    "Confirmación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    return;
                }

                try
                {
                    var filas = _accesoDatos.EliminarSeguridad(idEmpleado);
                    MessageBox.Show(filas > 0 ? "Usuario eliminado." : "No se eliminó ningún registro.");
                    CargarUsuarios();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "No fue posible eliminar el usuario.\n" + ex.Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }

                return;
            }

            if (colName == "btnEditar")
            {
                using (var frm = new frmEditarSeguridad(idEmpleado))
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        CargarUsuarios();
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
    }
}


