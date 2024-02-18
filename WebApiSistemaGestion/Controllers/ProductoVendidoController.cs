using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiSistemaGestion.service;
using WebApiSistemaGestion.models;
using WebApiSistemaGestion.DTOs;

namespace WebApiSistemaGestion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoVendidoController : Controller
    {

        private ProductoVendidoService productoVendidoService;

        public ProductoVendidoController(ProductoVendidoService productoVendidoService)
        {
            this.productoVendidoService = productoVendidoService;
        }


        [HttpGet]
        public List<ProductoVendido> getProductosVendidos()
        {
            return productoVendidoService.GetAllProductosVendidos();
        }



        //////////////////////////////////////////////////////////////////////////////////////////
        ///


        [HttpPost]
        public IActionResult AgregarProductoVendido([FromBody] ProductoVendidoDTO productoVendido)
        {

            if (this.productoVendidoService.AgregarProductoVendido(productoVendido))
            {

                return base.Ok(new { mensaje = "Producto Vendido agregado", productoVendido });
            }
            else
            {
                return base.Conflict(new { mensaje = "No se agrego un Producto Vendido" });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult BorrarProductoVendido(int id)
        {
            if (id > 0)
            {
                if (this.productoVendidoService.EliminarProductoVendidoPorId(id))
                {
                    return base.Ok(new { mensaje = "Producto Vendido borrado", status = 200 });
                }

                return base.Conflict(new { mensaje = "No se pudo borrar el producto vendido" });

            }
            return base.BadRequest(new { status = 400, mensaje = "El id no puede ser negativo" });
        }

        [HttpPut("{id}")]
        public IActionResult ActualizarProductoVendidoPorId(int id, ProductoVendidoDTO productoVendidoDTO)
        {
            if (id > 0)
            {
                if (this.productoVendidoService.ActualizarProductoVendidoPorId(productoVendidoDTO, id))
                {
                    return base.Ok(new { mensaje = "Producto Vendido Actualizado", status = 200, productoVendidoDTO });
                }
                return base.Conflict(new { mensaje = "No se pudo Actualizar el producto vendido" });

            }
            return base.BadRequest(new { status = 400, mensaje = "El id no puede ser negativo" });
        }

        ////////////////////////////////////
        ///

        [HttpGet("{idUsuario}")]
        public ActionResult<List<ProductoVendido>>? ObtenerProductosVendidosPorIdUsuario(int idUsuario)
        {
            return productoVendidoService.ObtenerProductosVendidosPorIdUsuario(idUsuario);
        }


    }
}
