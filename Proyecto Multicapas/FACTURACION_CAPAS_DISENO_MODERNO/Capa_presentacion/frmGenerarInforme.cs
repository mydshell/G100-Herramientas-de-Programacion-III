using MaterialSkin.Controls;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ClosedXML.Excel;

namespace Pantallas_Sistema_facturación
{
    public partial class frmGenerarInforme : MaterialForm
    {
        public static BindingList<Informe> InformesSesion { get; } = new BindingList<Informe>();

        private readonly Cls_Gestion_Negocio _accesoDatos = new Cls_Gestion_Negocio();
        public Informe InformeEditado { get; private set; }

        private DataGridView _dgVista;
        private Panel _pnlExcel;
        private Button _btnDescargarExcel;
        private DataTable _ultimoResultado = new DataTable();

        private bool _yaGenero;
        private bool _esEdicion;
        private bool _guardado;

        public frmGenerarInforme()
        {
            InitializeComponent();
            Load += frmGenerarInforme_Load;
        }

        public frmGenerarInforme(Informe informe)
        {
            InitializeComponent();
            InformeEditado = informe;
            Load += frmGenerarInforme_Load;
        }

        private void frmGenerarInforme_Load(object sender, EventArgs e)
        {
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;

            PrepararCombos();
            PrepararVistaPanel();

            _esEdicion = InformeEditado != null;
            if (!_esEdicion)
            {
                txtIdInforme.Text = "0";
                dtpFechaInicial.Value = DateTime.Today.AddDays(-30);
                dtpFechaFinal.Value = DateTime.Today;
                cmbTipoInforme.SelectedIndex = 0;
                cmbOrdenado.SelectedIndex = 0;
                mrbEnPantalla.Checked = true;
                _yaGenero = false;
                _guardado = false;
                btnGenerar.Text = "Generar";
                btnGenerar.Visible = true;
                RenderModoVista();
                return;
            }

            txtIdInforme.Text = InformeEditado.IdInforme.ToString();
            dtpFechaInicial.Value = InformeEditado.FechaInicial == default(DateTime) ? DateTime.Today.AddDays(-30) : InformeEditado.FechaInicial;
            dtpFechaFinal.Value = InformeEditado.FechaFinal == default(DateTime) ? DateTime.Today : InformeEditado.FechaFinal;
            SeleccionarCombo(cmbTipoInforme, InformeEditado.TipoInforme);
            SeleccionarCombo(cmbOrdenado, InformeEditado.OrdenadoPor);
            mrbExcel.Checked = string.Equals(InformeEditado.VisualizadoEn, "Excel", StringComparison.OrdinalIgnoreCase);
            mrbEnPantalla.Checked = !mrbExcel.Checked;
            btnGenerar.Text = "Actualizar";
            btnGenerar.Visible = true;

            GenerarYRenderizar();
            _yaGenero = true;
            _guardado = false;
            RenderModoVista();
        }

        private void PrepararCombos()
        {
            cmbTipoInforme.Items.Clear();
            cmbTipoInforme.Items.Add("Factura");
            cmbTipoInforme.Items.Add("Cliente");
            cmbTipoInforme.Items.Add("Empleado");
            cmbTipoInforme.DropDownStyle = ComboBoxStyle.DropDownList;

            cmbOrdenado.Items.Clear();
            cmbOrdenado.Items.Add("FechaDesc");
            cmbOrdenado.Items.Add("FechaAsc");
            cmbOrdenado.Items.Add("TotalDesc");
            cmbOrdenado.Items.Add("TotalAsc");
            cmbOrdenado.DropDownStyle = ComboBoxStyle.DropDownList;

            mrbEnPantalla.CheckedChanged -= RadioChanged;
            mrbExcel.CheckedChanged -= RadioChanged;
            mrbEnPantalla.CheckedChanged += RadioChanged;
            mrbExcel.CheckedChanged += RadioChanged;

            cmbTipoInforme.SelectedIndexChanged -= CualquierCambioRequiereGenerar;
            cmbOrdenado.SelectedIndexChanged -= CualquierCambioRequiereGenerar;
            dtpFechaInicial.ValueChanged -= CualquierCambioRequiereGenerar;
            dtpFechaFinal.ValueChanged -= CualquierCambioRequiereGenerar;

            cmbTipoInforme.SelectedIndexChanged += CualquierCambioRequiereGenerar;
            cmbOrdenado.SelectedIndexChanged += CualquierCambioRequiereGenerar;
            dtpFechaInicial.ValueChanged += CualquierCambioRequiereGenerar;
            dtpFechaFinal.ValueChanged += CualquierCambioRequiereGenerar;
        }

