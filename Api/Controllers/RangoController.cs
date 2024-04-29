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
        private readonly RangoService _RangoService;


        public RangoController(RangoService RangoService)
        {
            _RangoService = RangoService;
        }

        [HttpGet]
        public ActionResult<List<Rango>> GetAll()
        {
            return _RangoService.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<Rango> Get(int id)
        {
            try
            {
                var Rango = _RangoService.Get(id);
                if (Rango == null)
                {
                    return NotFound();
                }

                return Rango;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error al hacer el get por id ");
                return StatusCode(500, "Error interno del servidor");
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

                var existingRango = _RangoService.Get(id);
                if (existingRango == null)
                {
                    return NotFound();
                }

                _RangoService.Update(rango);
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
