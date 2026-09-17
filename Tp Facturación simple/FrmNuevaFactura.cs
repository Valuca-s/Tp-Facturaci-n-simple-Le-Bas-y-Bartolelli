using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tp_Facturación_simple.Datos;
using Tp_Facturación_simple.Entidades;
namespace Tp_Facturación_simple

{
    public partial class FrmNuevaFactura : Form
    {
        private ProductoDao productoDao = new ProductoDao();
        private List<Producto> productosActivos = new List<Producto>();
        //lista productos agregados a la fac final
        private List<FacturaDetalle> detalles = new List<FacturaDetalle>();
        //guardar facturas sql
        private FacturaDao facturaDao = new FacturaDao();

        public FrmNuevaFactura()
        {
            InitializeComponent();
            CargarProductos();
            ConfigurarGrilla();
        }
        private void ConfigurarGrilla()
        {
            // Limpiamos las columnas que pueda tener el DataGridView
            dgvDetalles.Columns.Clear();

            // Creamos las columnas que queremos mostrar
            dgvDetalles.AutoGenerateColumns = false;

            dgvDetalles.Columns.Add("ProductoNombre", "Producto");
            dgvDetalles.Columns.Add("Cantidad", "Cantidad");
            dgvDetalles.Columns.Add("PrecioUnitario", "Precio unitario");
            dgvDetalles.Columns.Add("Subtotal", "Subtotal");
        }

