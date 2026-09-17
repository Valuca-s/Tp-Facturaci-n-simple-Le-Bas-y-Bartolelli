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
using Tp_Facturación_simple.Entidades;
//using Tp_Facturación_simple.Entidades;

namespace Tp_Facturación_simple
{
    public partial class FrmProductos : Form
    {
        private int productoSeleccionadoId = 0;
        private ProductoDao productoDao = new ProductoDao();
        public FrmProductos()
        {
            InitializeComponent();
            CargarProductos();
        }
        private void CargarProductos()
        {
            try
            {
                List<Producto> productos = productoDao.ObtenerTodos();

                dgvProductos.DataSource = null;
                dgvProductos.DataSource = productos;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    "No se pudieron cargar los productos.\n\n" + ex.Message,
                    "Error de conexión",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private void FrmProductos_Load(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //verificamos que no este vacio
            if (string.IsNullOrWhiteSpace(txtCodigo.Text))
            {
                MessageBox.Show(
                    "Debe ingresar un código.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtCodigo.Focus();
                return;
            }
            //verificamos que el nombre no este vacio
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show(
                    "Debe ingresar un nombre.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtNombre.Focus();
                return;
            }

            //intentamos convertir el precio a decimal
            if (!decimal.TryParse(txtPrecio.Text, out decimal precio))
            {
                MessageBox.Show(
                    "El precio debe ser un número válido.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtPrecio.Focus();
                return;
            }

            //verificamos que el precio no sea negativo
            if (precio < 0)
            {
                MessageBox.Show(
                    "El precio no puede ser negativo.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtPrecio.Focus();
                return;
            }

            //creamos el objeto Producto con los datos ingresados
            Producto producto = new Producto
            {
                Codigo = txtCodigo.Text.Trim(),
                Nombre = txtNombre.Text.Trim(),
                Precio = precio,
                Activo = true
            };

            try
            {
                //enviamos el producto al DAO para guardarlo en SQL Server
                productoDao.Agregar(producto);

                MessageBox.Show(
                    "Producto agregado correctamente.",
                    "Éxito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                //volvemos a cargar la grilla
                CargarProductos();

                // limpiamos los campos
                txtCodigo.Clear();
                txtNombre.Clear();
                txtPrecio.Clear();

                //dejamos el cursor nuevamente en código
                txtCodigo.Focus();
            }
            catch (SqlException ex)
            {
                // 2601 y 2627 corresponden a violaciones de índices/constraints únicos
                if (ex.Number == 2601 || ex.Number == 2627)
                {
                    MessageBox.Show(
                        "Ya existe un producto con ese código.",
                        "Código duplicado",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
                else
                {
                    // mostramos cualquier otro error de SQL
                    MessageBox.Show(
                        "No se pudo guardar el producto.\n\n" + ex.Message,
                        "Error de base de datos",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // verificamos que se haya seleccionado una fila válida
            if (e.RowIndex < 0) { return; }

            // obtenemos la fila seleccionada
            DataGridViewRow fila = dgvProductos.Rows[e.RowIndex];

            //gardamos el ID del producto seleccionado
            productoSeleccionadoId = Convert.ToInt32(fila.Cells["Id"].Value);

            // pasamos los datos de la fila a los TextBox
            txtCodigo.Text = fila.Cells["Codigo"].Value?.ToString() ?? "";
            txtNombre.Text = fila.Cells["Nombre"].Value?.ToString() ?? "";
            txtPrecio.Text = fila.Cells["Precio"].Value?.ToString() ?? "";
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            // Verificamos que haya un producto seleccionado
            if (productoSeleccionadoId == 0)
            {
                MessageBox.Show(
                    "Debe seleccionar un producto de la grilla.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            // Verificamos que el codigo no esté vacío
            if (string.IsNullOrWhiteSpace(txtCodigo.Text))
            {
                MessageBox.Show(
                    "Debe ingresar un código.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtCodigo.Focus();
                return;
            }

            // Verificamos que el nombre no esté vacio
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show(
                    "Debe ingresar un nombre.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtNombre.Focus();
                return;
            }

            // Intentamos convertir el precio a decimal
            if (!decimal.TryParse(txtPrecio.Text, out decimal precio))
            {
                MessageBox.Show(
                    "El precio debe ser un número válido.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtPrecio.Focus();
                return;
            }

            // Verificamos que el precio no sea negativo
            if (precio < 0)
            {
                MessageBox.Show(
                    "El precio no puede ser negativo.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtPrecio.Focus();
                return;
            }

            // Creamos el objeto con los datos modificados
            Producto producto = new Producto
            {
                Id = productoSeleccionadoId,
                Codigo = txtCodigo.Text.Trim(),
                Nombre = txtNombre.Text.Trim(),
                Precio = precio
            };

            try
            {
                // Enviamos el producto al DAO para actualizarlo
                productoDao.Modificar(producto);

                MessageBox.Show(
                    "Producto modificado correctamente.",
                    "Éxito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                // Actualizamos la grilla
                CargarProductos();

                // Limpiamos los campos
                txtCodigo.Clear();
                txtNombre.Clear();
                txtPrecio.Clear();

                // Reiniciamos la selección
                productoSeleccionadoId = 0;

                // Dejamos el cursor en código
                txtCodigo.Focus();
            }
            catch (SqlException ex)
            {
                // 2601 y 2627 indican conflictos con valores únicos (cosas de sql)
                if (ex.Number == 2601 || ex.Number == 2627)
                {
                    MessageBox.Show(
                        "Ya existe otro producto con ese código.",
                        "Código duplicado",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(
                        "No se pudo modificar el producto.\n\n" + ex.Message,
                        "Error de base de datos",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void btnDarDeBaja_Click(object sender, EventArgs e)
        {
            //verificar  que el producto esta seleccionado
            if (productoSeleccionadoId == 0)
            {
                MessageBox.Show(
                    "Debe seleccionar un producto de la grilla.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            //pedimos confirmacion antes de realizar una accion destructiva
            DialogResult respuesta = MessageBox.Show(
                "¿Está seguro de que desea dar de baja este producto?",
                "Confirmar baja",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            // si el usuario elige No, no hacemos nada
            if (respuesta != DialogResult.Yes)
                return;

            try
            {
                // Realizamos la baja logica en SQL Server
                productoDao.DarDeBaja(productoSeleccionadoId);

                MessageBox.Show(
                    "Producto dado de baja correctamente.",
                    "Éxito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                // Volvemos a cargar los productos
                CargarProductos();

                // Limpiamos los TextBox
                txtCodigo.Clear();
                txtNombre.Clear();
                txtPrecio.Clear();

                // Reiniciamos el producto seleccionado
                productoSeleccionadoId = 0;

                // Dejamos el cursor en codigo
                txtCodigo.Focus();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    "No se pudo dar de baja el producto.\n\n" + ex.Message,
                    "Error de base de datos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

        }

        //mejora para buscar productos por codigo o nombre en tiempo real
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            // Obtenemos el texto escrito en el buscador
            string texto = txtBuscar.Text.Trim();

            try
            {
                // Si no escribió nada, mostramos todos los productos
                if (string.IsNullOrWhiteSpace(texto))
                {
                    CargarProductos();
                    return;
                }

                // Buscamos por código o nombre
                List<Producto> productos = productoDao.Buscar(texto);

                // Actualizamos la grilla
                dgvProductos.DataSource = null;
                dgvProductos.DataSource = productos;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    "No se pudieron buscar los productos.\n\n" + ex.Message,
                    "Error de base de datos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

    }
}
