using Microsoft.EntityFrameworkCore;
using RuleStreet.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using RuleStreet.Data;

namespace RuleStreet.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly RuleStreetAppContext _context;
        private readonly ILogger<AuthRepository> _logger;


        public AuthRepository(RuleStreetAppContext context, ILogger<AuthRepository> logger)
        {

            _context = context;
            _logger = logger;
        }


        public UsuarioDTO GetUserFromCredentials(UsuarioRegisterPostDTO loginDtoIn)
        {
            var usuario = _context.Usuario.FirstOrDefault(u => u.Dni == loginDtoIn.Dni && u.NombreUsuario == loginDtoIn.NombreUsuario && u.Contrasena == loginDtoIn.Contrasena);
            var ciudadano = _context.Ciudadano.FirstOrDefault(c => c.IdCiudadano == usuario.IdCiudadano);
            if (usuario == null)
            {

                throw new KeyNotFoundException("User not found.");
            }
            else
            {
                var user = new UsuarioDTO { IdUsuario = usuario.IdUsuario, NombreUsuario = usuario.NombreUsuario, Nombre = usuario.Nombre, Contrasena = usuario.Contrasena, IdCiudadano = usuario.IdCiudadano, IsPolicia = ciudadano.IsPoli };
                return user;
            }
        }

        public PoliciaDTO GetUserFromCredentialsPolicia(PoliciaPostRegisterDTO loginDtoIn)
        {
            var usuario = _context.Policia.FirstOrDefault(u => u.NumeroPlaca == loginDtoIn.NumeroPlaca && u.Contrasena == loginDtoIn.Contrasena);
            var ciudadano = _context.Ciudadano.FirstOrDefault(c => c.IdCiudadano == usuario.IdCiudadano);
            if (usuario == null)
            {

                throw new KeyNotFoundException("User not found.");
            }
            else
            {
                var user = new PoliciaDTO { IdPolicia = usuario.IdPolicia, NumeroPlaca = usuario.NumeroPlaca, Contrasena = usuario.Contrasena, IdCiudadano = usuario.IdCiudadano.Value, IsPolicia = (bool)ciudadano.IsPoli, Rango = usuario.Rango };
                return user;
            }
        }
    }
}

