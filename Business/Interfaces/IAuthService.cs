using System.Collections.Generic;
using System.Security.Claims;
using RuleStreet.Models;

namespace RuleStreet.Business
{
    public interface IAuthService
    {
        string Login(UsuarioRegisterPostDTO loginDtoIn);
        string GenerateToken(UsuarioDTO userDTOOut);
        string LoginPolicia(PoliciaPostRegisterDTO policiaPostDTO);
        string GenerateTokenPolicia(PoliciaDTO policiaDTOOut);
        string LoginAyuntamiento(AyuntamientoPostRegisterDTO ayuntamientoPostDTO);
        string GenerateTokenAyuntamiento(Ayuntamiento ayuntamientoDTOOut);


    }
}