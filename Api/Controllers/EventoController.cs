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
    public class EventoController : ControllerBase
    {
        private readonly EventoService _EventoService;


        public EventoController(EventoService EventoService)
        {
            _EventoService = EventoService;
        }
        [AllowAnonymous]
        [HttpGet]
        public ActionResult<List<Evento>> GetAll()
        {
            return _EventoService.GetAll();
        }

      

        [AllowAnonymous]
        [HttpGet("{id}")]
        public ActionResult<Evento> Get(int id)
        {
            try
            {
                var Evento = _EventoService.Get(id);
                if (Evento == null)
                {
                    return NotFound();
                }

                return Evento;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error al hacer el get por id ");
                return StatusCode(500, "Error interno del servidor");
            }
        }


        [HttpPost]
        public ActionResult<Evento> Create(Evento Evento)
        {
            try
            {

                if (_EventoService.Get((int)Evento.IdEventos) != null)
                {
                    return BadRequest($"Evento con ID {Evento.IdEventos} ya existe.");
                }

                _EventoService.Add(Evento);
                return CreatedAtAction(nameof(Create), new { id = Evento.IdEventos }, Evento);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error al obtener todas las Eventos");
                return StatusCode(500, "Error interno del servidor");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Evento Evento)
        {
            try
            {
                if (id != Evento.IdEventos)
                {
                    return BadRequest();
                }

                var existingEvento = _EventoService.Get(id);
                if (existingEvento == null)
                {
                    return NotFound();
                }

                _EventoService.Update(Evento);
                return NoContent();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error al modificar la Evento por id");
                return StatusCode(ex.HResult, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var Evento = _EventoService.Get(id);
                if (Evento == null)
                {
                    return NotFound();
                }

                _EventoService.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error al eliminar la Evento por id");
                return StatusCode(500, "Error interno del servidor");
            }
        }
    }
}
