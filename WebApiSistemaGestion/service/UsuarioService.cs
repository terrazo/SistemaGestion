

using Microsoft.EntityFrameworkCore;
using WebApiSistemaGestion.database;
using WebApiSistemaGestion.models;

namespace WebApiSistemaGestion.Service
{
    public static class UsuarioService
    {
        public static List<Usuario> GetAllUser()
        {
            using (CoderContext context = new CoderContext())
            {
                return context.Usuarios.ToList();
            }
        }



        public static List<Usuario> ObtenerTodosLosUsuarios()
        {
            using (CoderContext context = new CoderContext())
            {

                List<Usuario> usuarios = context.Usuarios.ToList();

                return usuarios;

            }
        }

        public static Usuario ObtenerUsuarioPorId(int id)
        {
            using (CoderContext context = new CoderContext())
            {

                Usuario? usuarioBuscado = context.Usuarios.Where(u => u.Id == id).FirstOrDefault();
                return usuarioBuscado;
            }
        }

        public static Usuario ObtenerUsuarioPorId2(int id)
        {
            List<Usuario> usuarios = UsuarioService.ObtenerTodosLosUsuarios();

            foreach (Usuario item in usuarios)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }
            return null;
        }

        public static bool AgregarUsuario(Usuario usuario)
        {
            using (CoderContext context = new CoderContext())
            {
                context.Usuarios.Add(usuario);

                context.SaveChanges();
                return true;
            }


        }

        public static bool ActualizarUsuarioPorId(Usuario usuario, int id)
        {
            using (CoderContext context = new CoderContext())
            {
                Usuario? usuarioBuscado = context.Usuarios.Where(u => u.Id == id).FirstOrDefault();


                usuarioBuscado.Nombre = usuario.Nombre;
                usuarioBuscado.NombreUsuario = usuario.NombreUsuario;
                usuarioBuscado.Apellido = usuario.Apellido;
                usuarioBuscado.Mail = usuario.Mail;

                context.Usuarios.Update(usuarioBuscado);

                context.SaveChanges();

                return true;
            }
        }


        public static bool EliminarUsuarioPorId(int id)
        {
            using (CoderContext context = new CoderContext())
            {
                Usuario? AEliminar = context.Usuarios.Where(u => u.Id == id).FirstOrDefault();

                if (AEliminar is not null)
                {
                    context.Usuarios.Remove(AEliminar);
                    context.SaveChanges();
                    return true;
                }
            }

            return false;
        }



    }
}
