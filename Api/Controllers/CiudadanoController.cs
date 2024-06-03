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
    public class CiudadanoController : ControllerBase
    {
        private readonly CiudadanoService _CiudadanoService;
        private readonly ILogger<CiudadanoController> _logger;


        public CiudadanoController(CiudadanoService CiudadanoService, ILogger<CiudadanoController> logger)
        {
            _CiudadanoService = CiudadanoService;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<List<CiudadanoDTO>> GetAll()
        {
            _logger.LogInformation("Inicio de la solicitud HTTP GET para obtener todos los ciudadanos.");
            var startTime = DateTime.UtcNow;

            try
            {
                var ciudadanos = _CiudadanoService.GetAll();
                var endTime = DateTime.UtcNow;
                _logger.LogInformation("Solicitud HTTP GET procesada con éxito, tiempo de ejecución: {Duration}ms, retornando {Count} ciudadanos.", (endTime - startTime).TotalMilliseconds, ciudadanos.Count);

                if (ciudadanos.Count == 0)
                {
                    _logger.LogWarning("No se encontraron ciudadanos en la base de datos.");
                }

                return Ok(ciudadanos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error en la solicitud HTTP GET al obtener todos los ciudadanos");
                return StatusCode(500, "Error interno del servidor");
            }
            finally
            {
                _logger.LogInformation("Solicitud HTTP GET completada. Tiempo total de ejecución: {TotalDuration}ms.", (DateTime.UtcNow - startTime).TotalMilliseconds);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<CiudadanoDTO> Get(int id)
        {
            _logger.LogInformation("Solicitud HTTP GET recibida para obtener el ciudadano con ID: {Id}", id);
            var startTime = DateTime.UtcNow;

            try
            {
                var ciudadano = _CiudadanoService.Get(id);
                var endTime = DateTime.UtcNow;

                if (ciudadano == null)
                {
                    _logger.LogWarning("No se encontró un ciudadano con ID: {Id}", id);
                    return NotFound($"No se encontró el ciudadano con ID: {id}");
                }

                _logger.LogInformation("Ciudadano con ID: {Id} obtenido exitosamente. Tiempo de procesamiento: {Duration}ms", id, (endTime - startTime).TotalMilliseconds);
                return Ok(ciudadano);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener el ciudadano con ID: {Id}", id);
                return StatusCode(500, "Error interno del servidor");
            }
            finally
            {
                _logger.LogInformation("Solicitud HTTP GET para el ciudadano con ID: {Id} completada. Tiempo total de ejecución: {TotalTime}ms", id, (DateTime.UtcNow - startTime).TotalMilliseconds);
            }
        }

        [HttpPost]
        public ActionResult<CiudadanoDTO> Create(CiudadanoPostDTO ciudadanoPostDTO)
        {
            _logger.LogInformation("Recibida solicitud POST para crear un nuevo ciudadano con los datos recibidos: {ciudadanoPostDTO}", ciudadanoPostDTO);
            var startTime = DateTime.UtcNow;

            try
            {
                _logger.LogInformation("Verificando la existencia del ciudadano con ID: {Id}", ciudadanoPostDTO.IdCiudadano);
                if (_CiudadanoService.Get(ciudadanoPostDTO.IdCiudadano) != null)
                {
                    _logger.LogInformation("Ya existe un ciudadano con ID: {Id}, no se puede proceder con la creación.", ciudadanoPostDTO.IdCiudadano);
                    return BadRequest($"El ciudadano con ID {ciudadanoPostDTO.IdCiudadano} ya existe.");
                }

                _logger.LogInformation("No se encontró un ciudadano existente con ID: {Id}. Procediendo a agregar nuevo ciudadano.", ciudadanoPostDTO.IdCiudadano);
                _CiudadanoService.Add(ciudadanoPostDTO);
                _logger.LogInformation("Ciudadano creado exitosamente con ID: {Id}", ciudadanoPostDTO.IdCiudadano);
                return CreatedAtAction(nameof(Create), new { id = ciudadanoPostDTO.IdCiudadano }, ciudadanoPostDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al intentar crear el ciudadano con ID: {Id}", ciudadanoPostDTO.IdCiudadano);
                return StatusCode(500, "Error interno del servidor");
            }
            finally
            {
                var endTime = DateTime.UtcNow;
                _logger.LogInformation("Proceso POST para crear ciudadano completado. Duración total: {Duration}ms", (endTime - startTime).TotalMilliseconds);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, CiudadanoPostDTO ciudadanoPostDTO)
        {
            _logger.LogInformation("Recibida solicitud PUT para actualizar ciudadano con ID: {Id}", id);
            var startTime = DateTime.UtcNow;

            try
            {
                if (id != ciudadanoPostDTO.IdCiudadano)
                {
                    _logger.LogWarning("ID en la URL no coincide con ID del cuerpo del mensaje.");
                    return BadRequest($"El ID {ciudadanoPostDTO.IdCiudadano} no coincide");
                }

                _logger.LogInformation("Verificando existencia del ciudadano con ID: {Id}", id);
                var existingCiudadano = _CiudadanoService.Get(id);
                if (existingCiudadano == null)
                {
                    _logger.LogWarning("Ciudadano con ID: {Id} no encontrado.", id);
                    return NotFound($"No se ha encontrado el ciudadano con ID {ciudadanoPostDTO.IdCiudadano}");
                }

                _logger.LogInformation("Ciudadano encontrado. Procediendo a actualizar datos.");
                _CiudadanoService.Update(ciudadanoPostDTO);
                _logger.LogInformation("Ciudadano con ID: {Id} actualizado exitosamente.", id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al modificar el ciudadano con ID: {Id}", id);
                return StatusCode(500, "Internal server error");
            }
            finally
            {
                var endTime = DateTime.UtcNow;
                _logger.LogInformation("Proceso PUT completado. Duración total: {Duration}ms", (endTime - startTime).TotalMilliseconds);
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
