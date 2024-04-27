using System.Collections.Generic;
using RuleStreet.Models;

namespace RuleStreet.Data
{
    public interface IUsuarioRepository
    {
        List<Usuario> GetAll();
        Usuario? Get(int id);
        void Add(Usuario usuario);
        void Delete(int id);
        void Update(Usuario usuario);
        Usuario? GetByName(string nombre, string nombreUsuario, string contrasena);
    }
}