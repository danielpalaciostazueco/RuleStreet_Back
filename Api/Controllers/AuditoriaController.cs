using Microsoft.AspNetCore.Mvc;
using RuleStreet.Models;
using RuleStreet.Business;
using System.Collections.Generic;
using Serilog;

namespace RuleStreet.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuditoriaController : ControllerBase
    {
        private readonly AuditoriaService _AuditoriaService;


        public AuditoriaController(AuditoriaService AuditoriaService)
        {
            _AuditoriaService = AuditoriaService;
        }

        [HttpGet]
        public ActionResult<List<AuditoriaDTO>> GetAll()
        {
            return _AuditoriaService.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<AuditoriaDTO> Get(int id)
        {
            try
            {
                var Auditoria = _AuditoriaService.Get(id);
                if (Auditoria == null)
                {
                    return NotFound();
                }

                return Auditoria;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error al hacer el get por id ");
                return StatusCode(500, "Error interno del servidor");
            }
        }


        [HttpPost]
        public ActionResult<AuditoriaPostDTO> Create(AuditoriaPostDTO auditoria)
        {
            try
            {
                if (_AuditoriaService.Get(auditoria.IdAuditoria) != null)
                {
                    return BadRequest($"Ciudadano con ID {auditoria.IdAuditoria} ya existe.");
                }

                _AuditoriaService.Add(auditoria);
                return CreatedAtAction(nameof(Create), new { id = auditoria.IdAuditoria }, auditoria);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error al obtener todas las auditorias");
                return StatusCode(500, "Error interno del servidor");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Auditoria auditoria)
        {
            try
            {
                if (id != auditoria.IdAuditoria)
                {
                    return BadRequest();
                }

                var existingAuditoria = _AuditoriaService.Get(id);
                if (existingAuditoria == null)
                {
                    return NotFound();
                }

                _AuditoriaService.Update(auditoria);
                return NoContent();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error al modificar la auditoria por id");
                return StatusCode(500, "Error interno del servidor");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var Auditoria = _AuditoriaService.Get(id);
                if ( Auditoria == null)
                {
                    return NotFound();
                }

                _AuditoriaService.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error al eliminar la auditoria por id");
                return StatusCode(500, "Error interno del servidor");
            }
        }
    }
}
