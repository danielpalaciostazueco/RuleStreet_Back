using Microsoft.AspNetCore.Mvc;
using RuleStreet.Models;
using RuleStreet.Business;
using System.Collections.Generic;
using Serilog;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace RuleStreet.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class PermisoController : ControllerBase
    {
        private readonly PermisoService _PermisoService;


        public PermisoController(PermisoService PermisoService)
        {
            _PermisoService = PermisoService;
        }

        [HttpGet]
        public ActionResult<List<PermisoDTO>> GetAll()
        {
            return _PermisoService.GetAll();
        }


      

        [HttpGet("{id}")]
        public ActionResult<PermisoDTO> Get(int id)
        {
            try
            {
                var Ciudadano = _PermisoService.Get(id);
                if (Ciudadano == null)
                {
                    return NotFound();
                }

                return Ciudadano;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error al hacer el get por id ");
                return StatusCode(500, "Error interno del servidor");
            }
        }


        [HttpPut("{id}")]
        public IActionResult Update(int id, PermisoDTO permiso)
        {
            try
            {
                if (id != permiso.IdPermiso)
                {
                    return BadRequest();
                }

                var existingPermiso = _PermisoService.Get(id);
                if (existingPermiso == null)
                {
                    return NotFound();
                }

                _PermisoService.Update(permiso);
                return NoContent();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error al modificar el Permiso por id");
                return StatusCode(500, "Error interno del servidor");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var Permiso = _PermisoService.Get(id);

                if (Permiso is null)

                {
                    return NotFound();
                }

                _PermisoService.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Error obteniendo al eliminar el articulo con ID: {id}.");
                return StatusCode(500, "Un error ocurrió al eliminar el articulo.");
            }
        }



    }
}
