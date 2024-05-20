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
    public class NotaController : ControllerBase
    {
        private readonly NotaService _NotaService;


        public NotaController(NotaService NotaService)
        {
            _NotaService = NotaService;
        }

        [HttpGet]
        public ActionResult<List<Nota>> GetAll()
        {
            return _NotaService.GetAll();
        }
        
        [HttpGet("English")]
        public ActionResult<List<Nota>> GetAllIdioma()
        {
            return _NotaService.GetAllIdioma();
        }


        [HttpGet("{id}")]
        public ActionResult<Nota> Get(int id)
        {
            try
            {
                var Nota = _NotaService.Get(id);
                if (Nota == null)
                {
                    return NotFound();
                }

                return Nota;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error al hacer el get por id ");
                return StatusCode(500, "Error interno del servidor");
            }
        }

        

        [HttpGet("English/{id}")]
        public ActionResult<Nota> GetIdioma(int id)
        {
            try
            {
                var Nota = _NotaService.GetIdioma(id);
                if (Nota == null)
                {
                    return NotFound();
                }

                return Nota;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error al hacer el get por id ");
                return StatusCode(500, "Error interno del servidor");
            }
        }



        [HttpPost]
        public ActionResult<NotaPostDTO> Create(NotaPostDTO Nota)
        {
            try
            {
                if (_NotaService.Get(Nota.IdNota) != null)
                {
                    return BadRequest($"La Nota{Nota.IdNota} ya existe.");
                }

                _NotaService.Add(Nota);
                return Ok();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error al crear la nota");
                return StatusCode(500, "Error interno del servidor");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, NotaPostDTO Nota)
        {
            try
            {
                if (id != Nota.IdNota)
                {
                    return BadRequest();
                }

                var existingNota = _NotaService.Get(id);
                if (existingNota == null)
                {
                    return NotFound();
                }

                _NotaService.Update(Nota);
                return NoContent();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error al modificar la Nota por id");
                return StatusCode(500, "Error interno del servidor");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var Nota = _NotaService.Get(id);
                if (Nota == null)
                {
                    return NotFound();
                }

                _NotaService.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error al eliminar la Nota por id");
                return StatusCode(500, "Error interno del servidor");
            }
        }
    }
}
