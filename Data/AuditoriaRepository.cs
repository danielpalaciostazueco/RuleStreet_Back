using Microsoft.EntityFrameworkCore;
using RuleStreet.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using RuleStreet.Data;
using RuleStreet.Business;

namespace RuleStreet.Data
{
    public class AuditoriaRepository : IAuditoriaRepository
    {
        private readonly RuleStreetAppContext _context;
        private readonly ILogger<AuditoriaRepository> _logger;


        public AuditoriaRepository(RuleStreetAppContext context, ILogger<AuditoriaRepository> logger)
        {

            _context = context;
            _logger = logger;
        }
        public List<Auditoria> GetAll()
        {
            return _context.Auditoria
                .Include(m => m.policia)
                .ToList();
        }

        public Auditoria Get(int id)
        {
            try
            {
                return _context.Auditoria
                    .Include(m => m.policia)
                    .AsNoTracking()
                    .FirstOrDefault(Auditoria => Auditoria.IdAuditoria == id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error obteniendo la auditoria por id.");
                throw;
            }
        }

        public void Add(Auditoria auditoria)
        {
            try
            {
                _context.Auditoria.Add(auditoria);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al añadir la auditoria.");
                throw;
            }
        }

        public void Update(Auditoria auditoria)
        {
            try
            {
                _context.Entry(auditoria).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al añadir la auditoria.");
                throw;
            }
        }



        public void Delete(int id)
        {
            try
            {
                var auditoria = _context.Auditoria.FirstOrDefault(Auditoria => Auditoria.IdAuditoria == id);
                _context.Auditoria.Remove(auditoria);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al eliminar la auditoria.");
                throw;

            }
        }

    }
}
