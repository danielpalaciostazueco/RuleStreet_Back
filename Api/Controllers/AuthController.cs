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

                var token = _authService.Login(usuarioRequest);

                return Ok(token);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error al añadir el usuario.");
                return StatusCode(500, "Error interno del servidor.");
            }
        }

        [HttpPost("Login/Policia")]
        public IActionResult AddUsuarioPolicia([FromBody] PoliciaPostRegisterDTO policiaRequest)
        {
            try
            {
                var token = _authService.LoginPolicia(policiaRequest);

                return Ok(token);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error al añadir el policia.");
                return StatusCode(ex.HResult, "Error interno del servidor.");
            }
        }

        
        [HttpPost("Login/Ayuntamiento")]
        public IActionResult AddUsuarioAyuntamiento([FromBody] AyuntamientoPostRegisterDTO ayuntamientoRequest)
        {
            try
            {
                var token = _authService.LoginAyuntamiento(ayuntamientoRequest);

                return Ok(token);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error al añadir el ayuntamiento.");
                return StatusCode(ex.HResult, "Error interno del servidor.");
            }
        }
     


    }
}