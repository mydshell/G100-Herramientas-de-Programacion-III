using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Security.Principal;
using System.Text;
using System.Text.RegularExpressions;
using Capa_AccesoDatos.Entidades;

namespace Capa_AccesoDatos
{
    public class Cls_Acceso_Datos
    {
        private static readonly Regex TableNameRegex = new Regex("^[A-Za-z0-9_]+$", RegexOptions.Compiled);
        private readonly string _connectionString;
        private readonly SqlConnection _conexionCompartida;

        public Cls_Acceso_Datos()
        {
            var configured = ConfigurationManager.ConnectionStrings["DbFacturas"]?.ConnectionString;
            _connectionString = string.IsNullOrWhiteSpace(configured)
                ? "Server=localhost\\SQLEXPRESS;Database=[DBFACTURAS];Integrated Security=SSPI;TrustServerCertificate=True"
                : configured;
            _conexionCompartida = new SqlConnection(_connectionString);
        }

        private SqlConnection CrearConexion()
        {
            return new SqlConnection(_connectionString);
        }

        public SqlConnection AbrirBd()
        {
            if (_conexionCompartida.State != ConnectionState.Open)
            {
                _conexionCompartida.Open();
            }

            return _conexionCompartida;
        }

        public SqlConnection AbrirBD()
        {
            return AbrirBd();
        }

        public void CerrarBd()
        {
            if (_conexionCompartida.State != ConnectionState.Closed)
            {
                _conexionCompartida.Close();
            }
        }

        public void CerrarBD()
        {
            CerrarBd();
        }

