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
    public class MultaController : ControllerBase
    {
        private readonly MultaService _MultaService;


        public MultaController(MultaService MultaService)
        {
            _MultaService = MultaService;
        }

        [HttpGet]
        public ActionResult<List<MultaDTO>> GetAll()
        {
            return _MultaService.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<MultaDTO> Get(int id)
        {
            try
            {
                var Multa = _MultaService.Get(id);
                if (Multa == null)
                {
                    return NotFound();
                }

                return Multa;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error al hacer el get por id ");
                return StatusCode(500, "Error interno del servidor");
            }
        }


        [HttpPost]
        public ActionResult<MultaDTO> Create(MultaPostDTO multa)
        {
            try
            {
                if (_MultaService.Get(multa.IdMulta) != null)
                {
                    return BadRequest($"La multa {multa.IdMulta} ya existe.");
                }

                _MultaService.Add(multa);
                return Ok();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error al crear la multa");
                return StatusCode(500, "Error interno del servidor");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, MultaPostDTO multa)
        {
            try
            {
                if (id != multa.IdMulta)
                {
                    return BadRequest();
                }

                var existingMulta = _MultaService.Get(id);
                if (existingMulta == null)
                {
                    return NotFound();
                }

                _MultaService.Update(multa, id);
                return NoContent();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error al modificar la multa por id");
                return StatusCode(500, "Error interno del servidor");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var Policia = _MultaService.Get(id);
                if (Policia == null)
                {
                    return NotFound();
                }

                _MultaService.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error al eliminar la multa por id");
                return StatusCode(500, "Error interno del servidor");
            }
        }
    }
}
