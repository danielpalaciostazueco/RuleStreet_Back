using System.IdentityModel.Tokens.Jwt;
using System.Runtime.Serialization;
using System.Security.Claims;
using System.Text;
using RuleStreet.Data;
using RuleStreet.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RuleStreet.Business;
using Microsoft.IdentityModel.JsonWebTokens;

namespace RuleStreet.Business
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        private readonly IAuthRepository _repository;
        private readonly ICiudadanoRepository _ciudadanoRepository;

        public AuthService(IConfiguration configuration, IAuthRepository repository, ICiudadanoRepository ciudadanoRepository)
        {
            _configuration = configuration;
            _repository = repository;
            _ciudadanoRepository = ciudadanoRepository;
        }

        public string Login(UsuarioRegisterPostDTO loginDtoIn)
        {

            var user = _repository.GetUserFromCredentials(loginDtoIn);
            return GenerateToken(user);
        }

        public string LoginPolicia(PoliciaPostRegisterDTO policiaPostDTO)
        {
            var policia = _repository.GetUserFromCredentialsPolicia(policiaPostDTO);
            return GenerateTokenPolicia(policia);
        }

         public string LoginAyuntamiento(AyuntamientoPostRegisterDTO ayuntamientoPostDTO)
        {
            var ayuntamiento = _repository.GetUserFromCredentialsAyuntamiento(ayuntamientoPostDTO);
            return GenerateTokenAyuntamiento(ayuntamiento);
        }






        public string GenerateToken(UsuarioDTO policiaDTOOut)
        {
            var key = Encoding.UTF8.GetBytes(_configuration["JWT:SecretKey"]);
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, Convert.ToString(policiaDTOOut.IdUsuario)),
                new Claim(ClaimTypes.Name, policiaDTOOut.NombreUsuario ?? ""),
                new Claim("Nombre", policiaDTOOut.Nombre ?? ""),
            };


            var properties = policiaDTOOut.GetType().GetProperties();


            foreach (var property in properties)
            {

                if (!claims.Any(c => c.Type == property.Name))
                {
                    var value = property.GetValue(policiaDTOOut, null);
                    claims.Add(new Claim(property.Name, value?.ToString() ?? ""));
                }
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _configuration["JWT:ValidIssuer"],
                Audience = _configuration["JWT:ValidAudience"],
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(7), 
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            return tokenString;
        }

        public string GenerateTokenPolicia(PoliciaDTO policiaDTOOut)
        {
            var key = Encoding.UTF8.GetBytes(_configuration["JWT:SecretKey"]);
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, Convert.ToString(policiaDTOOut.IdPolicia)),

            };


            var properties = policiaDTOOut.GetType().GetProperties();


            foreach (var property in properties)
            {

                if (!claims.Any(c => c.Type == property.Name))
                {
                    var value = property.GetValue(policiaDTOOut, null);
                    claims.Add(new Claim(property.Name, value?.ToString() ?? ""));
                }
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _configuration["JWT:ValidIssuer"],
                Audience = _configuration["JWT:ValidAudience"],
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            return tokenString;
        }



         public string GenerateTokenAyuntamiento(Ayuntamiento ayuntamiento)
        {
            var key = Encoding.UTF8.GetBytes(_configuration["JWT:SecretKey"]);
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, Convert.ToString(ayuntamiento.IdUsuarioAyuntamiento)),

            };


            var properties = ayuntamiento.GetType().GetProperties();


            foreach (var property in properties)
            {

                if (!claims.Any(c => c.Type == property.Name))
                {
                    var value = property.GetValue(ayuntamiento, null);
                    claims.Add(new Claim(property.Name, value?.ToString() ?? ""));
                }
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _configuration["JWT:ValidIssuer"],
                Audience = _configuration["JWT:ValidAudience"],
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            return tokenString;
        }
    }
}