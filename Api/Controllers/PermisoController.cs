using Microsoft.AspNetCore.Mvc;
using RuleStreet.Models;
using RuleStreet.Business;
using System.Collections.Generic;
using Serilog;

namespace RuleStreet.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PermisoController : ControllerBase
    {
        private readonly PermisoService _PermisoService;


        public PermisoController(PermisoService PermisoService)
        {
            _PermisoService = PermisoService;
        }

        [HttpGet]
        public ActionResult<List<Permiso>> GetAll()
        {
            return _PermisoService.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<Permiso> Get(int id)
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
        public IActionResult Update(int id, Permiso permiso)
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
        

    
    }
}
