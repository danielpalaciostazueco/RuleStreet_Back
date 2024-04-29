using Microsoft.AspNetCore.Mvc;
using RuleStreet.Models;
using RuleStreet.Business;
using System.Collections.Generic;
using Serilog;
using Azure.Messaging;

namespace RuleStreet.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;
        private readonly UsuarioService _usuarioService;
        private readonly CiudadanoService _ciudadanoService;
        private readonly ILogger<AuthController> _logger;

        public object Get { get; private set; }

        public AuthController(AuthService authService, ILogger<AuthController> logger, UsuarioService usuarioService, CiudadanoService ciudadanoService)
        {
            _authService = authService;
            _logger = logger;
            _usuarioService = usuarioService;
            _ciudadanoService = ciudadanoService;
        }

      

        [HttpPost("Register")]
        public IActionResult Create(UsuarioPostDTO usuarioPostDTO)
        {
            try
            {
                 _usuarioService.Add(usuarioPostDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error obteniendo al crear el usuario.");
                return StatusCode(500, "Un error ocurrió al crear el usuario.");
            }
        }

       


        [HttpPost("Login")]
        public IActionResult AddUsuario([FromBody] UsuarioRegisterPostDTO usuarioRequest)
        {
            try
            {
                /*if (string.IsNullOrWhiteSpace(usuarioRequest.Nombre) || string.IsNullOrWhiteSpace(usuarioRequest.NombreUsuario) || string.IsNullOrWhiteSpace(usuarioRequest.Contrasena))
                {
                    return BadRequest("El nombre de usuario y la contraseña son obligatorios.");
                }
                var usuario = _usuarioService.GetByName(usuarioRequest.Nombre, usuarioRequest.NombreUsuario, usuarioRequest.Contrasena);
                if (usuario == null)
                {

                    return null;
                }*/
            
               
                var token = _authService.Login(usuarioRequest);

                return Ok(token);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error al añadir el usuario.");
                return StatusCode(500, "Error interno del servidor.");
            }
        }

    }
}