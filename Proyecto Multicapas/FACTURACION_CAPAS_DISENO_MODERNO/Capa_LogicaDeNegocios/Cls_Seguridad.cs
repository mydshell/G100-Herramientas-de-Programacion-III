using System.Data;
using Capa_AccesoDatos;

namespace Pantallas_Sistema_facturación
{
    public class Cls_Seguridad
    {
        private readonly Cls_Acceso_Datos _datos = new Cls_Acceso_Datos();

        public DataTable ListarSeguridad(string filtro) => _datos.ListarSeguridad(filtro);
        public SeguridadUsuario ObtenerSeguridadPorEmpleado(int idEmpleado) => Cls_Mapeador_Entidades.Map(_datos.ObtenerSeguridadPorEmpleado(idEmpleado));
        public bool ExisteUsuarioSeguridad(string usuario, int idEmpleadoActual) => _datos.ExisteUsuarioSeguridad(usuario, idEmpleadoActual);
        public int GuardarSeguridad(SeguridadUsuario usuario, string usuarioModifica) => _datos.GuardarSeguridad(Cls_Mapeador_Entidades.MapToData(usuario), usuarioModifica);
        public int EliminarSeguridad(int idEmpleado) => _datos.EliminarSeguridad(idEmpleado);
        public DataTable ConsultarEmpleados() => _datos.ListarEmpleadosBasico();

        public DataTable ConsultarSeguridad(int idEmpleado)
        {
            return ConvertirSeguridadATabla(ObtenerSeguridadPorEmpleado(idEmpleado));
        }

        public int Guardar(SeguridadUsuario usuario, string usuarioModifica) => GuardarSeguridad(usuario, usuarioModifica);
        public int Eliminar(int idEmpleado) => EliminarSeguridad(idEmpleado);

        private static DataTable ConvertirSeguridadATabla(SeguridadUsuario usuario)
        {
            var tabla = new DataTable();
            tabla.Columns.Add("IdSeguridad", typeof(int));
            tabla.Columns.Add("IdEmpleado", typeof(int));
            tabla.Columns.Add("Empleado", typeof(string));
            tabla.Columns.Add("Usuario", typeof(string));
            tabla.Columns.Add("Clave", typeof(string));

            if (usuario == null)
            {
                return tabla;
            }

            var fila = tabla.NewRow();
            fila["IdSeguridad"] = usuario.IdSeguridad;
            fila["IdEmpleado"] = usuario.IdEmpleado;
            fila["Empleado"] = usuario.Empleado ?? string.Empty;
            fila["Usuario"] = usuario.Usuario ?? string.Empty;
            fila["Clave"] = usuario.Clave ?? string.Empty;
            tabla.Rows.Add(fila);

            return tabla;
        }
    }
}
