using Microsoft.AspNetCore.Mvc;
using RuleStreet.Models;
using RuleStreet.Business;
using System.Collections.Generic;
using Serilog;

namespace RuleStreet.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DenunciaController : ControllerBase
    {
        private readonly DenunciaService _DenunciaService;


        public DenunciaController(DenunciaService DenunciaService)
        {
            _DenunciaService = DenunciaService;
        }

        [HttpGet]
        public ActionResult<List<Denuncia>> GetAll()
        {
            return _DenunciaService.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<Denuncia> Get(int id)
        {
            try
            {
                var Denuncia = _DenunciaService.Get(id);
                if (Denuncia == null)
                {
                    return NotFound();
                }

                return Denuncia;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error al hacer el get por id ");
                return StatusCode(500, "Error interno del servidor");
            }
        }


        [HttpPost]
        public ActionResult<DenunciaPostDTO> Create(DenunciaPostDTO denuncia)
        {
            try
            {
                if (_DenunciaService.Get(denuncia.IdDenuncia) != null)
                {
                    return BadRequest($"La Denuncia{denuncia.IdDenuncia} ya existe.");
                }

                _DenunciaService.Add(denuncia);
                return Ok();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error al crear la multa");
                return StatusCode(500, "Error interno del servidor");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, DenunciaPostDTO denuncia)
        {
            try
            {
                if (id != denuncia.IdDenuncia)
                {
                    return BadRequest();
                }

                var existingDenuncia = _DenunciaService.Get(id);
                if (existingDenuncia == null)
                {
                    return NotFound();
                }

                _DenunciaService.Update(denuncia);
                return NoContent();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error al modificar la Denuncia por id");
                return StatusCode(500, "Error interno del servidor");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var Denuncia = _DenunciaService.Get(id);
                if (Denuncia == null)
                {
                    return NotFound();
                }

                _DenunciaService.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error al eliminar la Denuncia por id");
                return StatusCode(500, "Error interno del servidor");
            }
        }
    }
}
