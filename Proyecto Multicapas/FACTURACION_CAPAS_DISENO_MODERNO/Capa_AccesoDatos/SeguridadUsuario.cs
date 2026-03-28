using System;

namespace Capa_AccesoDatos.Entidades
{
    public class SeguridadUsuario
    {
        public int IdSeguridad { get; set; }

        public int IdEmpleado { get; set; }
        public string Empleado { get; set; }

        public string Usuario { get; set; }
        public string Clave { get; set; }
    }
}
