using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiSistemaGestion.database;
using WebApiSistemaGestion.models;
using WebApiSistemaGestion.service;

namespace WebApiSistemaGestion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : Controller
    {

        private UsuarioService usuarioService;

        public UsuarioController(UsuarioService usuarioService)
        {
            this.usuarioService = usuarioService;
        }


        [HttpGet]
        public List<Usuario> getUsuarios()
        {
            return usuarioService.GetAllUsers();
        }

//////////////////////////////////////////////////////////////////////////////////////////

        /*
        [HttpGet("nombre")]
        public string ObtenerNombre()
        {
            return "Este es el nombre";
        }

        List<string> list = new List<string>();

        [HttpGet("listado/{id}")]
        public ActionResult<string> ObtenerNombrePorId(int id)
        {
            if (id < 0 || id >= list.Count())
            {
                return BadRequest(new { mensaje = "El numero no puede ser negativo", status = 400 });
            }
            return this.list[id];
        }
        */

    }
}
