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
using System.Globalization;
using Tp_Facturación_simple.Datos;
using Tp_Facturación_simple.Entidades;

namespace Tp_Facturación_simple
{
    public partial class FrmReportes : Form
    {
        // dao encargado de obtener los datos del reporte
        private ReporteDao reporteDao = new ReporteDao();

        // dao encargado de obtener los productos
        private ProductoDao productoDao = new ProductoDao();

        // lista de productos disponibles
        private List<Producto> productos = new List<Producto>();

        public FrmReportes()
        {
            InitializeComponent();

            // configuramos la grilla
            ConfigurarGrilla();

            // configuramos las fechas iniciales
            dtpFechaDesde.Value = DateTime.Today.AddDays(-30);
            dtpFechaHasta.Value = DateTime.Today;

            // cargamos los productos
            CargarProductos();

            // cargamos el reporte inicial
            CargarReporte();
        }


        private void ConfigurarGrilla()
        {
            // configuramos la grilla del reporte
            dgvReporte.AutoGenerateColumns = false;
            dgvReporte.Columns.Clear();

            // agregamos las columnas
            dgvReporte.Columns.Add(
                "ProductoNombre",
                "Producto");

            dgvReporte.Columns.Add(
                "CantidadVendida",
                "Cantidad vendida");

            dgvReporte.Columns.Add(
                "MontoFacturado",
                "Monto facturado");

            // configuramos el tamaño proporcional
            dgvReporte.Columns["ProductoNombre"].FillWeight = 50;
            dgvReporte.Columns["CantidadVendida"].FillWeight = 25;
            dgvReporte.Columns["MontoFacturado"].FillWeight = 25;

            // hacemos que las columnas ocupen todo el ancho
            dgvReporte.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            // hacemos que el reporte sea solo lectura
            dgvReporte.ReadOnly = true;

            // evitamos que el usuario agregue filas
            dgvReporte.AllowUserToAddRows = false;

            // seleccionamos la fila completa
            dgvReporte.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            // permitimos seleccionar una sola fila
            dgvReporte.MultiSelect = false;
        }

        private void CargarProductos()
        {
            try
            {
                // obtenemos todos los productos
                productos = productoDao.ObtenerTodos();

                // agregamos una opcion para consultar todos
                Producto todos = new Producto
                {
                    Id = 0,
                    Nombre = "Todos los productos"
                };

                productos.Insert(0, todos);

                // cargamos los productos en el combo
                cmbProducto.DataSource = productos;
                cmbProducto.DisplayMember = "Nombre";
                cmbProducto.ValueMember = "Id";

                // seleccionamos todos los productos
                cmbProducto.SelectedIndex = 0;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    "no se pudieron cargar los productos.\n\n" +
                    ex.Message,
                    "error de base de datos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void CargarReporte()
        {
            try
            {
                // obtenemos las fechas seleccionadas
                DateTime fechaDesde = dtpFechaDesde.Value;
                DateTime fechaHasta = dtpFechaHasta.Value;

                // verificamos que las fechas sean correctas
                if (fechaDesde.Date > fechaHasta.Date)
                {
                    MessageBox.Show(
                        "La fecha desde no puede ser posterior a la fecha hasta.",
                        "Validacion",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                // obtenemos el producto seleccionado
                Producto productoSeleccionado = (Producto)cmbProducto.SelectedItem;

                // si se seleccionaron todos, enviamos null
                int? productoId = null;

                if (productoSeleccionado != null &&
                    productoSeleccionado.Id != 0)
                {
                    productoId = productoSeleccionado.Id;
                }

                // obtenemos los resultados del reporte
                List<ReporteProducto> reporte =
                    reporteDao.ObtenerReportePorProducto(
                        fechaDesde,
                        fechaHasta,
                        productoId);

                // limpiamos la grilla
                dgvReporte.Rows.Clear();

                // mostramos los resultados
                foreach (ReporteProducto resultado in reporte)
                {
                    dgvReporte.Rows.Add(
                        resultado.ProductoNombre,
                        resultado.CantidadVendida,
                        resultado.MontoFacturado.ToString(
                            "C2",
                            new CultureInfo("es-AR")));
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    "no se pudo generar el reporte.\n\n" +
                    ex.Message,
                    "error de base de datos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarReporte();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            //fechasa
            dtpFechaDesde.Value = DateTime.Today.AddDays(-30);
            dtpFechaHasta.Value = DateTime.Today;

            // seleccionamos todos los productos
            if (cmbProducto.Items.Count > 0)
            {
                cmbProducto.SelectedIndex = 0;
            }

            // volvemos a generar el reporte
            CargarReporte();
        }
    }
}

