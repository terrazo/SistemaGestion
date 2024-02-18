using WebApiSistemaGestion.models;
using WebApiSistemaGestion.DTOs;


namespace WebApiSistemaGestion.Mapper
{
    public class VentaMapper
    {
        public static Venta MapearAVenta(VentaDTO dto)
        {
            Venta v = new Venta();
            v.Id = dto.Id;
            v.Comentarios = dto.Comentarios;
            v.IdUsuario = dto.IdUsuario;

            return v;
        }

        public static VentaDTO MapearADTO(Venta v)
        {
            VentaDTO dto = new VentaDTO();

            dto.Id = v.Id;
            dto.Comentarios = v.Comentarios;
            dto.IdUsuario = v.IdUsuario;

            return dto;

        }

    }
}