        public string ObtenerDiagnosticoConexion(Exception ex = null)
        {
            var sb = new StringBuilder();

            sb.AppendLine("Diagnostico de conexion SQL Server");
            sb.AppendLine("Usuario Windows: " + WindowsIdentity.GetCurrent().Name);
            sb.AppendLine("Maquina: " + Environment.MachineName);
            sb.AppendLine("Config file: " + AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
            sb.AppendLine("ConnectionString: " + _connectionString);

            if (ex == null)
            {
                return sb.ToString();
            }

            sb.AppendLine("Tipo de excepcion: " + ex.GetType().FullName);
            sb.AppendLine("Mensaje: " + ex.Message);

            var sqlEx = ex as SqlException;
            if (sqlEx != null)
            {
                sb.AppendLine("SqlException.Number: " + sqlEx.Number);
                sb.AppendLine("SqlException.State: " + sqlEx.State);
                sb.AppendLine("SqlException.Class: " + sqlEx.Class);
                sb.AppendLine("SqlException.Server: " + sqlEx.Server);
                sb.AppendLine("SqlException.Procedure: " + sqlEx.Procedure);
                sb.AppendLine("SqlException.LineNumber: " + sqlEx.LineNumber);
                sb.AppendLine("SqlException.ClientConnectionId: " + sqlEx.ClientConnectionId);

                for (int i = 0; i < sqlEx.Errors.Count; i++)
                {
                    var error = sqlEx.Errors[i];
                    sb.AppendLine(
                        string.Format(
                            "SqlError[{0}] Number={1}, State={2}, Class={3}, Line={4}, Procedure={5}, Server={6}, Message={7}",
                            i,
                            error.Number,
                            error.State,
                            error.Class,
                            error.LineNumber,
                            error.Procedure,
                            error.Server,
                            error.Message));
                }
            }

            if (ex.InnerException != null)
            {
                sb.AppendLine("InnerException: " + ex.InnerException.Message);
            }

            return sb.ToString();
        }

        public string ValidarUsuario(string usuario, string clave)
        {
            const string sql = @"
SELECT TOP 1 e.strNombre
FROM TBLSEGURIDAD s
INNER JOIN TBLEMPLEADO e ON e.IdEmpleado = s.IdEmpleado
WHERE s.StrUsuario = @usuario
  AND s.StrClave = @clave;";

            using (var conexion = CrearConexion())
            using (var comando = new SqlCommand(sql, conexion))
            {
                comando.Parameters.Add("@usuario", SqlDbType.VarChar, 50).Value = (usuario ?? string.Empty).Trim();
                comando.Parameters.Add("@clave", SqlDbType.VarChar, 50).Value = (clave ?? string.Empty).Trim();

                conexion.Open();
                var resultado = comando.ExecuteScalar();
                return resultado == null ? string.Empty : Convert.ToString(resultado);
            }
        }

        public int EjecutarComando(string sentencia, params SqlParameter[] parametros)
        {
            return EjecutarComando(sentencia, ConvertirParametros(parametros));
        }

        public int EjecutarComando(string sentencia, List<Cls_parametros> listaParametros)
        {
            var conexion = AbrirBd();

            try
            {
                using (var comando = CrearComando(sentencia, CommandType.Text, conexion, listaParametros))
                {
                    return comando.ExecuteNonQuery();
                }
            }
            finally
            {
                CerrarBd();
            }
        }

        public DataTable EjecutarComandoDatos(string sentencia, params SqlParameter[] parametros)
        {
            return EjecutarConsulta(sentencia, ConvertirParametros(parametros));
        }

        public DataTable EjecutarConsulta(string sentencia)
        {
            return EjecutarConsulta(sentencia, null);
        }

        public DataTable EjecutarConsulta(string sentencia, List<Cls_parametros> listaParametros)
        {
            var tabla = new DataTable();
            var conexion = AbrirBd();

            try
            {
                using (var comando = CrearComando(sentencia, CommandType.Text, conexion, listaParametros))
                using (var adaptador = new SqlDataAdapter(comando))
                {
                    adaptador.Fill(tabla);
                }
            }
            finally
            {
                CerrarBd();
            }

            return tabla;
        }

        public int Ejecutar_procedimiento(string nombreProcedimiento, List<Cls_parametros> listaParametros)
        {
            var conexion = AbrirBd();

            try
            {
                using (var comando = CrearComando(nombreProcedimiento, CommandType.StoredProcedure, conexion, listaParametros))
                {
                    return comando.ExecuteNonQuery();
                }
            }
            finally
            {
                CerrarBd();
            }
        }

        public DataTable CargarTabla(string tabla, string condicion = "")
        {
            if (string.IsNullOrWhiteSpace(tabla) || !TableNameRegex.IsMatch(tabla))
            {
                throw new ArgumentException("Nombre de tabla inválido.", nameof(tabla));
            }

            var sql = $"SELECT * FROM {tabla}";
            if (!string.IsNullOrWhiteSpace(condicion))
            {
                sql += " " + condicion;
            }

            return EjecutarComandoDatos(sql);
        }

        public DataTable ListarClientes(string filtro)
        {
            const string sql = @"
SELECT
    IdCliente,
    StrNombre AS NombreCliente,
    CONVERT(VARCHAR(30), NumDocumento) AS Documento,
    StrDireccion AS Direccion,
    StrTelefono AS Telefono,
    StrEmail AS Email
FROM TBLCLIENTES
WHERE (@filtro = '' OR
       StrNombre LIKE '%' + @filtro + '%' OR
       CONVERT(VARCHAR(30), NumDocumento) LIKE '%' + @filtro + '%' OR
       StrTelefono LIKE '%' + @filtro + '%')
ORDER BY IdCliente DESC;";

            return EjecutarComandoDatos(
                sql,
                new SqlParameter("@filtro", SqlDbType.VarChar, 80) { Value = (filtro ?? string.Empty).Trim() }
            );
        }

        public DataTable ListarClientesBasico()
        {
            const string sql = @"
SELECT
    IdCliente,
    StrNombre AS NombreCliente
FROM TBLCLIENTES
ORDER BY StrNombre;";

            return EjecutarComandoDatos(sql);
        }

        public Cliente ObtenerClientePorId(int idCliente)
        {
            const string sql = @"
SELECT
    IdCliente,
    StrNombre AS NombreCliente,
    CONVERT(VARCHAR(30), NumDocumento) AS Documento,
    StrDireccion AS Direccion,
    StrTelefono AS Telefono,
    StrEmail AS Email
FROM TBLCLIENTES
WHERE IdCliente = @idCliente;";

            var tabla = EjecutarComandoDatos(
                sql,
                new SqlParameter("@idCliente", SqlDbType.Int) { Value = idCliente }
            );

            if (tabla.Rows.Count == 0)
            {
                return null;
            }

            var row = tabla.Rows[0];
            return new Cliente
            {
                IdCliente = Convert.ToInt32(row["IdCliente"]),
                NombreCliente = Convert.ToString(row["NombreCliente"]),
                Documento = Convert.ToString(row["Documento"]),
                Direccion = Convert.ToString(row["Direccion"]),
                Telefono = Convert.ToString(row["Telefono"]),
                Email = Convert.ToString(row["Email"])
            };
        }

        public int GuardarCliente(Cliente cliente, string usuarioModifica)
        {
            if (cliente == null) throw new ArgumentNullException(nameof(cliente));

            long documento = 0;
            long.TryParse((cliente.Documento ?? string.Empty).Trim(), out documento);

            return Ejecutar_procedimiento(
                "actualizar_Cliente",
                new List<Cls_parametros>
                {
                    CrearParametro("@IdCliente", SqlDbType.Int, cliente.IdCliente <= 0 ? (object)DBNull.Value : cliente.IdCliente),
                    CrearParametro("@StrNombre", SqlDbType.VarChar, (cliente.NombreCliente ?? string.Empty).Trim(), 55),
                    CrearParametro("@NumDocumento", SqlDbType.BigInt, documento),
                    CrearParametro("@StrDireccion", SqlDbType.VarChar, (cliente.Direccion ?? string.Empty).Trim(), 70),
                    CrearParametro("@StrTelefono", SqlDbType.VarChar, (cliente.Telefono ?? string.Empty).Trim(), 30),
                    CrearParametro("@StrEmail", SqlDbType.VarChar, (cliente.Email ?? string.Empty).Trim(), 50),
                    CrearParametro("@StrUsuarioModifica", SqlDbType.VarChar, Recortar(usuarioModifica, 10), 10),
                    CrearParametro("@DtmFechaModifica", SqlDbType.DateTime, DateTime.Now)
                });
        }

        public int EliminarCliente(int idCliente)
        {
            return Ejecutar_procedimiento(
                "Eliminar_Cliente",
                new List<Cls_parametros> { CrearParametro("@IdCliente", SqlDbType.Int, idCliente) });
        }

        public DataTable ListarCategorias(string filtro)
        {
            const string sql = @"
SELECT
    IdCategoria,
    StrDescripcion AS NombreCategoria
FROM TBLCATEGORIA_PROD
WHERE (@filtro = '' OR StrDescripcion LIKE '%' + @filtro + '%')
ORDER BY IdCategoria DESC;";

            return EjecutarComandoDatos(
                sql,
                new SqlParameter("@filtro", SqlDbType.VarChar, 80) { Value = (filtro ?? string.Empty).Trim() }
            );
        }

        public DataTable ListarCategoriasBasico()
        {
            const string sql = @"
SELECT
    IdCategoria,
    StrDescripcion AS NombreCategoria
FROM TBLCATEGORIA_PROD
ORDER BY StrDescripcion;";

            return EjecutarComandoDatos(sql);
        }

        public Categoria ObtenerCategoriaPorId(int idCategoria)
        {
            const string sql = @"
SELECT
    IdCategoria,
    StrDescripcion AS NombreCategoria
FROM TBLCATEGORIA_PROD
WHERE IdCategoria = @idCategoria;";

            var tabla = EjecutarComandoDatos(
                sql,
                new SqlParameter("@idCategoria", SqlDbType.Int) { Value = idCategoria }
            );

            if (tabla.Rows.Count == 0)
            {
                return null;
            }

            var row = tabla.Rows[0];
            return new Categoria
            {
                IdCategoria = Convert.ToInt32(row["IdCategoria"]),
                NombreCategoria = Convert.ToString(row["NombreCategoria"])
            };
        }

        public int GuardarCategoria(Categoria categoria, string usuarioModifica)
        {
            if (categoria == null) throw new ArgumentNullException(nameof(categoria));

            return Ejecutar_procedimiento(
                "actualizar_CategoriaProducto",
                new List<Cls_parametros>
                {
                    CrearParametro("@IdCategoria", SqlDbType.Int, categoria.IdCategoria <= 0 ? (object)DBNull.Value : categoria.IdCategoria),
                    CrearParametro("@StrDescripcion", SqlDbType.VarChar, (categoria.NombreCategoria ?? string.Empty).Trim(), 60),
                    CrearParametro("@DtmFechaModifica", SqlDbType.DateTime, DateTime.Now),
                    CrearParametro("@StrUsuarioModifico", SqlDbType.VarChar, Recortar(usuarioModifica, 20), 20)
                });
        }

        public int EliminarCategoria(int idCategoria)
        {
            const string sql = @"
DELETE FROM TBLCATEGORIA_PROD
WHERE IdCategoria = @IdCategoria;";
            return EjecutarComando(
                sql,
                new SqlParameter("@IdCategoria", SqlDbType.Int) { Value = idCategoria }
            );
        }

        public int ContarProductosPorCategoria(int idCategoria)
        {
            const string sql = @"
SELECT COUNT(1)
FROM TBLPRODUCTO
WHERE IdCategoria = @IdCategoria;";

            using (var conexion = CrearConexion())
            using (var comando = new SqlCommand(sql, conexion))
            {
                comando.Parameters.Add("@IdCategoria", SqlDbType.Int).Value = idCategoria;
                conexion.Open();
                var resultado = comando.ExecuteScalar();
                return resultado == null || resultado == DBNull.Value ? 0 : Convert.ToInt32(resultado);
            }
        }

        public DataTable ListarProductos(string filtro)
        {
            const string sql = @"
SELECT
    p.IdProducto,
    p.StrNombre AS NombreProducto,
    p.StrCodigo AS Codigo,
    p.IdCategoria,
    ISNULL(c.StrDescripcion, '') AS Categoria,
    CONVERT(VARCHAR(30), p.NumPrecioCompra) AS PrecioCompra,
    CONVERT(VARCHAR(30), p.NumPrecioVenta) AS PrecioVenta,
    CONVERT(VARCHAR(30), p.NumStock) AS Stock,
    p.StrDetalle AS Detalle,
    p.strFoto AS RutaImagen
FROM TBLPRODUCTO p
LEFT JOIN TBLCATEGORIA_PROD c ON c.IdCategoria = p.IdCategoria
WHERE (
    @filtro = '' OR
    p.StrNombre LIKE '%' + @filtro + '%' OR
    p.StrCodigo LIKE '%' + @filtro + '%' OR
    ISNULL(c.StrDescripcion, '') LIKE '%' + @filtro + '%'
)
ORDER BY p.IdProducto DESC;";

            return EjecutarComandoDatos(
                sql,
                new SqlParameter("@filtro", SqlDbType.VarChar, 80) { Value = (filtro ?? string.Empty).Trim() }
            );
        }

        public Producto ObtenerProductoPorId(int idProducto)
        {
            const string sql = @"
SELECT
    p.IdProducto,
    p.StrNombre AS NombreProducto,
    p.StrCodigo AS Codigo,
    p.IdCategoria,
    ISNULL(c.StrDescripcion, '') AS Categoria,
    CONVERT(VARCHAR(30), p.NumPrecioCompra) AS PrecioCompra,
    CONVERT(VARCHAR(30), p.NumPrecioVenta) AS PrecioVenta,
    CONVERT(VARCHAR(30), p.NumStock) AS Stock,
    p.StrDetalle AS Detalle,
    p.strFoto AS RutaImagen
FROM TBLPRODUCTO p
LEFT JOIN TBLCATEGORIA_PROD c ON c.IdCategoria = p.IdCategoria
WHERE p.IdProducto = @idProducto;";

            var tabla = EjecutarComandoDatos(
                sql,
                new SqlParameter("@idProducto", SqlDbType.Int) { Value = idProducto }
            );

            if (tabla.Rows.Count == 0)
            {
                return null;
            }

            var row = tabla.Rows[0];
            return new Producto
            {
                IdProducto = Convert.ToInt32(row["IdProducto"]),
                NombreProducto = Convert.ToString(row["NombreProducto"]),
                Codigo = Convert.ToString(row["Codigo"]),
                IdCategoria = Convert.ToInt32(row["IdCategoria"]),
                Categoria = Convert.ToString(row["Categoria"]),
                PrecioCompra = Convert.ToString(row["PrecioCompra"]),
                PrecioVenta = Convert.ToString(row["PrecioVenta"]),
                Stock = Convert.ToString(row["Stock"]),
                Detalle = Convert.ToString(row["Detalle"]),
                RutaImagen = Convert.ToString(row["RutaImagen"])
            };
        }

        public int GuardarProducto(Producto producto, string usuarioModifica)
        {
            if (producto == null) throw new ArgumentNullException(nameof(producto));

            return Ejecutar_procedimiento(
                "actualizar_Producto",
                new List<Cls_parametros>
                {
                    CrearParametro("@IdProducto", SqlDbType.Int, producto.IdProducto <= 0 ? (object)DBNull.Value : producto.IdProducto),
                    CrearParametro("@StrNombre", SqlDbType.VarChar, (producto.NombreProducto ?? string.Empty).Trim(), 70),
                    CrearParametro("@StrCodigo", SqlDbType.VarChar, (producto.Codigo ?? string.Empty).Trim(), 30),
                    CrearParametro("@NumPrecioCompra", SqlDbType.Float, ParseDouble(producto.PrecioCompra)),
                    CrearParametro("@NumPrecioVenta", SqlDbType.Float, ParseDouble(producto.PrecioVenta)),
                    CrearParametro("@IdCategoria", SqlDbType.Int, producto.IdCategoria <= 0 ? (object)DBNull.Value : producto.IdCategoria),
                    CrearParametro("@StrDetalle", SqlDbType.VarChar, (producto.Detalle ?? string.Empty).Trim(), 50),
                    CrearParametro("@strFoto", SqlDbType.VarChar, (producto.RutaImagen ?? string.Empty).Trim(), 50),
                    CrearParametro("@NumStock", SqlDbType.Int, ParseInt(producto.Stock)),
                    CrearParametro("@DtmFechaModifica", SqlDbType.DateTime, DateTime.Now),
                    CrearParametro("@StrUsuarioModifica", SqlDbType.VarChar, Recortar(usuarioModifica, 40), 40)
                });
        }

        public int EliminarProducto(int idProducto)
        {
            return Ejecutar_procedimiento(
                "Eliminar_Producto",
                new List<Cls_parametros> { CrearParametro("@IdProducto", SqlDbType.Int, idProducto) });
        }

        public DataTable ListarEmpleadosBasico()
        {
            const string sql = @"
SELECT
    IdEmpleado,
    strNombre AS NombreEmpleado
FROM TBLEMPLEADO
ORDER BY strNombre;";

            return EjecutarComandoDatos(sql);
        }

        public DataTable ListarEmpleados(string filtro)
        {
            var roleInfo = ObtenerInfoRoles();
            var roleExpr = roleInfo != null ? $"ISNULL(r.[{roleInfo.NombreColumna}], '')" : "''";
            var joinRole = roleInfo != null ? $"LEFT JOIN TBLROLES r ON r.[{roleInfo.IdColumna}] = e.IdRolEmpleado" : string.Empty;

            var sql = $@"
SELECT
    e.IdEmpleado,
    e.strNombre AS NombreEmpleado,
    CONVERT(VARCHAR(30), e.NumDocumento) AS Documento,
    e.StrDireccion AS Direccion,
    e.StrTelefono AS Telefono,
    e.StrEmail AS Email,
    e.IdRolEmpleado,
    {roleExpr} AS RolEmpleadoNombre,
    e.DtmIngreso AS FechaIngreso,
    e.DtmRetiro AS FechaRetiro,
    e.strDatosAdicionales AS DatoAdicional
FROM TBLEMPLEADO e
{joinRole}
WHERE (
    @filtro = '' OR
    e.strNombre LIKE '%' + @filtro + '%' OR
    CONVERT(VARCHAR(30), e.NumDocumento) LIKE '%' + @filtro + '%' OR
    ISNULL(e.StrTelefono, '') LIKE '%' + @filtro + '%' OR
    ISNULL(e.StrEmail, '') LIKE '%' + @filtro + '%' OR
    {roleExpr} LIKE '%' + @filtro + '%'
)
ORDER BY e.IdEmpleado DESC;";

            return EjecutarComandoDatos(
                sql,
                new SqlParameter("@filtro", SqlDbType.VarChar, 80) { Value = (filtro ?? string.Empty).Trim() }
            );
        }

        public Empleado ObtenerEmpleadoPorId(int idEmpleado)
        {
            var roleInfo = ObtenerInfoRoles();
            var roleExpr = roleInfo != null ? $"ISNULL(r.[{roleInfo.NombreColumna}], '')" : "''";
            var joinRole = roleInfo != null ? $"LEFT JOIN TBLROLES r ON r.[{roleInfo.IdColumna}] = e.IdRolEmpleado" : string.Empty;

            var sql = $@"
SELECT
    e.IdEmpleado,
    e.strNombre AS NombreEmpleado,
    CONVERT(VARCHAR(30), e.NumDocumento) AS Documento,
    e.StrDireccion AS Direccion,
    e.StrTelefono AS Telefono,
    e.StrEmail AS Email,
    e.IdRolEmpleado,
    {roleExpr} AS RolEmpleadoNombre,
    e.DtmIngreso AS FechaIngreso,
    e.DtmRetiro AS FechaRetiro,
    e.strDatosAdicionales AS DatoAdicional
FROM TBLEMPLEADO e
{joinRole}
WHERE e.IdEmpleado = @idEmpleado;";

            var tabla = EjecutarComandoDatos(
                sql,
                new SqlParameter("@idEmpleado", SqlDbType.Int) { Value = idEmpleado }
            );

            if (tabla.Rows.Count == 0)
            {
                return null;
            }

            var row = tabla.Rows[0];
            return new Empleado
            {
                IdEmpleado = Convert.ToInt32(row["IdEmpleado"]),
                NombreEmpleado = Convert.ToString(row["NombreEmpleado"]),
                Documento = Convert.ToString(row["Documento"]),
                Direccion = Convert.ToString(row["Direccion"]),
                Telefono = Convert.ToString(row["Telefono"]),
                Email = Convert.ToString(row["Email"]),
                IdRolEmpleado = row["IdRolEmpleado"] == DBNull.Value ? 0 : Convert.ToInt32(row["IdRolEmpleado"]),
                RolEmpleadoNombre = Convert.ToString(row["RolEmpleadoNombre"]),
                FechaIngreso = row["FechaIngreso"] == DBNull.Value ? DateTime.Today : Convert.ToDateTime(row["FechaIngreso"]),
                FechaRetiro = row["FechaRetiro"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row["FechaRetiro"]),
                DatoAdicional = Convert.ToString(row["DatoAdicional"])
            };
        }

        public int GuardarEmpleado(Empleado empleado, string usuarioModifica)
        {
            if (empleado == null) throw new ArgumentNullException(nameof(empleado));

            long documento;
            long.TryParse((empleado.Documento ?? string.Empty).Trim(), out documento);

            return Ejecutar_procedimiento(
                "actualizar_Empleado",
                new List<Cls_parametros>
                {
                    CrearParametro("@IdEmpleado", SqlDbType.Int, empleado.IdEmpleado <= 0 ? (object)DBNull.Value : empleado.IdEmpleado),
                    CrearParametro("@strNombre", SqlDbType.VarChar, (empleado.NombreEmpleado ?? string.Empty).Trim(), 50),
                    CrearParametro("@NumDocumento", SqlDbType.BigInt, documento),
                    CrearParametro("@StrDireccion", SqlDbType.VarChar, (empleado.Direccion ?? string.Empty).Trim(), 50),
                    CrearParametro("@StrTelefono", SqlDbType.VarChar, (empleado.Telefono ?? string.Empty).Trim(), 20),
                    CrearParametro("@StrEmail", SqlDbType.VarChar, (empleado.Email ?? string.Empty).Trim(), 50),
                    CrearParametro("@IdRolEmpleado", SqlDbType.Int, empleado.IdRolEmpleado <= 0 ? (object)DBNull.Value : empleado.IdRolEmpleado),
                    CrearParametro("@DtmIngreso", SqlDbType.DateTime, empleado.FechaIngreso == default(DateTime) ? DateTime.Today : empleado.FechaIngreso.Date),
                    CrearParametro("@DtmRetiro", SqlDbType.DateTime, empleado.FechaRetiro.HasValue ? (object)empleado.FechaRetiro.Value.Date : DBNull.Value),
                    CrearParametro("@strDatosAdicionales", SqlDbType.NVarChar, (empleado.DatoAdicional ?? string.Empty).Trim(), 250),
                    CrearParametro("@DtmFechaModifica", SqlDbType.DateTime, DateTime.Now),
                    CrearParametro("@StrUsuarioModifico", SqlDbType.VarChar, Recortar(usuarioModifica, 20), 20)
                });
        }

        public int EliminarEmpleado(int idEmpleado)
        {
            return Ejecutar_procedimiento(
                "Eliminar_Empleado",
                new List<Cls_parametros> { CrearParametro("@IdEmpleado", SqlDbType.Int, idEmpleado) });
        }

        public DataTable ListarSeguridad(string filtro)
        {
            const string sql = @"
SELECT
    s.IdSeguridad,
    s.IdEmpleado,
    e.strNombre AS Empleado,
    s.StrUsuario AS Usuario,
    s.StrClave AS Clave
FROM TBLSEGURIDAD s
INNER JOIN TBLEMPLEADO e ON e.IdEmpleado = s.IdEmpleado
WHERE (@filtro = '' OR
       s.StrUsuario LIKE '%' + @filtro + '%' OR
       e.strNombre LIKE '%' + @filtro + '%')
ORDER BY s.IdSeguridad DESC;";

            return EjecutarComandoDatos(
                sql,
                new SqlParameter("@filtro", SqlDbType.VarChar, 80) { Value = (filtro ?? string.Empty).Trim() }
            );
        }

        public SeguridadUsuario ObtenerSeguridadPorEmpleado(int idEmpleado)
        {
            const string sql = @"
SELECT TOP 1
    s.IdSeguridad,
    s.IdEmpleado,
    e.strNombre AS Empleado,
    s.StrUsuario AS Usuario,
    s.StrClave AS Clave
FROM TBLSEGURIDAD s
INNER JOIN TBLEMPLEADO e ON e.IdEmpleado = s.IdEmpleado
WHERE s.IdEmpleado = @idEmpleado;";

            var tabla = EjecutarComandoDatos(
                sql,
                new SqlParameter("@idEmpleado", SqlDbType.Int) { Value = idEmpleado }
            );

            if (tabla.Rows.Count == 0)
            {
                return null;
            }

            var row = tabla.Rows[0];
            return new SeguridadUsuario
            {
                IdSeguridad = Convert.ToInt32(row["IdSeguridad"]),
                IdEmpleado = Convert.ToInt32(row["IdEmpleado"]),
                Empleado = Convert.ToString(row["Empleado"]),
                Usuario = Convert.ToString(row["Usuario"]),
                Clave = Convert.ToString(row["Clave"])
            };
        }

        public bool ExisteUsuarioSeguridad(string usuario, int idEmpleadoActual)
        {
            const string sql = @"
SELECT COUNT(1)
FROM TBLSEGURIDAD
WHERE StrUsuario = @usuario
  AND IdEmpleado <> @idEmpleado;";

            using (var conexion = CrearConexion())
            using (var comando = new SqlCommand(sql, conexion))
            {
                comando.Parameters.Add("@usuario", SqlDbType.VarChar, 50).Value = (usuario ?? string.Empty).Trim();
                comando.Parameters.Add("@idEmpleado", SqlDbType.Int).Value = idEmpleadoActual;

                conexion.Open();
                var total = Convert.ToInt32(comando.ExecuteScalar());
                return total > 0;
            }
        }

        public int GuardarSeguridad(SeguridadUsuario usuario, string usuarioModifica)
        {
            if (usuario == null) throw new ArgumentNullException(nameof(usuario));
            if (usuario.IdEmpleado <= 0) throw new ArgumentException("IdEmpleado inválido.", nameof(usuario));

            return Ejecutar_procedimiento(
                "actualizar_Seguridad",
                new List<Cls_parametros>
                {
                    CrearParametro("@IdEmpleado", SqlDbType.Int, usuario.IdEmpleado),
                    CrearParametro("@StrUsuario", SqlDbType.VarChar, (usuario.Usuario ?? string.Empty).Trim(), 50),
                    CrearParametro("@StrClave", SqlDbType.VarChar, (usuario.Clave ?? string.Empty).Trim(), 50),
                    CrearParametro("@DtmFechaModifica", SqlDbType.DateTime, DateTime.Now),
                    CrearParametro("@StrUsuarioModifico", SqlDbType.VarChar, Recortar(usuarioModifica, 10), 10)
                });
        }

        public int EliminarSeguridad(int idEmpleado)
        {
            return Ejecutar_procedimiento(
                "Eliminar_Seguridad",
                new List<Cls_parametros> { CrearParametro("@IdEmpleado", SqlDbType.Int, idEmpleado) });
        }

        public DataTable ListarRoles(string filtro)
        {
            var roleInfo = ObtenerInfoRoles(true);
            var whereDetalle = roleInfo.DetalleColumna == null
                ? ""
                : $" OR ISNULL([{roleInfo.DetalleColumna}], '') LIKE '%' + @filtro + '%'";

            var sql = $@"
SELECT
    [{roleInfo.IdColumna}] AS IdRolEmpleado,
    [{roleInfo.NombreColumna}] AS NombreRol,
    {(roleInfo.DetalleColumna == null ? "CAST('' AS VARCHAR(250))" : $"ISNULL([{roleInfo.DetalleColumna}], '')")} AS DetallesRol
FROM TBLROLES
WHERE (
    @filtro = '' OR
    [{roleInfo.NombreColumna}] LIKE '%' + @filtro + '%'
    {whereDetalle}
)
ORDER BY [{roleInfo.IdColumna}] DESC;";

            return EjecutarComandoDatos(
                sql,
                new SqlParameter("@filtro", SqlDbType.VarChar, 80) { Value = (filtro ?? string.Empty).Trim() }
            );
        }

        public DataTable ListarRolesBasico()
        {
            var roleInfo = ObtenerInfoRoles(true);

            var sql = $@"
SELECT
    [{roleInfo.IdColumna}] AS IdRolEmpleado,
    [{roleInfo.NombreColumna}] AS NombreRol
FROM TBLROLES
ORDER BY [{roleInfo.NombreColumna}];";

            return EjecutarComandoDatos(sql);
        }

        public RolEmpleado ObtenerRolPorId(int idRolEmpleado)
        {
            var roleInfo = ObtenerInfoRoles(true);

            var sql = $@"
SELECT TOP 1
    [{roleInfo.IdColumna}] AS IdRolEmpleado,
    [{roleInfo.NombreColumna}] AS NombreRol,
    {(roleInfo.DetalleColumna == null ? "CAST('' AS VARCHAR(250))" : $"ISNULL([{roleInfo.DetalleColumna}], '')")} AS DetallesRol
FROM TBLROLES
WHERE [{roleInfo.IdColumna}] = @idRolEmpleado;";

            var tabla = EjecutarComandoDatos(
                sql,
                new SqlParameter("@idRolEmpleado", SqlDbType.Int) { Value = idRolEmpleado }
            );

            if (tabla.Rows.Count == 0)
            {
                return null;
            }

            var row = tabla.Rows[0];
            return new RolEmpleado
            {
                IdRolEmpleado = Convert.ToInt32(row["IdRolEmpleado"]),
                NombreRol = Convert.ToString(row["NombreRol"]),
                DetallesRol = Convert.ToString(row["DetallesRol"])
            };
        }

        public int GuardarRol(RolEmpleado rol, string usuarioModifica)
        {
            if (rol == null) throw new ArgumentNullException(nameof(rol));

            var roleInfo = ObtenerInfoRoles(true);
            var conDetalle = !string.IsNullOrWhiteSpace(roleInfo.DetalleColumna);
            var conFecha = !string.IsNullOrWhiteSpace(roleInfo.FechaColumna);
            var conUsuario = !string.IsNullOrWhiteSpace(roleInfo.UsuarioColumna);

            if (rol.IdRolEmpleado <= 0)
            {
                var columnas = new List<string> { $"[{roleInfo.NombreColumna}]" };
                var valores = new List<string> { "@nombre" };
                var parametros = new List<SqlParameter>
                {
                    new SqlParameter("@nombre", SqlDbType.VarChar, 120) { Value = (rol.NombreRol ?? string.Empty).Trim() }
                };

                if (conDetalle)
                {
                    columnas.Add($"[{roleInfo.DetalleColumna}]");
                    valores.Add("@detalle");
                    parametros.Add(new SqlParameter("@detalle", SqlDbType.VarChar, 250) { Value = (rol.DetallesRol ?? string.Empty).Trim() });
                }

                if (conFecha)
                {
                    columnas.Add($"[{roleInfo.FechaColumna}]");
                    valores.Add("@fecha");
                    parametros.Add(new SqlParameter("@fecha", SqlDbType.DateTime) { Value = DateTime.Now });
                }

                if (conUsuario)
                {
                    columnas.Add($"[{roleInfo.UsuarioColumna}]");
                    valores.Add("@usuario");
                    parametros.Add(new SqlParameter("@usuario", SqlDbType.VarChar, 20) { Value = Recortar(usuarioModifica, 20) });
                }

                var insertSql = $"INSERT INTO TBLROLES ({string.Join(",", columnas)}) VALUES ({string.Join(",", valores)});";
                return EjecutarComando(insertSql, parametros.ToArray());
            }

            var updates = new List<string> { $"[{roleInfo.NombreColumna}] = @nombre" };
            var updateParams = new List<SqlParameter>
            {
                new SqlParameter("@nombre", SqlDbType.VarChar, 120) { Value = (rol.NombreRol ?? string.Empty).Trim() },
                new SqlParameter("@id", SqlDbType.Int) { Value = rol.IdRolEmpleado }
            };

            if (conDetalle)
            {
                updates.Add($"[{roleInfo.DetalleColumna}] = @detalle");
                updateParams.Add(new SqlParameter("@detalle", SqlDbType.VarChar, 250) { Value = (rol.DetallesRol ?? string.Empty).Trim() });
            }

            if (conFecha)
            {
                updates.Add($"[{roleInfo.FechaColumna}] = @fecha");
                updateParams.Add(new SqlParameter("@fecha", SqlDbType.DateTime) { Value = DateTime.Now });
            }

            if (conUsuario)
            {
                updates.Add($"[{roleInfo.UsuarioColumna}] = @usuario");
                updateParams.Add(new SqlParameter("@usuario", SqlDbType.VarChar, 20) { Value = Recortar(usuarioModifica, 20) });
            }

            var updateSql = $"UPDATE TBLROLES SET {string.Join(",", updates)} WHERE [{roleInfo.IdColumna}] = @id;";
            return EjecutarComando(updateSql, updateParams.ToArray());
        }

        public int EliminarRol(int idRolEmpleado)
        {
            var roleInfo = ObtenerInfoRoles(true);
            var sql = $@"
UPDATE TBLEMPLEADO
SET IdRolEmpleado = NULL
WHERE IdRolEmpleado = @id;

DELETE FROM TBLROLES
WHERE [{roleInfo.IdColumna}] = @id;";
            return EjecutarComando(
                sql,
                new SqlParameter("@id", SqlDbType.Int) { Value = idRolEmpleado }
            );
        }

        public bool ExisteEmpleadosConRol(int idRolEmpleado)
        {
            const string sql = "SELECT COUNT(1) FROM TBLEMPLEADO WHERE IdRolEmpleado = @id;";
            using (var conexion = CrearConexion())
            using (var comando = new SqlCommand(sql, conexion))
            {
                comando.Parameters.Add("@id", SqlDbType.Int).Value = idRolEmpleado;
                conexion.Open();
                return Convert.ToInt32(comando.ExecuteScalar()) > 0;
            }
        }

        public DataTable ListarEstadosFactura()
        {
            var columnas = ObtenerColumnasTabla("TBLESTADO_FACTURA");
            var idCol = PrimeraCoincidencia(columnas, "IdEstadoFactura", "IdEstado");
            if (idCol == null)
            {
                throw new InvalidOperationException("No se encontro la columna de identificador en TBLESTADO_FACTURA.");
            }

            var descCol = PrimeraCoincidencia(columnas, "StrDescripcion", "StrEstado", "Descripcion", "Estado");
            var altCol = descCol == "StrDescripcion" ? PrimeraCoincidencia(columnas, "StrEstado") : null;

            string expr;
            if (!string.IsNullOrWhiteSpace(descCol) && !string.IsNullOrWhiteSpace(altCol))
            {
                expr = $"COALESCE(NULLIF(LTRIM(RTRIM([{descCol}])),''), [{altCol}], CAST([{idCol}] AS VARCHAR(20)))";
            }
            else if (!string.IsNullOrWhiteSpace(descCol))
            {
                expr = $"ISNULL([{descCol}], CAST([{idCol}] AS VARCHAR(20)))";
            }
            else
            {
                expr = $"CAST([{idCol}] AS VARCHAR(20))";
            }

            var sql = $@"
SELECT
    [{idCol}] AS IdEstado,
    {expr} AS EstadoFactura
FROM TBLESTADO_FACTURA
ORDER BY [{idCol}];";

            return EjecutarComandoDatos(sql);
        }

        public DataTable ListarFacturas(string filtro)
        {
            var camposFactura = ObtenerInfoCamposFactura();
            var estadoFactura = ObtenerInfoEstadoFactura();

            var sql = $@"
SELECT
    f.IdFactura,
    {camposFactura.NumeroExpr} AS NumeroFactura,
    f.IdCliente,
    c.StrNombre AS ClienteNombreActual,
    f.IdEmpleado,
    e.strNombre AS EmpleadoNombreActual,
    f.DtmFecha AS FechaFactura,
    f.IdEstado,
    {estadoFactura.EstadoExpr} AS EstadoFactura,
    CONVERT(VARCHAR(30), ISNULL(f.NumImpuesto, 0)) AS TotalIvaMostrar,
    CONVERT(VARCHAR(30), ISNULL(f.NumDescuento, 0)) AS DescuentoMostrar,
    CONVERT(VARCHAR(30), ISNULL(f.NumValorTotal, 0)) AS TotalFacturaMostrar,
    {camposFactura.DetalleExpr} AS DetallesProducto
FROM TBLFACTURA f
INNER JOIN TBLCLIENTES c ON c.IdCliente = f.IdCliente
INNER JOIN TBLEMPLEADO e ON e.IdEmpleado = f.IdEmpleado
LEFT JOIN TBLESTADO_FACTURA ef ON ef.[{estadoFactura.IdEstadoCol}] = f.IdEstado
WHERE (
    @filtro = '' OR
    CAST(f.IdFactura AS VARCHAR(30)) LIKE '%' + @filtro + '%' OR
    c.StrNombre LIKE '%' + @filtro + '%' OR
    e.strNombre LIKE '%' + @filtro + '%' OR
    {estadoFactura.EstadoExpr} LIKE '%' + @filtro + '%' OR
    {camposFactura.NumeroExpr} LIKE '%' + @filtro + '%'
)
ORDER BY f.IdFactura DESC;";

            return EjecutarComandoDatos(
                sql,
                new SqlParameter("@filtro", SqlDbType.VarChar, 80) { Value = (filtro ?? string.Empty).Trim() }
            );
        }

        public Factura ObtenerFacturaPorId(int idFactura)
        {
            var camposFactura = ObtenerInfoCamposFactura();
            var estadoFactura = ObtenerInfoEstadoFactura();

            var sql = $@"
SELECT TOP 1
    f.IdFactura,
    {camposFactura.NumeroExpr} AS NumeroFactura,
    f.IdCliente,
    c.StrNombre AS Cliente,
    f.IdEmpleado,
    e.strNombre AS Empleado,
    f.DtmFecha AS FechaFactura,
    f.IdEstado,
    {estadoFactura.EstadoExpr} AS EstadoFactura,
    CONVERT(VARCHAR(30), ISNULL(f.NumImpuesto, 0)) AS TotalIva,
    CONVERT(VARCHAR(30), ISNULL(f.NumDescuento, 0)) AS Descuento,
    CONVERT(VARCHAR(30), ISNULL(f.NumValorTotal, 0)) AS TotalFactura,
    {camposFactura.DetalleExpr} AS DetallesProducto
FROM TBLFACTURA f
INNER JOIN TBLCLIENTES c ON c.IdCliente = f.IdCliente
INNER JOIN TBLEMPLEADO e ON e.IdEmpleado = f.IdEmpleado
LEFT JOIN TBLESTADO_FACTURA ef ON ef.[{estadoFactura.IdEstadoCol}] = f.IdEstado
WHERE f.IdFactura = @idFactura;";

            var tabla = EjecutarComandoDatos(
                sql,
                new SqlParameter("@idFactura", SqlDbType.Int) { Value = idFactura }
            );

            if (tabla.Rows.Count == 0)
            {
                return null;
            }

            var row = tabla.Rows[0];
            return new Factura
            {
                IdFactura = Convert.ToInt32(row["IdFactura"]),
                NumeroFactura = Convert.ToString(row["NumeroFactura"]),
                IdCliente = Convert.ToInt32(row["IdCliente"]),
                Cliente = Convert.ToString(row["Cliente"]),
                IdEmpleado = Convert.ToInt32(row["IdEmpleado"]),
                Empleado = Convert.ToString(row["Empleado"]),
                FechaFactura = row["FechaFactura"] == DBNull.Value ? DateTime.Today : Convert.ToDateTime(row["FechaFactura"]),
                IdEstado = row["IdEstado"] == DBNull.Value ? 0 : Convert.ToInt32(row["IdEstado"]),
                EstadoFactura = Convert.ToString(row["EstadoFactura"]),
                TotalIva = Convert.ToString(row["TotalIva"]),
                Descuento = Convert.ToString(row["Descuento"]),
                TotalFactura = Convert.ToString(row["TotalFactura"]),
                DetallesProducto = Convert.ToString(row["DetallesProducto"])
            };
        }

        public int GuardarFactura(Factura factura, string usuarioModifica)
        {
            if (factura == null) throw new ArgumentNullException(nameof(factura));

            var idEstado = factura.IdEstado;
            if (idEstado <= 0)
            {
                idEstado = BuscarIdEstadoPorNombre(factura.EstadoFactura);
                if (idEstado <= 0)
                {
                    throw new InvalidOperationException("No se pudo determinar el estado de factura.");
                }
            }

            var filas = Ejecutar_procedimiento(
                "actualizar_Factura",
                new List<Cls_parametros>
                {
                    CrearParametro("@IdFactura", SqlDbType.Int, factura.IdFactura <= 0 ? (object)DBNull.Value : factura.IdFactura),
                    CrearParametro("@DtmFecha", SqlDbType.DateTime, factura.FechaFactura == default(DateTime) ? DateTime.Today : factura.FechaFactura.Date),
                    CrearParametro("@IdCliente", SqlDbType.Int, factura.IdCliente),
                    CrearParametro("@IdEmpleado", SqlDbType.Int, factura.IdEmpleado),
                    CrearParametro("@NumDescuento", SqlDbType.Float, ParseDouble(factura.Descuento)),
                    CrearParametro("@NumImpuesto", SqlDbType.Float, ParseDouble(factura.TotalIva)),
                    CrearParametro("@NumValorTotal", SqlDbType.Float, ParseDouble(factura.TotalFactura)),
                    CrearParametro("@IdEstado", SqlDbType.Int, idEstado),
                    CrearParametro("@DtmFechaModifica", SqlDbType.DateTime, DateTime.Now),
                    CrearParametro("@StrUsuarioModifica", SqlDbType.VarChar, Recortar(usuarioModifica, 10), 10)
                });

            var idFacturaObjetivo = factura.IdFactura;
            if (idFacturaObjetivo <= 0 && filas > 0)
            {
                idFacturaObjetivo = ObtenerUltimaFacturaGuardada(factura, idEstado);
            }

            if (idFacturaObjetivo > 0)
            {
                ActualizarCamposOpcionalesFactura(idFacturaObjetivo, factura);
            }

            return filas;
        }

        public int EliminarFactura(int idFactura)
        {
            const string sql = @"
IF OBJECT_ID('dbo.TBLDETALLE_FACTURA', 'U') IS NOT NULL
BEGIN
    DELETE FROM dbo.TBLDETALLE_FACTURA WHERE IdFactura = @IdFactura;
END
DELETE FROM dbo.TBLFACTURA WHERE IdFactura = @IdFactura;";

            return EjecutarComando(
                sql,
                new SqlParameter("@IdFactura", SqlDbType.Int) { Value = idFactura }
            );
        }

        public DataTable ConsultarFacturasParaInforme(DateTime fechaInicial, DateTime fechaFinal)
        {
            var estadoFactura = ObtenerInfoEstadoFactura();

            var sql = $@"
SELECT
    f.IdFactura,
    f.DtmFecha AS Fecha,
    c.StrNombre AS Cliente,
    e.strNombre AS Empleado,
    {estadoFactura.EstadoExpr} AS Estado,
    ISNULL(f.NumImpuesto, 0) AS Iva,
    ISNULL(f.NumDescuento, 0) AS Descuento,
    ISNULL(f.NumValorTotal, 0) AS Total
FROM TBLFACTURA f
INNER JOIN TBLCLIENTES c ON c.IdCliente = f.IdCliente
INNER JOIN TBLEMPLEADO e ON e.IdEmpleado = f.IdEmpleado
LEFT JOIN TBLESTADO_FACTURA ef ON ef.[{estadoFactura.IdEstadoCol}] = f.IdEstado
WHERE f.DtmFecha >= @fechaInicial
  AND f.DtmFecha < DATEADD(DAY, 1, @fechaFinal);";

            return EjecutarComandoDatos(
                sql,
                new SqlParameter("@fechaInicial", SqlDbType.DateTime) { Value = fechaInicial.Date },
                new SqlParameter("@fechaFinal", SqlDbType.DateTime) { Value = fechaFinal.Date }
            );
        }

        private int BuscarIdEstadoPorNombre(string nombreEstado)
        {
            var estados = ListarEstadosFactura();
            if (estados.Rows.Count == 0)
            {
                return 0;
            }

            if (string.IsNullOrWhiteSpace(nombreEstado))
            {
                return Convert.ToInt32(estados.Rows[0]["IdEstado"]);
            }

            foreach (DataRow row in estados.Rows)
            {
                var actual = Convert.ToString(row["EstadoFactura"]);
                if (string.Equals((actual ?? string.Empty).Trim(), nombreEstado.Trim(), StringComparison.OrdinalIgnoreCase))
                {
                    return Convert.ToInt32(row["IdEstado"]);
                }
            }

            return Convert.ToInt32(estados.Rows[0]["IdEstado"]);
        }

        private EstadoFacturaInfo ObtenerInfoEstadoFactura()
        {
            var estadoCols = ObtenerColumnasTabla("TBLESTADO_FACTURA");
            var idEstadoCol = PrimeraCoincidencia(estadoCols, "IdEstadoFactura", "IdEstado") ?? "IdEstadoFactura";
            var estadoTextCol = PrimeraCoincidencia(estadoCols, "StrDescripcion", "StrEstado", "Descripcion");
            var estadoExpr = string.IsNullOrWhiteSpace(estadoTextCol)
                ? "CAST(f.IdEstado AS VARCHAR(20))"
                : $"ISNULL(ef.[{estadoTextCol}], CAST(f.IdEstado AS VARCHAR(20)))";

            return new EstadoFacturaInfo
            {
                IdEstadoCol = idEstadoCol,
                EstadoExpr = estadoExpr
            };
        }

        private FacturaCamposInfo ObtenerInfoCamposFactura()
        {
            var facturaCols = ObtenerColumnasTabla("TBLFACTURA");
            var tieneNumero = facturaCols.Contains("StrNumeroFactura");
            var detalleCol = facturaCols.Contains("StrDetalle")
                ? "StrDetalle"
                : (facturaCols.Contains("StrDescripcion") ? "StrDescripcion" : null);

            return new FacturaCamposInfo
            {
                TieneNumero = tieneNumero,
                ColumnaDetalle = detalleCol,
                NumeroExpr = tieneNumero ? "ISNULL(f.StrNumeroFactura, '')" : "CONCAT('F-', CAST(f.IdFactura AS VARCHAR(20)))",
                DetalleExpr = string.IsNullOrWhiteSpace(detalleCol) ? "CAST('' AS VARCHAR(250))" : $"ISNULL(f.[{detalleCol}], '')"
            };
        }

        private int ObtenerUltimaFacturaGuardada(Factura factura, int idEstado)
        {
            const string sql = @"
SELECT TOP 1 IdFactura
FROM TBLFACTURA
WHERE IdCliente = @IdCliente
  AND IdEmpleado = @IdEmpleado
  AND CAST(DtmFecha AS DATE) = @DtmFecha
  AND IdEstado = @IdEstado
ORDER BY IdFactura DESC;";

            using (var conexion = CrearConexion())
            using (var comando = new SqlCommand(sql, conexion))
            {
                comando.Parameters.Add("@IdCliente", SqlDbType.Int).Value = factura.IdCliente;
                comando.Parameters.Add("@IdEmpleado", SqlDbType.Int).Value = factura.IdEmpleado;
                comando.Parameters.Add("@DtmFecha", SqlDbType.Date).Value =
                    (factura.FechaFactura == default(DateTime) ? DateTime.Today : factura.FechaFactura.Date);
                comando.Parameters.Add("@IdEstado", SqlDbType.Int).Value = idEstado;

                conexion.Open();
                var valor = comando.ExecuteScalar();
                return valor == null || valor == DBNull.Value ? 0 : Convert.ToInt32(valor);
            }
        }

        private void ActualizarCamposOpcionalesFactura(int idFactura, Factura factura)
        {
            var camposFactura = ObtenerInfoCamposFactura();
            var updates = new List<string>();
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@IdFactura", SqlDbType.Int) { Value = idFactura }
            };

            if (camposFactura.TieneNumero)
            {
                updates.Add("StrNumeroFactura = @StrNumeroFactura");
                parametros.Add(new SqlParameter("@StrNumeroFactura", SqlDbType.VarChar, 50)
                {
                    Value = (factura.NumeroFactura ?? string.Empty).Trim()
                });
            }

            if (camposFactura.ColumnaDetalle == "StrDetalle")
            {
                updates.Add("StrDetalle = @StrDetalle");
                parametros.Add(new SqlParameter("@StrDetalle", SqlDbType.VarChar, 500)
                {
                    Value = (factura.DetallesProducto ?? string.Empty).Trim()
                });
            }
            else if (camposFactura.ColumnaDetalle == "StrDescripcion")
            {
                updates.Add("StrDescripcion = @StrDescripcion");
                parametros.Add(new SqlParameter("@StrDescripcion", SqlDbType.VarChar, 500)
                {
                    Value = (factura.DetallesProducto ?? string.Empty).Trim()
                });
            }

            if (updates.Count == 0)
            {
                return;
            }

            var sql = "UPDATE TBLFACTURA SET " + string.Join(",", updates) + " WHERE IdFactura = @IdFactura;";
            EjecutarComando(sql, parametros.ToArray());
        }

