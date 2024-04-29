using Microsoft.EntityFrameworkCore;
using RuleStreet.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using RuleStreet.Data;

namespace RuleStreet.Data
{
    public class MultaRepository : IMultaRepository
    {
        private readonly RuleStreetAppContext _context;
        private readonly ILogger<MultaRepository> _logger;


        public MultaRepository(RuleStreetAppContext context, ILogger<MultaRepository> logger)
        {

            _context = context;
            _logger = logger;
        }
        public List<Multa> GetAll()
        {
            return _context.Multa
                .Include(m => m.Policia)
                    .ThenInclude(p => p.Ciudadano)
                .Include(m => m.Ciudadano)
                .ToList();
        }

        public Multa Get(int id)
        {
            try
            {
                return _context.Multa
                    .Include(m => m.Policia)
                    .Include(m => m.Ciudadano)
                    .AsNoTracking()
                    .FirstOrDefault(Multa => Multa.IdMulta == id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error obteniendo la multa por id.");
                throw;
            }
        }

        public void Add(Multa multa)
        {
            try
            {
                _context.Multa.Add(multa);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al añadir la multa.");
                throw;
            }
        }

        public void Update(Multa multa)
        {
            try
            {
                _context.Entry(multa).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al añadir la multa.");
                throw;
            }
        }



        public void Delete(int id)
        {
            try
            {
                var multa = _context.Multa.FirstOrDefault(Multa => Multa.IdMulta == id);
                _context.Multa.Remove(multa);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al eliminar la multa.");
                throw;

            }
        }

    }
}
