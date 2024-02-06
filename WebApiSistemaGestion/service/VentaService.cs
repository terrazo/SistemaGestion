
using Microsoft.EntityFrameworkCore;
using WebApiSistemaGestion.database;
using WebApiSistemaGestion.models;


namespace WebApiSistemaGestion.service
{
    public static class VentaService
    {



        public static List<Venta> GetAllVentas()
        {
            using (CoderContext context = new CoderContext())
            {
                return context.Venta.ToList();
            }
        }



        public static List<Venta> ObtenerTodasLasVentas()
        {
            using (CoderContext context = new CoderContext())
            {

                List<Venta> v = context.Venta.ToList();

                return v;

            }
        }

        public static Venta ObtenerUsuarioPorId(int id)
        {
            using (CoderContext context = new CoderContext())
            {

                Venta? vbuscada = context.Venta.Where(v => v.Id == id).FirstOrDefault();
                return vbuscada;
            }
        }

        public static Venta ObtenerVentaPorId2(int id)
        {
            List<Venta> v = VentaService.ObtenerTodasLasVentas();

            foreach (Venta item in v)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }
            return null;
        }

        public static bool AgregarVenta(Venta v)
        {
            using (CoderContext context = new CoderContext())
            {
                context.Venta.Add(v);

                context.SaveChanges();
                return true;
            }


        }

        public static bool ActualizarVentaPorId(Venta v, int id)
        {
            using (CoderContext context = new CoderContext())
            {
                Venta? vBuscado = context.Venta.Where(v => v.Id == id).FirstOrDefault();


                vBuscado.Comentarios = vBuscado.Comentarios;
                vBuscado.IdUsuario = vBuscado.IdUsuario;

                context.Venta.Update(vBuscado);

                context.SaveChanges();

                return true;
            }
        }


        public static bool EliminarVentaPorId(int id)
        {
            using (CoderContext context = new CoderContext())
            {
                Venta? AEliminar = context.Venta.Where(v => v.Id == id).FirstOrDefault();

                if (AEliminar is not null)
                {
                    context.Venta.Remove(AEliminar);
                    context.SaveChanges();
                    return true;
                }
            }

            return false;
        }










    }


}
