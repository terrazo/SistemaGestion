using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaGestionData;
using SistemaGestionEntities;


namespace SistemaGestionBussiness
{
    public static class UsuarioBussiness
    {
        public static List<Usuario> GetUsuarios()
        {
            return UsuarioData.GetUsuarios();
        }


        public static void CreateUsuario(string nombre, string apellido, string nombreUsuario, string contraseña, string mail)
        {
            Usuario user = new Usuario(nombre,apellido,nombreUsuario,contraseña,mail);

                UsuarioData.CrearUsuario(user);

        }
    }
}
