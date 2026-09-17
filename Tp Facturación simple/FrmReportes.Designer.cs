namespace Tp_Facturación_simple
{
    partial class FrmReportes
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
            dtpFechaDesde = new DateTimePicker();
            label2 = new Label();
            dtpFechaHasta = new DateTimePicker();
            cmbProducto = new ComboBox();
            label3 = new Label();
            btnLimpiar = new Button();
            btnBuscar = new Button();
            dgvReporte = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvReporte).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(12, 18);
            label1.Name = "label1";
            label1.Size = new Size(102, 21);
            label1.TabIndex = 0;
            label1.Text = "Fecha desde :";
            // 
            // dtpFechaDesde
            // 
            dtpFechaDesde.Font = new Font("Segoe UI", 12F);
            dtpFechaDesde.Format = DateTimePickerFormat.Short;
            dtpFechaDesde.Location = new Point(120, 12);
            dtpFechaDesde.Name = "dtpFechaDesde";
            dtpFechaDesde.Size = new Size(141, 29);
            dtpFechaDesde.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(267, 18);
            label2.Name = "label2";
            label2.Size = new Size(98, 21);
            label2.TabIndex = 2;
            label2.Text = "Fecha hasta :";
            // 
            // dtpFechaHasta
            // 
            dtpFechaHasta.Font = new Font("Segoe UI", 12F);
            dtpFechaHasta.Format = DateTimePickerFormat.Short;
            dtpFechaHasta.Location = new Point(371, 12);
            dtpFechaHasta.Name = "dtpFechaHasta";
            dtpFechaHasta.Size = new Size(147, 29);
            dtpFechaHasta.TabIndex = 3;
            // 
            // cmbProducto
            // 
            cmbProducto.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProducto.Font = new Font("Segoe UI", 12F);
            cmbProducto.FormattingEnabled = true;
            cmbProducto.Location = new Point(120, 47);
            cmbProducto.Name = "cmbProducto";
            cmbProducto.Size = new Size(674, 29);
            cmbProducto.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(12, 50);
            label3.Name = "label3";
            label3.Size = new Size(80, 21);
            label3.TabIndex = 5;
            label3.Text = "Producto :";
            // 
            // btnLimpiar
            // 
            btnLimpiar.Font = new Font("Segoe UI", 12F);
            btnLimpiar.Location = new Point(12, 88);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(102, 34);
            btnLimpiar.TabIndex = 6;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // btnBuscar
            // 
            btnBuscar.Font = new Font("Segoe UI", 12F);
            btnBuscar.Location = new Point(120, 88);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(102, 34);
            btnBuscar.TabIndex = 7;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // dgvReporte
            // 
            dgvReporte.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReporte.Location = new Point(12, 128);
            dgvReporte.Name = "dgvReporte";
            dgvReporte.Size = new Size(796, 310);
            dgvReporte.TabIndex = 8;
            // 
            // FrmReportes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(820, 450);
            Controls.Add(dgvReporte);
            Controls.Add(btnBuscar);
            Controls.Add(btnLimpiar);
            Controls.Add(label3);
            Controls.Add(cmbProducto);
            Controls.Add(dtpFechaHasta);
            Controls.Add(label2);
            Controls.Add(dtpFechaDesde);
            Controls.Add(label1);
            Name = "FrmReportes";
            Text = "FrmReportes";
            ((System.ComponentModel.ISupportInitialize)dgvReporte).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DateTimePicker dtpFechaDesde;
        private Label label2;
        private DateTimePicker dtpFechaHasta;
        private ComboBox cmbProducto;
        private Label label3;
        private Button btnLimpiar;
        private Button btnBuscar;
        private DataGridView dgvReporte;
    }
}