        private HashSet<string> ObtenerColumnasTabla(string tabla)
        {
            if (string.IsNullOrWhiteSpace(tabla) || !TableNameRegex.IsMatch(tabla))
            {
                throw new ArgumentException("Nombre de tabla invalido.", nameof(tabla));
            }

            const string sql = @"
SELECT c.name
FROM sys.columns c
INNER JOIN sys.tables t ON t.object_id = c.object_id
WHERE t.name = @tabla;";

            var set = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            using (var conexion = CrearConexion())
            using (var comando = new SqlCommand(sql, conexion))
            {
                comando.Parameters.Add("@tabla", SqlDbType.VarChar, 128).Value = tabla;
                conexion.Open();
                using (var reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        set.Add(Convert.ToString(reader[0]));
                    }
                }
            }

            return set;
        }

        private static string PrimeraCoincidencia(HashSet<string> columnas, params string[] candidatos)
        {
            if (columnas == null || candidatos == null)
            {
                return null;
            }

            foreach (var candidato in candidatos)
            {
                if (!string.IsNullOrWhiteSpace(candidato) && columnas.Contains(candidato))
                {
                    return candidato;
                }
            }

            return null;
        }

        private static SqlCommand CrearComando(string texto, CommandType tipoComando, SqlConnection conexion, List<Cls_parametros> listaParametros)
        {
            var comando = new SqlCommand(texto, conexion)
            {
                CommandType = tipoComando
            };

            AgregarParametros(comando, listaParametros);
            return comando;
        }

