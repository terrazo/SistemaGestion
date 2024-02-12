using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionEntities
{
    public class Producto
    {
        private int id;
        private string descripcion;
        private double costo;
        private double precioVenta;
        private int stock;
        private int idUsuario;

        public int Id { get => id; set => id = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public double Costo { get => costo; set => costo = value; }
        public double PrecioVenta { get => precioVenta; set => precioVenta = value; }
        public int Stock { get => stock; set => stock = value; }
        public int IdUsuario { get => idUsuario; set => idUsuario = value; }

        public Producto() { }

        public Producto(int id, string descripcion, double costo, double precioVenta, int stock, int idUsuario)
        {
            this.id = id;
            this.descripcion = descripcion;
            this.costo = costo;
            this.precioVenta= precioVenta;
            this.stock = stock;
            this.idUsuario = idUsuario;
        }

        public Producto(string descripcion, double costo, double precioVenta, int stock, int idUsuario)
        {
             this.descripcion = descripcion;
            this.costo = costo;
            this.precioVenta = precioVenta;
            this.stock = stock;
            this.idUsuario = idUsuario;
        }


    }
}
