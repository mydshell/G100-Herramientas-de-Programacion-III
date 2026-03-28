using System;

namespace Pantallas_Sistema_facturación
{
    public class Factura
    {
        public int IdFactura { get; set; }

        public string NumeroFactura { get; set; }

        public int IdCliente { get; set; }
        public string Cliente { get; set; }

        public int IdEmpleado { get; set; }
        public string Empleado { get; set; }

        public DateTime FechaFactura { get; set; }
        public int IdEstado { get; set; }
        public string EstadoFactura { get; set; }

        // Totales
        public string TotalIva { get; set; }
        public string TotalFactura { get; set; }
        public string Descuento { get; set; }

        public string DetallesProducto { get; set; }

        public string ClienteNombreActual => Cliente ?? string.Empty;
        public string EmpleadoNombreActual => Empleado ?? string.Empty;

        public string TotalFacturaMostrar => TotalFactura ?? "0";
        public string TotalIvaMostrar => TotalIva ?? "0";
        public string DescuentoMostrar => Descuento ?? "0";
    }
}
