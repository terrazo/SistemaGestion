using WebApiSistemaGestion.models;
using WebApiSistemaGestion.DTOs;


namespace WebApiSistemaGestion.Mapper
{
    public class ProductoVendidoMapper
    {
        public ProductoVendido MapearAProductoVendido(ProductoVendidoDTO dto)
        {
            ProductoVendido producto = new ProductoVendido();
            producto.Id = dto.Id;
            producto.IdProducto = dto.IdProducto;
            producto.Stock = dto.Stock;
            producto.IdVenta = dto.IdVenta;

            return producto;
        }

        public ProductoVendidoDTO MapearADTO(ProductoVendido producto)
        {
            ProductoVendidoDTO dto = new ProductoVendidoDTO();

            dto.Id = producto.Id;
            dto.IdProducto = producto.IdProducto;
            dto.Stock = producto.Stock;
            dto.IdVenta = producto.IdVenta;

            return dto;

        }
    }
}

