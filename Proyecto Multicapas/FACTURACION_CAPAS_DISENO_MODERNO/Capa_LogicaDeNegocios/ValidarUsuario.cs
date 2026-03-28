using System;
using System.Data;
using Capa_AccesoDatos;

namespace Pantallas_Sistema_facturación
{
    public class ValidarUsuario
    {
        private readonly Cls_Acceso_Datos _acceso = new Cls_Acceso_Datos();

        public string Usuario { get; set; }
        public string Clave { get; set; }
        public int IdEmpleado { get; private set; }
        public string NombreEmpleado { get; private set; }

        public void ConsultarUsuario()
        {
            try
            {
                string sentencia = string.Format(
                    "SELECT TOP 1 e.IdEmpleado, e.strNombre FROM TBLSEGURIDAD s INNER JOIN TBLEMPLEADO e ON e.IdEmpleado = s.IdEmpleado WHERE s.StrUsuario = '{0}' AND s.StrClave = '{1}';",
                    EscaparSql(Usuario),
                    EscaparSql(Clave));

                DataTable dt = new DataTable();
                dt = _acceso.EjecutarConsulta(sentencia);

                IdEmpleado = 0;
                NombreEmpleado = string.Empty;

                foreach (DataRow row in dt.Rows)
                {
                    IdEmpleado = int.Parse(row[0].ToString());
                    NombreEmpleado = row.Table.Columns.Count > 1 ? Convert.ToString(row[1]) : string.Empty;
                    break;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la consulta", ex);
            }
        }

        public string Ejecutar(string usuario, string clave)
        {
            Usuario = usuario;
            Clave = clave;
            ConsultarUsuario();
            return NombreEmpleado ?? string.Empty;
        }

        public string ObtenerDiagnosticoConexion(Exception ex = null)
        {
            return _acceso.ObtenerDiagnosticoConexion(ex);
        }

        private static string EscaparSql(string valor)
        {
            return (valor ?? string.Empty).Trim().Replace("'", "''");
        }
    }

    public class Validar_usuario
    {
        private readonly ValidarUsuario _validarUsuario = new ValidarUsuario();

        public string C_StrUsuario
        {
            get { return _validarUsuario.Usuario; }
            set { _validarUsuario.Usuario = value; }
        }

        public string C_StrClave
        {
            get { return _validarUsuario.Clave; }
            set { _validarUsuario.Clave = value; }
        }

        public int C_IntIdEmpleado
        {
            get { return _validarUsuario.IdEmpleado; }
        }

        public string C_StrEmpleado
        {
            get { return _validarUsuario.NombreEmpleado; }
        }

        public void ValidarUsuario()
        {
            _validarUsuario.ConsultarUsuario();
        }

        public string ObtenerDiagnosticoConexion(Exception ex = null)
        {
            return _validarUsuario.ObtenerDiagnosticoConexion(ex);
        }
    }
}
