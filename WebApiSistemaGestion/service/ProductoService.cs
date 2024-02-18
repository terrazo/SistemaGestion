
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using WebApiSistemaGestion.database;
using WebApiSistemaGestion.DTOs;
using WebApiSistemaGestion.Mapper;
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

        public List<Producto> GetAllProducts()
        {
            return context.Productos.ToList();
        }



        public List<Producto> ObtenerTodosLosProductos()
        {

            List<Producto> productos = context.Productos.ToList();

            return productos;
        }

        public Producto ObtenerProductoPorId(int id)
        {
            Producto? productoBuscado = context.Productos.Where(p => p.Id == id).FirstOrDefault();
            return productoBuscado;
        }


        public bool AgregarUnProducto(ProductoDTO dto)
        {
            Producto p = ProductoMapper.MapearAProducto(dto);

            this.context.Productos.Add(p);
            this.context.SaveChanges();
            return true;
        }

        public bool BorrarProductoPorId(int id)
        {
            Producto? producto = this.context.Productos.Where(p => p.Id == id).FirstOrDefault();

            if (producto is not null)
            {
                List<ProductoVendido>? productoVendidos = context.ProductoVendidos.Where(p => p.IdProducto == id).ToList();

                if (productoVendidos.Count > 0)
                {
                    foreach (ProductoVendido v in productoVendidos)
                    {
                        this.context.Remove(producto);
                        this.context.SaveChanges();
                    }
                }

                this.context.Remove(producto);
                this.context.SaveChanges();
                return true;
            }

            return false;
        }

        public bool ActualizarProductoPorId(int id, ProductoDTO productoDTO)
        {
            Producto? producto = this.context.Productos.Where(p => p.Id == id).FirstOrDefault();

            if (producto is not null)
            {
                producto.PrecioVenta = productoDTO.PrecioVenta;
                producto.Stock = productoDTO.Stock;
                producto.Descripciones = productoDTO.Descripciones;
                producto.IdUsuario = productoDTO.IdUsuario;
                producto.Costo = productoDTO.Costo;

                this.context.Productos.Update(producto);
                this.context.SaveChanges();
                return true;
            }


            return false;
        }

        /*
        public bool AgregarProducto(Producto p)
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
        */


    }
}
