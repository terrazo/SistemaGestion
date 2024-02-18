using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiSistemaGestion.DTOs;
using WebApiSistemaGestion.models;
using WebApiSistemaGestion.service;

namespace WebApiSistemaGestion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : Controller
    {

        private VentaService ventaService;

        public VentaController(VentaService ventaService)
        {
            this.ventaService = ventaService;
        }


        [HttpGet]
        public List<Venta> getVentas()
        {
            return ventaService.GetAllVentas();
        }

        //////////////////////////////////////////////////////////////////////////////////////////


        [HttpPost]
        public IActionResult AgregarVenta([FromBody] VentaDTO venta)
        {

            if (this.ventaService.AgregarVenta(venta))
            {

                return base.Ok(new { mensaje = "Venta agregado", venta });
            }
            else
            {
                return base.Conflict(new { mensaje = "No se agrego una Venta" });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult BorrarVenta(int id)
        {
            if (id > 0)
            {
                if (this.ventaService.EliminarVentaPorId(id))
                {
                    return base.Ok(new { mensaje = "Venta borrado", status = 200 });
                }

                return base.Conflict(new { mensaje = "No se pudo borrar Venta" });

            }
            return base.BadRequest(new { status = 400, mensaje = "El id no puede ser negativo" });
        }

        [HttpPut("{id}")]
        public IActionResult ActualizarVentaPorId(int id, VentaDTO ventaDTO)
        {
            if (id > 0)
            {
                if (this.ventaService.ActualizarVentaPorId(ventaDTO, id))
                {
                    return base.Ok(new { mensaje = "Venta Actualizado", status = 200, ventaDTO });
                }
                return base.Conflict(new { mensaje = "No se pudo Actualizar Venta" });

            }
            return base.BadRequest(new { status = 400, mensaje = "El id no puede ser negativo" });
        }

        /////////////
        ///

        /*
        [HttpPost]
        public IActionResult CargarVenta([FromBody] VentaDTO venta, List<ProductoVendidoDTO> pvList)
        {

            if (this.ventaService.AgregarVenta(venta))
            {
                foreach(var item in pvList)
                {
                    this.
                }


                return base.Ok(new { mensaje = "Venta agregado", venta });
            }
            else
            {
                return base.Conflict(new { mensaje = "No se agrego una Venta" });
            }
        }
        */

    }
}
