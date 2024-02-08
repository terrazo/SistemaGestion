using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiSistemaGestion.service;
using WebApiSistemaGestion.models;

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
            return productoService.GetAllProducts() ;
        }

        //////////////////////////////////////////////////////////////////////////////////////////

    }
}
