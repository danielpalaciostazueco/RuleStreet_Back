using Microsoft.EntityFrameworkCore;
using RuleStreet.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using RuleStreet.Data;

namespace RuleStreet.Data
{
    public class DenunciaRepository : IDenunciaRepository
    {
        private readonly RuleStreetAppContext _context;
        private readonly ILogger<DenunciaRepository> _logger;


        public DenunciaRepository(RuleStreetAppContext context, ILogger<DenunciaRepository> logger)
        {

            _context = context;
            _logger = logger;
        }
        public List<Denuncia> GetAll()
        {
            return _context.Denuncia
                .Include(m => m.Policia)
                .Include(m => m.Ciudadano)
                .ToList();
        }

        public Denuncia Get(int id)
        {
            try
            {
                return _context.Denuncia
                    .Include(m => m.Policia)
                    .Include(m => m.Ciudadano)
                    .AsNoTracking()
                    .FirstOrDefault(Denuncia => Denuncia.IdDenuncia == id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error obteniendo la denuncia por id.");
                throw;
            }
        }

        public void Add(Denuncia denuncia)
        {
            try
            {
                _context.Denuncia.Add(denuncia);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al añadir la denuncia.");
                throw;
            }
        }


        public void Update(Denuncia denuncia)
        {
            try
            {
                _context.Entry(denuncia).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al añadir la denuncia.");
                throw;
            }
        }



        public void Delete(int id)
        {
            try
            {
                var denuncia = _context.Denuncia.FirstOrDefault(Denuncia => Denuncia.IdDenuncia == id);
                _context.Denuncia.Remove(denuncia);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al eliminar la denuncia.");
                throw;

            }
        }

    }
}
