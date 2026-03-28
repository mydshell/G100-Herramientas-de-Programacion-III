using System.Data;

namespace Capa_AccesoDatos
{
    public class Cls_parametros
    {
        public string Nombre { get; set; }
        public object Valor { get; set; }
        public SqlDbType TipoDato { get; set; }
        public ParameterDirection Direccion { get; set; } = ParameterDirection.Input;
        public int Tamano { get; set; }
    }
}