        private static void AgregarParametros(SqlCommand comando, List<Cls_parametros> listaParametros)
        {
            if (comando == null || listaParametros == null)
            {
                return;
            }

            foreach (var parametro in listaParametros)
            {
                if (parametro == null || string.IsNullOrWhiteSpace(parametro.Nombre))
                {
                    continue;
                }

                SqlParameter sqlParametro;
                if (parametro.Tamano > 0)
                {
                    sqlParametro = comando.Parameters.Add(parametro.Nombre, parametro.TipoDato, parametro.Tamano);
                }
                else
                {
                    sqlParametro = comando.Parameters.Add(parametro.Nombre, parametro.TipoDato);
                }

                sqlParametro.Direction = parametro.Direccion;
                sqlParametro.Value = parametro.Valor ?? DBNull.Value;
            }
        }

        private static List<Cls_parametros> ConvertirParametros(IEnumerable<SqlParameter> parametros)
        {
            var lista = new List<Cls_parametros>();
            if (parametros == null)
            {
                return lista;
            }

            foreach (var parametro in parametros)
            {
                if (parametro == null)
                {
                    continue;
                }

                lista.Add(CrearParametro(
                    parametro.ParameterName,
                    parametro.SqlDbType,
                    parametro.Value,
                    parametro.Size,
                    parametro.Direction));
            }

            return lista;
        }

