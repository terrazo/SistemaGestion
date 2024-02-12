using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionEntities
{
    public class Venta
    {
        private int id;
        private string comentarios;
        private int idUsuario;

        public int Id { get => id; set => id = value; }
        public string Comentarios { get => comentarios; set => comentarios = value; }
        public int IdUsuario { get => idUsuario; set => idUsuario = value; }


        public Venta() { }

        public Venta(int id, string comentarios, int idUsuario)
        {
            Id = id;
            Comentarios = comentarios;
            IdUsuario = idUsuario;
 
        }

        public Venta(string comentarios, int idUsuario )
        {
            Comentarios = comentarios;
            IdUsuario = idUsuario;
 
        }
    }
}
