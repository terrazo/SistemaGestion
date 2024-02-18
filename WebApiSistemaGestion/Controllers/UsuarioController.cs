using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiSistemaGestion.database;
using WebApiSistemaGestion.DTOs;
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

        [HttpPost]
        public IActionResult AgregarUsuario([FromBody] UsuarioDTO usuarioDTO)
        {

            if (this.usuarioService.AgregarUsuario(usuarioDTO))
            {
                return base.Ok(new { mensaje = "Usuario agregado", usuarioDTO });
            }
            else
            {
                return base.Conflict(new { mensaje = "No se agrego un Usuario" });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult BorrarUsuario(int id)
        {
            if (id > 0)
            {
                if (this.usuarioService.EliminarUsuarioPorId(id))
                {
                    return base.Ok(new { mensaje = "Usuario borrado", status = 200 });
                }

                return base.Conflict(new { mensaje = "No se pudo borrar Usuario" });

            }
            return base.BadRequest(new { status = 400, mensaje = "El id no puede ser negativo" });
        }

        [HttpPut("{id}")]
        public IActionResult ActualizarUsuarioPorId(int id, UsuarioDTO usuarioDTO)
        {
            if (id > 0)
            {
                if (this.usuarioService.ActualizarUsuarioPorId(usuarioDTO, id))
                {
                    return base.Ok(new { mensaje = "Usuario Actualizado", status = 200, usuarioDTO });
                }
                return base.Conflict(new { mensaje = "No se pudo Actualizar Usuario" });

            }
            return base.BadRequest(new { status = 400, mensaje = "El id no puede ser negativo" });
        }

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
