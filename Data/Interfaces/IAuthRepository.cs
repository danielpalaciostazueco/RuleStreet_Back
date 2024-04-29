using System.Collections.Generic;
using RuleStreet.Models;

namespace RuleStreet.Data
{
    public interface IAuthRepository
    {
      
        UsuarioDTO GetUserFromCredentials(UsuarioRegisterPostDTO loginDtoIn);
    }
}