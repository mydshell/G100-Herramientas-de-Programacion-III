using System;

namespace Pantallas_Sistema_facturación
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