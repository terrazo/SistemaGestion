
using Microsoft.EntityFrameworkCore;
using WebApiSistemaGestion.database;
using WebApiSistemaGestion.models;



namespace WebApiSistemaGestion.service
{
    public static class ProductoService
    {
        public static List<Producto> GetAllProducts()
        {
            using (CoderContext context = new CoderContext())
            {
                return context.Productos.ToList();
            }
        }



        public static List<Producto> ObtenerTodosLosProductos()
        {
            using (CoderContext context = new CoderContext())
            {

                List<Producto> productos = context.Productos.ToList();

                return productos;

            }
        }

        public static Producto ObtenerProductoPorId(int id)
        {
            using (CoderContext context = new CoderContext())
            {

                Producto? productoBuscado = context.Productos.Where(p => p.Id == id).FirstOrDefault();
                return productoBuscado;
            }
        }


        public static bool AgregarProducto(Producto p)
        {
            using (CoderContext context = new CoderContext())
            {
                context.Productos.Add(p);

                context.SaveChanges();
                return true;
            }


        }


        public static bool ActualizarProductoPorId(Producto producto, int id)
        {
            using (CoderContext context = new CoderContext())
            {
                Producto? productoBuscado = context.Productos.Where(p => p.Id == id).FirstOrDefault();


                productoBuscado.Descripciones = producto.Descripciones;
                productoBuscado.Costo = producto.Costo;
                productoBuscado.PrecioVenta = producto.PrecioVenta;
                productoBuscado.Stock = producto.Stock;
                productoBuscado.IdUsuario = producto.IdUsuario;


                context.Productos.Update(productoBuscado);

                context.SaveChanges();

                return true;
            }
        }



        public static bool EliminarProductoPorId(int id)
        {
            using (CoderContext context = new CoderContext())
            {
                Producto productoAEliminar = context.Productos.Include(p => p.ProductoVendidos).Where(p => p.Id == id).FirstOrDefault();

                if (productoAEliminar is not null)
                {
                    context.Productos.Remove(productoAEliminar);
                    context.SaveChanges();
                    return true;
                }
            }

            return false;
        }
    }
}
