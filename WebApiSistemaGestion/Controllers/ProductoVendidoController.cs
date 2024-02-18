using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiSistemaGestion.service;
using WebApiSistemaGestion.models;

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
        public List<ProductoVendido> getUsuarios()
        {
            return productoVendidoService.GetAllProductosVendidos();
        }

        //////////////////////////////////////////////////////////////////////////////////////////

    }
}
