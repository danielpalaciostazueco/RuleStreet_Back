using System.Collections.Generic;
using RuleStreet.Models;

namespace RuleStreet.Business
{
    public interface IUsuarioService
    {
        List<UsuarioDTO> GetAll();
        UsuarioDTO? Get(int id);
        void Add(UsuarioPostDTO usuarioDTO);
        void Delete(int id);
        void Update(Usuario usuario);
        UsuarioDTO? GetByName(string nombre, string nombreUsuario, string contrasena);
    }
}