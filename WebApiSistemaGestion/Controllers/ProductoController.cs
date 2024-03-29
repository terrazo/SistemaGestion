﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiSistemaGestion.service;
using WebApiSistemaGestion.models;
using WebApiSistemaGestion.DTOs;

namespace WebApiSistemaGestion.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : Controller
    {
        private ProductoService productoService;

        public ProductoController(ProductoService productoService)
        {
            this.productoService = productoService;
        }


        [HttpGet]
        public List<Producto> getProductos()
        {
            return productoService.GetAllProducts();
        }

        //////////////////////////////////////////////////////////////////////////////////////////
        /*
        [HttpGet]
        public IActionResult Index([FromQuery] string? nombre, [FromQuery] string? edad)
        {
            return base.Ok(new { mensaje = "Hola desde producto", estado = 200, parametros = new List<string> { nombre, edad } });

        }
        */

        [HttpGet("{idUsuario}")]
        public List<Producto> getProductosPorIdUsuario(int idUsuario)
        {
            return productoService.GetProductosPorIdUsuario(idUsuario);
        }
        /// ///////////////////////////
        
        [HttpPost]
        public IActionResult AgregarUnNuevoProducto([FromBody] ProductoDTO producto)
        {

            if (this.productoService.AgregarUnProducto(producto))
            {

                return base.Ok(new { mensaje = "Producto agregado", producto });
            }
            else
            {
                return base.Conflict(new { mensaje = "No se agrego un producto" });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult BorrarProducto(int id)
        {
                if (this.productoService.BorrarProductoPorId(id))
                {
                    return base.Ok(new { mensaje = "Producto borrado", status = 200 });
                }

                return base.Conflict(new { mensaje = "No se pudo borrar el producto" });
        }

        [HttpPut("{id}")]
        public IActionResult ActualizarProductoPorId(int id, ProductoDTO productoDTO)
        {
            if (id > 0)
            {
                if (this.productoService.ActualizarProductoPorId(id, productoDTO))
                {
                    return base.Ok(new { mensaje = "Producto Actualizado", status = 200, productoDTO });
                }
                return base.Conflict(new { mensaje = "No se pudo Actualizar el producto" });

            }
            return base.BadRequest(new { status = 400, mensaje = "El id no puede ser negativo" });
        }

    }
}
