using Microsoft.EntityFrameworkCore;
using RuleStreet.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using RuleStreet.Data;


namespace RuleStreet.Data
{
    public class PermisoRepository : IPermisoRepository
    {
        private readonly RuleStreetAppContext _context;
        private readonly ILogger<PermisoRepository> _logger;


        public PermisoRepository(RuleStreetAppContext context, ILogger<PermisoRepository> logger)
        {

            _context = context;
            _logger = logger;
        }
        public List<Permiso> GetAll()
        {
            return _context.Permiso
                .ToList();
        }


        public Permiso Get(int id)
        {
            try
            {
                return _context.Permiso

                    .AsNoTracking()
                    .FirstOrDefault(Permiso => Permiso.IdPermiso == id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error obteniendo el permiso por id.");
                throw;
            }
        }

        public void Update(Permiso permiso)
        {
            try
            {
                _context.Entry(permiso).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al añadir el permiso.");
                throw;
            }
        }


        public void Add(Permiso permiso)
        {
            try
            {
                _context.Permiso.Add(permiso);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al añadir el permiso.");
                throw;
            }
        }


        public void Delete(int id)
        {
            try
            {
                var permiso = _context.Permiso.Find(id);
                if (permiso is null)
                {
                    _logger.LogError("Error al eliminar el permiso por id.");
                    throw new Exception("Permiso no encontrado.");
                }
                _context.Permiso.Remove(permiso);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al eliminar el permiso por id.");
                throw;
            }
        }

    }
}
