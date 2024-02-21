using WebApiSistemaGestion.models;
using WebApiSistemaGestion.DTOs;

namespace WebApiSistemaGestion.Mapper
{
    public class UsuarioMapper
    {

        public Usuario MapearAUsuario(UsuarioDTO dto)
        {
            Usuario u = new Usuario();
            u.Id = dto.Id;
            u.Nombre = dto.Nombre;
            u.Apellido = dto.Apellido;
            u.NombreUsuario = dto.NombreUsuario;
            u.Contraseña = dto.Contraseña;
            u.Mail = dto.Mail;

            return u;
        }

        public UsuarioDTO MapearADTO(Usuario u)
        {
            UsuarioDTO dto = new UsuarioDTO();

            dto.Id = u.Id;
            dto.Nombre = u.Nombre;
            dto.Apellido = u.Apellido;
            dto.NombreUsuario = u.NombreUsuario;
            dto.Contraseña = u.Contraseña;
            dto.Mail = u.Mail;

            return dto;

        }

    }
}
