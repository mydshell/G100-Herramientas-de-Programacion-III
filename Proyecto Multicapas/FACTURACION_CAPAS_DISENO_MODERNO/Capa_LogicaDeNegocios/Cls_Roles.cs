using System.Data;
using Capa_AccesoDatos;

namespace Pantallas_Sistema_facturación
{
    public class Cls_Roles
    {
        private readonly Cls_Acceso_Datos _datos = new Cls_Acceso_Datos();

        public DataTable ListarRoles(string filtro) => _datos.ListarRoles(filtro);
        public DataTable ListarRolesBasico() => _datos.ListarRolesBasico();
        public RolEmpleado ObtenerRolPorId(int idRolEmpleado) => Cls_Mapeador_Entidades.Map(_datos.ObtenerRolPorId(idRolEmpleado));
        public int GuardarRol(RolEmpleado rol, string usuarioModifica) => _datos.GuardarRol(Cls_Mapeador_Entidades.MapToData(rol), usuarioModifica);
        public int EliminarRol(int idRolEmpleado) => _datos.EliminarRol(idRolEmpleado);
        public bool ExisteEmpleadosConRol(int idRolEmpleado) => _datos.ExisteEmpleadosConRol(idRolEmpleado);
    }
}


