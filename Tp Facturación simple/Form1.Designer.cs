namespace Tp_Facturación_simple
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnProductos = new Button();
            btnCerrar = new Button();
            btnNuevaFactura = new Button();
            btnConsultarFacturas = new Button();
            btnReportes = new Button();
            SuspendLayout();
            // 
            // btnProductos
            // 
            btnProductos.Font = new Font("Segoe UI", 24F);
            btnProductos.Location = new Point(12, 12);
            btnProductos.Name = "btnProductos";
            btnProductos.Size = new Size(219, 64);
            btnProductos.TabIndex = 0;
            btnProductos.Text = "Productos";
            btnProductos.UseVisualStyleBackColor = true;
            btnProductos.Click += btnProductos_Click;
            // 
            // btnCerrar
            // 
            btnCerrar.Location = new Point(12, 415);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(219, 23);
            btnCerrar.TabIndex = 1;
            btnCerrar.Text = "Cerrar";
            btnCerrar.UseVisualStyleBackColor = true;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // btnNuevaFactura
            // 
            btnNuevaFactura.Font = new Font("Segoe UI", 24F);
            btnNuevaFactura.Location = new Point(12, 82);
            btnNuevaFactura.Name = "btnNuevaFactura";
            btnNuevaFactura.Size = new Size(219, 109);
            btnNuevaFactura.TabIndex = 2;
            btnNuevaFactura.Text = "Nueva Factura";
            btnNuevaFactura.UseVisualStyleBackColor = true;
            btnNuevaFactura.Click += btnNuevaFactura_Click;
            // 
            // btnConsultarFacturas
            // 
            btnConsultarFacturas.Font = new Font("Segoe UI", 24F);
            btnConsultarFacturas.Location = new Point(12, 197);
            btnConsultarFacturas.Name = "btnConsultarFacturas";
            btnConsultarFacturas.Size = new Size(219, 102);
            btnConsultarFacturas.TabIndex = 3;
            btnConsultarFacturas.Text = "Consultar Facturas";
            btnConsultarFacturas.UseVisualStyleBackColor = true;
            btnConsultarFacturas.Click += btnConsultarFacturas_Click;
            // 
            // btnReportes
            // 
            btnReportes.Font = new Font("Segoe UI", 24F);
            btnReportes.Location = new Point(12, 305);
            btnReportes.Name = "btnReportes";
            btnReportes.Size = new Size(219, 60);
            btnReportes.TabIndex = 4;
            btnReportes.Text = "Reportes";
            btnReportes.UseVisualStyleBackColor = true;
            btnReportes.Click += btnReportes_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(243, 444);
            Controls.Add(btnReportes);
            Controls.Add(btnConsultarFacturas);
            Controls.Add(btnNuevaFactura);
            Controls.Add(btnCerrar);
            Controls.Add(btnProductos);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button btnProductos;
        private Button btnCerrar;
        private Button btnNuevaFactura;
        private Button btnConsultarFacturas;
        private Button btnReportes;
    }
}