        private void CargarProductos()
        {
            try
            {
                // Obtenemos desde SQL Server solamente los productos activos
                productosActivos = productoDao.ObtenerActivos();

                // Limpiamos el ComboBox
                cmbProducto.DataSource = null;

                // Le asignamos la lista de productos
                cmbProducto.DataSource = productosActivos;

                // Lo que se mostrará en pantalla será el nombre
                cmbProducto.DisplayMember = "Nombre";

                // El valor interno será el Id del producto
                cmbProducto.ValueMember = "Id";
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    "No se pudieron cargar los productos.\n\n" + ex.Message,
                    "Error de base de datos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void cmbProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verificamos que haya un producto seleccionado
            if (cmbProducto.SelectedItem == null)
                return;

            // Obtenemos el producto seleccionado
            Producto productoSeleccionado = (Producto)cmbProducto.SelectedItem;

            // Mostramos su precio actual
            lblPrecioValor.Text = productoSeleccionado.Precio.ToString("C2", new CultureInfo("es-AR"));

            // Calculamos también el subtotal inicial
            CalcularSubtotal();
        }

        private void CalcularSubtotal()
        {
            // Verificamos que haya un producto seleccionado
            if (cmbProducto.SelectedItem == null)
                return;

            // Obtenemos el producto seleccionado
            Producto productoSeleccionado = (Producto)cmbProducto.SelectedItem;

            // Obtenemos la cantidad seleccionada
            int cantidad = (int)nudCantidad.Value;

            // Calculamos el subtotal
            decimal subtotal = productoSeleccionado.Precio * cantidad;

            // Mostramos el subtotal
            lblSubtotalValor.Text = subtotal.ToString("C2", new CultureInfo("es-AR"));
        }

        private void lblFecha_Click(object sender, EventArgs e)
        {

        }

        private void nudCantidad_ValueChanged(object sender, EventArgs e)
        {
            CalcularSubtotal();
        }

        private void btnAgregarDetalle_Click(object sender, EventArgs e)
        {
            // Verificamos que haya un producto seleccionado
            if (cmbProducto.SelectedItem == null)
            {
                MessageBox.Show(
                    "Debe seleccionar un producto.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            // Obtenemos el producto seleccionado
            Producto productoSeleccionado = (Producto)cmbProducto.SelectedItem;

            // Obtenemos la cantidad
            int cantidad = (int)nudCantidad.Value;

            // Verificamos que el producto no esté repetido
            bool productoRepetido = detalles.Any(
                d => d.ProductoId == productoSeleccionado.Id);

            if (productoRepetido)
            {
                MessageBox.Show(
                    "El producto ya fue agregado a la factura.",
                    "Producto repetido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            //obtenemos el precio actual del producto
            decimal precioUnitario = productoSeleccionado.Precio;

            // Calculamos el subtotal
            decimal subtotal = precioUnitario * cantidad;

            //creamos el detalle
            FacturaDetalle detalle = new FacturaDetalle
            {
                ProductoId = productoSeleccionado.Id,
                ProductoNombre = productoSeleccionado.Nombre,
                Cantidad = cantidad,
                PrecioUnitario = precioUnitario,
                Subtotal = subtotal
            };

            //detalle a la lista
            detalles.Add(detalle);

            //Mostrar detalle en grilla
            dgvDetalles.Rows.Add(
                detalle.ProductoNombre,
                detalle.Cantidad,
                // para que ponga en pesos
                detalle.PrecioUnitario.ToString("C2", new CultureInfo("es-AR")),
                detalle.Subtotal.ToString("C2", new CultureInfo("es-AR")));

            // Recalculamos el total de la factura
            CalcularTotal();
        }
        private void CalcularTotal()
        {
            // Sumamos todos los subtotales de los detalles
            decimal total = detalles.Sum(d => d.Subtotal);

            // para que ponga en pesos
            lblTotalValor.Text = total.ToString("C2", new CultureInfo("es-AR"));
        }

        private void btnEliminarDetalle_Click(object sender, EventArgs e)
        {
            if (dgvDetalles.CurrentRow == null)
            {
                MessageBox.Show(
                    "Seleccione un producto de la factura.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            int indice = dgvDetalles.CurrentRow.Index;

            if (indice < 0 || indice >= detalles.Count)
                return;

            string nombreProducto = detalles[indice].ProductoNombre;

            DialogResult respuesta = MessageBox.Show(
                $"¿Desea eliminar '{nombreProducto}' de la factura?",
                "Eliminar producto",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (respuesta != DialogResult.Yes)
                return;

            detalles.RemoveAt(indice);
            dgvDetalles.Rows.RemoveAt(indice);
            CalcularTotal();
        }

        private void LimpiarFactura()
        {

            txtClienteNombre.Clear();
            txtClienteDocumento.Clear();

            dtpFecha.Value = DateTime.Today;

            detalles.Clear();

            dgvDetalles.Rows.Clear();

            nudCantidad.Value = 1;

            lblPrecioValor.Text = "$ 0,00";
            lblSubtotalValor.Text = "$ 0,00";
            lblTotalValor.Text = "$ 0,00";

            if (cmbProducto.Items.Count > 0)
            {
                cmbProducto.SelectedIndex = 0;
            }
        }

        private void btnGuardarFactura_Click(object sender, EventArgs e)
        {

            //validar nombre del cliente
            if (string.IsNullOrWhiteSpace(txtClienteNombre.Text))
            {
                MessageBox.Show(
                    "Debe ingresar el nombre del cliente.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtClienteNombre.Focus();
                return;
            }


            //validar doc cliente

            if (string.IsNullOrWhiteSpace(txtClienteDocumento.Text))
            {
                MessageBox.Show(
                    "Debe ingresar el documento del cliente.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtClienteDocumento.Focus();
                return;
            }


            // para que no haya productos repetidos, validamos que haya al menos un detalle
            if (detalles.Count == 0)
            {
                MessageBox.Show(
                    "Debe agregar al menos un producto a la factura.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }


            //calcular total

            // Sumamos los subtotales de todos los detalles
            decimal total = detalles.Sum(d => d.Subtotal);


            //crear el objeto factura con los datos del formulario y la lista de detalles

            Factura factura = new Factura
            {
                //la fecha se obtiene del DateTimePicker
                Fecha = dtpFecha.Value,

                // obtenemos los datos del cliente
                ClienteNombre = txtClienteNombre.Text.Trim(),
                ClienteDocumento = txtClienteDocumento.Text.Trim(),

                //guardamos el total calculado
                Total = total,

                //copiamos todos los detalles de la factura
                Detalles = detalles
            };


            //guardar factura en la base de datos mediante el DAO

            try
            {
                // guardamos la factura mediante el DAO.
                // el DAO se encarga de la transaccion.
                int numeroFactura = facturaDao.Guardar(factura);


                //se guardo bien

                MessageBox.Show(
                    $"La factura se guardó correctamente.\n\n" +
                    $"Número de factura: {numeroFactura}",
                    "Factura guardada",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);


                LimpiarFactura();
            }
            catch (SqlException ex)
            {
                //error de SQL Server
                MessageBox.Show(
                    "No se pudo guardar la factura.\n\n" +
                    ex.Message,
                    "Error de base de datos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // Cualquier otro error inesperado
                MessageBox.Show(
                    "Ocurrió un error al guardar la factura.\n\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
