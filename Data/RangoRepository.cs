using Microsoft.EntityFrameworkCore;
using RuleStreet.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using RuleStreet.Data;


namespace RuleStreet.Data
{
    public class RangoRepository : IRangoRepository
    {
        private readonly RuleStreetAppContext _context;
        private readonly ILogger<RangoRepository> _logger;


        public RangoRepository(RuleStreetAppContext context, ILogger<RangoRepository> logger)
        {

            _context = context;
            _logger = logger;
        }
        public List<Rango> GetAll()
        {
            return _context.Rango
                           .Include(r => r.RangosPermisos)
                           .ThenInclude(rp => rp.Permiso)
                           .ToList();
        }

        public Rango Get(int id)
        {
            try
            {
                return _context.Rango
                               .AsNoTracking()
                               .Include(r => r.RangosPermisos)
                               .ThenInclude(rp => rp.Permiso)
                               .FirstOrDefault(r => r.IdRango == id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error obteniendo el Rango por id.");
                throw;
            }
        }

        public void Update(Rango rango)
        {
            try
            {
                var rangoExistente = _context.Rango.Include(r => r.RangosPermisos).FirstOrDefault(r => r.IdRango == rango.IdRango);
                if (rangoExistente != null)
                {
                    _context.Entry(rangoExistente).CurrentValues.SetValues(rango);

                    foreach (var existingRangoPermiso in rangoExistente.RangosPermisos.ToList())
                    {
                        if (!rango.RangosPermisos.Any(rp => rp.IdPermiso == existingRangoPermiso.IdPermiso))
                        {
                            _context.RangoPermiso.Remove(existingRangoPermiso);
                        }
                    }

                    foreach (var rangoPermiso in rango.RangosPermisos)
                    {
                        var existingPermiso = rangoExistente.RangosPermisos
                            .FirstOrDefault(rp => rp.IdPermiso == rangoPermiso.IdPermiso);

                        if (existingPermiso == null)
                        {
                            rangoExistente.RangosPermisos.Add(new RangoPermiso
                            {
                                IdRango = rango.IdRango,
                                IdPermiso = rangoPermiso.IdPermiso
                            });
                        }
                    }

                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al actualizar el Rango.");
                throw;
            }
        }
    }
}
