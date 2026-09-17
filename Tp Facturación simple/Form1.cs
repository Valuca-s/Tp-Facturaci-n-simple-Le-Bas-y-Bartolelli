using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using Tp_Facturación_simple.Datos;

namespace Tp_Facturación_simple
{
    public partial class Form1 : Form
    {
        //metodo para probar si la conexion a la base de datos es exitosa

        private void ProbarConexion()
        {
            try
            {
                using SqlConnection conexion = Conexion.CrearConexion();

                conexion.Open();

                MessageBox.Show("¡Conexión exitosa con FacturacionSimple!");
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    "Error al conectar con SQL Server:\n" + ex.Message,
                    "Error de conexión",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        public Form1()
        {
            InitializeComponent();
            //este metodo lo uso para probar si la conexion funciona
            //ProbarConexion();
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            FrmProductos FormProductos = new FrmProductos();
            FormProductos.ShowDialog();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNuevaFactura_Click(object sender, EventArgs e)
        {
            FrmNuevaFactura formNuevaFactura = new FrmNuevaFactura();
            formNuevaFactura.ShowDialog();
        }

        private void btnConsultarFacturas_Click(object sender, EventArgs e)
        {
            FrmConsultarFacturas formConsultarFacturas = new FrmConsultarFacturas();
            formConsultarFacturas.ShowDialog();
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            FrmReportes formReportes = new FrmReportes();
            formReportes.ShowDialog();
        }
    }
}
