# Facturación Simple

Trabajo práctico para la materia **Desarrollo y Arquitectura de Software**.

## Tecnologías utilizadas

* .NET 8
* C#
* Windows Forms
* ADO.NET
* Microsoft.Data.SqlClient
* SQL Server
* Visual Studio 2022

## Descripción

Aplicación de escritorio para gestionar productos, emitir facturas, consultar facturas y generar reportes de ventas.

La aplicación utiliza ADO.NET en modo conectado para comunicarse con SQL Server.

## Funcionalidades

### Productos

* Alta de productos.
* Modificación de productos.
* Búsqueda por código o nombre.
* Baja lógica mediante el campo `Activo`.
* Validación de código único.
* Validación de precio mayor o igual a cero.

### Facturación

* Carga de datos del cliente.
* Selección de productos activos.
* Selección de cantidades.
* Cálculo automático de subtotales.
* Cálculo automático del total.
* Evita agregar el mismo producto dos veces a una factura.
* Guarda cabecera y detalles mediante una transacción.
* El precio utilizado en la factura se copia al detalle para conservar el precio histórico.

### Consulta de facturas

* Filtro por fecha desde y fecha hasta.
* Filtro por cliente.
* Visualización de las facturas encontradas.
* Visualización del detalle de una factura seleccionada.

### Reportes

* Consulta de ventas por período.
* Filtro opcional por producto.
* Cantidad total vendida por producto.
* Monto total facturado por producto.

## Arquitectura

El proyecto utiliza una separación simple de responsabilidades:

```text
Formularios
    ↓
DAO
    ↓
SqlCommand
    ↓
SQL Server
```

Los formularios se encargan de la interfaz y las validaciones de entrada.

Las clases DAO se encargan del acceso a datos y contienen las consultas SQL.

Las entidades representan los datos utilizados por la aplicación.

## Estructura del proyecto

```text
Tp_Facturación_simple
│
├── BaseDeDatos
│   └── CrearBaseDatos.sql
│
├── Datos
│   ├── Conexion.cs
│   ├── ProductoDao.cs
│   ├── FacturaDao.cs
│   └── ReporteDao.cs
│
├── Entidades
│   ├── Producto.cs
│   ├── Factura.cs
│   ├── FacturaDetalle.cs
│   └── ReporteProducto.cs
│
├── Form1.cs
├── FrmProductos.cs
├── FrmNuevaFactura.cs
├── FrmConsultarFacturas.cs
├── FrmReportes.cs
├── Program.cs
└── Tp_Facturación_simple.sln
```

## Base de datos

La aplicación utiliza una base de datos llamada:

```text
FacturacionSimple
```

El modelo está compuesto por tres tablas:

```text
Productos
    │
    │
    └───────────────┐
                    │
                    ↓
              FacturaDetalle
                    ↑
                    │
                    │
                 Facturas
```

### Productos

Contiene el catálogo de productos.

Campos principales:

* `Id`
* `Codigo`
* `Nombre`
* `Precio`
* `Activo`

### Facturas

Contiene la cabecera de cada factura.

Campos principales:

* `Id`
* `Numero`
* `Fecha`
* `ClienteNombre`
* `ClienteDocumento`
* `Total`

### FacturaDetalle

Contiene los productos incluidos en cada factura.

Campos principales:

* `Id`
* `FacturaId`
* `ProductoId`
* `Cantidad`
* `PrecioUnitario`
* `Subtotal`

## Creación de la base de datos

Dentro de la carpeta:

```text
BaseDeDatos
```

se encuentra el archivo:

```text
CrearBaseDatos.sql
```

Para crear la base de datos:

1. Abrir SQL Server Management Studio.
2. Abrir el archivo `CrearBaseDatos.sql`.
3. Ejecutar el script con `F5`.
4. Verificar que aparezca la base de datos `FacturacionSimple`.

El script crea automáticamente la base de datos y las tres tablas necesarias.

## Conexión a SQL Server

La conexión utilizada actualmente es:

```text
Data Source=(localdb)\MSSQLLocalDB;
Initial Catalog=FacturacionSimple;
Integrated Security=True;
TrustServerCertificate=True;
```

La cadena se encuentra en:

```text
Datos/Conexion.cs
```

Si el servidor SQL utilizado es diferente, se debe modificar la cadena de conexión en ese archivo.

Por ejemplo, si se utiliza otra instancia de SQL Server, se debe reemplazar:

```text
(localdb)\MSSQLLocalDB
```

por el nombre correspondiente del servidor.

## Ejecución del proyecto

1. Instalar Visual Studio 2022.
2. Tener instalado .NET 8.
3. Tener SQL Server o SQL Server LocalDB.
4. Abrir el archivo:

```text
Tp_Facturación_simple.sln
```

5. Crear la base de datos ejecutando:

```text
BaseDeDatos/CrearBaseDatos.sql
```

6. Verificar la cadena de conexión en:

```text
Datos/Conexion.cs
```

7. Ejecutar el proyecto desde Visual Studio.

## Acceso a datos

La aplicación utiliza:

* `SqlConnection`
* `SqlCommand`
* `SqlDataReader`
* `SqlTransaction`
* Parámetros SQL

No se utilizan como mecanismo principal de persistencia:

* `SqlDataAdapter`
* `DataSet`
* `DataTable`

Tampoco se utilizan ORMs como Entity Framework o Dapper.

## Transacciones

La emisión de una factura utiliza una transacción.

La cabecera y todos sus detalles se guardan dentro de la misma transacción.

Si ocurre un error durante el proceso, se realiza `Rollback` para evitar que quede una factura incompleta.

Si todo se guarda correctamente, se realiza `Commit`.

## Precio histórico

Cuando se crea una factura, el precio actual del producto se copia en `FacturaDetalle.PrecioUnitario`.

De esta manera, si posteriormente se modifica el precio del producto, las facturas existentes mantienen el precio utilizado en el momento de la venta.

## Requisitos

* Windows 10/11
* Visual Studio 2022
* .NET 8
* SQL Server o SQL Server LocalDB


