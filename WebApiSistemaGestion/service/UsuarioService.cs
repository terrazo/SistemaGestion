

using Microsoft.EntityFrameworkCore;
using WebApiSistemaGestion.database;
using WebApiSistemaGestion.DTOs;
using WebApiSistemaGestion.Mapper;
using WebApiSistemaGestion.models;

namespace WebApiSistemaGestion.service
{
    public class UsuarioService
    {

        private CoderContext context;

        //constructor del usuarioService
        public UsuarioService(CoderContext coderContext)
        {
            this.context = coderContext;
        }

        public List<Usuario> ObtenerTodosLosUsuarios()
        {
            return this.context.Usuarios.ToList();
        }

        /// ///////////////////////////////////////////////////////////

        public List<Usuario> GetAllUsers()
        {
            using (CoderContext context = new CoderContext())
            {
                return context.Usuarios.ToList();
            }
        }

        /// ///////////////////////////////////////////////////////////


        public Usuario ObtenerUsuarioPorId(int id)
        {
                Usuario? usuarioBuscado = context.Usuarios.Where(u => u.Id == id).FirstOrDefault();
                return usuarioBuscado;
        }

        public Usuario ObtenerUsuarioPorId2(int id)
        {
            List<Usuario> usuarios = ObtenerTodosLosUsuarios();

            foreach (Usuario item in usuarios)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }
            return null;
        }

        public bool AgregarUsuario(UsuarioDTO usuarioDTO)
        {
            Usuario usuario = UsuarioMapper.MapearAUsuario(usuarioDTO);

                context.Usuarios.Add(usuario);

                context.SaveChanges();
                return true;
        }

        public bool ActualizarUsuarioPorId(UsuarioDTO usuarioDTO, int id)
        {
                Usuario? usuarioBuscado = context.Usuarios.Where(u => u.Id == id).FirstOrDefault();
           
            if (usuarioBuscado is not null)
            {

                usuarioBuscado.Nombre = usuarioDTO.Nombre;
                usuarioBuscado.NombreUsuario = usuarioDTO.NombreUsuario;
                usuarioBuscado.Apellido = usuarioDTO.Apellido;
                usuarioBuscado.Mail = usuarioDTO.Mail;

                context.Usuarios.Update(usuarioBuscado);

                context.SaveChanges();
                return true;
            }
            return false;
        }


        public bool EliminarUsuarioPorId(int id)
        {
                Usuario? AEliminar = context.Usuarios.Where(u => u.Id == id).FirstOrDefault();

                if (AEliminar is not null)
                {
                    context.Usuarios.Remove(AEliminar);
                    context.SaveChanges();
                    return true;
                }
            return false;
        }



    }
}
