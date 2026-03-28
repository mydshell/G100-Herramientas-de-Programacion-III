namespace Pantallas_Sistema_facturación
{
    partial class frmListaInformes
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
            this.lblTitulo = new MaterialSkin.Controls.MaterialLabel();
            this.dgInformes = new System.Windows.Forms.DataGridView();
            this.Id_Informe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.strTipoInforme = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.strOrdenado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.strVisualizado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnEditar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnBorrar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnSalir = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnBuscar = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnNuevo = new MaterialSkin.Controls.MaterialRaisedButton();
            this.txtBuscar = new MaterialSkin.Controls.MaterialSingleLineTextField();
            ((System.ComponentModel.ISupportInitialize)(this.dgInformes)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Depth = 0;
            this.lblTitulo.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTitulo.Location = new System.Drawing.Point(266, 48);
            this.lblTitulo.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(292, 24);
            this.lblTitulo.TabIndex = 2;
            this.lblTitulo.Text = "ADMINISTRACIÓN DE INFORMES";
            // 
            // dgInformes
            // 
            this.dgInformes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgInformes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id_Informe,
            this.strTipoInforme,
            this.strOrdenado,
            this.strVisualizado,
            this.btnEditar,
            this.btnBorrar});
            this.dgInformes.Location = new System.Drawing.Point(38, 134);
            this.dgInformes.Name = "dgInformes";
            this.dgInformes.RowHeadersWidth = 51;
            this.dgInformes.RowTemplate.Height = 24;
            this.dgInformes.Size = new System.Drawing.Size(722, 257);
            this.dgInformes.TabIndex = 21;
            this.dgInformes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgInformes_CellContentClick);
            // 
            // Id_Informe
            // 
            this.Id_Informe.HeaderText = "ID";
            this.Id_Informe.MinimumWidth = 6;
            this.Id_Informe.Name = "Id_Informe";
            this.Id_Informe.Width = 80;
            // 
            // strTipoInforme
            // 
            this.strTipoInforme.HeaderText = "TIPO INFORME";
            this.strTipoInforme.MinimumWidth = 6;
            this.strTipoInforme.Name = "strTipoInforme";
            this.strTipoInforme.Width = 240;
            // 
            // strOrdenado
            // 
            this.strOrdenado.HeaderText = "ORDENADO";
            this.strOrdenado.MinimumWidth = 6;
            this.strOrdenado.Name = "strOrdenado";
            this.strOrdenado.Width = 125;
            // 
            // strVisualizado
            // 
            this.strVisualizado.HeaderText = "VISUALIZADO";
            this.strVisualizado.MinimumWidth = 6;
            this.strVisualizado.Name = "strVisualizado";
            this.strVisualizado.Width = 125;
            // 
            // btnEditar
            // 
            this.btnEditar.HeaderText = "EDITAR";
            this.btnEditar.MinimumWidth = 6;
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Text = "EDITAR";
            this.btnEditar.UseColumnTextForButtonValue = true;
            this.btnEditar.Width = 80;
            // 
            // btnBorrar
            // 
            this.btnBorrar.HeaderText = "BORRAR";
            this.btnBorrar.MinimumWidth = 6;
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Text = "BORRAR";
            this.btnBorrar.UseColumnTextForButtonValue = true;
            this.btnBorrar.Width = 80;
            // 
            // btnSalir
            // 
            this.btnSalir.Depth = 0;
            this.btnSalir.Location = new System.Drawing.Point(680, 397);
            this.btnSalir.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Primary = true;
            this.btnSalir.Size = new System.Drawing.Size(80, 40);
            this.btnSalir.TabIndex = 20;
            this.btnSalir.Text = "SALIR";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.BlueViolet;
            this.btnBuscar.Depth = 0;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Location = new System.Drawing.Point(544, 78);
            this.btnBuscar.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Primary = true;
            this.btnBuscar.Size = new System.Drawing.Size(80, 40);
            this.btnBuscar.TabIndex = 19;
            this.btnBuscar.Text = "BUSCAR";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Depth = 0;
            this.btnNuevo.Location = new System.Drawing.Point(680, 77);
            this.btnNuevo.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Primary = true;
            this.btnNuevo.Size = new System.Drawing.Size(80, 40);
            this.btnNuevo.TabIndex = 18;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // txtBuscar
            // 
            this.txtBuscar.Depth = 0;
            this.txtBuscar.Hint = "Buscar por Informe";
            this.txtBuscar.Location = new System.Drawing.Point(43, 89);
            this.txtBuscar.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.PasswordChar = '\0';
            this.txtBuscar.SelectedText = "";
            this.txtBuscar.SelectionLength = 0;
            this.txtBuscar.SelectionStart = 0;
            this.txtBuscar.Size = new System.Drawing.Size(452, 28);
            this.txtBuscar.TabIndex = 17;
            this.txtBuscar.UseSystemPasswordChar = false;
            // 
            // frmListaInformes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgInformes);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.lblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmListaInformes";
            this.Text = "frmListaInformes";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmListaInformes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgInformes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel lblTitulo;
        private System.Windows.Forms.DataGridView dgInformes;
        private MaterialSkin.Controls.MaterialRaisedButton btnSalir;
        private MaterialSkin.Controls.MaterialRaisedButton btnBuscar;
        private MaterialSkin.Controls.MaterialRaisedButton btnNuevo;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtBuscar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id_Informe;
        private System.Windows.Forms.DataGridViewTextBoxColumn strTipoInforme;
        private System.Windows.Forms.DataGridViewTextBoxColumn strOrdenado;
        private System.Windows.Forms.DataGridViewTextBoxColumn strVisualizado;
        private System.Windows.Forms.DataGridViewButtonColumn btnEditar;
        private System.Windows.Forms.DataGridViewButtonColumn btnBorrar;
    }
}