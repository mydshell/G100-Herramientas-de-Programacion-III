using System.Data;
using Capa_AccesoDatos;

namespace Pantallas_Sistema_facturación
{
    public class Cls_Productos
    {
        private readonly Cls_Acceso_Datos _datos = new Cls_Acceso_Datos();

        public DataTable ListarProductos(string filtro) => _datos.ListarProductos(filtro);
        public Producto ObtenerProductoPorId(int idProducto) => Cls_Mapeador_Entidades.Map(_datos.ObtenerProductoPorId(idProducto));
        public int GuardarProducto(Producto producto, string usuarioModifica) => _datos.GuardarProducto(Cls_Mapeador_Entidades.MapToData(producto), usuarioModifica);
        public int EliminarProducto(int idProducto) => _datos.EliminarProducto(idProducto);
        public int ContarProductosPorCategoria(int idCategoria) => _datos.ContarProductosPorCategoria(idCategoria);
    }
}


