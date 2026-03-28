namespace Pantallas_Sistema_facturación
{
    internal static class Cls_Mapeador_Entidades
    {
        public static Cliente Map(Capa_AccesoDatos.Entidades.Cliente origen)
        {
            if (origen == null) return null;
            return new Cliente
            {
                IdCliente = origen.IdCliente,
                NombreCliente = origen.NombreCliente,
                Documento = origen.Documento,
                Direccion = origen.Direccion,
                Telefono = origen.Telefono,
                Email = origen.Email
            };
        }

        public static Capa_AccesoDatos.Entidades.Cliente MapToData(Cliente origen)
        {
            if (origen == null) return null;
            return new Capa_AccesoDatos.Entidades.Cliente
            {
                IdCliente = origen.IdCliente,
                NombreCliente = origen.NombreCliente,
                Documento = origen.Documento,
                Direccion = origen.Direccion,
                Telefono = origen.Telefono,
                Email = origen.Email
            };
        }

        public static Categoria Map(Capa_AccesoDatos.Entidades.Categoria origen)
        {
            if (origen == null) return null;
            return new Categoria
            {
                IdCategoria = origen.IdCategoria,
                NombreCategoria = origen.NombreCategoria
            };
        }

        public static Capa_AccesoDatos.Entidades.Categoria MapToData(Categoria origen)
        {
            if (origen == null) return null;
            return new Capa_AccesoDatos.Entidades.Categoria
            {
                IdCategoria = origen.IdCategoria,
                NombreCategoria = origen.NombreCategoria
            };
        }

        public static Producto Map(Capa_AccesoDatos.Entidades.Producto origen)
        {
            if (origen == null) return null;
            return new Producto
            {
                IdProducto = origen.IdProducto,
                NombreProducto = origen.NombreProducto,
                Codigo = origen.Codigo,
                IdCategoria = origen.IdCategoria,
                Categoria = origen.Categoria,
                PrecioCompra = origen.PrecioCompra,
                PrecioVenta = origen.PrecioVenta,
                Stock = origen.Stock,
                Detalle = origen.Detalle,
                RutaImagen = origen.RutaImagen
            };
        }

        public static Capa_AccesoDatos.Entidades.Producto MapToData(Producto origen)
        {
            if (origen == null) return null;
            return new Capa_AccesoDatos.Entidades.Producto
            {
                IdProducto = origen.IdProducto,
                NombreProducto = origen.NombreProducto,
                Codigo = origen.Codigo,
                IdCategoria = origen.IdCategoria,
                Categoria = origen.Categoria,
                PrecioCompra = origen.PrecioCompra,
                PrecioVenta = origen.PrecioVenta,
                Stock = origen.Stock,
                Detalle = origen.Detalle,
                RutaImagen = origen.RutaImagen
            };
        }

        public static Empleado Map(Capa_AccesoDatos.Entidades.Empleado origen)
        {
            if (origen == null) return null;
            return new Empleado
            {
                IdEmpleado = origen.IdEmpleado,
                NombreEmpleado = origen.NombreEmpleado,
                Documento = origen.Documento,
                Direccion = origen.Direccion,
                Telefono = origen.Telefono,
                Email = origen.Email,
                IdRolEmpleado = origen.IdRolEmpleado,
                RolEmpleadoNombre = origen.RolEmpleadoNombre,
                FechaIngreso = origen.FechaIngreso,
                FechaRetiro = origen.FechaRetiro,
                DatoAdicional = origen.DatoAdicional
            };
        }

        public static Capa_AccesoDatos.Entidades.Empleado MapToData(Empleado origen)
        {
            if (origen == null) return null;
            return new Capa_AccesoDatos.Entidades.Empleado
            {
                IdEmpleado = origen.IdEmpleado,
                NombreEmpleado = origen.NombreEmpleado,
                Documento = origen.Documento,
                Direccion = origen.Direccion,
                Telefono = origen.Telefono,
                Email = origen.Email,
                IdRolEmpleado = origen.IdRolEmpleado,
                RolEmpleadoNombre = origen.RolEmpleadoNombre,
                FechaIngreso = origen.FechaIngreso,
                FechaRetiro = origen.FechaRetiro,
                DatoAdicional = origen.DatoAdicional
            };
        }

        public static SeguridadUsuario Map(Capa_AccesoDatos.Entidades.SeguridadUsuario origen)
        {
            if (origen == null) return null;
            return new SeguridadUsuario
            {
                IdSeguridad = origen.IdSeguridad,
                IdEmpleado = origen.IdEmpleado,
                Empleado = origen.Empleado,
                Usuario = origen.Usuario,
                Clave = origen.Clave
            };
        }

        public static Capa_AccesoDatos.Entidades.SeguridadUsuario MapToData(SeguridadUsuario origen)
        {
            if (origen == null) return null;
            return new Capa_AccesoDatos.Entidades.SeguridadUsuario
            {
                IdSeguridad = origen.IdSeguridad,
                IdEmpleado = origen.IdEmpleado,
                Empleado = origen.Empleado,
                Usuario = origen.Usuario,
                Clave = origen.Clave
            };
        }

        public static RolEmpleado Map(Capa_AccesoDatos.Entidades.RolEmpleado origen)
        {
            if (origen == null) return null;
            return new RolEmpleado
            {
                IdRolEmpleado = origen.IdRolEmpleado,
                NombreRol = origen.NombreRol,
                DetallesRol = origen.DetallesRol
            };
        }

        public static Capa_AccesoDatos.Entidades.RolEmpleado MapToData(RolEmpleado origen)
        {
            if (origen == null) return null;
            return new Capa_AccesoDatos.Entidades.RolEmpleado
            {
                IdRolEmpleado = origen.IdRolEmpleado,
                NombreRol = origen.NombreRol,
                DetallesRol = origen.DetallesRol
            };
        }

        public static Factura Map(Capa_AccesoDatos.Entidades.Factura origen)
        {
            if (origen == null) return null;
            return new Factura
            {
                IdFactura = origen.IdFactura,
                NumeroFactura = origen.NumeroFactura,
                IdCliente = origen.IdCliente,
                Cliente = origen.Cliente,
                IdEmpleado = origen.IdEmpleado,
                Empleado = origen.Empleado,
                FechaFactura = origen.FechaFactura,
                IdEstado = origen.IdEstado,
                EstadoFactura = origen.EstadoFactura,
                TotalIva = origen.TotalIva,
                Descuento = origen.Descuento,
                TotalFactura = origen.TotalFactura,
                DetallesProducto = origen.DetallesProducto
            };
        }

        public static Capa_AccesoDatos.Entidades.Factura MapToData(Factura origen)
        {
            if (origen == null) return null;
            return new Capa_AccesoDatos.Entidades.Factura
            {
                IdFactura = origen.IdFactura,
                NumeroFactura = origen.NumeroFactura,
                IdCliente = origen.IdCliente,
                Cliente = origen.Cliente,
                IdEmpleado = origen.IdEmpleado,
                Empleado = origen.Empleado,
                FechaFactura = origen.FechaFactura,
                IdEstado = origen.IdEstado,
                EstadoFactura = origen.EstadoFactura,
                TotalIva = origen.TotalIva,
                Descuento = origen.Descuento,
                TotalFactura = origen.TotalFactura,
                DetallesProducto = origen.DetallesProducto
            };
        }
    }
}