        private void CualquierCambioRequiereGenerar(object sender, EventArgs e)
        {
            if (!_yaGenero) return;
            _yaGenero = false;
            _ultimoResultado = new DataTable();
            btnGenerar.Visible = true;
            RenderModoVista();
        }

        private void RadioChanged(object sender, EventArgs e)
        {
            if (!IsHandleCreated) return;
            RenderModoVista();
        }

        private void PrepararVistaPanel()
        {
            if (pnlInformeVista == null) return;

            pnlInformeVista.Controls.Clear();

            _dgVista = new DataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };

            _pnlExcel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                Visible = false
            };

            _btnDescargarExcel = new Button
            {
                Text = "Descargar Excel",
                AutoSize = true,
                BackColor = Color.White,
                ForeColor = Color.Black,
                FlatStyle = FlatStyle.Standard,
                UseVisualStyleBackColor = false,
                Visible = false
            };
            _btnDescargarExcel.Click += (_, __) => DescargarExcelXlsx();

            _pnlExcel.Controls.Add(_btnDescargarExcel);
            _pnlExcel.Resize += (_, __) => CentrarBotonExcel();
            pnlInformeVista.Resize += (_, __) => CentrarBotonExcel();

            pnlInformeVista.Controls.Add(_dgVista);
            pnlInformeVista.Controls.Add(_pnlExcel);

