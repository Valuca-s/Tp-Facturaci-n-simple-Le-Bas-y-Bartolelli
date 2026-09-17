namespace Tp_Facturación_simple
{
    partial class FrmProductos
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
            label1 = new Label();
            label2 = new Label();
            txtCodigo = new TextBox();
            txtNombre = new TextBox();
            label3 = new Label();
            txtPrecio = new TextBox();
            lblBuscar = new Label();
            txtBuscar = new TextBox();
            btnAgregar = new Button();
            btnModificar = new Button();
            btnDarDeBaja = new Button();
            dgvProductos = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(17, 20);
            label1.Name = "label1";
            label1.Size = new Size(60, 21);
            label1.TabIndex = 0;
            label1.Text = "Codigo";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(17, 60);
            label2.Name = "label2";
            label2.Size = new Size(68, 21);
            label2.TabIndex = 1;
            label2.Text = "Nombre";
            // 
            // txtCodigo
            // 
            txtCodigo.Font = new Font("Segoe UI", 12F);
            txtCodigo.Location = new Point(116, 17);
            txtCodigo.Name = "txtCodigo";
            txtCodigo.Size = new Size(444, 29);
            txtCodigo.TabIndex = 2;
            // 
            // txtNombre
            // 
            txtNombre.Font = new Font("Segoe UI", 12F);
            txtNombre.Location = new Point(116, 57);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(444, 29);
            txtNombre.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(17, 98);
            label3.Name = "label3";
            label3.Size = new Size(53, 21);
            label3.TabIndex = 4;
            label3.Text = "Precio";
            // 
            // txtPrecio
            // 
            txtPrecio.Font = new Font("Segoe UI", 12F);
            txtPrecio.Location = new Point(116, 95);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.Size = new Size(444, 29);
            txtPrecio.TabIndex = 5;
            // 
            // lblBuscar
            // 
            lblBuscar.AutoSize = true;
            lblBuscar.Font = new Font("Segoe UI", 12F);
            lblBuscar.Location = new Point(14, 199);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new Size(56, 21);
            lblBuscar.TabIndex = 6;
            lblBuscar.Text = "Buscar";
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(85, 199);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(475, 23);
            txtBuscar.TabIndex = 7;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            // 
            // btnAgregar
            // 
            btnAgregar.Font = new Font("Segoe UI", 12F);
            btnAgregar.Location = new Point(17, 145);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(178, 38);
            btnAgregar.TabIndex = 8;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnModificar
            // 
            btnModificar.Font = new Font("Segoe UI", 12F);
            btnModificar.Location = new Point(201, 145);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(178, 38);
            btnModificar.TabIndex = 9;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnDarDeBaja
            // 
            btnDarDeBaja.Font = new Font("Segoe UI", 12F);
            btnDarDeBaja.Location = new Point(385, 145);
            btnDarDeBaja.Name = "btnDarDeBaja";
            btnDarDeBaja.Size = new Size(178, 38);
            btnDarDeBaja.TabIndex = 10;
            btnDarDeBaja.Text = "Dar de baja";
            btnDarDeBaja.UseVisualStyleBackColor = true;
            btnDarDeBaja.Click += btnDarDeBaja_Click;
            // 
            // dgvProductos
            // 
            dgvProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProductos.Location = new Point(12, 228);
            dgvProductos.Name = "dgvProductos";
            dgvProductos.Size = new Size(548, 210);
            dgvProductos.TabIndex = 11;
            dgvProductos.CellClick += dgvProductos_CellClick;
            // 
            // FrmProductos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(581, 450);
            Controls.Add(dgvProductos);
            Controls.Add(btnDarDeBaja);
            Controls.Add(btnModificar);
            Controls.Add(btnAgregar);
            Controls.Add(txtBuscar);
            Controls.Add(lblBuscar);
            Controls.Add(txtPrecio);
            Controls.Add(label3);
            Controls.Add(txtNombre);
            Controls.Add(txtCodigo);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FrmProductos";
            Text = "FrmProductos";
            Load += FrmProductos_Load;
            ((System.ComponentModel.ISupportInitialize)dgvProductos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtCodigo;
        private TextBox txtNombre;
        private Label label3;
        private TextBox txtPrecio;
        private Label lblBuscar;
        private TextBox txtBuscar;
        private Button btnAgregar;
        private Button btnModificar;
        private Button btnDarDeBaja;
        private DataGridView dgvProductos;
    }
}