        private static Cls_parametros CrearParametro(
            string nombre,
            SqlDbType tipoDato,
            object valor,
            int tamano = 0,
            ParameterDirection direccion = ParameterDirection.Input)
        {
            return new Cls_parametros
            {
                Nombre = nombre,
                TipoDato = tipoDato,
                Valor = valor,
                Tamano = tamano,
                Direccion = direccion
            };
        }

        private RolInfo ObtenerInfoRoles(bool throwOnMissing = false)
        {
            HashSet<string> columnas;
            try
            {
                columnas = ObtenerColumnasTabla("TBLROLES");
            }
            catch
            {
                if (throwOnMissing)
                {
                    throw;
                }

                return null;
            }

            if (columnas == null || columnas.Count == 0)
            {
                if (throwOnMissing)
                {
                    throw new InvalidOperationException("No se encontraron columnas en TBLROLES.");
                }

                return null;
            }

            var id = PrimeraCoincidencia(columnas, "IdRolEmpleado", "IdRol");
            var nombre = PrimeraCoincidencia(columnas, "StrDescripcion", "StrNombre", "NombreRol", "StrRol", "Rol");
            var detalle = PrimeraCoincidencia(columnas, "StrDetalle", "StrDetalles", "DescripcionDetalle");
            var fecha = PrimeraCoincidencia(columnas, "DtmFechaModifica", "DtmFecha");
            var usuario = PrimeraCoincidencia(columnas, "StrUsuarioModifico", "StrUsuarioModifica");

            if ((string.IsNullOrWhiteSpace(id) || string.IsNullOrWhiteSpace(nombre)) && throwOnMissing)
            {
                throw new InvalidOperationException("No se pudo mapear la estructura de TBLROLES.");
            }

            return new RolInfo
            {
                IdColumna = id,
                NombreColumna = nombre,
                DetalleColumna = detalle,
                FechaColumna = fecha,
                UsuarioColumna = usuario
            };
        }

