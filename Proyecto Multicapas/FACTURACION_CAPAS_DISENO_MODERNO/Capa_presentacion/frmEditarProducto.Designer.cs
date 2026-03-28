namespace Pantallas_Sistema_facturación
{
    partial class frmEditarProducto
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnSalir = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnActualizar = new MaterialSkin.Controls.MaterialRaisedButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.txtNombreProducto = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txtCodigo = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txtPrecioCompra = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txtPrecioVenta = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txtCantidadStock = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txtIdProducto = new System.Windows.Forms.TextBox();
            this.lblTitulo = new MaterialSkin.Controls.MaterialLabel();
            this.cmbCategoria = new System.Windows.Forms.ComboBox();
            this.txtRutaImagen = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txtCategoria = new MaterialSkin.Controls.MaterialLabel();
            this.lblDetallesProducto = new MaterialSkin.Controls.MaterialLabel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.txtDetallesProducto = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSalir
            // 
            this.btnSalir.Depth = 0;
            this.btnSalir.Location = new System.Drawing.Point(693, 380);
            this.btnSalir.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Primary = true;
            this.btnSalir.Size = new System.Drawing.Size(80, 40);
            this.btnSalir.TabIndex = 9;
            this.btnSalir.Text = "SALIR";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Depth = 0;
            this.btnActualizar.Location = new System.Drawing.Point(560, 380);
            this.btnActualizar.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Primary = true;
            this.btnActualizar.Size = new System.Drawing.Size(119, 40);
            this.btnActualizar.TabIndex = 8;
            this.btnActualizar.Text = "ACTUALIZAR";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Location = new System.Drawing.Point(42, 160);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(375, 260);
            this.panel1.TabIndex = 7;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.txtNombreProducto);
            this.flowLayoutPanel1.Controls.Add(this.txtCodigo);
            this.flowLayoutPanel1.Controls.Add(this.txtPrecioCompra);
            this.flowLayoutPanel1.Controls.Add(this.txtPrecioVenta);
            this.flowLayoutPanel1.Controls.Add(this.txtCantidadStock);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(372, 260);
            this.flowLayoutPanel1.TabIndex = 5;
            // 
            // txtNombreProducto
            // 
            this.txtNombreProducto.Depth = 0;
            this.txtNombreProducto.Hint = "Nombre Producto";
            this.txtNombreProducto.Location = new System.Drawing.Point(23, 3);
            this.txtNombreProducto.Margin = new System.Windows.Forms.Padding(3, 3, 3, 25);
            this.txtNombreProducto.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtNombreProducto.Name = "txtNombreProducto";
            this.txtNombreProducto.PasswordChar = '\0';
            this.txtNombreProducto.SelectedText = "";
            this.txtNombreProducto.SelectionLength = 0;
            this.txtNombreProducto.SelectionStart = 0;
            this.txtNombreProducto.Size = new System.Drawing.Size(320, 28);
            this.txtNombreProducto.TabIndex = 0;
            this.txtNombreProducto.UseSystemPasswordChar = false;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Depth = 0;
            this.txtCodigo.Hint = "Código Referencia";
            this.txtCodigo.Location = new System.Drawing.Point(23, 59);
            this.txtCodigo.Margin = new System.Windows.Forms.Padding(3, 3, 3, 25);
            this.txtCodigo.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.PasswordChar = '\0';
            this.txtCodigo.SelectedText = "";
            this.txtCodigo.SelectionLength = 0;
            this.txtCodigo.SelectionStart = 0;
            this.txtCodigo.Size = new System.Drawing.Size(211, 28);
            this.txtCodigo.TabIndex = 1;
            this.txtCodigo.UseSystemPasswordChar = false;
            // 
            // txtPrecioCompra
            // 
            this.txtPrecioCompra.Depth = 0;
            this.txtPrecioCompra.Hint = "Precio Compra";
            this.txtPrecioCompra.Location = new System.Drawing.Point(23, 115);
            this.txtPrecioCompra.Margin = new System.Windows.Forms.Padding(3, 3, 3, 25);
            this.txtPrecioCompra.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtPrecioCompra.Name = "txtPrecioCompra";
            this.txtPrecioCompra.PasswordChar = '\0';
            this.txtPrecioCompra.SelectedText = "";
            this.txtPrecioCompra.SelectionLength = 0;
            this.txtPrecioCompra.SelectionStart = 0;
            this.txtPrecioCompra.Size = new System.Drawing.Size(211, 28);
            this.txtPrecioCompra.TabIndex = 2;
            this.txtPrecioCompra.UseSystemPasswordChar = false;
            // 
            // txtPrecioVenta
            // 
            this.txtPrecioVenta.Depth = 0;
            this.txtPrecioVenta.Hint = "Precio Venta";
            this.txtPrecioVenta.Location = new System.Drawing.Point(23, 171);
            this.txtPrecioVenta.Margin = new System.Windows.Forms.Padding(3, 3, 3, 25);
            this.txtPrecioVenta.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtPrecioVenta.Name = "txtPrecioVenta";
            this.txtPrecioVenta.PasswordChar = '\0';
            this.txtPrecioVenta.SelectedText = "";
            this.txtPrecioVenta.SelectionLength = 0;
            this.txtPrecioVenta.SelectionStart = 0;
            this.txtPrecioVenta.Size = new System.Drawing.Size(211, 28);
            this.txtPrecioVenta.TabIndex = 3;
            this.txtPrecioVenta.UseSystemPasswordChar = false;
            // 
            // txtCantidadStock
            // 
            this.txtCantidadStock.Depth = 0;
            this.txtCantidadStock.Hint = "Cantidad Stock";
            this.txtCantidadStock.Location = new System.Drawing.Point(23, 227);
            this.txtCantidadStock.Margin = new System.Windows.Forms.Padding(3, 3, 3, 25);
            this.txtCantidadStock.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtCantidadStock.Name = "txtCantidadStock";
            this.txtCantidadStock.PasswordChar = '\0';
            this.txtCantidadStock.SelectedText = "";
            this.txtCantidadStock.SelectionLength = 0;
            this.txtCantidadStock.SelectionStart = 0;
            this.txtCantidadStock.Size = new System.Drawing.Size(211, 28);
            this.txtCantidadStock.TabIndex = 4;
            this.txtCantidadStock.UseSystemPasswordChar = false;
            // 
            // txtIdProducto
            // 
            this.txtIdProducto.Location = new System.Drawing.Point(41, 128);
            this.txtIdProducto.Name = "txtIdProducto";
            this.txtIdProducto.ReadOnly = true;
            this.txtIdProducto.Size = new System.Drawing.Size(57, 22);
            this.txtIdProducto.TabIndex = 6;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Depth = 0;
            this.lblTitulo.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTitulo.Location = new System.Drawing.Point(123, 87);
            this.lblTitulo.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(175, 24);
            this.lblTitulo.TabIndex = 5;
            this.lblTitulo.Text = "EDITAR PRODUCTO";
            // 
            // cmbCategoria
            // 
            this.cmbCategoria.FormattingEnabled = true;
            this.cmbCategoria.Location = new System.Drawing.Point(135, 3);
            this.cmbCategoria.Margin = new System.Windows.Forms.Padding(18, 3, 3, 3);
            this.cmbCategoria.Name = "cmbCategoria";
            this.cmbCategoria.Size = new System.Drawing.Size(167, 24);
            this.cmbCategoria.TabIndex = 10;
            // 
            // txtRutaImagen
            // 
            this.txtRutaImagen.Depth = 0;
            this.txtRutaImagen.Hint = "Ruta Imagen";
            this.txtRutaImagen.Location = new System.Drawing.Point(23, 50);
            this.txtRutaImagen.Margin = new System.Windows.Forms.Padding(3, 3, 3, 20);
            this.txtRutaImagen.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtRutaImagen.Name = "txtRutaImagen";
            this.txtRutaImagen.PasswordChar = '\0';
            this.txtRutaImagen.SelectedText = "";
            this.txtRutaImagen.SelectionLength = 0;
            this.txtRutaImagen.SelectionStart = 0;
            this.txtRutaImagen.Size = new System.Drawing.Size(279, 28);
            this.txtRutaImagen.TabIndex = 13;
            this.txtRutaImagen.UseSystemPasswordChar = false;
            // 
            // txtCategoria
            // 
            this.txtCategoria.AutoSize = true;
            this.txtCategoria.Depth = 0;
            this.txtCategoria.Font = new System.Drawing.Font("Roboto", 11F);
            this.txtCategoria.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtCategoria.Location = new System.Drawing.Point(23, 3);
            this.txtCategoria.Margin = new System.Windows.Forms.Padding(3, 3, 3, 20);
            this.txtCategoria.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtCategoria.Name = "txtCategoria";
            this.txtCategoria.Size = new System.Drawing.Size(91, 24);
            this.txtCategoria.TabIndex = 14;
            this.txtCategoria.Text = "Categoría";
            // 
            // lblDetallesProducto
            // 
            this.lblDetallesProducto.AutoSize = true;
            this.lblDetallesProducto.Depth = 0;
            this.lblDetallesProducto.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDetallesProducto.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblDetallesProducto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblDetallesProducto.Location = new System.Drawing.Point(23, 101);
            this.lblDetallesProducto.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.lblDetallesProducto.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblDetallesProducto.Name = "lblDetallesProducto";
            this.lblDetallesProducto.Size = new System.Drawing.Size(150, 24);
            this.lblDetallesProducto.TabIndex = 15;
            this.lblDetallesProducto.Text = "Detalle Producto";
            this.lblDetallesProducto.Click += new System.EventHandler(this.txtDetallesProducto_Click);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.txtCategoria);
            this.flowLayoutPanel2.Controls.Add(this.cmbCategoria);
            this.flowLayoutPanel2.Controls.Add(this.txtRutaImagen);
            this.flowLayoutPanel2.Controls.Add(this.lblDetallesProducto);
            this.flowLayoutPanel2.Controls.Add(this.txtDetallesProducto);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(458, 160);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.flowLayoutPanel2.Size = new System.Drawing.Size(315, 208);
            this.flowLayoutPanel2.TabIndex = 16;
            // 
            // txtDetallesProducto
            // 
            this.txtDetallesProducto.Location = new System.Drawing.Point(23, 138);
            this.txtDetallesProducto.MinimumSize = new System.Drawing.Size(4, 50);
            this.txtDetallesProducto.Multiline = true;
            this.txtDetallesProducto.Name = "txtDetallesProducto";
            this.txtDetallesProducto.Size = new System.Drawing.Size(262, 58);
            this.txtDetallesProducto.TabIndex = 16;
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider1.ContainerControl = this;
            // 
            // frmEditarProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtIdProducto);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Name = "frmEditarProducto";
            this.Text = "Actualizar Producto";
            this.Load += new System.EventHandler(this.frmEditarProducto_Load);
            this.panel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialRaisedButton btnSalir;
        private MaterialSkin.Controls.MaterialRaisedButton btnActualizar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtCodigo;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtPrecioCompra;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtPrecioVenta;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtCantidadStock;
        private System.Windows.Forms.TextBox txtIdProducto;
        private MaterialSkin.Controls.MaterialLabel lblTitulo;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtNombreProducto;
        private System.Windows.Forms.ComboBox cmbCategoria;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtRutaImagen;
        private MaterialSkin.Controls.MaterialLabel txtCategoria;
        private MaterialSkin.Controls.MaterialLabel lblDetallesProducto;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.TextBox txtDetallesProducto;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
