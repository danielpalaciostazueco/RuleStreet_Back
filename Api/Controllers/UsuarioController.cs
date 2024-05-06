using Microsoft.AspNetCore.Mvc;
using RuleStreet.Models;
using RuleStreet.Business;
using System.Collections.Generic;
using Serilog;
using Azure.Messaging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;


namespace RuleStreet.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioService _usuarioService;
        private readonly ILogger<UsuarioController> _logger;

        public UsuarioController(UsuarioService usuarioService, ILogger<UsuarioController> logger)
        {
            _usuarioService = usuarioService;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<List<UsuarioDTO>> GetAll()
        {
            try
            {
                _logger.LogInformation("Solicitando la lista de todas los usuarios.");
                return _usuarioService.GetAll();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error obteniendo todas los usuarios.");
                return StatusCode(500, "Un error ocurrió al obtener la lista de usuarios.");
            }
        }

        [HttpGet("{id}")]
        public ActionResult<UsuarioDTO> Get(int id)
        {
            try
            {
                _logger.LogInformation($"Buscando usuario con ID: {id}");
                var usuario = _usuarioService.Get(id);

                if (usuario == null)
                {
                    _logger.LogWarning($"Usuario con ID: {id} no encontrada.");
                    return NotFound();
                }

                return usuario;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error obteniendo el usuario con ID: {id}.");
                return StatusCode(500, "Un error ocurrió al obtener el usuario.");
            }
        }

        [HttpPost]
        public IActionResult Create(UsuarioPostDTO usuarioPostDTO)
        {
            try
            {
                _logger.LogInformation($"Creando nuevo usuario con ID: {usuarioPostDTO.IdUsuario}");
                _usuarioService.Add(usuarioPostDTO);
                return CreatedAtAction(nameof(Get), new { id = usuarioPostDTO.IdUsuario }, usuarioPostDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error obteniendo al crear el usuario.");
                return StatusCode(500, "Un error ocurrió al crear el usuario.");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Usuario usuario)
        {
            try
            {
                _logger.LogInformation($"Actualizando usuario con ID: {id}");
                if (id != usuario.IdUsuario)
                {
                    _logger.LogWarning($"No se puede actualizar: Usuario con ID: {id} no encontrada.");
                    return BadRequest();
                }

                var existingUsuario = _usuarioService.Get(id);
                if (existingUsuario is null)
                    return NotFound();

                _usuarioService.Update(usuario);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al modificar el usuario con ID: {id}.");
                return StatusCode(500, "Un error ocurrió al modificar el usuario.");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _logger.LogInformation($"Eliminando usuario con ID: {id}");
                var usuario = _usuarioService.Get(id);

                if (usuario is null)
                {
                    _logger.LogWarning($"No se puede eliminar: Usuario con ID: {id} no encontrado.");
                    return NotFound();
                }

                _usuarioService.Delete(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error obteniendo al eliminar el usuario con ID: {id}.");
                return StatusCode(500, "Un error ocurrió al eliminar el usuario.");
            }
        }


        [HttpPost("Register")]
        public IActionResult AddUsuario([FromBody] UsuarioRegisterPostDTO usuarioRequest)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(usuarioRequest.Dni) || string.IsNullOrWhiteSpace(usuarioRequest.NombreUsuario) || string.IsNullOrWhiteSpace(usuarioRequest.Contrasena))
                {
                    return BadRequest("El nombre de usuario y la contraseña son obligatorios.");
                }
                var usuario = _usuarioService.GetUserWithParameters(usuarioRequest.Dni, usuarioRequest.NombreUsuario, usuarioRequest.Contrasena);
                if (usuario == null)
                {

                    return null;
                }
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error al añadir el usuario.");
                return StatusCode(500, "Error interno del servidor.");
            }
        }

    }
}