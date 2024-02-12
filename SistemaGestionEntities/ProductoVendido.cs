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
        private int stock;
        private int idVenta;

        public int Id { get => id; set => id = value; }
        public int IdProducto { get => idProducto; set => idProducto = value; }
        public int Stock { get => stock; set => stock = value; }
        public int IdVenta { get => idVenta; set => idVenta = value; }



        public ProductoVendido() { }

        public ProductoVendido(int id, int idProducto, int stock, int idVenta)
        {
            Id = id;
            IdProducto = idProducto;
            Stock = stock;
            IdVenta = idVenta;
        }

        public ProductoVendido(int idProducto, int stock, int idVenta)
        {
            IdProducto = idProducto;
            Stock = stock;
            IdVenta = idVenta;
        }
    }
}
