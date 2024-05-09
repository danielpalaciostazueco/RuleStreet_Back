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
    public class RangoController : ControllerBase
    {
        private readonly RangoService _rangoService;
        private readonly ILogger<RangoController> _logger;

        public RangoController(RangoService rangoService, ILogger<RangoController> logger)
        {
            _rangoService = rangoService;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<List<RangoDTO>> GetAll()
        {
            try
            {
                _logger.LogInformation("Solicitando la lista de todos los rangos.");
                var rangos = _rangoService.GetAll();
                return Ok(rangos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error obteniendo todos los rangos.");
                return StatusCode(500, "Un error ocurrió al obtener la lista de rangos.");
            }
        }

        [HttpGet("{id}")]
        public ActionResult<RangoDTO> Get(int id)
        {
            try
            {
                _logger.LogInformation($"Buscando rango con ID: {id}");
                var rango = _rangoService.Get(id);

                if (rango == null)
                {
                    _logger.LogWarning($"Rango con ID: {id} no encontrado.");
                    return NotFound($"Rango con ID: {id} no encontrado.");
                }

                return Ok(rango);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error obteniendo el rango con ID: {id}.");
                return StatusCode(500, "Un error ocurrió al obtener el rango.");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, RangoDTO rango)
        {
            try
            {
                _logger.LogInformation($"Actualizando rango con ID: {id}");
                if (id != rango.IdRango)
                {
                    _logger.LogWarning($"Mala solicitud: El ID proporcionado ({id}) no coincide con el ID del rango ({rango.IdRango}).");
                    return BadRequest("El ID proporcionado no coincide con el ID del rango.");
                }

                var existingRango = _rangoService.Get(id);
                if (existingRango == null)
                {
                    _logger.LogWarning($"No se puede actualizar: Rango con ID: {id} no encontrado.");
                    return NotFound();
                }

                _rangoService.Update(rango, id);
                _logger.LogInformation($"Rango con ID: {id} actualizado correctamente.");
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al modificar el rango con ID: {id}.");
                return StatusCode(500, "Un error ocurrió al modificar el rango.");
            }
        }
    }
}
