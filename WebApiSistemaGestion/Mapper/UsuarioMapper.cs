using WebApiSistemaGestion.models;
using WebApiSistemaGestion.DTOs;

namespace WebApiSistemaGestion.Mapper
{
    public static class UsuarioMapper
    {

        public static Usuario MapearAUsuario(UsuarioDTO dto)
        {
            Usuario u = new Usuario();
            u.Id = dto.Id;
            u.Nombre = dto.Nombre;
            u.NombreUsuario = dto.NombreUsuario;
            u.Contraseña = dto.Contraseña;
            u.Mail = dto.Mail;

            return u;
        }

        public static UsuarioDTO MapearADTO(Usuario u)
        {
            UsuarioDTO dto = new UsuarioDTO();

            dto.Id = u.Id;
            dto.Nombre = u.Nombre;
            dto.NombreUsuario = u.NombreUsuario;
            dto.Contraseña = u.Contraseña;
            dto.Mail = u.Mail;

            return dto;

        }

    }
}
