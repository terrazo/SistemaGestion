
using Microsoft.EntityFrameworkCore;
using WebApiSistemaGestion.database;
using WebApiSistemaGestion.models;


namespace WebApiSistemaGestion.service
{
    public class ProductoVendidoService
    {




        public static List<ProductoVendido> GetAllProductosVendidos()
        {
            using (CoderContext context = new CoderContext())
            {
                return context.ProductoVendidos.ToList();
            }
        }



        public static List<ProductoVendido> ObtenerTodosLosProductosVendidos()
        {
            using (CoderContext context = new CoderContext())
            {

                List<ProductoVendido> v = context.ProductoVendidos.ToList();

                return v;

            }
        }

        public static ProductoVendido ObtenerProductoVendidoPorId(int id)
        {
            using (CoderContext context = new CoderContext())
            {

                ProductoVendido? pvbuscado = context.ProductoVendidos.Where(pv => pv.Id == id).FirstOrDefault();
                return pvbuscado;
            }
        }

        public static ProductoVendido ObtenerProductoVendidoPorId2(int id)
        {
            List<ProductoVendido> v = ProductoVendidoService.ObtenerTodosLosProductosVendidos();

            foreach (ProductoVendido item in v)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }
            return null;
        }

        public static bool AgregarProductoVendido(ProductoVendido v)
        {
            using (CoderContext context = new CoderContext())
            {
                context.ProductoVendidos.Add(v);

                context.SaveChanges();
                return true;
            }


        }

        public static bool ActualizarProductoVendidoPorId(ProductoVendido v, int id)
        {
            using (CoderContext context = new CoderContext())
            {
                ProductoVendido? vBuscado = context.ProductoVendidos.Where(v => v.Id == id).FirstOrDefault();


                vBuscado.Stock = vBuscado.Stock;
                vBuscado.IdProducto = vBuscado.IdProducto;
                vBuscado.IdVenta = vBuscado.IdVenta;


                context.ProductoVendidos.Update(vBuscado);

                context.SaveChanges();

                return true;
            }
        }


        public static bool EliminarProductoVendidoPorId(int id)
        {
            using (CoderContext context = new CoderContext())
            {
                ProductoVendido? AEliminar = context.ProductoVendidos.Where(v => v.Id == id).FirstOrDefault();

                if (AEliminar is not null)
                {
                    context.ProductoVendidos.Remove(AEliminar);
                    context.SaveChanges();
                    return true;
                }
            }

            return false;
        }




    }
}
