﻿
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using WebApiSistemaGestion.database;
using WebApiSistemaGestion.DTOs;
using WebApiSistemaGestion.Mapper;
using WebApiSistemaGestion.models;


namespace WebApiSistemaGestion.service
{
    public class ProductoVendidoService
    {

        private readonly CoderContext context;
        private readonly ProductoVendidoMapper productoVendidoMapper;

        public ProductoVendidoService(CoderContext coderContext, ProductoVendidoMapper productoVendidoMapper)
        {
            this.context = coderContext;
            this.productoVendidoMapper = productoVendidoMapper; 
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
        public bool AgregarProductoVendido(ProductoVendidoDTO dto)
        {
            ProductoVendido pv = productoVendidoMapper.MapearAProductoVendido(dto);
            EntityEntry<ProductoVendido>? resultado = this.context.ProductoVendidos.Add(pv);

            resultado.State = EntityState.Added;
            context.SaveChanges();
            return true;
        }

        public bool ActualizarProductoVendidoPorId(ProductoVendidoDTO productoVendidoDTO, int id)
        {
            ProductoVendido? vBuscado = context.ProductoVendidos.Where(v => v.Id == id).FirstOrDefault();


            if (vBuscado is not null)
            {
                vBuscado.Stock = productoVendidoDTO.Stock;
                vBuscado.IdProducto = productoVendidoDTO.IdProducto;
                vBuscado.IdVenta = productoVendidoDTO.IdVenta;


                context.ProductoVendidos.Update(vBuscado);

                context.SaveChanges();

                return true;
            }
            return false;
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

        ///////////////////////////////////////////

        public List<ProductoVendido>? ObtenerProductosVendidosPorIdUsuario(int idUsuario)
        {

            List<Producto> productos = context.Productos.ToList();

            List<Producto> productosFiltrados = productos.Where(p => p.IdUsuario == idUsuario).ToList();


            List<ProductoVendido> resultadoFinal = new List<ProductoVendido>();


            List<ProductoVendido> productosVendidos = ObtenerTodosLosProductosVendidos();



            foreach (Producto p in productosFiltrados)
            {
                int id = p.Id;
                ProductoVendido? pVendido = productosVendidos.Find(p => p.IdProducto == id);

                if (pVendido is not null)
                {
                    resultadoFinal.Add(pVendido);
                }
            }
            return resultadoFinal;

        }

        public List<ProductoVendidoDTO>? ObtenerProductoVendidosPorIdUsuario(int idUsuario)
        {

            List<Producto>? productos = context.Productos
                                                .Include(p => p.ProductoVendidos)
                                                .Where(p => p.IdUsuario == idUsuario)
                                                .ToList();

            List<ProductoVendido>? productosVendidos = productos
                                                       .Select(p => p.ProductoVendidos
                                                                   .ToList()
                                                                   .Find(pv => pv.IdProducto == p.Id))
                                                                   .Where(p => !object.ReferenceEquals(p, null))
                                                                   .ToList();

            List<ProductoVendidoDTO> dto = productosVendidos
                                           .Select(p => productoVendidoMapper.MapearADTO(p))
                                           .ToList();
            return dto;
        }






    }
}
