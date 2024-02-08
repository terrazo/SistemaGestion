
using Microsoft.EntityFrameworkCore;
using WebApiSistemaGestion.database;
using WebApiSistemaGestion.models;



namespace WebApiSistemaGestion.service
{
    public class ProductoService
    {
        private CoderContext context;

        public ProductoService(CoderContext coderContext)
        {
            this.context = coderContext;
        }

        public   List<Producto> GetAllProducts()
        {
                return context.Productos.ToList();
        }



        public   List<Producto> ObtenerTodosLosProductos()
        {

                List<Producto> productos = context.Productos.ToList();

                return productos;
        }

        public   Producto ObtenerProductoPorId(int id)
        {
                Producto? productoBuscado = context.Productos.Where(p => p.Id == id).FirstOrDefault();
                return productoBuscado;
        }


        public   bool AgregarProducto(Producto p)
        {
                context.Productos.Add(p);

                context.SaveChanges();
                return true;
        }


        public   bool ActualizarProductoPorId(Producto producto, int id)
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



        public   bool EliminarProductoPorId(int id)
        {
                Producto productoAEliminar = context.Productos.Include(p => p.ProductoVendidos).Where(p => p.Id == id).FirstOrDefault();

                if (productoAEliminar is not null)
                {
                    context.Productos.Remove(productoAEliminar);
                    context.SaveChanges();
                    return true;
                }

            return false;
        }



    }
}
