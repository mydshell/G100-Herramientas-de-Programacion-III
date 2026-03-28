using System;
using System.Data;
using Capa_AccesoDatos;

namespace Pantallas_Sistema_facturación
{
    public class Cls_Informes
    {
        private readonly Cls_Acceso_Datos _datos = new Cls_Acceso_Datos();

        public DataTable ConsultarFacturasParaInforme(DateTime fechaInicial, DateTime fechaFinal)
            => _datos.ConsultarFacturasParaInforme(fechaInicial, fechaFinal);
    }
}


