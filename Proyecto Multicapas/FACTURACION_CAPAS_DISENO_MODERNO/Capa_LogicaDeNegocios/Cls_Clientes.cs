using System.Data;
using Capa_AccesoDatos;

namespace Pantallas_Sistema_facturación
{
    public class Cls_Clientes
    {
        private readonly Cls_Acceso_Datos _datos = new Cls_Acceso_Datos();

        public DataTable ListarClientes(string filtro) => _datos.ListarClientes(filtro);
        public DataTable ListarClientesBasico() => _datos.ListarClientesBasico();
        public Cliente ObtenerClientePorId(int idCliente) => Cls_Mapeador_Entidades.Map(_datos.ObtenerClientePorId(idCliente));
        public int GuardarCliente(Cliente cliente, string usuarioModifica) => _datos.GuardarCliente(Cls_Mapeador_Entidades.MapToData(cliente), usuarioModifica);
        public int EliminarCliente(int idCliente) => _datos.EliminarCliente(idCliente);
    }
}


