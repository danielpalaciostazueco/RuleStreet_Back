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
        public ActionResult<List<RangoDto>> GetAll()
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
        public ActionResult<RangoDto> Get(int id)
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
        public IActionResult Update(int id, Rango rango)
        {
            try
            {
                if (id != rango.IdRango)
                {
                    return BadRequest();
                }

                var existingRango = _rangoService.Get(id);
                if (existingRango == null)
                {
                    return NotFound();
                }

                _rangoService.Update(rango);
                return NoContent();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error al modificar el rango por id");
                return StatusCode(500, "Error interno del servidor");
            }
        }
    }
}
