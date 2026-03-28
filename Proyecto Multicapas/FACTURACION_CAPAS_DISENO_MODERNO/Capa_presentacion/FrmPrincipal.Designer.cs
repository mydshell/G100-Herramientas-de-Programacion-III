namespace Pantallas_Sistema_facturación
{
    partial class FrmPrincipal
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
            this.PnlPrincipal = new System.Windows.Forms.Panel();
            this.PnlMenu = new System.Windows.Forms.Panel();
            this.TbpMenu = new MaterialSkin.Controls.MaterialTabControl();
            this.principal = new System.Windows.Forms.TabPage();
            this.tablas = new System.Windows.Forms.TabPage();
            this.facturacion = new System.Windows.Forms.TabPage();
            this.seguridad = new System.Windows.Forms.TabPage();
            this.ayuda = new System.Windows.Forms.TabPage();
            this.tabOpcionesMenu = new MaterialSkin.Controls.MaterialTabSelector();
            this.pnlContenedor = new System.Windows.Forms.Panel();
            this.plnContenedor = new System.Windows.Forms.Panel();
            this.btnSalir = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnCategorias = new System.Windows.Forms.Button();
            this.btnProductos = new System.Windows.Forms.Button();
            this.btnClientes = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnInformes = new System.Windows.Forms.Button();
            this.btnFacturas = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.btnSeguridad = new System.Windows.Forms.Button();
            this.btnRoles = new System.Windows.Forms.Button();
            this.btnEmpleados = new System.Windows.Forms.Button();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.btnAcercaDe = new System.Windows.Forms.Button();
            this.btnAyuda = new System.Windows.Forms.Button();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.PnlPrincipal.SuspendLayout();
            this.PnlMenu.SuspendLayout();
            this.TbpMenu.SuspendLayout();
            this.principal.SuspendLayout();
            this.tablas.SuspendLayout();
            this.facturacion.SuspendLayout();
            this.seguridad.SuspendLayout();
            this.ayuda.SuspendLayout();
            this.pnlContenedor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.SuspendLayout();
            // 
            // PnlPrincipal
            // 
            this.PnlPrincipal.Controls.Add(this.pnlContenedor);
            this.PnlPrincipal.Controls.Add(this.PnlMenu);
            this.PnlPrincipal.Location = new System.Drawing.Point(1, 65);
            this.PnlPrincipal.Name = "PnlPrincipal";
            this.PnlPrincipal.Size = new System.Drawing.Size(1198, 585);
            this.PnlPrincipal.TabIndex = 0;
            this.PnlPrincipal.Paint += new System.Windows.Forms.PaintEventHandler(this.PnlPrincipal_Paint);
            // 
            // PnlMenu
            // 
            this.PnlMenu.BackColor = System.Drawing.Color.MediumPurple;
            this.PnlMenu.Controls.Add(this.TbpMenu);
            this.PnlMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.PnlMenu.Location = new System.Drawing.Point(0, 0);
            this.PnlMenu.Name = "PnlMenu";
            this.PnlMenu.Size = new System.Drawing.Size(300, 585);
            this.PnlMenu.TabIndex = 0;
            // 
            // TbpMenu
            // 
            this.TbpMenu.Controls.Add(this.principal);
            this.TbpMenu.Controls.Add(this.tablas);
            this.TbpMenu.Controls.Add(this.facturacion);
            this.TbpMenu.Controls.Add(this.seguridad);
            this.TbpMenu.Controls.Add(this.ayuda);
            this.TbpMenu.Depth = 0;
            this.TbpMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TbpMenu.Location = new System.Drawing.Point(0, 0);
            this.TbpMenu.MouseState = MaterialSkin.MouseState.HOVER;
            this.TbpMenu.Name = "TbpMenu";
            this.TbpMenu.SelectedIndex = 0;
            this.TbpMenu.Size = new System.Drawing.Size(300, 585);
            this.TbpMenu.TabIndex = 1;
            // 
            // principal
            // 
            this.principal.BackColor = System.Drawing.Color.Plum;
            this.principal.Controls.Add(this.btnSalir);
            this.principal.Controls.Add(this.pictureBox1);
            this.principal.Location = new System.Drawing.Point(4, 25);
            this.principal.Name = "principal";
            this.principal.Padding = new System.Windows.Forms.Padding(3);
            this.principal.Size = new System.Drawing.Size(292, 556);
            this.principal.TabIndex = 0;
            this.principal.Text = "Principal";
            this.principal.Click += new System.EventHandler(this.Principal_Click);
            // 
            // tablas
            // 
            this.tablas.BackColor = System.Drawing.Color.Plum;
            this.tablas.Controls.Add(this.btnCategorias);
            this.tablas.Controls.Add(this.btnProductos);
            this.tablas.Controls.Add(this.btnClientes);
            this.tablas.Controls.Add(this.pictureBox2);
            this.tablas.Location = new System.Drawing.Point(4, 25);
            this.tablas.Name = "tablas";
            this.tablas.Padding = new System.Windows.Forms.Padding(3);
            this.tablas.Size = new System.Drawing.Size(292, 556);
            this.tablas.TabIndex = 1;
            this.tablas.Text = "Admin Tablas";
            this.tablas.Click += new System.EventHandler(this.Tablas_Click);
            // 
            // facturacion
            // 
            this.facturacion.BackColor = System.Drawing.Color.Plum;
            this.facturacion.Controls.Add(this.btnInformes);
            this.facturacion.Controls.Add(this.btnFacturas);
            this.facturacion.Controls.Add(this.pictureBox3);
            this.facturacion.Location = new System.Drawing.Point(4, 25);
            this.facturacion.Name = "facturacion";
            this.facturacion.Size = new System.Drawing.Size(292, 556);
            this.facturacion.TabIndex = 2;
            this.facturacion.Text = "Facturación";
            // 
            // seguridad
            // 
            this.seguridad.BackColor = System.Drawing.Color.Plum;
            this.seguridad.Controls.Add(this.btnSeguridad);
            this.seguridad.Controls.Add(this.btnRoles);
            this.seguridad.Controls.Add(this.btnEmpleados);
            this.seguridad.Controls.Add(this.pictureBox4);
            this.seguridad.Location = new System.Drawing.Point(4, 25);
            this.seguridad.Name = "seguridad";
            this.seguridad.Size = new System.Drawing.Size(292, 556);
            this.seguridad.TabIndex = 3;
            this.seguridad.Text = "Seguridad";
            // 
            // ayuda
            // 
            this.ayuda.BackColor = System.Drawing.Color.Plum;
            this.ayuda.Controls.Add(this.btnAcercaDe);
            this.ayuda.Controls.Add(this.btnAyuda);
            this.ayuda.Controls.Add(this.pictureBox5);
            this.ayuda.Location = new System.Drawing.Point(4, 25);
            this.ayuda.Name = "ayuda";
            this.ayuda.Size = new System.Drawing.Size(292, 556);
            this.ayuda.TabIndex = 4;
            this.ayuda.Text = "Ayuda";
            // 
            // tabOpcionesMenu
            // 
            this.tabOpcionesMenu.BaseTabControl = this.TbpMenu;
            this.tabOpcionesMenu.Depth = 0;
            this.tabOpcionesMenu.Location = new System.Drawing.Point(302, 31);
            this.tabOpcionesMenu.MouseState = MaterialSkin.MouseState.HOVER;
            this.tabOpcionesMenu.Name = "tabOpcionesMenu";
            this.tabOpcionesMenu.Size = new System.Drawing.Size(897, 23);
            this.tabOpcionesMenu.TabIndex = 1;
            this.tabOpcionesMenu.Click += new System.EventHandler(this.TabOpcionesMenu_Click);
            // 
            // pnlContenedor
            // 
            this.pnlContenedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlContenedor.Controls.Add(this.plnContenedor);
            this.pnlContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContenedor.Location = new System.Drawing.Point(300, 0);
            this.pnlContenedor.Name = "pnlContenedor";
            this.pnlContenedor.Size = new System.Drawing.Size(898, 585);
            this.pnlContenedor.TabIndex = 1;
            // 
            // plnContenedor
            // 
            this.plnContenedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.plnContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plnContenedor.Location = new System.Drawing.Point(0, 0);
            this.plnContenedor.Name = "plnContenedor";
            this.plnContenedor.Size = new System.Drawing.Size(896, 583);
            this.plnContenedor.TabIndex = 0;
            this.plnContenedor.Paint += new System.Windows.Forms.PaintEventHandler(this.PlnContenedor_Paint);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSalir.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSalir.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnSalir.FlatAppearance.BorderSize = 0;
            this.btnSalir.FlatAppearance.MouseDownBackColor = System.Drawing.Color.BlueViolet;
            this.btnSalir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Indigo;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.ForeColor = System.Drawing.Color.White;
            this.btnSalir.Image = global::Pantallas_Sistema_facturación.Properties.Resources.direction_small;
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalir.Location = new System.Drawing.Point(3, 107);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(286, 73);
            this.btnSalir.TabIndex = 1;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = global::Pantallas_Sistema_facturación.Properties.Resources.cat;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(286, 104);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.PictureBox1_Click);
            // 
            // btnCategorias
            // 
            this.btnCategorias.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCategorias.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCategorias.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnCategorias.FlatAppearance.BorderSize = 0;
            this.btnCategorias.FlatAppearance.MouseDownBackColor = System.Drawing.Color.BlueViolet;
            this.btnCategorias.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Indigo;
            this.btnCategorias.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCategorias.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCategorias.ForeColor = System.Drawing.Color.White;
            this.btnCategorias.Image = global::Pantallas_Sistema_facturación.Properties.Resources.categorization1;
            this.btnCategorias.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCategorias.Location = new System.Drawing.Point(3, 253);
            this.btnCategorias.Name = "btnCategorias";
            this.btnCategorias.Size = new System.Drawing.Size(286, 73);
            this.btnCategorias.TabIndex = 5;
            this.btnCategorias.Text = "Categorías";
            this.btnCategorias.UseVisualStyleBackColor = true;
            this.btnCategorias.Click += new System.EventHandler(this.BtnCategorias_Click);
            // 
            // btnProductos
            // 
            this.btnProductos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnProductos.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnProductos.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnProductos.FlatAppearance.BorderSize = 0;
            this.btnProductos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.BlueViolet;
            this.btnProductos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Indigo;
            this.btnProductos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProductos.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProductos.ForeColor = System.Drawing.Color.White;
            this.btnProductos.Image = global::Pantallas_Sistema_facturación.Properties.Resources.supply_chain1;
            this.btnProductos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProductos.Location = new System.Drawing.Point(3, 180);
            this.btnProductos.Name = "btnProductos";
            this.btnProductos.Size = new System.Drawing.Size(286, 73);
            this.btnProductos.TabIndex = 4;
            this.btnProductos.Text = "Productos";
            this.btnProductos.UseVisualStyleBackColor = true;
            this.btnProductos.Click += new System.EventHandler(this.BtnProductos_Click);
            // 
            // btnClientes
            // 
            this.btnClientes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnClientes.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnClientes.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnClientes.FlatAppearance.BorderSize = 0;
            this.btnClientes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.BlueViolet;
            this.btnClientes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Indigo;
            this.btnClientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClientes.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClientes.ForeColor = System.Drawing.Color.White;
            this.btnClientes.Image = global::Pantallas_Sistema_facturación.Properties.Resources.users_avatar1;
            this.btnClientes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClientes.Location = new System.Drawing.Point(3, 107);
            this.btnClientes.Name = "btnClientes";
            this.btnClientes.Size = new System.Drawing.Size(286, 73);
            this.btnClientes.TabIndex = 3;
            this.btnClientes.Text = "Clientes";
            this.btnClientes.UseVisualStyleBackColor = true;
            this.btnClientes.Click += new System.EventHandler(this.Button1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox2.Image = global::Pantallas_Sistema_facturación.Properties.Resources.cat;
            this.pictureBox2.Location = new System.Drawing.Point(3, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(286, 104);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // btnInformes
            // 
            this.btnInformes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnInformes.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnInformes.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnInformes.FlatAppearance.BorderSize = 0;
            this.btnInformes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.BlueViolet;
            this.btnInformes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Indigo;
            this.btnInformes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInformes.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInformes.ForeColor = System.Drawing.Color.White;
            this.btnInformes.Image = global::Pantallas_Sistema_facturación.Properties.Resources.file1;
            this.btnInformes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInformes.Location = new System.Drawing.Point(0, 177);
            this.btnInformes.Name = "btnInformes";
            this.btnInformes.Size = new System.Drawing.Size(292, 73);
            this.btnInformes.TabIndex = 8;
            this.btnInformes.Text = "Informes";
            this.btnInformes.UseVisualStyleBackColor = true;
            this.btnInformes.Click += new System.EventHandler(this.BtnInformes_Click);
            // 
            // btnFacturas
            // 
            this.btnFacturas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnFacturas.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnFacturas.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnFacturas.FlatAppearance.BorderSize = 0;
            this.btnFacturas.FlatAppearance.MouseDownBackColor = System.Drawing.Color.BlueViolet;
            this.btnFacturas.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Indigo;
            this.btnFacturas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFacturas.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFacturas.ForeColor = System.Drawing.Color.White;
            this.btnFacturas.Image = global::Pantallas_Sistema_facturación.Properties.Resources.invoce1;
            this.btnFacturas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFacturas.Location = new System.Drawing.Point(0, 104);
            this.btnFacturas.Name = "btnFacturas";
            this.btnFacturas.Size = new System.Drawing.Size(292, 73);
            this.btnFacturas.TabIndex = 7;
            this.btnFacturas.Text = "Facturas";
            this.btnFacturas.UseVisualStyleBackColor = true;
            this.btnFacturas.Click += new System.EventHandler(this.BtnFacturas_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox3.Image = global::Pantallas_Sistema_facturación.Properties.Resources.cat;
            this.pictureBox3.Location = new System.Drawing.Point(0, 0);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(292, 104);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 6;
            this.pictureBox3.TabStop = false;
            // 
            // btnSeguridad
            // 
            this.btnSeguridad.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSeguridad.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSeguridad.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnSeguridad.FlatAppearance.BorderSize = 0;
            this.btnSeguridad.FlatAppearance.MouseDownBackColor = System.Drawing.Color.BlueViolet;
            this.btnSeguridad.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Indigo;
            this.btnSeguridad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSeguridad.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSeguridad.ForeColor = System.Drawing.Color.White;
            this.btnSeguridad.Image = global::Pantallas_Sistema_facturación.Properties.Resources.user_management1;
            this.btnSeguridad.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSeguridad.Location = new System.Drawing.Point(0, 250);
            this.btnSeguridad.Name = "btnSeguridad";
            this.btnSeguridad.Size = new System.Drawing.Size(292, 73);
            this.btnSeguridad.TabIndex = 9;
            this.btnSeguridad.Text = "Seguridad";
            this.btnSeguridad.UseVisualStyleBackColor = true;
            this.btnSeguridad.Click += new System.EventHandler(this.BtnSeguridad_Click);
            // 
            // btnRoles
            // 
            this.btnRoles.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRoles.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnRoles.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnRoles.FlatAppearance.BorderSize = 0;
            this.btnRoles.FlatAppearance.MouseDownBackColor = System.Drawing.Color.BlueViolet;
            this.btnRoles.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Indigo;
            this.btnRoles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRoles.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRoles.ForeColor = System.Drawing.Color.White;
            this.btnRoles.Image = global::Pantallas_Sistema_facturación.Properties.Resources.stakeholders1;
            this.btnRoles.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRoles.Location = new System.Drawing.Point(0, 177);
            this.btnRoles.Name = "btnRoles";
            this.btnRoles.Size = new System.Drawing.Size(292, 73);
            this.btnRoles.TabIndex = 8;
            this.btnRoles.Text = "Roles";
            this.btnRoles.UseVisualStyleBackColor = true;
            this.btnRoles.Click += new System.EventHandler(this.BtnRoles_Click);
            // 
            // btnEmpleados
            // 
            this.btnEmpleados.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnEmpleados.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnEmpleados.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnEmpleados.FlatAppearance.BorderSize = 0;
            this.btnEmpleados.FlatAppearance.MouseDownBackColor = System.Drawing.Color.BlueViolet;
            this.btnEmpleados.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Indigo;
            this.btnEmpleados.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEmpleados.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmpleados.ForeColor = System.Drawing.Color.White;
            this.btnEmpleados.Image = global::Pantallas_Sistema_facturación.Properties.Resources.group1;
            this.btnEmpleados.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEmpleados.Location = new System.Drawing.Point(0, 104);
            this.btnEmpleados.Name = "btnEmpleados";
            this.btnEmpleados.Size = new System.Drawing.Size(292, 73);
            this.btnEmpleados.TabIndex = 7;
            this.btnEmpleados.Text = "Empleados";
            this.btnEmpleados.UseVisualStyleBackColor = true;
            this.btnEmpleados.Click += new System.EventHandler(this.BtnEmpleados_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox4.Image = global::Pantallas_Sistema_facturación.Properties.Resources.cat;
            this.pictureBox4.Location = new System.Drawing.Point(0, 0);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(292, 104);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 6;
            this.pictureBox4.TabStop = false;
            // 
            // btnAcercaDe
            // 
            this.btnAcercaDe.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAcercaDe.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAcercaDe.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnAcercaDe.FlatAppearance.BorderSize = 0;
            this.btnAcercaDe.FlatAppearance.MouseDownBackColor = System.Drawing.Color.BlueViolet;
            this.btnAcercaDe.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Indigo;
            this.btnAcercaDe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAcercaDe.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAcercaDe.ForeColor = System.Drawing.Color.White;
            this.btnAcercaDe.Image = global::Pantallas_Sistema_facturación.Properties.Resources.about_us1;
            this.btnAcercaDe.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAcercaDe.Location = new System.Drawing.Point(0, 177);
            this.btnAcercaDe.Name = "btnAcercaDe";
            this.btnAcercaDe.Size = new System.Drawing.Size(292, 73);
            this.btnAcercaDe.TabIndex = 8;
            this.btnAcercaDe.Text = "Acerca de..";
            this.btnAcercaDe.UseVisualStyleBackColor = true;
            this.btnAcercaDe.Click += new System.EventHandler(this.BtnAcercaDe_Click);
            // 
            // btnAyuda
            // 
            this.btnAyuda.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAyuda.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAyuda.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnAyuda.FlatAppearance.BorderSize = 0;
            this.btnAyuda.FlatAppearance.MouseDownBackColor = System.Drawing.Color.BlueViolet;
            this.btnAyuda.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Indigo;
            this.btnAyuda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAyuda.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAyuda.ForeColor = System.Drawing.Color.White;
            this.btnAyuda.Image = global::Pantallas_Sistema_facturación.Properties.Resources.help1;
            this.btnAyuda.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAyuda.Location = new System.Drawing.Point(0, 104);
            this.btnAyuda.Name = "btnAyuda";
            this.btnAyuda.Size = new System.Drawing.Size(292, 73);
            this.btnAyuda.TabIndex = 7;
            this.btnAyuda.Text = "Ayuda";
            this.btnAyuda.UseVisualStyleBackColor = true;
            this.btnAyuda.Click += new System.EventHandler(this.BtnAyuda_Click);
            // 
            // pictureBox5
            // 
            this.pictureBox5.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox5.Image = global::Pantallas_Sistema_facturación.Properties.Resources.cat;
            this.pictureBox5.Location = new System.Drawing.Point(0, 0);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(292, 104);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 6;
            this.pictureBox5.TabStop = false;
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 650);
            this.Controls.Add(this.tabOpcionesMenu);
            this.Controls.Add(this.PnlPrincipal);
            this.Name = "FrmPrincipal";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SISTEMA DE FACTURACIÓN";
            this.Load += new System.EventHandler(this.FrmPrincipal_Load);
            this.PnlPrincipal.ResumeLayout(false);
            this.PnlMenu.ResumeLayout(false);
            this.TbpMenu.ResumeLayout(false);
            this.principal.ResumeLayout(false);
            this.tablas.ResumeLayout(false);
            this.facturacion.ResumeLayout(false);
            this.seguridad.ResumeLayout(false);
            this.ayuda.ResumeLayout(false);
            this.pnlContenedor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PnlPrincipal;
        private System.Windows.Forms.Panel PnlMenu;
        private MaterialSkin.Controls.MaterialTabControl TbpMenu;
        private System.Windows.Forms.TabPage principal;
        private System.Windows.Forms.TabPage tablas;
        private System.Windows.Forms.TabPage facturacion;
        private System.Windows.Forms.TabPage seguridad;
        private System.Windows.Forms.TabPage ayuda;
        private MaterialSkin.Controls.MaterialTabSelector tabOpcionesMenu;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnClientes;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnCategorias;
        private System.Windows.Forms.Button btnProductos;
        private System.Windows.Forms.Button btnInformes;
        private System.Windows.Forms.Button btnFacturas;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Button btnSeguridad;
        private System.Windows.Forms.Button btnRoles;
        private System.Windows.Forms.Button btnEmpleados;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Button btnAcercaDe;
        private System.Windows.Forms.Button btnAyuda;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Panel pnlContenedor;
        private System.Windows.Forms.Panel plnContenedor;
        private System.Windows.Forms.Button btnSalir;
    }
}