            BeginInvoke(new Action(() =>
            {
                CentrarBotonExcel();
                RenderModoVista();
            }));
        }

        private void CentrarBotonExcel()
        {
            if (_pnlExcel == null || _btnDescargarExcel == null) return;

            var x = (_pnlExcel.ClientSize.Width - _btnDescargarExcel.Width) / 2;
            var y = (_pnlExcel.ClientSize.Height - _btnDescargarExcel.Height) / 2;
            _btnDescargarExcel.Left = x < 0 ? 0 : x;
            _btnDescargarExcel.Top = y < 0 ? 0 : y;
        }

        private void RenderModoVista()
        {
            if (_dgVista == null || _pnlExcel == null || _btnDescargarExcel == null) return;

            if (mrbExcel.Checked)
            {
                _dgVista.Visible = false;
                _pnlExcel.Visible = true;
                _pnlExcel.BringToFront();
                _btnDescargarExcel.Visible = _yaGenero && _ultimoResultado != null && _ultimoResultado.Rows.Count > 0;
                if (_btnDescargarExcel.Visible) _btnDescargarExcel.BringToFront();
                CentrarBotonExcel();
            }
            else
            {
                _pnlExcel.Visible = false;
                _dgVista.Visible = true;
                _dgVista.BringToFront();
                _btnDescargarExcel.Visible = false;
            }
        }

        private void SeleccionarCombo(ComboBox cmb, string value)
        {
            if (cmb == null) return;
            var idx = cmb.Items.IndexOf(value);
            cmb.SelectedIndex = idx >= 0 ? idx : 0;
        }

        private bool ValidarCampos()
        {
            errorProvider1.Clear();
            var ok = true;

            if (dtpFechaFinal.Value.Date < dtpFechaInicial.Value.Date)
            {
                errorProvider1.SetError(dtpFechaFinal, "La Fecha Final no puede ser menor que la Fecha Inicial.");
                ok = false;
            }

            if (cmbTipoInforme.SelectedItem == null)
            {
                errorProvider1.SetError(cmbTipoInforme, "Debe seleccionar un tipo de informe.");
                ok = false;
            }

            if (cmbOrdenado.SelectedItem == null)
            {
                errorProvider1.SetError(cmbOrdenado, "Debe seleccionar un ordenamiento.");
                ok = false;
            }

            if (!mrbExcel.Checked && !mrbEnPantalla.Checked)
            {
                errorProvider1.SetError(mrbEnPantalla, "Debe seleccionar un modo de visualización.");
                ok = false;
            }

            return ok;
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            if (InformeEditado == null)
            {
                InformeEditado = new Informe();
            }

            InformeEditado.TipoInforme = Convert.ToString(cmbTipoInforme.SelectedItem ?? "Factura");
            InformeEditado.OrdenadoPor = Convert.ToString(cmbOrdenado.SelectedItem ?? "FechaDesc");
            InformeEditado.VisualizadoEn = mrbExcel.Checked ? "Excel" : "Pantalla";
            InformeEditado.FechaInicial = dtpFechaInicial.Value.Date;
            InformeEditado.FechaFinal = dtpFechaFinal.Value.Date;
            InformeEditado.FechaGeneracion = DateTime.Now;

            GuardarEnSesionSiAplica();
            GenerarYRenderizar();

            _yaGenero = true;
            _guardado = true;
            btnGenerar.Visible = _esEdicion;
            RenderModoVista();
        }

        private void GuardarEnSesionSiAplica()
        {
            if (InformeEditado.IdInforme <= 0)
            {
                var nextId = InformesSesion.Count == 0 ? 1 : InformesSesion.Max(x => x.IdInforme) + 1;
                InformeEditado.IdInforme = nextId;
                txtIdInforme.Text = nextId.ToString();
            }

            var existente = InformesSesion.FirstOrDefault(x => x.IdInforme == InformeEditado.IdInforme);
            if (existente == null)
            {
                InformesSesion.Add(new Informe
                {
                    IdInforme = InformeEditado.IdInforme,
                    TipoInforme = InformeEditado.TipoInforme,
                    OrdenadoPor = InformeEditado.OrdenadoPor,
                    VisualizadoEn = InformeEditado.VisualizadoEn,
                    FechaInicial = InformeEditado.FechaInicial,
                    FechaFinal = InformeEditado.FechaFinal,
                    FechaGeneracion = InformeEditado.FechaGeneracion
                });
                return;
            }

            existente.TipoInforme = InformeEditado.TipoInforme;
            existente.OrdenadoPor = InformeEditado.OrdenadoPor;
            existente.VisualizadoEn = InformeEditado.VisualizadoEn;
            existente.FechaInicial = InformeEditado.FechaInicial;
            existente.FechaFinal = InformeEditado.FechaFinal;
            existente.FechaGeneracion = InformeEditado.FechaGeneracion;
        }

        private void GenerarYRenderizar()
        {
            _ultimoResultado = ObtenerDatosInforme();

            _dgVista.SuspendLayout();
            _dgVista.DataSource = null;
            _dgVista.Columns.Clear();
            _dgVista.AutoGenerateColumns = true;
            _dgVista.DataSource = _ultimoResultado;
            _dgVista.ResumeLayout();
            _dgVista.Refresh();
        }

        private DataTable ObtenerDatosInforme()
        {
            var baseData = _accesoDatos.ConsultarFacturasParaInforme(dtpFechaInicial.Value.Date, dtpFechaFinal.Value.Date);
            var tipo = Convert.ToString(cmbTipoInforme.SelectedItem ?? "Factura");

            if (tipo == "Factura")
            {
                var tabla = new DataTable();
                tabla.Columns.Add("IdFactura", typeof(int));
                tabla.Columns.Add("Fecha", typeof(DateTime));
                tabla.Columns.Add("Cliente", typeof(string));
                tabla.Columns.Add("Empleado", typeof(string));
                tabla.Columns.Add("Estado", typeof(string));
                tabla.Columns.Add("IVA", typeof(decimal));
                tabla.Columns.Add("Descuento", typeof(decimal));
                tabla.Columns.Add("Total", typeof(decimal));

                foreach (DataRow row in baseData.Rows)
                {
                    tabla.Rows.Add(
                        Convert.ToInt32(row["IdFactura"]),
                        Convert.ToDateTime(row["Fecha"]),
                        Convert.ToString(row["Cliente"]),
                        Convert.ToString(row["Empleado"]),
                        Convert.ToString(row["Estado"]),
                        ToDecimal(row["Iva"]),
                        ToDecimal(row["Descuento"]),
                        ToDecimal(row["Total"])
                    );
                }

                return OrdenarFactura(tabla);
            }

            if (tipo == "Cliente")
            {
                var tabla = new DataTable();
                tabla.Columns.Add("Cliente", typeof(string));
                tabla.Columns.Add("CantidadFacturas", typeof(int));
                tabla.Columns.Add("Total", typeof(decimal));

                var grupos = baseData.AsEnumerable()
                    .GroupBy(r => Convert.ToString(r["Cliente"]) ?? string.Empty)
                    .Select(g => new
                    {
                        Nombre = g.Key,
                        Cantidad = g.Count(),
                        Total = g.Sum(x => ToDecimal(x["Total"]))
                    });

                foreach (var g in grupos)
                {
                    tabla.Rows.Add(g.Nombre, g.Cantidad, g.Total);
                }

                return OrdenarResumen(tabla, "Cliente");
            }

            {
                var tabla = new DataTable();
                tabla.Columns.Add("Empleado", typeof(string));
                tabla.Columns.Add("CantidadFacturas", typeof(int));
                tabla.Columns.Add("Total", typeof(decimal));

                var grupos = baseData.AsEnumerable()
                    .GroupBy(r => Convert.ToString(r["Empleado"]) ?? string.Empty)
                    .Select(g => new
                    {
                        Nombre = g.Key,
                        Cantidad = g.Count(),
                        Total = g.Sum(x => ToDecimal(x["Total"]))
                    });

                foreach (var g in grupos)
                {
                    tabla.Rows.Add(g.Nombre, g.Cantidad, g.Total);
                }

                return OrdenarResumen(tabla, "Empleado");
            }
        }

        private DataTable OrdenarFactura(DataTable tabla)
        {
            var orden = Convert.ToString(cmbOrdenado.SelectedItem ?? "FechaDesc");
            var sort = "Fecha DESC";
            switch (orden)
            {
                case "FechaAsc":
                    sort = "Fecha ASC";
                    break;
                case "TotalAsc":
                    sort = "Total ASC";
                    break;
                case "TotalDesc":
                    sort = "Total DESC";
                    break;
                case "FechaDesc":
                default:
                    sort = "Fecha DESC";
                    break;
            }

            var view = new DataView(tabla) { Sort = sort };
            return view.ToTable();
        }

        private DataTable OrdenarResumen(DataTable tabla, string nombreColumna)
        {
            var orden = Convert.ToString(cmbOrdenado.SelectedItem ?? "TotalDesc");
            var sort = "Total DESC";
            if (orden == "TotalAsc") sort = "Total ASC";
            if (orden == "FechaAsc" || orden == "FechaDesc") sort = $"{nombreColumna} ASC";

            var view = new DataView(tabla) { Sort = sort };
            return view.ToTable();
        }

        private static decimal ToDecimal(object value)
        {
            if (value == null || value == DBNull.Value) return 0m;
            decimal d;
            if (decimal.TryParse(Convert.ToString(value), out d)) return d;
            return 0m;
        }

        private void DescargarExcelXlsx()
        {
            if (_ultimoResultado == null || _ultimoResultado.Rows.Count == 0)
            {
                MessageBox.Show("Primero genere el informe.");
                return;
            }

            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter = "Excel (*.xlsx)|*.xlsx";
                sfd.FileName = $"Informe_{cmbTipoInforme.SelectedItem}_{DateTime.Now:yyyyMMdd_HHmm}.xlsx";
                if (sfd.ShowDialog() != DialogResult.OK) return;

                ExportarXlsxConClosedXml(sfd.FileName, _ultimoResultado);
                MessageBox.Show("Excel generado correctamente.");
            }
        }

        private void ExportarXlsxConClosedXml(string filePath, DataTable tabla)
        {
            using (var wb = new XLWorkbook())
            {
                var ws = wb.Worksheets.Add("Informe");

                for (var c = 0; c < tabla.Columns.Count; c++)
                {
                    ws.Cell(1, c + 1).Value = tabla.Columns[c].ColumnName;
                    ws.Cell(1, c + 1).Style.Font.Bold = true;
                }

                for (var r = 0; r < tabla.Rows.Count; r++)
                {
                    for (var c = 0; c < tabla.Columns.Count; c++)
                    {
                        var valor = tabla.Rows[r][c];
                        var cell = ws.Cell(r + 2, c + 1);

                        if (valor == null || valor == DBNull.Value)
                        {
                            cell.Value = string.Empty;
                            continue;
                        }

                        switch (valor)
                        {
                            case int i:
                                cell.Value = i;
                                break;
                            case long l:
                                cell.Value = l;
                                break;
                            case short s:
                                cell.Value = s;
                                break;
                            case byte b:
                                cell.Value = b;
                                break;
                            case decimal dec:
                                cell.Value = dec;
                                break;
                            case double d:
                                cell.Value = d;
                                break;
                            case float f:
                                cell.Value = (double)f;
                                break;
                            case bool bo:
                                cell.Value = bo;
                                break;
                            case DateTime dt:
                                cell.Value = dt;
                                cell.Style.DateFormat.Format = "yyyy-MM-dd";
                                break;
                            default:
                                cell.Value = Convert.ToString(valor);
                                break;
                        }
                    }
                }

                ws.Columns().AdjustToContents();
                wb.SaveAs(filePath);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult = _guardado ? DialogResult.OK : DialogResult.Cancel;
            Close();
        }

        private void dtpFechaInicial_ValueChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(dtpFechaFinal, string.Empty);
        }

        private void dtpFechaFinal_ValueChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(dtpFechaFinal, string.Empty);
        }

        private void cmbTipoInforme_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(cmbTipoInforme, string.Empty);
        }

        private void cmbOrdenado_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(cmbOrdenado, string.Empty);
        }

        private void mrbEnPantalla_CheckedChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(mrbEnPantalla, string.Empty);
        }

        private void mrbExcel_CheckedChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(mrbEnPantalla, string.Empty);
        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}


