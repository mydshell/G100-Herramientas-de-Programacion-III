using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Pantallas_Sistema_facturación
{
    public partial class frmListaRoles : Form
    {
        private readonly Cls_Gestion_Negocio _accesoDatos = new Cls_Gestion_Negocio();
        private readonly BindingSource _bsRoles = new BindingSource();
        private bool _cargado;

        public frmListaRoles()
        {
            InitializeComponent();
        }

        private void frmListaRoles_Load(object sender, EventArgs e)
        {
            if (_cargado) return;
            _cargado = true;

            dgRoles.AutoGenerateColumns = false;
            dgRoles.Columns["Id_Rol"].DataPropertyName = "IdRolEmpleado";
            dgRoles.Columns["strRol"].DataPropertyName = "NombreRol";

            CargarRoles();
        }

        private void CargarRoles()
        {
            try
            {
                var filtro = (txtBuscar?.Text ?? string.Empty).Trim();
                var tabla = _accesoDatos.ListarRoles(filtro);
                _bsRoles.DataSource = tabla;
                dgRoles.DataSource = _bsRoles;
                dgRoles.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No fue posible consultar roles.\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            using (var frm = new frmEditarRolEmpleado())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    CargarRoles();
                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (!_cargado) return;
            CargarRoles();
        }

        private void dgRoles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            var rowView = dgRoles.Rows[e.RowIndex].DataBoundItem as DataRowView;
            if (rowView == null) return;

            int idRol;
            if (!int.TryParse(Convert.ToString(rowView["IdRolEmpleado"]), out idRol) || idRol <= 0)
            {
                MessageBox.Show("No se pudo identificar el rol seleccionado.");
                return;
            }

            var colName = dgRoles.Columns[e.ColumnIndex].Name;
            if (colName == "btnBorrar")
            {
                try
                {
                    var usados = _accesoDatos.ExisteEmpleadosConRol(idRol);
                    var msg = usados
                        ? "Este rol está asignado a empleados. Si lo elimina, esos empleados quedarán sin rol. ¿Desea continuar?"
                        : "¿Está seguro de eliminar este rol?";

                    if (MessageBox.Show(msg, "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    {
                        return;
                    }

                    var filas = _accesoDatos.EliminarRol(idRol);
                    MessageBox.Show(filas > 0 ? "Rol eliminado." : "No se eliminó ningún registro.");
                    CargarRoles();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "No fue posible eliminar el rol.\n" + ex.Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }

                return;
            }

            if (colName == "btnEditar")
            {
                using (var frm = new frmEditarRolEmpleado(idRol))
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        CargarRoles();
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


