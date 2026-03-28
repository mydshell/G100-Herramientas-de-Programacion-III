namespace Pantallas_Sistema_facturación
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public string Codigo { get; set; }
        public int IdCategoria { get; set; }
        public string Categoria { get; set; }
        public string PrecioCompra { get; set; }
        public string PrecioVenta { get; set; }
        public string Stock { get; set; }
        public string Detalle { get; set; }
        public string RutaImagen { get; set; }
    }
}

