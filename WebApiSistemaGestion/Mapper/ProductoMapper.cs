using WebApiSistemaGestion.models;
using WebApiSistemaGestion.DTOs;


namespace WebApiSistemaGestion.Mapper
{
    public class ProductoMapper
    {
        public Producto MapearAProducto(ProductoDTO dto)
        {
            Producto producto = new Producto();
            producto.Descripciones = dto.Descripciones;
            producto.Id = dto.Id;
            producto.PrecioVenta = dto.PrecioVenta;
            producto.Stock = dto.Stock;
            producto.Costo = dto.Costo;
            producto.IdUsuario = dto.IdUsuario;

            return producto;
        }

        public ProductoDTO MapearADTO(Producto producto)
        {
            ProductoDTO dto = new ProductoDTO();

            dto.Descripciones = producto.Descripciones;
            dto.Id = producto.Id;
            dto.PrecioVenta = producto.PrecioVenta;
            dto.Stock = producto.Stock;
            dto.Costo = producto.Costo;
            dto.IdUsuario = producto.IdUsuario;

            return dto;

        }
    }
}
