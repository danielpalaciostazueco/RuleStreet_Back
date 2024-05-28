using Microsoft.EntityFrameworkCore;
using RuleStreet.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using RuleStreet.Data;

namespace RuleStreet.Data
{
    public class CodigoPenalRepository : ICodigoPenalRepository
    {
        private readonly RuleStreetAppContext _context;
        private readonly ILogger<CodigoPenalRepository> _logger;

        public CodigoPenalRepository(RuleStreetAppContext context, ILogger<CodigoPenalRepository> logger)
        {

            _context = context;
            _logger = logger;
        }
        public List<CodigoPenalDTO> GetAll()
        {
            var codigoPenal = _context.CodigoPenal.Select(m => new CodigoPenalDTO
            {
                IdCodigoPenal = m.IdCodigoPenal,
                Articulo = m.Articulo,
                Article = m.Article,
                Descripcion = m.Descripcion,
                Description = m.Description,
                Precio = m.Precio,
                Sentencia = m.Sentencia
            }).ToList();

            return codigoPenal;
        }

        public CodigoPenal? Get(int id)
        {
            try
            {
                return _context.CodigoPenal
                .AsNoTracking()
                .FirstOrDefault(CodigoPenal => CodigoPenal.IdCodigoPenal == id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error obteniendo Ciudadano por id.");
                throw;
            }
        }


        public void Add(CodigoPenalDTO codigoPenalDTO)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            try
            {
                var codigoPenal = _context.CodigoPenal.FirstOrDefault(CodigoPenal => CodigoPenal.IdCodigoPenal == id);
                _context.CodigoPenal.Remove(codigoPenal);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al eliminar el articulo con ID {id}.");
                throw;
            }
        }

        public void Update(CodigoPenalDTO codigoPenalDTO)
        {
            throw new NotImplementedException();
        }
    }
}

