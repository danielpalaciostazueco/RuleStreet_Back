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



        public string GenerateToken(UsuarioDTO userDTOOut)
        {
            var key = Encoding.UTF8.GetBytes(_configuration["JWT:SecretKey"]);
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, Convert.ToString(userDTOOut.IdUsuario)),
                new Claim(ClaimTypes.Name, userDTOOut.NombreUsuario ?? ""),
                new Claim("Nombre", userDTOOut.Nombre ?? ""),
            };

     
            var properties = userDTOOut.GetType().GetProperties();

   
            foreach (var property in properties)
            {
          
                if (!claims.Any(c => c.Type == property.Name))
                {
                    var value = property.GetValue(userDTOOut, null);
                    claims.Add(new Claim(property.Name, value?.ToString() ?? ""));
                }
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _configuration["JWT:ValidIssuer"],
                Audience = _configuration["JWT:ValidAudience"],
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(7), // AddMinutes(60)
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            return tokenString;
        }
       


    }
}
