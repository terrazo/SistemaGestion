
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
        private readonly ProductoMapper productoMapper;

        public ProductoService(CoderContext coderContext, ProductoMapper productoMapper)
        {
            this.context = coderContext;
            this.productoMapper = productoMapper;
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


        public List<Producto> GetProductosPorIdUsuario(int idUsuario)
        {

            List<Producto> productos = context.Productos.Where(p=>p.IdUsuario==idUsuario).ToList();

            return productos;
        }

        public ProductoDTO ObtenerProductoPorId(int id)
        {
            Producto? productoBuscado = context.Productos.Where(p => p.Id == id).FirstOrDefault();
            ProductoDTO pdto = productoMapper.MapearADTO(productoBuscado);
            return pdto;
        }


        public bool AgregarUnProducto(ProductoDTO dto)
        {
            Producto p = productoMapper.MapearAProducto(dto);

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
