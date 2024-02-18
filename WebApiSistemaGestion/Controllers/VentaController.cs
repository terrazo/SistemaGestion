using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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


    }
}
