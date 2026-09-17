namespace Tp_Facturación_simple
{
    partial class FrmConsultarFacturas
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
            lblFechaDesde = new Label();
            lblFechaHasta = new Label();
            dtpFechaDesde = new DateTimePicker();
            dtpFechaHasta = new DateTimePicker();
            label1 = new Label();
            txtBuscarCliente = new TextBox();
            btnBuscar = new Button();
            btnLimpiar = new Button();
            dgvFacturas = new DataGridView();
            label2 = new Label();
            dgvDetalles = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvFacturas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvDetalles).BeginInit();
            SuspendLayout();
            // 
            // lblFechaDesde
            // 
            lblFechaDesde.AutoSize = true;
            lblFechaDesde.Font = new Font("Segoe UI", 13F);
            lblFechaDesde.Location = new Point(12, 14);
            lblFechaDesde.Name = "lblFechaDesde";
            lblFechaDesde.Size = new Size(110, 25);
            lblFechaDesde.TabIndex = 0;
            lblFechaDesde.Text = "Fecha desde";
            // 
            // lblFechaHasta
            // 
            lblFechaHasta.AutoSize = true;
            lblFechaHasta.Font = new Font("Segoe UI", 13F);
            lblFechaHasta.Location = new Point(12, 49);
            lblFechaHasta.Name = "lblFechaHasta";
            lblFechaHasta.Size = new Size(104, 25);
            lblFechaHasta.TabIndex = 1;
            lblFechaHasta.Text = "Fecha hasta";
            lblFechaHasta.Click += label1_Click;
            // 
            // dtpFechaDesde
            // 
            dtpFechaDesde.Font = new Font("Segoe UI", 12F);
            dtpFechaDesde.Location = new Point(128, 9);
            dtpFechaDesde.Name = "dtpFechaDesde";
            dtpFechaDesde.Size = new Size(442, 29);
            dtpFechaDesde.TabIndex = 2;
            // 
            // dtpFechaHasta
            // 
            dtpFechaHasta.Font = new Font("Segoe UI", 12F);
            dtpFechaHasta.Location = new Point(128, 44);
            dtpFechaHasta.Name = "dtpFechaHasta";
            dtpFechaHasta.Size = new Size(442, 29);
            dtpFechaHasta.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13F);
            label1.Location = new Point(15, 81);
            label1.Name = "label1";
            label1.Size = new Size(74, 25);
            label1.TabIndex = 4;
            label1.Text = "Cliente :";
            // 
            // txtBuscarCliente
            // 
            txtBuscarCliente.Font = new Font("Segoe UI", 12F);
            txtBuscarCliente.Location = new Point(86, 79);
            txtBuscarCliente.Name = "txtBuscarCliente";
            txtBuscarCliente.Size = new Size(484, 29);
            txtBuscarCliente.TabIndex = 5;
            // 
            // btnBuscar
            // 
            btnBuscar.Font = new Font("Segoe UI", 12F);
            btnBuscar.Location = new Point(12, 114);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(197, 32);
            btnBuscar.TabIndex = 6;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Font = new Font("Segoe UI", 12F);
            btnLimpiar.Location = new Point(370, 114);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(200, 32);
            btnLimpiar.TabIndex = 7;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // dgvFacturas
            // 
            dgvFacturas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFacturas.Location = new Point(12, 152);
            dgvFacturas.Name = "dgvFacturas";
            dgvFacturas.Size = new Size(558, 198);
            dgvFacturas.TabIndex = 8;
            dgvFacturas.CellClick += dgvFacturas_CellClick;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = SystemColors.ScrollBar;
            label2.BorderStyle = BorderStyle.Fixed3D;
            label2.FlatStyle = FlatStyle.Flat;
            label2.Font = new Font("Segoe UI", 19F);
            label2.Location = new Point(239, 351);
            label2.Name = "label2";
            label2.Size = new Size(114, 38);
            label2.TabIndex = 9;
            label2.Text = "DETALLE";
            // 
            // dgvDetalles
            // 
            dgvDetalles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDetalles.Location = new Point(12, 392);
            dgvDetalles.Name = "dgvDetalles";
            dgvDetalles.Size = new Size(558, 239);
            dgvDetalles.TabIndex = 10;
            // 
            // FrmConsultarFacturas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(582, 643);
            Controls.Add(dgvDetalles);
            Controls.Add(label2);
            Controls.Add(dgvFacturas);
            Controls.Add(btnLimpiar);
            Controls.Add(btnBuscar);
            Controls.Add(txtBuscarCliente);
            Controls.Add(label1);
            Controls.Add(dtpFechaHasta);
            Controls.Add(dtpFechaDesde);
            Controls.Add(lblFechaHasta);
            Controls.Add(lblFechaDesde);
            Name = "FrmConsultarFacturas";
            Text = "CONSULTAR FACTURAS";
            ((System.ComponentModel.ISupportInitialize)dgvFacturas).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvDetalles).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblFechaDesde;
        private Label lblFechaHasta;
        private DateTimePicker dtpFechaDesde;
        private DateTimePicker dtpFechaHasta;
        private Label label1;
        private TextBox txtBuscarCliente;
        private Button btnBuscar;
        private Button btnLimpiar;
        private DataGridView dgvFacturas;
        private Label label2;
        private DataGridView dgvDetalles;
    }
}