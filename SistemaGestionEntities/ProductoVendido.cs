using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionEntities
{
    public class ProductoVendido
    {
        private int id;
        private int idProducto;
        private double stock;
        private int idVenta;

        public int Id { get => id; set => id = value; }
        public int IdProducto { get => idProducto; set => idProducto = value; }
        public double Stock { get => stock; set => stock = value; }
        public int IdVenta { get => idVenta; set => idVenta = value; }
    }
}
