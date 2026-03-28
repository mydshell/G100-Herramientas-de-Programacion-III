using System;
using System.Globalization;
using System.Windows.Forms;
using MaterialSkin.Controls;

namespace Pantallas_Sistema_facturación
{
    public partial class frmEditarProducto : MaterialForm
    {
        private readonly Cls_Gestion_Negocio _accesoDatos = new Cls_Gestion_Negocio();
        private readonly int _idProducto;

        public frmEditarProducto() : this(0)
        {
        }

        public frmEditarProducto(int idProducto)
        {
            InitializeComponent();
            _idProducto = idProducto;
        }

        private void frmEditarProducto_Load(object sender, EventArgs e)
        {
            CargarCategorias();

            if (_idProducto <= 0)
            {
                lblTitulo.Text = "INGRESO NUEVO PRODUCTO";
                btnActualizar.Text = "GUARDAR";
                Text = "Nuevo Producto";
                txtIdProducto.Text = "0";
                return;
            }

            lblTitulo.Text = "MODIFICAR PRODUCTO";
            btnActualizar.Text = "ACTUALIZAR";
            Text = "Actualizar Producto";
            CargarProducto();
        }

        private void CargarCategorias()
        {
            try
            {
                var dt = _accesoDatos.ListarCategoriasBasico();
                cmbCategoria.DataSource = dt;
                cmbCategoria.DisplayMember = "NombreCategoria";
                cmbCategoria.ValueMember = "IdCategoria";
                cmbCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No fue posible cargar categorías.\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void CargarProducto()
        {
            try
            {
                var producto = _accesoDatos.ObtenerProductoPorId(_idProducto);
                if (producto == null)
                {
                    MessageBox.Show(
                        "No se encontró el producto seleccionado.",
                        "Aviso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    DialogResult = DialogResult.Cancel;
                    Close();
                    return;
                }

                txtIdProducto.Text = producto.IdProducto.ToString();
                txtNombreProducto.Text = producto.NombreProducto ?? string.Empty;
                txtCodigo.Text = producto.Codigo ?? string.Empty;
                txtPrecioCompra.Text = producto.PrecioCompra ?? string.Empty;
                txtPrecioVenta.Text = producto.PrecioVenta ?? string.Empty;
                txtCantidadStock.Text = producto.Stock ?? string.Empty;
                txtDetallesProducto.Text = producto.Detalle ?? string.Empty;
                txtRutaImagen.Text = producto.RutaImagen ?? string.Empty;

                if (producto.IdCategoria > 0)
                {
                    cmbCategoria.SelectedValue = producto.IdCategoria;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No fue posible cargar el producto.\n" + ex.Message,
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

            if (string.IsNullOrWhiteSpace(txtNombreProducto.Text))
            {
                errorProvider1.SetError(txtNombreProducto, "El nombre del producto es obligatorio.");
                ok = false;
            }

            if (cmbCategoria.SelectedValue == null)
            {
                errorProvider1.SetError(cmbCategoria, "Debe seleccionar una categoría.");
                ok = false;
            }

            if (!EsDecimal(txtPrecioCompra.Text))
            {
                errorProvider1.SetError(txtPrecioCompra, "Precio compra inválido.");
                ok = false;
            }

            if (!EsDecimal(txtPrecioVenta.Text))
            {
                errorProvider1.SetError(txtPrecioVenta, "Precio venta inválido.");
                ok = false;
            }

            int stock;
            if (!int.TryParse((txtCantidadStock.Text ?? string.Empty).Trim(), out stock))
            {
                errorProvider1.SetError(txtCantidadStock, "Stock inválido.");
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

            int idCategoria;
            if (!int.TryParse(Convert.ToString(cmbCategoria.SelectedValue), out idCategoria) || idCategoria <= 0)
            {
                MessageBox.Show("Debe seleccionar una categoría válida.");
                return;
            }

            var entidad = new Producto
            {
                IdProducto = _idProducto,
                NombreProducto = txtNombreProducto.Text.Trim(),
                Codigo = txtCodigo.Text.Trim(),
                PrecioCompra = txtPrecioCompra.Text.Trim(),
                PrecioVenta = txtPrecioVenta.Text.Trim(),
                Stock = txtCantidadStock.Text.Trim(),
                Detalle = txtDetallesProducto.Text.Trim(),
                RutaImagen = txtRutaImagen.Text.Trim(),
                IdCategoria = idCategoria
            };

            try
            {
                var filas = _accesoDatos.GuardarProducto(entidad, Environment.UserName);
                if (filas > 0)
                {
                    DialogResult = DialogResult.OK;
                    Close();
                    return;
                }

                MessageBox.Show("No se guardó información del producto.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No fue posible guardar el producto.\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnCategorias_Click(object sender, EventArgs e)
        {
            var seleccionado = Convert.ToString(cmbCategoria.SelectedValue);

            using (var frm = new frmListaCategorias())
            {
                frm.ShowDialog();
            }

            CargarCategorias();

            int id;
            if (int.TryParse(seleccionado, out id) && id > 0)
            {
                cmbCategoria.SelectedValue = id;
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void txtDetallesProducto_Click(object sender, EventArgs e)
        {
        }

        private void txtNombreProducto_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtNombreProducto, string.Empty);
        }

        private void cmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(cmbCategoria, string.Empty);
        }
    }
}


