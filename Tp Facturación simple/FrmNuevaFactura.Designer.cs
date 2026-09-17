namespace Tp_Facturación_simple
{
    partial class FrmNuevaFactura
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
            lblFecha = new Label();
            dtpFecha = new DateTimePicker();
            lblClienteNombre = new Label();
            txtClienteNombre = new TextBox();
            lblClienteDocumento = new Label();
            txtClienteDocumento = new TextBox();
            lblProducto = new Label();
            cmbProducto = new ComboBox();
            lblCantidad = new Label();
            nudCantidad = new NumericUpDown();
            lblPrecio = new Label();
            lblPrecioValor = new Label();
            lblSubtotal = new Label();
            lblSubtotalValor = new Label();
            btnAgregarDetalle = new Button();
            dgvDetalles = new DataGridView();
            lblTotal = new Label();
            lblTotalValor = new Label();
            btnGuardarFactura = new Button();
            button1 = new Button();
            btnEliminarDetalle = new Button();
            ((System.ComponentModel.ISupportInitialize)nudCantidad).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvDetalles).BeginInit();
            SuspendLayout();
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.BackColor = SystemColors.Window;
            lblFecha.ForeColor = SystemColors.Desktop;
            lblFecha.Location = new Point(12, 15);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(38, 15);
            lblFecha.TabIndex = 0;
            lblFecha.Text = "Fecha";
            lblFecha.Click += lblFecha_Click;
            // 
            // dtpFecha
            // 
            dtpFecha.Location = new Point(101, 9);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(228, 23);
            dtpFecha.TabIndex = 1;
            // 
            // lblClienteNombre
            // 
            lblClienteNombre.AutoSize = true;
            lblClienteNombre.BackColor = SystemColors.Window;
            lblClienteNombre.ForeColor = SystemColors.Desktop;
            lblClienteNombre.Location = new Point(12, 41);
            lblClienteNombre.Name = "lblClienteNombre";
            lblClienteNombre.Size = new Size(44, 15);
            lblClienteNombre.TabIndex = 2;
            lblClienteNombre.Text = "Cliente";
            // 
            // txtClienteNombre
            // 
            txtClienteNombre.Location = new Point(101, 38);
            txtClienteNombre.Name = "txtClienteNombre";
            txtClienteNombre.Size = new Size(228, 23);
            txtClienteNombre.TabIndex = 3;
            // 
            // lblClienteDocumento
            // 
            lblClienteDocumento.AutoSize = true;
            lblClienteDocumento.BackColor = SystemColors.Window;
            lblClienteDocumento.ForeColor = SystemColors.Desktop;
            lblClienteDocumento.Location = new Point(12, 70);
            lblClienteDocumento.Name = "lblClienteDocumento";
            lblClienteDocumento.Size = new Size(70, 15);
            lblClienteDocumento.TabIndex = 4;
            lblClienteDocumento.Text = "Documento";
            // 
            // txtClienteDocumento
            // 
            txtClienteDocumento.Location = new Point(101, 67);
            txtClienteDocumento.Name = "txtClienteDocumento";
            txtClienteDocumento.Size = new Size(228, 23);
            txtClienteDocumento.TabIndex = 5;
            // 
            // lblProducto
            // 
            lblProducto.AutoSize = true;
            lblProducto.BackColor = SystemColors.Window;
            lblProducto.ForeColor = SystemColors.Desktop;
            lblProducto.Location = new Point(12, 99);
            lblProducto.Name = "lblProducto";
            lblProducto.Size = new Size(56, 15);
            lblProducto.TabIndex = 6;
            lblProducto.Text = "Producto";
            // 
            // cmbProducto
            // 
            cmbProducto.FormattingEnabled = true;
            cmbProducto.Location = new Point(101, 96);
            cmbProducto.Name = "cmbProducto";
            cmbProducto.Size = new Size(228, 23);
            cmbProducto.TabIndex = 7;
            cmbProducto.SelectedIndexChanged += cmbProducto_SelectedIndexChanged;
            // 
            // lblCantidad
            // 
            lblCantidad.AutoSize = true;
            lblCantidad.BackColor = SystemColors.Window;
            lblCantidad.Location = new Point(12, 127);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(55, 15);
            lblCantidad.TabIndex = 8;
            lblCantidad.Text = "Cantidad";
            // 
            // nudCantidad
            // 
            nudCantidad.Location = new Point(101, 125);
            nudCantidad.Name = "nudCantidad";
            nudCantidad.Size = new Size(228, 23);
            nudCantidad.TabIndex = 9;
            nudCantidad.ValueChanged += nudCantidad_ValueChanged;
            // 
            // lblPrecio
            // 
            lblPrecio.AutoSize = true;
            lblPrecio.Location = new Point(7, 187);
            lblPrecio.Name = "lblPrecio";
            lblPrecio.Size = new Size(85, 15);
            lblPrecio.TabIndex = 10;
            lblPrecio.Text = "Precio Unitario";
            // 
            // lblPrecioValor
            // 
            lblPrecioValor.AutoSize = true;
            lblPrecioValor.BorderStyle = BorderStyle.FixedSingle;
            lblPrecioValor.Font = new Font("Segoe UI", 12F);
            lblPrecioValor.Location = new Point(101, 182);
            lblPrecioValor.Name = "lblPrecioValor";
            lblPrecioValor.Size = new Size(51, 23);
            lblPrecioValor.TabIndex = 11;
            lblPrecioValor.Text = "$0,00";
            // 
            // lblSubtotal
            // 
            lblSubtotal.AutoSize = true;
            lblSubtotal.Location = new Point(12, 222);
            lblSubtotal.Name = "lblSubtotal";
            lblSubtotal.Size = new Size(51, 15);
            lblSubtotal.TabIndex = 12;
            lblSubtotal.Text = "Subtotal";
            // 
            // lblSubtotalValor
            // 
            lblSubtotalValor.AutoSize = true;
            lblSubtotalValor.BorderStyle = BorderStyle.FixedSingle;
            lblSubtotalValor.Font = new Font("Segoe UI", 12F);
            lblSubtotalValor.Location = new Point(101, 217);
            lblSubtotalValor.Name = "lblSubtotalValor";
            lblSubtotalValor.Size = new Size(55, 23);
            lblSubtotalValor.TabIndex = 13;
            lblSubtotalValor.Text = "$ 0,00";
            // 
            // btnAgregarDetalle
            // 
            btnAgregarDetalle.Location = new Point(199, 179);
            btnAgregarDetalle.Name = "btnAgregarDetalle";
            btnAgregarDetalle.Size = new Size(130, 61);
            btnAgregarDetalle.TabIndex = 14;
            btnAgregarDetalle.Text = "Agregar producto";
            btnAgregarDetalle.UseVisualStyleBackColor = true;
            btnAgregarDetalle.Click += btnAgregarDetalle_Click;
            // 
            // dgvDetalles
            // 
            dgvDetalles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDetalles.Location = new Point(344, 9);
            dgvDetalles.Name = "dgvDetalles";
            dgvDetalles.Size = new Size(444, 231);
            dgvDetalles.TabIndex = 15;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 15F);
            lblTotal.Location = new Point(346, 253);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(66, 28);
            lblTotal.TabIndex = 16;
            lblTotal.Text = "TOTAL";
            // 
            // lblTotalValor
            // 
            lblTotalValor.AutoSize = true;
            lblTotalValor.Font = new Font("Segoe UI", 15F);
            lblTotalValor.Location = new Point(427, 253);
            lblTotalValor.Name = "lblTotalValor";
            lblTotalValor.Size = new Size(70, 28);
            lblTotalValor.TabIndex = 17;
            lblTotalValor.Text = "$  0,00";
            // 
            // btnGuardarFactura
            // 
            btnGuardarFactura.Location = new Point(148, 253);
            btnGuardarFactura.Name = "btnGuardarFactura";
            btnGuardarFactura.Size = new Size(181, 28);
            btnGuardarFactura.TabIndex = 18;
            btnGuardarFactura.Text = "Guardar Factura";
            btnGuardarFactura.UseVisualStyleBackColor = true;
            btnGuardarFactura.Click += btnGuardarFactura_Click;
            // 
            // button1
            // 
            button1.Cursor = Cursors.No;
            button1.Location = new Point(7, 154);
            button1.Name = "button1";
            button1.Size = new Size(322, 23);
            button1.TabIndex = 19;
            button1.UseVisualStyleBackColor = true;
            // 
            // btnEliminarDetalle
            // 
            btnEliminarDetalle.Location = new Point(7, 253);
            btnEliminarDetalle.Name = "btnEliminarDetalle";
            btnEliminarDetalle.Size = new Size(135, 28);
            btnEliminarDetalle.TabIndex = 20;
            btnEliminarDetalle.Text = "Eliminar Producto";
            btnEliminarDetalle.UseVisualStyleBackColor = true;
            btnEliminarDetalle.Click += btnEliminarDetalle_Click;
            // 
            // FrmNuevaFactura
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 308);
            Controls.Add(btnEliminarDetalle);
            Controls.Add(button1);
            Controls.Add(btnGuardarFactura);
            Controls.Add(lblTotalValor);
            Controls.Add(lblTotal);
            Controls.Add(dgvDetalles);
            Controls.Add(btnAgregarDetalle);
            Controls.Add(lblSubtotalValor);
            Controls.Add(lblSubtotal);
            Controls.Add(lblPrecioValor);
            Controls.Add(lblPrecio);
            Controls.Add(nudCantidad);
            Controls.Add(lblCantidad);
            Controls.Add(cmbProducto);
            Controls.Add(lblProducto);
            Controls.Add(txtClienteDocumento);
            Controls.Add(lblClienteDocumento);
            Controls.Add(txtClienteNombre);
            Controls.Add(lblClienteNombre);
            Controls.Add(dtpFecha);
            Controls.Add(lblFecha);
            Name = "FrmNuevaFactura";
            Text = "FrmNuevaFactura";
            ((System.ComponentModel.ISupportInitialize)nudCantidad).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvDetalles).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblFecha;
        private DateTimePicker dtpFecha;
        private Label lblClienteNombre;
        private TextBox txtClienteNombre;
        private Label lblClienteDocumento;
        private TextBox txtClienteDocumento;
        private Label lblProducto;
        private ComboBox cmbProducto;
        private Label lblCantidad;
        private NumericUpDown nudCantidad;
        private Label lblPrecio;
        private Label lblPrecioValor;
        private Label lblSubtotal;
        private Label lblSubtotalValor;
        private Button btnAgregarDetalle;
        private DataGridView dgvDetalles;
        private Label lblTotal;
        private Label lblTotalValor;
        private Button btnGuardarFactura;
        private Button button1;
        private Button btnEliminarDetalle;
    }
}