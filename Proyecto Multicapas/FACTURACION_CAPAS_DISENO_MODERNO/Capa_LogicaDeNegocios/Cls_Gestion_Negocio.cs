using System;
using System.Data;
using System.Data.SqlClient;
using Capa_AccesoDatos;

namespace Pantallas_Sistema_facturación
{
    public class Cls_Gestion_Negocio
    {
        private readonly Cls_Acceso_Datos _datos = new Cls_Acceso_Datos();
        private readonly ValidarUsuario _validar = new ValidarUsuario();
        private readonly Cls_Clientes _clientes = new Cls_Clientes();
        private readonly Cls_Categorias _categorias = new Cls_Categorias();
        private readonly Cls_Productos _productos = new Cls_Productos();
        private readonly Cls_Empleados _empleados = new Cls_Empleados();
        private readonly Cls_Seguridad _seguridad = new Cls_Seguridad();
        private readonly Cls_Roles _roles = new Cls_Roles();
        private readonly Cls_Facturas _facturas = new Cls_Facturas();
        private readonly Cls_Informes _informes = new Cls_Informes();

        public string ObtenerDiagnosticoConexion(Exception ex = null) => _validar.ObtenerDiagnosticoConexion(ex);
        public string ValidarUsuario(string usuario, string clave) => _validar.Ejecutar(usuario, clave);
        public int EjecutarComando(string sentencia, params SqlParameter[] parametros) => _datos.EjecutarComando(sentencia, parametros);
        public DataTable EjecutarComandoDatos(string sentencia, params SqlParameter[] parametros) => _datos.EjecutarComandoDatos(sentencia, parametros);
        public DataTable CargarTabla(string tabla, string condicion = "") => _datos.CargarTabla(tabla, condicion);

        public DataTable ListarClientes(string filtro) => _clientes.ListarClientes(filtro);
        public DataTable ListarClientesBasico() => _clientes.ListarClientesBasico();
        public Cliente ObtenerClientePorId(int idCliente) => _clientes.ObtenerClientePorId(idCliente);
        public int GuardarCliente(Cliente cliente, string usuarioModifica) => _clientes.GuardarCliente(cliente, usuarioModifica);
        public int EliminarCliente(int idCliente) => _clientes.EliminarCliente(idCliente);

        public DataTable ListarCategorias(string filtro) => _categorias.ListarCategorias(filtro);
        public DataTable ListarCategoriasBasico() => _categorias.ListarCategoriasBasico();
        public Categoria ObtenerCategoriaPorId(int idCategoria) => _categorias.ObtenerCategoriaPorId(idCategoria);
        public int GuardarCategoria(Categoria categoria, string usuarioModifica) => _categorias.GuardarCategoria(categoria, usuarioModifica);
        public int EliminarCategoria(int idCategoria) => _categorias.EliminarCategoria(idCategoria);
        public int ContarProductosPorCategoria(int idCategoria) => _productos.ContarProductosPorCategoria(idCategoria);

        public DataTable ListarProductos(string filtro) => _productos.ListarProductos(filtro);
        public Producto ObtenerProductoPorId(int idProducto) => _productos.ObtenerProductoPorId(idProducto);
        public int GuardarProducto(Producto producto, string usuarioModifica) => _productos.GuardarProducto(producto, usuarioModifica);
        public int EliminarProducto(int idProducto) => _productos.EliminarProducto(idProducto);

        public DataTable ListarEmpleadosBasico() => _empleados.ListarEmpleadosBasico();
        public DataTable ListarEmpleados(string filtro) => _empleados.ListarEmpleados(filtro);
        public Empleado ObtenerEmpleadoPorId(int idEmpleado) => _empleados.ObtenerEmpleadoPorId(idEmpleado);
        public int GuardarEmpleado(Empleado empleado, string usuarioModifica) => _empleados.GuardarEmpleado(empleado, usuarioModifica);
        public int EliminarEmpleado(int idEmpleado) => _empleados.EliminarEmpleado(idEmpleado);

        public DataTable ListarSeguridad(string filtro) => _seguridad.ListarSeguridad(filtro);
        public SeguridadUsuario ObtenerSeguridadPorEmpleado(int idEmpleado) => _seguridad.ObtenerSeguridadPorEmpleado(idEmpleado);
        public bool ExisteUsuarioSeguridad(string usuario, int idEmpleadoActual) => _seguridad.ExisteUsuarioSeguridad(usuario, idEmpleadoActual);
        public int GuardarSeguridad(SeguridadUsuario usuario, string usuarioModifica) => _seguridad.GuardarSeguridad(usuario, usuarioModifica);
        public int EliminarSeguridad(int idEmpleado) => _seguridad.EliminarSeguridad(idEmpleado);

        public DataTable ListarRoles(string filtro) => _roles.ListarRoles(filtro);
        public DataTable ListarRolesBasico() => _roles.ListarRolesBasico();
        public RolEmpleado ObtenerRolPorId(int idRolEmpleado) => _roles.ObtenerRolPorId(idRolEmpleado);
        public int GuardarRol(RolEmpleado rol, string usuarioModifica) => _roles.GuardarRol(rol, usuarioModifica);
        public int EliminarRol(int idRolEmpleado) => _roles.EliminarRol(idRolEmpleado);
        public bool ExisteEmpleadosConRol(int idRolEmpleado) => _roles.ExisteEmpleadosConRol(idRolEmpleado);

        public DataTable ListarEstadosFactura() => _facturas.ListarEstadosFactura();
        public DataTable ListarFacturas(string filtro) => _facturas.ListarFacturas(filtro);
        public Factura ObtenerFacturaPorId(int idFactura) => _facturas.ObtenerFacturaPorId(idFactura);
        public int GuardarFactura(Factura factura, string usuarioModifica) => _facturas.GuardarFactura(factura, usuarioModifica);
        public int EliminarFactura(int idFactura) => _facturas.EliminarFactura(idFactura);

        public DataTable ConsultarFacturasParaInforme(DateTime fechaInicial, DateTime fechaFinal)
            => _informes.ConsultarFacturasParaInforme(fechaInicial, fechaFinal);
    }
}


