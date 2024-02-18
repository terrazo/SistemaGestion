
using Microsoft.EntityFrameworkCore;
using WebApiSistemaGestion.database;
using WebApiSistemaGestion.models;


namespace WebApiSistemaGestion.service
{
    public class ProductoVendidoService
    {

        private CoderContext context;

        public ProductoVendidoService(CoderContext coderContext)
        {
            this.context = coderContext;
        }


        public List<ProductoVendido> GetAllProductosVendidos()
        {
            return context.ProductoVendidos.ToList();
        }



        public List<ProductoVendido> ObtenerTodosLosProductosVendidos()
        {

            List<ProductoVendido> v = context.ProductoVendidos.ToList();

            return v;

        }

        public ProductoVendido ObtenerProductoVendidoPorId(int id)
        {


            ProductoVendido? pvbuscado = context.ProductoVendidos.Where(pv => pv.Id == id).FirstOrDefault();

            return pvbuscado;
        }

        /*
        public List<ProductoVendido> ObtenerProductosVendidosPorId(int id)
        {
            List<ProductoVendido> v = ObtenerTodosLosProductosVendidos();
            List<ProductoVendido> vPorId = new List<ProductoVendido>();

            foreach (ProductoVendido item in v)
            {
                if (item.Id == id)
                {
                    v.Add(item);
                }
            }
            return vPorId;
        }
        */
        public bool AgregarProductoVendido(ProductoVendido v)
        {
            context.ProductoVendidos.Add(v);

            context.SaveChanges();
            return true;
        }

        public bool ActualizarProductoVendidoPorId(ProductoVendido v, int id)
        {
            ProductoVendido? vBuscado = context.ProductoVendidos.Where(v => v.Id == id).FirstOrDefault();


            vBuscado.Stock = vBuscado.Stock;
            vBuscado.IdProducto = vBuscado.IdProducto;
            vBuscado.IdVenta = vBuscado.IdVenta;


            context.ProductoVendidos.Update(vBuscado);

            context.SaveChanges();

            return true;
        }


        public bool EliminarProductoVendidoPorId(int id)
        {
            ProductoVendido? AEliminar = context.ProductoVendidos.Where(v => v.Id == id).FirstOrDefault();

            if (AEliminar is not null)
            {
                context.ProductoVendidos.Remove(AEliminar);
                context.SaveChanges();
                return true;
            }

            return false;
        }




    }
}
