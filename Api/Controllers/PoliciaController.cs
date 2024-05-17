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
    public class PoliciaController : ControllerBase
    {
        private readonly PoliciaService _PoliciaService;


        public PoliciaController(PoliciaService PoliciaService)
        {
            _PoliciaService = PoliciaService;
        }

        [HttpGet]
        public ActionResult<List<PoliciaDTO>> GetAll()
        {
            return _PoliciaService.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<PoliciaDTO> Get(int id)
        {
            try
            {
                var Policia = _PoliciaService.Get(id);
                if (Policia == null)
                {
                    return NotFound();
                }

                return Policia;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error al hacer el get por id ");
                return StatusCode(500, "Error interno del servidor");
            }
        }


        [HttpPost]
        public ActionResult<PoliciaPostDTO> Create(PoliciaPostDTO Policia)
        {
            try
            {
                if (_PoliciaService.Get((int)Policia.IdPolicia) != null)
                {
                    return BadRequest($"Policia con ID {Policia.IdPolicia} ya existe.");
                }

                if(_PoliciaService.policiaDuplicado(Policia) == true){
                    return BadRequest("El ciudadano ya es policía");
                }
                else{
                    _PoliciaService.Add(Policia);
                    return CreatedAtAction(nameof(Create), new { id = Policia.IdPolicia }, Policia);
            
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error al obtener todas las Policias");
                return StatusCode(500, "Error interno del servidor");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, PoliciaPostDTO Policia)
        {
            try
            {
                if (id != Policia.IdPolicia)
                {
                    return BadRequest();
                }

                var existingPolicia = _PoliciaService.Get(id);
                if (existingPolicia == null)
                {
                    return NotFound();
                }

                _PoliciaService.Update(Policia, id);
                return NoContent();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error al modificar la Policia por id");
                return StatusCode(500, "Error interno del servidor");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var Policia = _PoliciaService.Get(id);
                if (Policia == null)
                {
                    return NotFound();
                }

                _PoliciaService.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error al eliminar la Policia por id");
                return StatusCode(500, "Error interno del servidor");
            }
        }
    }
}
