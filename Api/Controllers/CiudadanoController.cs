using Microsoft.AspNetCore.Mvc;
using RuleStreet.Models;
using RuleStreet.Business;
using System.Collections.Generic;
using Serilog;

namespace RuleStreet.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CiudadanoController : ControllerBase
    {
        private readonly CiudadanoService _CiudadanoService;


        public CiudadanoController(CiudadanoService CiudadanoService)
        {
            _CiudadanoService = CiudadanoService;
        }

        [HttpGet]
        public ActionResult<List<CiudadanoDTO>> GetAll()
        {
            return _CiudadanoService.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<Ciudadano> Get(int id)
        {
            try
            {
                var Ciudadano = _CiudadanoService.Get(id);
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


        [HttpPost]
        public ActionResult<Ciudadano> Create(Ciudadano Ciudadano)
        {
            try
            {
                if (_CiudadanoService.Get(Ciudadano.IdCiudadano) != null)
                {
                    return BadRequest($"Ciudadano con ID {Ciudadano.IdCiudadano} ya existe.");
                }

                _CiudadanoService.Add(Ciudadano);
                return CreatedAtAction(nameof(Create), new { id = Ciudadano.IdCiudadano }, Ciudadano);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error al obtener todas las Ciudadanos");
                return StatusCode(500, "Error interno del servidor");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Ciudadano Ciudadano)
        {
            try
            {
                if (id != Ciudadano.IdCiudadano)
                {
                    return BadRequest();
                }

                var existingCiudadano = _CiudadanoService.Get(id);
                if (existingCiudadano == null)
                {
                    return NotFound();
                }

                _CiudadanoService.Update(Ciudadano);
                return NoContent();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error al modificar la Ciudadano por id");
                return StatusCode(500, "Error interno del servidor");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var Ciudadano = _CiudadanoService.Get(id);
                if (Ciudadano == null)
                {
                    return NotFound();
                }

                _CiudadanoService.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error al eliminar la Ciudadano por id");
                return StatusCode(500, "Error interno del servidor");
            }
        }
    }
}
