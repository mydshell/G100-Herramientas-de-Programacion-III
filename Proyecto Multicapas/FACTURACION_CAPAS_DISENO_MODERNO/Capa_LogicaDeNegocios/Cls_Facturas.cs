using System.Data;
using Capa_AccesoDatos;

namespace Pantallas_Sistema_facturación
{
    public class Cls_Facturas
    {
        private readonly Cls_Acceso_Datos _datos = new Cls_Acceso_Datos();

        public DataTable ListarEstadosFactura() => _datos.ListarEstadosFactura();
        public DataTable ListarFacturas(string filtro) => _datos.ListarFacturas(filtro);
        public Factura ObtenerFacturaPorId(int idFactura) => Cls_Mapeador_Entidades.Map(_datos.ObtenerFacturaPorId(idFactura));
        public int GuardarFactura(Factura factura, string usuarioModifica) => _datos.GuardarFactura(Cls_Mapeador_Entidades.MapToData(factura), usuarioModifica);
        public int EliminarFactura(int idFactura) => _datos.EliminarFactura(idFactura);
    }
}


