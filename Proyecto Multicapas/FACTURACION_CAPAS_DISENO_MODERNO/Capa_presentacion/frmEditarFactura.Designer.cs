namespace Pantallas_Sistema_facturación
{
    partial class frmEditarFactura
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
            this.lblNumeroFactura = new MaterialSkin.Controls.MaterialLabel();
            this.txtNumeroFactura = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.lblCliente = new MaterialSkin.Controls.MaterialLabel();
            this.cmbCliente = new System.Windows.Forms.ComboBox();
            this.lblEmpleado = new MaterialSkin.Controls.MaterialLabel();
            this.cmbEmpleado = new System.Windows.Forms.ComboBox();
            this.txtDescuento = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txtTotalIva = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txtTotalFactura = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txtIdFactura = new System.Windows.Forms.TextBox();
            this.lblTitulo = new MaterialSkin.Controls.MaterialLabel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblFechaFactura = new MaterialSkin.Controls.MaterialLabel();
            this.dtpFechaFactura = new System.Windows.Forms.DateTimePicker();
            this.lblEstadoFactura = new MaterialSkin.Controls.MaterialLabel();
            this.cmbEstadoFactura = new System.Windows.Forms.ComboBox();
            this.lblDetallesProducto = new MaterialSkin.Controls.MaterialLabel();
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
            this.btnSalir.Location = new System.Drawing.Point(638, 372);
            this.btnSalir.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Primary = true;
            this.btnSalir.Size = new System.Drawing.Size(80, 40);
            this.btnSalir.TabIndex = 21;
            this.btnSalir.Text = "SALIR";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Depth = 0;
            this.btnActualizar.Location = new System.Drawing.Point(505, 372);
            this.btnActualizar.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Primary = true;
            this.btnActualizar.Size = new System.Drawing.Size(119, 40);
            this.btnActualizar.TabIndex = 20;
            this.btnActualizar.Text = "ACTUALIZAR";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Location = new System.Drawing.Point(35, 152);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(375, 260);
            this.panel1.TabIndex = 19;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.lblNumeroFactura);
            this.flowLayoutPanel1.Controls.Add(this.txtNumeroFactura);
            this.flowLayoutPanel1.Controls.Add(this.lblCliente);
            this.flowLayoutPanel1.Controls.Add(this.cmbCliente);
            this.flowLayoutPanel1.Controls.Add(this.lblEmpleado);
            this.flowLayoutPanel1.Controls.Add(this.cmbEmpleado);
            this.flowLayoutPanel1.Controls.Add(this.txtDescuento);
            this.flowLayoutPanel1.Controls.Add(this.txtTotalIva);
            this.flowLayoutPanel1.Controls.Add(this.txtTotalFactura);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(372, 260);
            this.flowLayoutPanel1.TabIndex = 5;
            // 
            // lblNumeroFactura
            // 
            this.lblNumeroFactura.AutoSize = true;
            this.lblNumeroFactura.Depth = 0;
            this.lblNumeroFactura.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblNumeroFactura.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblNumeroFactura.Location = new System.Drawing.Point(23, 3);
            this.lblNumeroFactura.Margin = new System.Windows.Forms.Padding(3, 3, 3, 20);
            this.lblNumeroFactura.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblNumeroFactura.Name = "lblNumeroFactura";
            this.lblNumeroFactura.Size = new System.Drawing.Size(109, 24);
            this.lblNumeroFactura.TabIndex = 16;
            this.lblNumeroFactura.Text = "Nro Factura";
            // 
            // txtNumeroFactura
            // 
            this.txtNumeroFactura.Depth = 0;
            this.txtNumeroFactura.Hint = "";
            this.txtNumeroFactura.Location = new System.Drawing.Point(138, 3);
            this.txtNumeroFactura.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtNumeroFactura.Name = "txtNumeroFactura";
            this.txtNumeroFactura.PasswordChar = '\0';
            this.txtNumeroFactura.SelectedText = "";
            this.txtNumeroFactura.SelectionLength = 0;
            this.txtNumeroFactura.SelectionStart = 0;
            this.txtNumeroFactura.Size = new System.Drawing.Size(167, 28);
            this.txtNumeroFactura.TabIndex = 21;
            this.txtNumeroFactura.UseSystemPasswordChar = false;
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Depth = 0;
            this.lblCliente.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblCliente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblCliente.Location = new System.Drawing.Point(23, 50);
            this.lblCliente.Margin = new System.Windows.Forms.Padding(3, 3, 3, 20);
            this.lblCliente.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(68, 24);
            this.lblCliente.TabIndex = 18;
            this.lblCliente.Text = "Cliente";
            // 
            // cmbCliente
            // 
            this.cmbCliente.FormattingEnabled = true;
            this.cmbCliente.Location = new System.Drawing.Point(112, 50);
            this.cmbCliente.Margin = new System.Windows.Forms.Padding(18, 3, 3, 3);
            this.cmbCliente.Name = "cmbCliente";
            this.cmbCliente.Size = new System.Drawing.Size(167, 24);
            this.cmbCliente.TabIndex = 17;
            // 
            // lblEmpleado
            // 
            this.lblEmpleado.AutoSize = true;
            this.lblEmpleado.Depth = 0;
            this.lblEmpleado.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblEmpleado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblEmpleado.Location = new System.Drawing.Point(23, 97);
            this.lblEmpleado.Margin = new System.Windows.Forms.Padding(3, 3, 3, 20);
            this.lblEmpleado.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblEmpleado.Name = "lblEmpleado";
            this.lblEmpleado.Size = new System.Drawing.Size(96, 24);
            this.lblEmpleado.TabIndex = 20;
            this.lblEmpleado.Text = "Empleado";
            // 
            // cmbEmpleado
            // 
            this.cmbEmpleado.FormattingEnabled = true;
            this.cmbEmpleado.Location = new System.Drawing.Point(140, 97);
            this.cmbEmpleado.Margin = new System.Windows.Forms.Padding(18, 3, 3, 3);
            this.cmbEmpleado.Name = "cmbEmpleado";
            this.cmbEmpleado.Size = new System.Drawing.Size(167, 24);
            this.cmbEmpleado.TabIndex = 19;
            // 
            // txtDescuento
            // 
            this.txtDescuento.Depth = 0;
            this.txtDescuento.Hint = "Descuento";
            this.txtDescuento.Location = new System.Drawing.Point(23, 144);
            this.txtDescuento.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.txtDescuento.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtDescuento.Name = "txtDescuento";
            this.txtDescuento.PasswordChar = '\0';
            this.txtDescuento.SelectedText = "";
            this.txtDescuento.SelectionLength = 0;
            this.txtDescuento.SelectionStart = 0;
            this.txtDescuento.Size = new System.Drawing.Size(211, 28);
            this.txtDescuento.TabIndex = 2;
            this.txtDescuento.UseSystemPasswordChar = false;
            // 
            // txtTotalIva
            // 
            this.txtTotalIva.Depth = 0;
            this.txtTotalIva.Hint = "Total Iva";
            this.txtTotalIva.Location = new System.Drawing.Point(23, 185);
            this.txtTotalIva.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.txtTotalIva.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtTotalIva.Name = "txtTotalIva";
            this.txtTotalIva.PasswordChar = '\0';
            this.txtTotalIva.SelectedText = "";
            this.txtTotalIva.SelectionLength = 0;
            this.txtTotalIva.SelectionStart = 0;
            this.txtTotalIva.Size = new System.Drawing.Size(211, 28);
            this.txtTotalIva.TabIndex = 3;
            this.txtTotalIva.UseSystemPasswordChar = false;
            // 
            // txtTotalFactura
            // 
            this.txtTotalFactura.Depth = 0;
            this.txtTotalFactura.Hint = "Total Factura";
            this.txtTotalFactura.Location = new System.Drawing.Point(23, 226);
            this.txtTotalFactura.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.txtTotalFactura.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtTotalFactura.Name = "txtTotalFactura";
            this.txtTotalFactura.PasswordChar = '\0';
            this.txtTotalFactura.SelectedText = "";
            this.txtTotalFactura.SelectionLength = 0;
            this.txtTotalFactura.SelectionStart = 0;
            this.txtTotalFactura.Size = new System.Drawing.Size(211, 28);
            this.txtTotalFactura.TabIndex = 4;
            this.txtTotalFactura.UseSystemPasswordChar = false;
            // 
            // txtIdFactura
            // 
            this.txtIdFactura.Location = new System.Drawing.Point(34, 120);
            this.txtIdFactura.Name = "txtIdFactura";
            this.txtIdFactura.ReadOnly = true;
            this.txtIdFactura.Size = new System.Drawing.Size(57, 22);
            this.txtIdFactura.TabIndex = 18;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Depth = 0;
            this.lblTitulo.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTitulo.Location = new System.Drawing.Point(116, 79);
            this.lblTitulo.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(160, 24);
            this.lblTitulo.TabIndex = 17;
            this.lblTitulo.Text = "EDITAR FACTURA";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.lblFechaFactura);
            this.flowLayoutPanel2.Controls.Add(this.dtpFechaFactura);
            this.flowLayoutPanel2.Controls.Add(this.lblEstadoFactura);
            this.flowLayoutPanel2.Controls.Add(this.cmbEstadoFactura);
            this.flowLayoutPanel2.Controls.Add(this.lblDetallesProducto);
            this.flowLayoutPanel2.Controls.Add(this.txtDetallesProducto);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(416, 152);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.flowLayoutPanel2.Size = new System.Drawing.Size(350, 214);
            this.flowLayoutPanel2.TabIndex = 22;
            // 
            // lblFechaFactura
            // 
            this.lblFechaFactura.AutoSize = true;
            this.lblFechaFactura.Depth = 0;
            this.lblFechaFactura.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblFechaFactura.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblFechaFactura.Location = new System.Drawing.Point(23, 3);
            this.lblFechaFactura.Margin = new System.Windows.Forms.Padding(3, 3, 3, 20);
            this.lblFechaFactura.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblFechaFactura.Name = "lblFechaFactura";
            this.lblFechaFactura.Size = new System.Drawing.Size(129, 24);
            this.lblFechaFactura.TabIndex = 14;
            this.lblFechaFactura.Text = "Fecha Factura";
            // 
            // dtpFechaFactura
            // 
            this.dtpFechaFactura.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFactura.Location = new System.Drawing.Point(158, 3);
            this.dtpFechaFactura.Name = "dtpFechaFactura";
            this.dtpFechaFactura.Size = new System.Drawing.Size(169, 22);
            this.dtpFechaFactura.TabIndex = 17;
            // 
            // lblEstadoFactura
            // 
            this.lblEstadoFactura.AutoSize = true;
            this.lblEstadoFactura.Depth = 0;
            this.lblEstadoFactura.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblEstadoFactura.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblEstadoFactura.Location = new System.Drawing.Point(23, 50);
            this.lblEstadoFactura.Margin = new System.Windows.Forms.Padding(3, 3, 3, 20);
            this.lblEstadoFactura.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblEstadoFactura.Name = "lblEstadoFactura";
            this.lblEstadoFactura.Size = new System.Drawing.Size(137, 24);
            this.lblEstadoFactura.TabIndex = 20;
            this.lblEstadoFactura.Text = "Estado Factura";
            // 
            // cmbEstadoFactura
            // 
            this.cmbEstadoFactura.FormattingEnabled = true;
            this.cmbEstadoFactura.Location = new System.Drawing.Point(181, 50);
            this.cmbEstadoFactura.Margin = new System.Windows.Forms.Padding(18, 3, 3, 3);
            this.cmbEstadoFactura.Name = "cmbEstadoFactura";
            this.cmbEstadoFactura.Size = new System.Drawing.Size(158, 24);
            this.cmbEstadoFactura.TabIndex = 19;
            // 
            // lblDetallesProducto
            // 
            this.lblDetallesProducto.AutoSize = true;
            this.lblDetallesProducto.Depth = 0;
            this.lblDetallesProducto.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDetallesProducto.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblDetallesProducto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblDetallesProducto.Location = new System.Drawing.Point(23, 97);
            this.lblDetallesProducto.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.lblDetallesProducto.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblDetallesProducto.Name = "lblDetallesProducto";
            this.lblDetallesProducto.Size = new System.Drawing.Size(136, 24);
            this.lblDetallesProducto.TabIndex = 15;
            this.lblDetallesProducto.Text = "Detalle Factura";
            // 
            // txtDetallesProducto
            // 
            this.txtDetallesProducto.Location = new System.Drawing.Point(23, 134);
            this.txtDetallesProducto.MinimumSize = new System.Drawing.Size(4, 4);
            this.txtDetallesProducto.Multiline = true;
            this.txtDetallesProducto.Name = "txtDetallesProducto";
            this.txtDetallesProducto.Size = new System.Drawing.Size(304, 45);
            this.txtDetallesProducto.TabIndex = 16;
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider1.ContainerControl = this;
            // 
            // frmEditarFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtIdFactura);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Name = "frmEditarFactura";
            this.Text = "Actualizar Factura";
            this.Load += new System.EventHandler(this.frmEditarFactura_Load);
            this.panel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
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
        private MaterialSkin.Controls.MaterialSingleLineTextField txtDescuento;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtTotalIva;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtTotalFactura;
        private System.Windows.Forms.TextBox txtIdFactura;
        private MaterialSkin.Controls.MaterialLabel lblTitulo;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private MaterialSkin.Controls.MaterialLabel lblFechaFactura;
        private MaterialSkin.Controls.MaterialLabel lblDetallesProducto;
        private System.Windows.Forms.TextBox txtDetallesProducto;
        private MaterialSkin.Controls.MaterialLabel lblNumeroFactura;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtNumeroFactura;
        private MaterialSkin.Controls.MaterialLabel lblCliente;
        private System.Windows.Forms.ComboBox cmbCliente;
        private MaterialSkin.Controls.MaterialLabel lblEmpleado;
        private System.Windows.Forms.ComboBox cmbEmpleado;
        private System.Windows.Forms.DateTimePicker dtpFechaFactura;
        private MaterialSkin.Controls.MaterialLabel lblEstadoFactura;
        private System.Windows.Forms.ComboBox cmbEstadoFactura;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}