        private static string Recortar(string valor, int maximo)
        {
            var limpio = (valor ?? string.Empty).Trim();
            return limpio.Length <= maximo ? limpio : limpio.Substring(0, maximo);
        }

        private static int ParseInt(string valor)
        {
            int number;
            return int.TryParse((valor ?? string.Empty).Trim(), out number) ? number : 0;
        }

        private static double ParseDouble(string valor)
        {
            var raw = (valor ?? string.Empty).Trim();
            if (string.IsNullOrWhiteSpace(raw))
            {
                return 0d;
            }

            double parsed;
            if (double.TryParse(raw, NumberStyles.Any, CultureInfo.CurrentCulture, out parsed))
            {
                return parsed;
            }

            if (double.TryParse(raw, NumberStyles.Any, CultureInfo.InvariantCulture, out parsed))
            {
                return parsed;
            }

            var normalized = raw.Replace(',', '.');
            return double.TryParse(normalized, NumberStyles.Any, CultureInfo.InvariantCulture, out parsed)
                ? parsed
                : 0d;
        }

        private sealed class EstadoFacturaInfo
        {
            public string IdEstadoCol { get; set; }
            public string EstadoExpr { get; set; }
        }

        private sealed class FacturaCamposInfo
        {
            public bool TieneNumero { get; set; }
            public string ColumnaDetalle { get; set; }
            public string NumeroExpr { get; set; }
            public string DetalleExpr { get; set; }
        }

        private sealed class RolInfo
        {
            public string IdColumna { get; set; }
            public string NombreColumna { get; set; }
            public string DetalleColumna { get; set; }
            public string FechaColumna { get; set; }
            public string UsuarioColumna { get; set; }
        }
    }
}


