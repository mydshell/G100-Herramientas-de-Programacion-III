using System;
using System.Windows.Forms;
using MaterialSkin.Controls;

namespace Pantallas_Sistema_facturación
{
    public partial class frmEditarCategoriaProducto : MaterialForm
    {
        private readonly Cls_Gestion_Negocio _accesoDatos = new Cls_Gestion_Negocio();
        private readonly int _idCategoria;

        public frmEditarCategoriaProducto() : this(0)
        {
        }

        public frmEditarCategoriaProducto(int idCategoria)
        {
            InitializeComponent();
            _idCategoria = idCategoria;
        }

        private void frmEditarCategoriaProducto_Load(object sender, EventArgs e)
        {
            if (_idCategoria <= 0)
            {
                lblTitulo.Text = "INGRESO NUEVA CATEGORÍA";
                btnActualizar.Text = "GUARDAR";
                Text = "Nueva Categoría";
                txtIdCategoria.Text = "0";
                return;
            }

            lblTitulo.Text = "MODIFICAR CATEGORÍA";
            btnActualizar.Text = "ACTUALIZAR";
            Text = "Actualizar Categoría";
            CargarCategoria();
        }

        private void CargarCategoria()
        {
            try
            {
                var categoria = _accesoDatos.ObtenerCategoriaPorId(_idCategoria);
                if (categoria == null)
                {
                    MessageBox.Show(
                        "No se encontró la categoría seleccionada.",
                        "Aviso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    DialogResult = DialogResult.Cancel;
                    Close();
                    return;
                }

                txtIdCategoria.Text = categoria.IdCategoria.ToString();
                txtNombreCategoria.Text = categoria.NombreCategoria ?? string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No fue posible cargar la categoría.\n" + ex.Message,
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

            if (string.IsNullOrWhiteSpace(txtNombreCategoria.Text))
            {
                errorProvider1.SetError(txtNombreCategoria, "El nombre de la categoría es obligatorio.");
                ok = false;
            }

            return ok;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            var categoria = new Categoria
            {
                IdCategoria = _idCategoria,
                NombreCategoria = txtNombreCategoria.Text.Trim()
            };

            try
            {
                var filas = _accesoDatos.GuardarCategoria(categoria, Environment.UserName);
                if (filas > 0)
                {
                    DialogResult = DialogResult.OK;
                    Close();
                    return;
                }

                MessageBox.Show("No se guardó información de la categoría.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No fue posible guardar la categoría.\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void txtNombreCategoria_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtNombreCategoria, string.Empty);
        }
    }
}


