using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tp_Facturación_simple.Datos;
using Microsoft.Data.SqlClient;
using System.Globalization;
using Tp_Facturación_simple.Entidades;

namespace Tp_Facturación_simple
{
    public partial class FrmConsultarFacturas : Form
    {
        private FacturaDao facturaDao = new FacturaDao();
        private List<Factura> facturas = new List<Factura>();
        public FrmConsultarFacturas()
        {
            InitializeComponent();

            // configuramos las grillas
            ConfigurarGrillas();

            // configuramos las fechas iniciales
            dtpFechaDesde.Value = DateTime.Today.AddDays(-30);
            dtpFechaHasta.Value = DateTime.Today;

            // cargamos las facturas
            CargarFacturas();
        }
        private void ConfigurarGrillas()
        {
            // configuramos la grilla principal de facturas
            dgvFacturas.AutoGenerateColumns = false;
            dgvFacturas.Columns.Clear();

            dgvFacturas.Columns.Add("Id", "Id");
            dgvFacturas.Columns.Add("Numero", "Numero");
            dgvFacturas.Columns.Add("Fecha", "Fecha");
            dgvFacturas.Columns.Add("ClienteNombre", "Cliente");
            dgvFacturas.Columns.Add("ClienteDocumento", "Documento");
            dgvFacturas.Columns.Add("Total", "Total");

            // ocultamos el id porque es un dato interno
            dgvFacturas.Columns["Id"].Visible = false;

            // repartimos el ancho disponible proporcionalmente
            dgvFacturas.Columns["Numero"].FillWeight = 10;
            dgvFacturas.Columns["Fecha"].FillWeight = 18;
            dgvFacturas.Columns["ClienteNombre"].FillWeight = 30;
            dgvFacturas.Columns["ClienteDocumento"].FillWeight = 20;
            dgvFacturas.Columns["Total"].FillWeight = 15;

            // hacemos que las columnas ocupen todo el ancho
            dgvFacturas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // configuramos la grilla como solo lectura
            dgvFacturas.ReadOnly = true;

            // evitamos que el usuario agregue filas
            dgvFacturas.AllowUserToAddRows = false;

            // seleccionamos la fila completa
            dgvFacturas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // permitimos seleccionar una sola fila
            dgvFacturas.MultiSelect = false;

            // ---------------------------------------------------------
            // configuramos la grilla de detalles
            // ---------------------------------------------------------

            dgvDetalles.AutoGenerateColumns = false;
            dgvDetalles.Columns.Clear();

            dgvDetalles.Columns.Add("ProductoNombre", "Producto");
            dgvDetalles.Columns.Add("Cantidad", "Cantidad");
            dgvDetalles.Columns.Add("PrecioUnitario", "Precio unitario");
            dgvDetalles.Columns.Add("Subtotal", "Subtotal");

            // repartimos el ancho disponible proporcionalmente
            dgvDetalles.Columns["ProductoNombre"].FillWeight = 40;
            dgvDetalles.Columns["Cantidad"].FillWeight = 15;
            dgvDetalles.Columns["PrecioUnitario"].FillWeight = 20;
            dgvDetalles.Columns["Subtotal"].FillWeight = 20;

            // hacemos que las columnas ocupen todo el ancho
            dgvDetalles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // configuramos la grilla como solo lectura
            dgvDetalles.ReadOnly = true;

            // evitamos que el usuario agregue filas
            dgvDetalles.AllowUserToAddRows = false;

            // seleccionamos la fila completa
            dgvDetalles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // permitimos seleccionar una sola fila
            dgvDetalles.MultiSelect = false;
        }

        private void CargarFacturas()
        {
            try
            {
                // obtenemos las fechas seleccionadas
                DateTime fechaDesde = dtpFechaDesde.Value;
                DateTime fechaHasta = dtpFechaHasta.Value;

                // obtenemos el texto del cliente
                string cliente = txtBuscarCliente.Text.Trim();

                // buscamos las facturas mediante el dao
                facturas = facturaDao.ObtenerFacturas(
                    fechaDesde,
                    fechaHasta,
                    cliente);

                // limpiamos la grilla de facturas
                dgvFacturas.Rows.Clear();

                // limpiamos el detalle porque todavia no hay una factura seleccionada
                dgvDetalles.Rows.Clear();

                // cargamos las facturas encontradas
                foreach (Factura factura in facturas)
                {
                    dgvFacturas.Rows.Add(
                        factura.Id,
                        factura.Numero,
                        factura.Fecha.ToString("dd/MM/yyyy HH:mm"),
                        factura.ClienteNombre,
                        factura.ClienteDocumento,
                        factura.Total.ToString(
                            "C2",
                            new CultureInfo("es-AR")));
                }

                // mostramos un mensaje si no encontramos facturas
                if (facturas.Count == 0)
                {
                    MessageBox.Show(
                        "No se encontraron facturas con los filtros seleccionados.",
                        "Sin resultados",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    "no se pudieron cargar las facturas.\n\n" +
                    ex.Message,
                    "error de base de datos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (dtpFechaDesde.Value > dtpFechaHasta.Value)
            {
                MessageBox.Show(
                    "La fecha desde no puede ser mayor que la fecha hasta.",
                    "Error de validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            CargarFacturas();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            // restauramos las fechas
            dtpFechaDesde.Value = DateTime.Today.AddDays(-30);
            dtpFechaHasta.Value = DateTime.Today;

            // limpiamos el texto del cliente
            txtBuscarCliente.Clear();

            // volvemos a cargar todas las facturas del periodo
            CargarFacturas();
        }

        private void CargarDetalles(int facturaId)
        {
            try
            {
                // obtenemos los detalles de la factura
                List<FacturaDetalle> detalles =
                    facturaDao.ObtenerDetalles(facturaId);

                // limpiamos la grilla de detalles
                dgvDetalles.Rows.Clear();

                // mostramos cada detalle en la grilla
                foreach (FacturaDetalle detalle in detalles)
                {
                    dgvDetalles.Rows.Add(
                        detalle.ProductoNombre,
                        detalle.Cantidad,
                        detalle.PrecioUnitario.ToString(
                            "C2",
                            new CultureInfo("es-AR")),
                        detalle.Subtotal.ToString(
                            "C2",
                            new CultureInfo("es-AR")));
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    "no se pudieron cargar los detalles.\n\n" +
                    ex.Message,
                    "error de base de datos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void dgvFacturas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // verificamos que se haya seleccionado una fila valida
            if (e.RowIndex < 0)
                return;

            // obtenemos el id de la factura seleccionada
            int facturaId = Convert.ToInt32(
                dgvFacturas.Rows[e.RowIndex].Cells["Id"].Value);

            // cargamos los detalles de la factura
            CargarDetalles(facturaId);
        }
    }
}
