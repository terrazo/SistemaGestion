
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using WebApiSistemaGestion.database;
using WebApiSistemaGestion.DTOs;
using WebApiSistemaGestion.Mapper;
using WebApiSistemaGestion.models;


namespace WebApiSistemaGestion.service
{
    public class VentaService
    {
        private CoderContext context;
        private readonly VentaMapper ventaMapper;
        private readonly ProductoVendidoService productoVendidoService;
        private readonly ProductoService productoService;

        public VentaService(CoderContext coderContext, 
                            VentaMapper ventaMapper, 
                            ProductoService productoService,
                            ProductoVendidoService productoVendidoService)
        {
            this.context = coderContext;
            this.ventaMapper = ventaMapper;
            this.productoService = productoService;
            this.productoVendidoService = productoVendidoService;
        }

        public List<Venta> GetAllVentas()
        {
            return context.Venta.ToList();
        }

        public List<Venta> ObtenerTodasLasVentas()
        {
            List<Venta> v = context.Venta.ToList();

            return v;
        }

        public Venta ObtenerVentaPorId(int id)
        {
            Venta? vbuscada = context.Venta.Where(v => v.Id == id).FirstOrDefault();
            return vbuscada;
        }

        public List<Venta> ObtenerVentasPorIdUsuario(int idUsuario)
        {
            List<Venta>? vbuscada = context.Venta.Where(v => v.IdUsuario == idUsuario).ToList();
            return vbuscada;
        }

        public Venta ObtenerVentaPorId2(int id)
        {
            List<Venta> v = ObtenerTodasLasVentas();

            foreach (Venta item in v)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }
            return null;
        }
        /*
        public bool AgregarVenta(VentaDTO vDTO)
        {

            Venta venta = ventaMapper.MapearAVenta(vDTO);

            context.Venta.Add(venta);

            context.SaveChanges();
            return true;
        }
        */

        public bool AgregarNuevaVenta(int idUsuario, List<ProductoDTO> productosDTO)
        {

            Venta venta = new Venta();
        
        List<string> nombresDeProductos = productosDTO.Select(p=>p.Descripciones).ToList();

            string comentarios = string.Join("-", nombresDeProductos);
            venta.Comentarios = comentarios;
            venta.IdUsuario = idUsuario;

            EntityEntry<Venta>? resultado = context.Venta.Add(venta);
            resultado.State = EntityState.Added;
            context.SaveChanges();

            MarcarComoProductosVendidos(productosDTO, venta.Id);

            ActualizarStockDeLosProductosVendidos(productosDTO);

            return true;
        
        }

        private void ActualizarStockDeLosProductosVendidos(List<ProductoDTO> productosDTO)
        {
            productosDTO.ForEach(p =>
            {
                ProductoDTO productoActual = productoService.ObtenerProductoPorId(p.Id);
                
                productoActual.Stock -= p.Stock;
                productoService.ActualizarProductoPorId(p.Id,productoActual);
            });
        }

        private void MarcarComoProductosVendidos(List<ProductoDTO> productosDTO, int idVenta) {

            productosDTO.ForEach(p =>
            {
                ProductoVendidoDTO productoVendidoDTO = new ProductoVendidoDTO();
                productoVendidoDTO.IdProducto = p.Id;
                productoVendidoDTO.IdVenta = idVenta;
                productoVendidoDTO.Stock = p.Stock;

                this.productoVendidoService.AgregarProductoVendido(productoVendidoDTO);

            });
        }

        public bool ActualizarVentaPorId(VentaDTO vDTO, int id)
        {
            Venta? vBuscado = context.Venta.Where(v => v.Id == id).FirstOrDefault();

            if (vBuscado is not null)
            {
                vBuscado.Comentarios = vDTO.Comentarios;
                vBuscado.IdUsuario = vDTO.IdUsuario;

                context.Venta.Update(vBuscado);

                context.SaveChanges();

                return true;
            }
            return false;
        }


        public bool EliminarVentaPorId(int id)
        {
            Venta? AEliminar = context.Venta.Where(v => v.Id == id).FirstOrDefault();

            if (AEliminar is not null)
            {
                context.Venta.Remove(AEliminar);
                context.SaveChanges();
                return true;
            }
            return false;
        }




    }


}
