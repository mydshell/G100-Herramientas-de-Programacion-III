namespace Pantallas_Sistema_facturación
{
    partial class frmEditarEmpleado
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
            this.txtNombreEmpleado = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txtDocumento = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txtDireccion = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txtTelefono = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txtEmail = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txtIdEmpleado = new System.Windows.Forms.TextBox();
            this.lblTitulo = new MaterialSkin.Controls.MaterialLabel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblRolEmpleado = new MaterialSkin.Controls.MaterialLabel();
            this.cmbRolEmpleado = new System.Windows.Forms.ComboBox();
            this.lblFechaIngreso = new MaterialSkin.Controls.MaterialLabel();
            this.dtpFechaIngreso = new System.Windows.Forms.DateTimePicker();
            this.lblFechaRetiro = new MaterialSkin.Controls.MaterialLabel();
            this.dtpFechaRetiro = new System.Windows.Forms.DateTimePicker();
            this.lblDatoAdicional = new MaterialSkin.Controls.MaterialLabel();
            this.txtDatoAdicional = new System.Windows.Forms.TextBox();
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
            this.btnSalir.Location = new System.Drawing.Point(686, 108);
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
            this.btnActualizar.Location = new System.Drawing.Point(553, 108);
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
            this.panel1.Location = new System.Drawing.Point(35, 158);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(364, 260);
            this.panel1.TabIndex = 7;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.txtNombreEmpleado);
            this.flowLayoutPanel1.Controls.Add(this.txtDocumento);
            this.flowLayoutPanel1.Controls.Add(this.txtDireccion);
            this.flowLayoutPanel1.Controls.Add(this.txtTelefono);
            this.flowLayoutPanel1.Controls.Add(this.txtEmail);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(361, 260);
            this.flowLayoutPanel1.TabIndex = 5;
            // 
            // txtNombreEmpleado
            // 
            this.txtNombreEmpleado.Depth = 0;
            this.txtNombreEmpleado.Hint = "Nombre Empleado";
            this.txtNombreEmpleado.Location = new System.Drawing.Point(23, 3);
            this.txtNombreEmpleado.Margin = new System.Windows.Forms.Padding(3, 3, 3, 25);
            this.txtNombreEmpleado.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtNombreEmpleado.Name = "txtNombreEmpleado";
            this.txtNombreEmpleado.PasswordChar = '\0';
            this.txtNombreEmpleado.SelectedText = "";
            this.txtNombreEmpleado.SelectionLength = 0;
            this.txtNombreEmpleado.SelectionStart = 0;
            this.txtNombreEmpleado.Size = new System.Drawing.Size(307, 28);
            this.txtNombreEmpleado.TabIndex = 0;
            this.txtNombreEmpleado.UseSystemPasswordChar = false;
            // 
            // txtDocumento
            // 
            this.txtDocumento.Depth = 0;
            this.txtDocumento.Hint = "Documento";
            this.txtDocumento.Location = new System.Drawing.Point(23, 59);
            this.txtDocumento.Margin = new System.Windows.Forms.Padding(3, 3, 3, 25);
            this.txtDocumento.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtDocumento.Name = "txtDocumento";
            this.txtDocumento.PasswordChar = '\0';
            this.txtDocumento.SelectedText = "";
            this.txtDocumento.SelectionLength = 0;
            this.txtDocumento.SelectionStart = 0;
            this.txtDocumento.Size = new System.Drawing.Size(211, 28);
            this.txtDocumento.TabIndex = 1;
            this.txtDocumento.UseSystemPasswordChar = false;
            // 
            // txtDireccion
            // 
            this.txtDireccion.Depth = 0;
            this.txtDireccion.Hint = "Dirección";
            this.txtDireccion.Location = new System.Drawing.Point(23, 115);
            this.txtDireccion.Margin = new System.Windows.Forms.Padding(3, 3, 3, 25);
            this.txtDireccion.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.PasswordChar = '\0';
            this.txtDireccion.SelectedText = "";
            this.txtDireccion.SelectionLength = 0;
            this.txtDireccion.SelectionStart = 0;
            this.txtDireccion.Size = new System.Drawing.Size(307, 28);
            this.txtDireccion.TabIndex = 2;
            this.txtDireccion.UseSystemPasswordChar = false;
            // 
            // txtTelefono
            // 
            this.txtTelefono.Depth = 0;
            this.txtTelefono.Hint = "Teléfono";
            this.txtTelefono.Location = new System.Drawing.Point(23, 171);
            this.txtTelefono.Margin = new System.Windows.Forms.Padding(3, 3, 3, 25);
            this.txtTelefono.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.PasswordChar = '\0';
            this.txtTelefono.SelectedText = "";
            this.txtTelefono.SelectionLength = 0;
            this.txtTelefono.SelectionStart = 0;
            this.txtTelefono.Size = new System.Drawing.Size(211, 28);
            this.txtTelefono.TabIndex = 3;
            this.txtTelefono.UseSystemPasswordChar = false;
            // 
            // txtEmail
            // 
            this.txtEmail.Depth = 0;
            this.txtEmail.Hint = "Email";
            this.txtEmail.Location = new System.Drawing.Point(23, 227);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(3, 3, 3, 25);
            this.txtEmail.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.PasswordChar = '\0';
            this.txtEmail.SelectedText = "";
            this.txtEmail.SelectionLength = 0;
            this.txtEmail.SelectionStart = 0;
            this.txtEmail.Size = new System.Drawing.Size(307, 28);
            this.txtEmail.TabIndex = 4;
            this.txtEmail.UseSystemPasswordChar = false;
            // 
            // txtIdEmpleado
            // 
            this.txtIdEmpleado.Location = new System.Drawing.Point(34, 126);
            this.txtIdEmpleado.Name = "txtIdEmpleado";
            this.txtIdEmpleado.ReadOnly = true;
            this.txtIdEmpleado.Size = new System.Drawing.Size(57, 22);
            this.txtIdEmpleado.TabIndex = 6;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Depth = 0;
            this.lblTitulo.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTitulo.Location = new System.Drawing.Point(116, 85);
            this.lblTitulo.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(176, 24);
            this.lblTitulo.TabIndex = 5;
            this.lblTitulo.Text = "EDITAR EMPLEADO";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.lblRolEmpleado);
            this.flowLayoutPanel2.Controls.Add(this.cmbRolEmpleado);
            this.flowLayoutPanel2.Controls.Add(this.lblFechaIngreso);
            this.flowLayoutPanel2.Controls.Add(this.dtpFechaIngreso);
            this.flowLayoutPanel2.Controls.Add(this.lblFechaRetiro);
            this.flowLayoutPanel2.Controls.Add(this.dtpFechaRetiro);
            this.flowLayoutPanel2.Controls.Add(this.lblDatoAdicional);
            this.flowLayoutPanel2.Controls.Add(this.txtDatoAdicional);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(405, 158);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.flowLayoutPanel2.Size = new System.Drawing.Size(361, 260);
            this.flowLayoutPanel2.TabIndex = 10;
            // 
            // lblRolEmpleado
            // 
            this.lblRolEmpleado.AutoSize = true;
            this.lblRolEmpleado.Depth = 0;
            this.lblRolEmpleado.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblRolEmpleado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblRolEmpleado.Location = new System.Drawing.Point(23, 3);
            this.lblRolEmpleado.Margin = new System.Windows.Forms.Padding(3, 3, 3, 20);
            this.lblRolEmpleado.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblRolEmpleado.Name = "lblRolEmpleado";
            this.lblRolEmpleado.Size = new System.Drawing.Size(129, 24);
            this.lblRolEmpleado.TabIndex = 23;
            this.lblRolEmpleado.Text = "Rol Empleado";
            // 
            // cmbRolEmpleado
            // 
            this.cmbRolEmpleado.FormattingEnabled = true;
            this.cmbRolEmpleado.Location = new System.Drawing.Point(173, 3);
            this.cmbRolEmpleado.Margin = new System.Windows.Forms.Padding(18, 3, 3, 3);
            this.cmbRolEmpleado.Name = "cmbRolEmpleado";
            this.cmbRolEmpleado.Size = new System.Drawing.Size(167, 24);
            this.cmbRolEmpleado.TabIndex = 22;
            // 
            // lblFechaIngreso
            // 
            this.lblFechaIngreso.AutoSize = true;
            this.lblFechaIngreso.Depth = 0;
            this.lblFechaIngreso.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblFechaIngreso.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblFechaIngreso.Location = new System.Drawing.Point(23, 50);
            this.lblFechaIngreso.Margin = new System.Windows.Forms.Padding(3, 3, 3, 20);
            this.lblFechaIngreso.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblFechaIngreso.Name = "lblFechaIngreso";
            this.lblFechaIngreso.Size = new System.Drawing.Size(129, 24);
            this.lblFechaIngreso.TabIndex = 18;
            this.lblFechaIngreso.Text = "Fecha Ingreso";
            // 
            // dtpFechaIngreso
            // 
            this.dtpFechaIngreso.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaIngreso.Location = new System.Drawing.Point(158, 50);
            this.dtpFechaIngreso.Name = "dtpFechaIngreso";
            this.dtpFechaIngreso.Size = new System.Drawing.Size(169, 22);
            this.dtpFechaIngreso.TabIndex = 19;
            // 
            // lblFechaRetiro
            // 
            this.lblFechaRetiro.AutoSize = true;
            this.lblFechaRetiro.Depth = 0;
            this.lblFechaRetiro.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblFechaRetiro.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblFechaRetiro.Location = new System.Drawing.Point(23, 97);
            this.lblFechaRetiro.Margin = new System.Windows.Forms.Padding(3, 3, 3, 20);
            this.lblFechaRetiro.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblFechaRetiro.Name = "lblFechaRetiro";
            this.lblFechaRetiro.Size = new System.Drawing.Size(116, 24);
            this.lblFechaRetiro.TabIndex = 20;
            this.lblFechaRetiro.Text = "Fecha Retiro";
            // 
            // dtpFechaRetiro
            // 
            this.dtpFechaRetiro.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaRetiro.Location = new System.Drawing.Point(145, 97);
            this.dtpFechaRetiro.Name = "dtpFechaRetiro";
            this.dtpFechaRetiro.Size = new System.Drawing.Size(169, 22);
            this.dtpFechaRetiro.TabIndex = 21;
            // 
            // lblDatoAdicional
            // 
            this.lblDatoAdicional.AutoSize = true;
            this.lblDatoAdicional.Depth = 0;
            this.lblDatoAdicional.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDatoAdicional.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblDatoAdicional.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblDatoAdicional.Location = new System.Drawing.Point(23, 144);
            this.lblDatoAdicional.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.lblDatoAdicional.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblDatoAdicional.Name = "lblDatoAdicional";
            this.lblDatoAdicional.Size = new System.Drawing.Size(191, 24);
            this.lblDatoAdicional.TabIndex = 24;
            this.lblDatoAdicional.Text = "DATOS ADICIONALES";
            // 
            // txtDatoAdicional
            // 
            this.txtDatoAdicional.Location = new System.Drawing.Point(23, 181);
            this.txtDatoAdicional.MinimumSize = new System.Drawing.Size(4, 4);
            this.txtDatoAdicional.Multiline = true;
            this.txtDatoAdicional.Name = "txtDatoAdicional";
            this.txtDatoAdicional.Size = new System.Drawing.Size(304, 63);
            this.txtDatoAdicional.TabIndex = 25;
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider1.ContainerControl = this;
            // 
            // frmEditarEmpleado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtIdEmpleado);
            this.Controls.Add(this.lblTitulo);
            this.Name = "frmEditarEmpleado";
            this.Text = "Actualizar Empleado";
            this.Load += new System.EventHandler(this.frmEditarEmpleado_Load);
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
        private MaterialSkin.Controls.MaterialSingleLineTextField txtNombreEmpleado;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtDocumento;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtDireccion;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtTelefono;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtEmail;
        private System.Windows.Forms.TextBox txtIdEmpleado;
        private MaterialSkin.Controls.MaterialLabel lblTitulo;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private MaterialSkin.Controls.MaterialLabel lblFechaIngreso;
        private System.Windows.Forms.DateTimePicker dtpFechaIngreso;
        private MaterialSkin.Controls.MaterialLabel lblFechaRetiro;
        private System.Windows.Forms.DateTimePicker dtpFechaRetiro;
        private MaterialSkin.Controls.MaterialLabel lblRolEmpleado;
        private System.Windows.Forms.ComboBox cmbRolEmpleado;
        private MaterialSkin.Controls.MaterialLabel lblDatoAdicional;
        private System.Windows.Forms.TextBox txtDatoAdicional;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}