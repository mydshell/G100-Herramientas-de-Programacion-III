using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace Pantallas_Sistema_facturación
{
    public partial class frmListaInformes : Form
    {
        private readonly BindingList<Informe> _informes = frmGenerarInforme.InformesSesion;
        private readonly BindingSource _bsInformes = new BindingSource();
        private bool _cargado;

        public frmListaInformes()
        {
            InitializeComponent();
        }

        private void frmListaInformes_Load(object sender, EventArgs e)
        {
            if (_cargado) return;
            _cargado = true;

            dgInformes.AutoGenerateColumns = false;
            dgInformes.Columns["Id_Informe"].DataPropertyName = "IdInforme";
            dgInformes.Columns["strTipoInforme"].DataPropertyName = "TipoInforme";
            dgInformes.Columns["strOrdenado"].DataPropertyName = "OrdenadoPor";
            dgInformes.Columns["strVisualizado"].DataPropertyName = "VisualizadoEn";

            _bsInformes.DataSource = _informes;
            dgInformes.DataSource = _bsInformes;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            using (var frm = new frmGenerarInforme())
            {
                var result = frm.ShowDialog();
                _bsInformes.ResetBindings(false);
                dgInformes.Refresh();
                if (result == DialogResult.OK)
                {
                    btnBuscar_Click(sender, EventArgs.Empty);
                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (!_cargado) return;

            var q = (txtBuscar?.Text ?? string.Empty).Trim();
            if (string.IsNullOrWhiteSpace(q))
            {
                _bsInformes.DataSource = _informes;
                _bsInformes.ResetBindings(false);
                dgInformes.Refresh();
                return;
            }

            var esNumero = int.TryParse(q, out var id);
            var esFecha = DateTime.TryParse(q, out var fecha);

            var filtrados = _informes
                .Where(i =>
                    (esNumero && i.IdInforme == id) ||
                    (!string.IsNullOrEmpty(i.TipoInforme) && i.TipoInforme.IndexOf(q, StringComparison.OrdinalIgnoreCase) >= 0) ||
                    (!string.IsNullOrEmpty(i.OrdenadoPor) && i.OrdenadoPor.IndexOf(q, StringComparison.OrdinalIgnoreCase) >= 0) ||
                    (!string.IsNullOrEmpty(i.VisualizadoEn) && i.VisualizadoEn.IndexOf(q, StringComparison.OrdinalIgnoreCase) >= 0) ||
                    (esFecha && (i.FechaInicial.Date == fecha.Date || i.FechaFinal.Date == fecha.Date || i.FechaGeneracion.Date == fecha.Date))
                )
                .ToList();

            _bsInformes.DataSource = filtrados;
            _bsInformes.ResetBindings(false);
            dgInformes.Refresh();
        }

        private void dgInformes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            var informe = dgInformes.Rows[e.RowIndex].DataBoundItem as Informe;
            if (informe == null) return;

            var colName = dgInformes.Columns[e.ColumnIndex].Name;
            if (colName == "btnBorrar")
            {
                if (MessageBox.Show("¿Está seguro de eliminar este informe?", "Confirmación",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _informes.Remove(informe);
                    _bsInformes.ResetBindings(false);
                    dgInformes.Refresh();
                    btnBuscar_Click(sender, EventArgs.Empty);
                }
                return;
            }

            if (colName == "btnEditar")
            {
                var copia = new Informe
                {
                    IdInforme = informe.IdInforme,
                    TipoInforme = informe.TipoInforme,
                    OrdenadoPor = informe.OrdenadoPor,
                    VisualizadoEn = informe.VisualizadoEn,
                    FechaInicial = informe.FechaInicial,
                    FechaFinal = informe.FechaFinal,
                    FechaGeneracion = informe.FechaGeneracion
                };

                using (var frm = new frmGenerarInforme(copia))
                {
                    var result = frm.ShowDialog();
                    _bsInformes.ResetBindings(false);
                    dgInformes.Refresh();
                    if (result == DialogResult.OK)
                    {
                        btnBuscar_Click(sender, EventArgs.Empty);
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

