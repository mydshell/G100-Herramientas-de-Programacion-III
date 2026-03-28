using System;
using System.Data;
using Capa_AccesoDatos;

namespace Pantallas_Sistema_facturación
{
    public class Cls_Empleados
    {
        private readonly Cls_Acceso_Datos _datos = new Cls_Acceso_Datos();

        public DataTable ListarEmpleadosBasico() => _datos.ListarEmpleadosBasico();
        public DataTable ListarEmpleados(string filtro) => _datos.ListarEmpleados(filtro);
        public Empleado ObtenerEmpleadoPorId(int idEmpleado) => Cls_Mapeador_Entidades.Map(_datos.ObtenerEmpleadoPorId(idEmpleado));
        public int GuardarEmpleado(Empleado empleado, string usuarioModifica) => _datos.GuardarEmpleado(Cls_Mapeador_Entidades.MapToData(empleado), usuarioModifica);
        public int EliminarEmpleado(int idEmpleado) => _datos.EliminarEmpleado(idEmpleado);

        public DataTable Consulta_Empleado() => ListarEmpleados(string.Empty);

        public DataTable Consulta_Empleado(int idEmpleado)
        {
            return ConvertirEmpleadoATabla(ObtenerEmpleadoPorId(idEmpleado));
        }

        public DataTable Filtrar_Empleado(string filtro) => ListarEmpleados(filtro);
        public DataTable Consultar_Roles() => _datos.ListarRolesBasico();
        public int Guardar_Empleado(Empleado empleado, string usuarioModifica) => GuardarEmpleado(empleado, usuarioModifica);
        public int Eliminar_Empleado(int idEmpleado) => EliminarEmpleado(idEmpleado);

        private static DataTable ConvertirEmpleadoATabla(Empleado empleado)
        {
            var tabla = new DataTable();
            tabla.Columns.Add("IdEmpleado", typeof(int));
            tabla.Columns.Add("NombreEmpleado", typeof(string));
            tabla.Columns.Add("Documento", typeof(string));
            tabla.Columns.Add("Direccion", typeof(string));
            tabla.Columns.Add("Telefono", typeof(string));
            tabla.Columns.Add("Email", typeof(string));
            tabla.Columns.Add("IdRolEmpleado", typeof(int));
            tabla.Columns.Add("RolEmpleadoNombre", typeof(string));
            tabla.Columns.Add("FechaIngreso", typeof(DateTime));
            tabla.Columns.Add("FechaRetiro", typeof(DateTime));
            tabla.Columns.Add("DatoAdicional", typeof(string));

            if (empleado == null)
            {
                return tabla;
            }

            var fila = tabla.NewRow();
            fila["IdEmpleado"] = empleado.IdEmpleado;
            fila["NombreEmpleado"] = empleado.NombreEmpleado ?? string.Empty;
            fila["Documento"] = empleado.Documento ?? string.Empty;
            fila["Direccion"] = empleado.Direccion ?? string.Empty;
            fila["Telefono"] = empleado.Telefono ?? string.Empty;
            fila["Email"] = empleado.Email ?? string.Empty;
            fila["IdRolEmpleado"] = empleado.IdRolEmpleado;
            fila["RolEmpleadoNombre"] = empleado.RolEmpleadoNombre ?? string.Empty;
            fila["FechaIngreso"] = empleado.FechaIngreso;
            fila["FechaRetiro"] = empleado.FechaRetiro.HasValue ? (object)empleado.FechaRetiro.Value : DBNull.Value;
            fila["DatoAdicional"] = empleado.DatoAdicional ?? string.Empty;
            tabla.Rows.Add(fila);

            return tabla;
        }
    }
}
