using Microsoft.Extensions.Logging;
using RuleStreet.Models;
using RuleStreet.Data;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Text.Json;
namespace RuleStreet.Business
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ICiudadanoRepository _ciudadanoRepository;

        private readonly ILogger<UsuarioService> _logger;


        public UsuarioService(IUsuarioRepository usuarioRepository, ICiudadanoRepository ciudadanoRepository, ILogger<UsuarioService> logger)
        {
            _usuarioRepository = usuarioRepository;
            _ciudadanoRepository = ciudadanoRepository;
            _logger = logger;
        }
        public List<UsuarioDTO> GetAll()
        {
            _logger.LogInformation("Obteniendo todas los usuarios.");
            try
            {
                var usuarios = _usuarioRepository.GetAll();

                List<UsuarioDTO> usuarioDTOs = new List<UsuarioDTO>();
                foreach (var usuario in usuarios)
                {
                    var ciudadano = _ciudadanoRepository.Get((int)usuario.IdCiudadano);
                    if (ciudadano == null)
                    {
                        _logger.LogError($"No se encontró ningún ciudadano con el ID: {usuario.IdCiudadano}");
                        continue; 
                    }

                    usuarioDTOs.Add(new UsuarioDTO
                    {
                        IdUsuario = usuario.IdUsuario,
                        Nombre = usuario.Nombre,
                        NombreUsuario = usuario.NombreUsuario,
                        IsPolicia = ciudadano.IsPoli,
                        Contrasena = usuario.Contrasena
                    });
                }

                _logger.LogInformation($"Retornadas {usuarioDTOs.Count} usuarios.");
                return usuarioDTOs;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener todas los usuarios.");
                throw;
            }
        }

        public Usuario? Get(int id)
        {
            _logger.LogInformation($"Buscando usuario con ID: {id}");
            try
            {
                _logger.LogInformation($"Usuario con ID: {id} encontrado.");
                return _usuarioRepository.Get(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al obtener el usaurio con ID: {id}.");
                throw;
            }
        }

        public void Add(UsuarioPostDTO usuarioDTO)
        {
            try
            {
                _logger.LogInformation($"Intentando agregar un nuevo usuario: {JsonSerializer.Serialize(usuarioDTO)}");
                CiudadanoDTO ciudadano = _ciudadanoRepository.Get(usuarioDTO.IdCiudadano);
                if (ciudadano == null)
                {
                    _logger.LogError($"No se encontró ningún ciudadano con el ID: {usuarioDTO.IdCiudadano}");
                    throw new Exception("Ciudadano no encontrado.");
                }

                var usuario = new Usuario
                {
                    IdUsuario = usuarioDTO.IdUsuario,
                    IdCiudadano = usuarioDTO.IdCiudadano,
                    Nombre = ciudadano.Nombre,
                    NombreUsuario = usuarioDTO.NombreUsuario,
                    Contrasena = usuarioDTO.Contrasena
                };
                _usuarioRepository.Add(usuario);
                _logger.LogInformation($"Usuario creado con éxito con ID {usuario.IdUsuario}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al agregar un nuevo usuario");
                throw;
            }
        }

        public void Delete(int id)
        {
            try
            {
                _logger.LogInformation($"Intentando eliminar el usuario con ID: {id}");
                _usuarioRepository.Delete(id);
                _logger.LogInformation($"Usuario con ID: {id} eliminado correctamente.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al eliminar el usuario con ID: {id}");
                throw;
            }
        }

        public void Update(Usuario usuario)
        {
            try
            {
                _logger.LogInformation($"Intentando actualizar el usuario con ID: {usuario.IdUsuario}");
                _usuarioRepository.Update(usuario);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al actualizar el usuario con ID: {usuario.IdUsuario}");
                throw;
            }
        }

    }
}
