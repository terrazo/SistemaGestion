using SistemaGestionData;
using SistemaGestionEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionBussiness
{
    public static class VentaBussiness
    {

        public static List<Venta> GetVentas()
        {
            return VentaData.ListarVentas();
        }


        public static void CreateVenta(string comentarios, int idUsuario)
        {
            Venta v = new Venta(comentarios, idUsuario);

            VentaData.CrearVenta(v);

        }
    }
}
