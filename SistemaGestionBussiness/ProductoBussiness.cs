﻿using SistemaGestionData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaGestionData;
using SistemaGestionEntities;

namespace SistemaGestionBussiness
{
    public static class ProductoBussiness
    {

        public static List<Producto> GetProductos()
        {
            return ProductoData.ListarProductos();
        }


        public static void CreateProducto(string descripcion, double costo, double precioVenta, int stock, int idUsuario)
        {
            Producto p = new Producto(descripcion,costo,precioVenta,stock,idUsuario);

            ProductoData.CrearProducto(p);

        }
    }
}
