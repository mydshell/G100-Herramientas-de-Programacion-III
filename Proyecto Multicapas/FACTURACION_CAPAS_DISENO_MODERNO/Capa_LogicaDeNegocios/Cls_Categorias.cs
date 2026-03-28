using System.Data;
using Capa_AccesoDatos;

namespace Pantallas_Sistema_facturación
{
    public class Cls_Categorias
    {
        private readonly Cls_Acceso_Datos _datos = new Cls_Acceso_Datos();

        public DataTable ListarCategorias(string filtro) => _datos.ListarCategorias(filtro);
        public DataTable ListarCategoriasBasico() => _datos.ListarCategoriasBasico();
        public Categoria ObtenerCategoriaPorId(int idCategoria) => Cls_Mapeador_Entidades.Map(_datos.ObtenerCategoriaPorId(idCategoria));
        public int GuardarCategoria(Categoria categoria, string usuarioModifica) => _datos.GuardarCategoria(Cls_Mapeador_Entidades.MapToData(categoria), usuarioModifica);
        public int EliminarCategoria(int idCategoria) => _datos.EliminarCategoria(idCategoria);
    }
}


