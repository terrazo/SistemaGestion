

using Microsoft.EntityFrameworkCore;
using WebApiSistemaGestion.database;
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
            using (CoderContext context = new CoderContext())
            {

                Usuario? usuarioBuscado = context.Usuarios.Where(u => u.Id == id).FirstOrDefault();
                return usuarioBuscado;
            }
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

        public bool AgregarUsuario(Usuario usuario)
        {
            using (CoderContext context = new CoderContext())
            {
                context.Usuarios.Add(usuario);

                context.SaveChanges();
                return true;
            }


        }

        public bool ActualizarUsuarioPorId(Usuario usuario, int id)
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


        public bool EliminarUsuarioPorId(int id)
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
