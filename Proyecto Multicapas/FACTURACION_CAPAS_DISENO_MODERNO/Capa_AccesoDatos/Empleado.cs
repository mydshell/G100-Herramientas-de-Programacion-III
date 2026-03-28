using System;

namespace Capa_AccesoDatos.Entidades
{
    public class Empleado
    {
        public int IdEmpleado { get; set; }
        public string NombreEmpleado { get; set; }

        public string Documento { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }

        public int IdRolEmpleado { get; set; }
        public string RolEmpleadoNombre { get; set; }

        public DateTime FechaIngreso { get; set; }
        public DateTime? FechaRetiro { get; set; }

        public string DatoAdicional { get; set; }
    }
}
