namespace Pantallas_Sistema_facturación
{
    partial class frmGenerarInforme
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
            this.btnGenerar = new MaterialSkin.Controls.MaterialRaisedButton();
            this.lblSeleccioneInforme = new MaterialSkin.Controls.MaterialLabel();
            this.cmbTipoInforme = new System.Windows.Forms.ComboBox();
            this.txtIdInforme = new System.Windows.Forms.TextBox();
            this.lblTitulo = new MaterialSkin.Controls.MaterialLabel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblOrdenado = new MaterialSkin.Controls.MaterialLabel();
            this.cmbOrdenado = new System.Windows.Forms.ComboBox();
            this.lblFechaInicial = new MaterialSkin.Controls.MaterialLabel();
            this.dtpFechaInicial = new System.Windows.Forms.DateTimePicker();
            this.lblFechaFinal = new MaterialSkin.Controls.MaterialLabel();
            this.dtpFechaFinal = new System.Windows.Forms.DateTimePicker();
            this.mrbExcel = new MaterialSkin.Controls.MaterialRadioButton();
            this.mrbEnPantalla = new MaterialSkin.Controls.MaterialRadioButton();
            this.pnlInformeVista = new System.Windows.Forms.Panel();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSalir
            // 
            this.btnSalir.Depth = 0;
            this.btnSalir.Location = new System.Drawing.Point(683, 96);
            this.btnSalir.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Primary = true;
            this.btnSalir.Size = new System.Drawing.Size(80, 40);
            this.btnSalir.TabIndex = 27;
            this.btnSalir.Text = "SALIR";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnGenerar
            // 
            this.btnGenerar.Depth = 0;
            this.btnGenerar.Location = new System.Drawing.Point(550, 96);
            this.btnGenerar.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Primary = true;
            this.btnGenerar.Size = new System.Drawing.Size(119, 40);
            this.btnGenerar.TabIndex = 26;
            this.btnGenerar.Text = "GENERAR";
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // lblSeleccioneInforme
            // 
            this.lblSeleccioneInforme.AutoSize = true;
            this.lblSeleccioneInforme.Depth = 0;
            this.lblSeleccioneInforme.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblSeleccioneInforme.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblSeleccioneInforme.Location = new System.Drawing.Point(23, 3);
            this.lblSeleccioneInforme.Margin = new System.Windows.Forms.Padding(3, 3, 3, 20);
            this.lblSeleccioneInforme.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblSeleccioneInforme.Name = "lblSeleccioneInforme";
            this.lblSeleccioneInforme.Size = new System.Drawing.Size(208, 24);
            this.lblSeleccioneInforme.TabIndex = 18;
            this.lblSeleccioneInforme.Text = "SELECCIONE INFORME";
            // 
            // cmbTipoInforme
            // 
            this.cmbTipoInforme.FormattingEnabled = true;
            this.cmbTipoInforme.Location = new System.Drawing.Point(252, 3);
            this.cmbTipoInforme.Margin = new System.Windows.Forms.Padding(18, 3, 3, 3);
            this.cmbTipoInforme.Name = "cmbTipoInforme";
            this.cmbTipoInforme.Size = new System.Drawing.Size(146, 24);
            this.cmbTipoInforme.TabIndex = 17;
            // 
            // txtIdInforme
            // 
            this.txtIdInforme.Location = new System.Drawing.Point(34, 120);
            this.txtIdInforme.Name = "txtIdInforme";
            this.txtIdInforme.ReadOnly = true;
            this.txtIdInforme.Size = new System.Drawing.Size(57, 22);
            this.txtIdInforme.TabIndex = 24;
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
            this.lblTitulo.Size = new System.Drawing.Size(236, 24);
            this.lblTitulo.TabIndex = 23;
            this.lblTitulo.Text = "GENERADOR DE INFORME";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.lblSeleccioneInforme);
            this.flowLayoutPanel2.Controls.Add(this.cmbTipoInforme);
            this.flowLayoutPanel2.Controls.Add(this.lblOrdenado);
            this.flowLayoutPanel2.Controls.Add(this.cmbOrdenado);
            this.flowLayoutPanel2.Controls.Add(this.lblFechaInicial);
            this.flowLayoutPanel2.Controls.Add(this.dtpFechaInicial);
            this.flowLayoutPanel2.Controls.Add(this.lblFechaFinal);
            this.flowLayoutPanel2.Controls.Add(this.dtpFechaFinal);
            this.flowLayoutPanel2.Controls.Add(this.mrbExcel);
            this.flowLayoutPanel2.Controls.Add(this.mrbEnPantalla);
            this.flowLayoutPanel2.Controls.Add(this.pnlInformeVista);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(34, 152);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.flowLayoutPanel2.Size = new System.Drawing.Size(740, 272);
            this.flowLayoutPanel2.TabIndex = 28;
            this.flowLayoutPanel2.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel2_Paint);
            // 
            // lblOrdenado
            // 
            this.lblOrdenado.AutoSize = true;
            this.lblOrdenado.Depth = 0;
            this.lblOrdenado.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblOrdenado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblOrdenado.Location = new System.Drawing.Point(404, 3);
            this.lblOrdenado.Margin = new System.Windows.Forms.Padding(3, 3, 3, 20);
            this.lblOrdenado.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblOrdenado.Name = "lblOrdenado";
            this.lblOrdenado.Size = new System.Drawing.Size(125, 24);
            this.lblOrdenado.TabIndex = 20;
            this.lblOrdenado.Text = "Ordenado por";
            // 
            // cmbOrdenado
            // 
            this.cmbOrdenado.FormattingEnabled = true;
            this.cmbOrdenado.Location = new System.Drawing.Point(550, 3);
            this.cmbOrdenado.Margin = new System.Windows.Forms.Padding(18, 3, 3, 3);
            this.cmbOrdenado.Name = "cmbOrdenado";
            this.cmbOrdenado.Size = new System.Drawing.Size(145, 24);
            this.cmbOrdenado.TabIndex = 19;
            // 
            // lblFechaInicial
            // 
            this.lblFechaInicial.AutoSize = true;
            this.lblFechaInicial.Depth = 0;
            this.lblFechaInicial.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblFechaInicial.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblFechaInicial.Location = new System.Drawing.Point(23, 50);
            this.lblFechaInicial.Margin = new System.Windows.Forms.Padding(3, 3, 3, 20);
            this.lblFechaInicial.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblFechaInicial.Name = "lblFechaInicial";
            this.lblFechaInicial.Size = new System.Drawing.Size(116, 24);
            this.lblFechaInicial.TabIndex = 14;
            this.lblFechaInicial.Text = "Fecha Inicial";
            // 
            // dtpFechaInicial
            // 
            this.dtpFechaInicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaInicial.Location = new System.Drawing.Point(145, 50);
            this.dtpFechaInicial.Name = "dtpFechaInicial";
            this.dtpFechaInicial.Size = new System.Drawing.Size(169, 22);
            this.dtpFechaInicial.TabIndex = 17;
            // 
            // lblFechaFinal
            // 
            this.lblFechaFinal.AutoSize = true;
            this.lblFechaFinal.Depth = 0;
            this.lblFechaFinal.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblFechaFinal.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblFechaFinal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblFechaFinal.Location = new System.Drawing.Point(320, 50);
            this.lblFechaFinal.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.lblFechaFinal.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblFechaFinal.Name = "lblFechaFinal";
            this.lblFechaFinal.Size = new System.Drawing.Size(107, 24);
            this.lblFechaFinal.TabIndex = 15;
            this.lblFechaFinal.Text = "Fecha Final";
            // 
            // dtpFechaFinal
            // 
            this.dtpFechaFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFinal.Location = new System.Drawing.Point(433, 50);
            this.dtpFechaFinal.Margin = new System.Windows.Forms.Padding(3, 3, 100, 3);
            this.dtpFechaFinal.Name = "dtpFechaFinal";
            this.dtpFechaFinal.Size = new System.Drawing.Size(169, 22);
            this.dtpFechaFinal.TabIndex = 21;
            // 
            // mrbExcel
            // 
            this.mrbExcel.AutoSize = true;
            this.mrbExcel.Depth = 0;
            this.mrbExcel.Font = new System.Drawing.Font("Roboto", 10F);
            this.mrbExcel.Location = new System.Drawing.Point(20, 94);
            this.mrbExcel.Margin = new System.Windows.Forms.Padding(0);
            this.mrbExcel.MouseLocation = new System.Drawing.Point(-1, -1);
            this.mrbExcel.MouseState = MaterialSkin.MouseState.HOVER;
            this.mrbExcel.Name = "mrbExcel";
            this.mrbExcel.Ripple = true;
            this.mrbExcel.Size = new System.Drawing.Size(71, 30);
            this.mrbExcel.TabIndex = 23;
            this.mrbExcel.TabStop = true;
            this.mrbExcel.Text = "Excel";
            this.mrbExcel.UseVisualStyleBackColor = true;
            // 
            // mrbEnPantalla
            // 
            this.mrbEnPantalla.AutoSize = true;
            this.mrbEnPantalla.Depth = 0;
            this.mrbEnPantalla.Font = new System.Drawing.Font("Roboto", 10F);
            this.mrbEnPantalla.Location = new System.Drawing.Point(91, 94);
            this.mrbEnPantalla.Margin = new System.Windows.Forms.Padding(0);
            this.mrbEnPantalla.MouseLocation = new System.Drawing.Point(-1, -1);
            this.mrbEnPantalla.MouseState = MaterialSkin.MouseState.HOVER;
            this.mrbEnPantalla.Name = "mrbEnPantalla";
            this.mrbEnPantalla.Ripple = true;
            this.mrbEnPantalla.Size = new System.Drawing.Size(116, 30);
            this.mrbEnPantalla.TabIndex = 22;
            this.mrbEnPantalla.TabStop = true;
            this.mrbEnPantalla.Text = "En Pantalla";
            this.mrbEnPantalla.UseVisualStyleBackColor = true;
            // 
            // pnlInformeVista
            // 
            this.pnlInformeVista.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.pnlInformeVista.Location = new System.Drawing.Point(23, 127);
            this.pnlInformeVista.Name = "pnlInformeVista";
            this.pnlInformeVista.Size = new System.Drawing.Size(693, 116);
            this.pnlInformeVista.TabIndex = 24;
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider1.ContainerControl = this;
            // 
            // frmGenerarInforme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnGenerar);
            this.Controls.Add(this.txtIdInforme);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Name = "frmGenerarInforme";
            this.Text = "Generar Informe";
            this.Load += new System.EventHandler(this.frmGenerarInforme_Load);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialRaisedButton btnSalir;
        private MaterialSkin.Controls.MaterialRaisedButton btnGenerar;
        private MaterialSkin.Controls.MaterialLabel lblSeleccioneInforme;
        private System.Windows.Forms.ComboBox cmbTipoInforme;
        private System.Windows.Forms.TextBox txtIdInforme;
        private MaterialSkin.Controls.MaterialLabel lblTitulo;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private MaterialSkin.Controls.MaterialLabel lblFechaInicial;
        private System.Windows.Forms.DateTimePicker dtpFechaInicial;
        private MaterialSkin.Controls.MaterialLabel lblOrdenado;
        private System.Windows.Forms.ComboBox cmbOrdenado;
        private MaterialSkin.Controls.MaterialLabel lblFechaFinal;
        private System.Windows.Forms.DateTimePicker dtpFechaFinal;
        private MaterialSkin.Controls.MaterialRadioButton mrbExcel;
        private MaterialSkin.Controls.MaterialRadioButton mrbEnPantalla;
        private System.Windows.Forms.Panel pnlInformeVista;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}