using Microsoft.AspNetCore.Mvc;
using RuleStreet.Models;
using RuleStreet.Business;
using System.Collections.Generic;
using Serilog;

namespace RuleStreet.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VehiculoController : ControllerBase
    {
        private readonly VehiculoService _VehiculoService;


        public VehiculoController(VehiculoService VehiculoService)
        {
            _VehiculoService = VehiculoService;
        }

        [HttpGet]
        public ActionResult<List<VehiculoDTO>> GetAll()
        {
            return _VehiculoService.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<VehiculoDTO> Get(int id)
        {
            try
            {
                var Vehiculo = _VehiculoService.Get(id);
                if (Vehiculo == null)
                {
                    return NotFound();
                }

                return Vehiculo;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error al hacer el get por id ");
                return StatusCode(500, "Error interno del servidor");
            }
        }


        [HttpPost]
        public ActionResult<VehiculoPostDTO> Create(VehiculoPostDTO vehiculo)
        {
            try
            {
                if (_VehiculoService.Get(vehiculo.IdVehiculo) != null)
                {
                    return BadRequest($"La multa {vehiculo.IdVehiculo} ya existe.");
                }

                _VehiculoService.Add(vehiculo);
                return Ok();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error al crear el vehiculo");
                return StatusCode(500, "Error interno del servidor");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, VehiculoPostDTO vehiculo)
        {
            try
            {
                if (id != vehiculo.IdVehiculo)
                {
                    return BadRequest();
                }

                var existingVehiculo = _VehiculoService.Get(id);
                if (existingVehiculo == null)
                {
                    return NotFound();
                }

                _VehiculoService.Update(vehiculo);
                return NoContent();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error al modificar el vehiculo por id");
                return StatusCode(500, "Error interno del servidor");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var Policia = _VehiculoService.Get(id);
                if (Policia == null)
                {
                    return NotFound();
                }

                _VehiculoService.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error al eliminar el vehiculo por id");
                return StatusCode(500, "Error interno del servidor");
            }
        }
    }
}
