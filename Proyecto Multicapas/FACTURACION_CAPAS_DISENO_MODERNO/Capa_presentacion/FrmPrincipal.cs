using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace Pantallas_Sistema_facturación
{
    public partial class FrmPrincipal : MaterialForm
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void PnlPrincipal_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Principal_Click(object sender, EventArgs e)
        {

        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        public void AbrirForm(Form formHijo)
        {
            if (this.pnlContenedor.Controls.Count > 0)
                this.pnlContenedor.Controls.RemoveAt(0);
            formHijo.TopLevel = false;
            formHijo.FormBorderStyle = FormBorderStyle.None;
            formHijo.Dock = DockStyle.Fill;
            this.pnlContenedor.Controls.Add(formHijo);
            formHijo.Show();
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            FrmListaClientes ListaClientes = new FrmListaClientes();
            AbrirForm(ListaClientes);
        }

        private void Button1_Click_1(object sender, EventArgs e)
        {

        }

        private void BtnProductos_Click(object sender, EventArgs e)
        {
            frmListaProductos ListaProductos = new frmListaProductos();
            AbrirForm(ListaProductos);
        }

        private void Tablas_Click(object sender, EventArgs e)
        {

        }

        private void TabOpcionesMenu_Click(object sender, EventArgs e)
        {

        }

        private void BtnFacturas_Click(object sender, EventArgs e)
        {
            frmListaFacturas ListaFacturas = new frmListaFacturas();
            AbrirForm(ListaFacturas);
        }

        private void BtnInformes_Click(object sender, EventArgs e)
        {
            frmListaInformes ListaInformes = new frmListaInformes();
            AbrirForm(ListaInformes);
        }

        private void BtnCategorias_Click(object sender, EventArgs e)
        {
            frmListaCategorias ListaCategorias = new frmListaCategorias();
            AbrirForm(ListaCategorias);
        }

        private void BtnEmpleados_Click(object sender, EventArgs e)
        {
            frmListaEmpleados ListaEmpleados = new frmListaEmpleados();
            AbrirForm(ListaEmpleados);
        }

        private void BtnRoles_Click(object sender, EventArgs e)
        {
            frmListaRoles ListaRoles = new frmListaRoles();
            AbrirForm(ListaRoles);
        }

        private void BtnSeguridad_Click(object sender, EventArgs e)
        {
            frmListaSeguridad ListaSeguridad = new frmListaSeguridad();
            AbrirForm(ListaSeguridad);
        }

        private void BtnAyuda_Click(object sender, EventArgs e)
        {
            frmListaAyuda ListaAyuda = new frmListaAyuda();
            AbrirForm(ListaAyuda);
        }

        private void BtnAcercaDe_Click(object sender, EventArgs e)
        {
            frmListaAcercaDe ListaAcercaDe = new frmListaAcercaDe();
            AbrirForm(ListaAcercaDe);
        }

        private void PlnContenedor_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
