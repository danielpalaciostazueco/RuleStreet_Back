using Microsoft.EntityFrameworkCore;
using RuleStreet.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using RuleStreet.Data;

namespace RuleStreet.Data
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly RuleStreetAppContext _context;
        private readonly ILogger<UsuarioRepository> _logger;


        public UsuarioRepository(RuleStreetAppContext context, ILogger<UsuarioRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public List<Usuario> GetAll()
        {
            return _context.Usuario.ToList();
        }

        public Usuario? Get(int id)
        {
            return _context.Usuario.AsNoTracking()
            .FirstOrDefault(usuario => usuario.IdUsuario == id);
        }
        public Usuario? GetByName(string nombre, string nombreUsuario, string contrasena)
        {
            return _context.Usuario.AsNoTracking()
            .FirstOrDefault(usuario => usuario.Nombre == nombre && usuario.NombreUsuario == nombreUsuario && usuario.Contrasena == contrasena);
        }


        public void Add(Usuario usuario)
        {
            _context.Usuario.Add(usuario);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var usuario = _context.Usuario.FirstOrDefault(usuario => usuario.IdUsuario == id);
            if (usuario != null)
            {
                _context.Usuario.Remove(usuario);
                _context.SaveChanges();
            }
        }


        public void Update(Usuario usuario)
        {
            _context.Usuario.Update(usuario);
            _context.SaveChanges();
        }
    }
}