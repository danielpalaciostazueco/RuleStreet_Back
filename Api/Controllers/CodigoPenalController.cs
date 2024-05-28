using Microsoft.AspNetCore.Mvc;
using RuleStreet.Models;
using RuleStreet.Business;
using System.Collections.Generic;
using Serilog;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace RuleStreet.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CodigoPenalController : ControllerBase
    {
        private readonly CodigoPenalService _codigoPenalService;
        private readonly ILogger<CodigoPenalController> _logger;

        public CodigoPenalController(CodigoPenalService codigoPenalService, ILogger<CodigoPenalController> logger)
        {
            _codigoPenalService = codigoPenalService;
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult<List<CodigoPenalDTO>> GetAll()
        {
            try
            {
                _logger.LogInformation("Solicitando la lista de todo el codigo penal.");
                return _codigoPenalService.GetAll();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error obteniendo todo el codigo penal.");
                return StatusCode(500, "Un error ocurrió al obtener la lista del codigo penal.");
            }
        }

      

        [AllowAnonymous]
        [HttpGet("{id}")]
        public ActionResult<CodigoPenal> Get(int id)
        {
            try
            {
                _logger.LogInformation($"Buscando articulo con ID: {id}");
                var codigoPenal = _codigoPenalService.Get(id);

                if (codigoPenal == null)
                {
                    _logger.LogWarning($"Codigo con ID: {id} no encontrada.");
                    return NotFound();
                }

                return codigoPenal;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error obteniendo el codigo con ID: {id}.");
                return StatusCode(500, "Un error ocurrió al obtener el codigo.");
            }
        }
        
        

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _logger.LogInformation($"Eliminando articulo con ID: {id}");
                var codigoPenal = _codigoPenalService.Get(id);

                if (codigoPenal is null)
                {
                    _logger.LogWarning($"No se puede eliminar: Articulo con ID: {id} no encontrada.");
                    return NotFound();
                }

                _codigoPenalService.Delete(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error obteniendo al eliminar el articulo con ID: {id}.");
                return StatusCode(500, "Un error ocurrió al eliminar el articulo.");
            }
        }
    }
}