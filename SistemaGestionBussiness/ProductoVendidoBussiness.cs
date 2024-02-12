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
    public static class ProductoVendidoBussiness
    {

        public static List<ProductoVendido> GetProductosVendidos()
        {
            return ProductoVendidoData.ListarProductosVendidos();
        }


        public static void CreateProductoVendido(int idProducto, int stock, int idVenta)
        {
            ProductoVendido pv = new ProductoVendido( idProducto,stock,idVenta);

            ProductoVendidoData.CrearProductoVendido(pv);

        }


    }
}
