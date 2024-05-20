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
            var codigoPenal = _context.CodigoPenal
            .Select(c => new CodigoPenalDTO
            {
                IdCodigoPenal = c.IdCodigoPenal,
                Articulo = c.Articulo,
                Descripcion = c.Descripcion,
                Precio = c.Precio,
                Sentencia = c.Sentencia
            }).ToList();

            return codigoPenal;
        }
          public List<CodigoPenalDTO> GetAllIdioma()
        {
            var codigoPenal = _context.CodigoPenal
            .Select(c => new CodigoPenalDTO
            {
                IdCodigoPenal = c.IdCodigoPenal,
                Article = c.Article,
                Description = c.Description,
                Precio = c.Precio,
                Sentencia = c.Sentencia
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

           public CodigoPenal? GetIdioma(int id)
        {
            try
            {
                var codigoPenal = _context.CodigoPenal
                .AsNoTracking()
                .FirstOrDefault(CodigoPenal => CodigoPenal.IdCodigoPenal == id);
                
                return new CodigoPenal
                {
                    IdCodigoPenal = codigoPenal.IdCodigoPenal,
                    Article = codigoPenal.Article,
                    Description = codigoPenal.Description,
                    Precio = codigoPenal.Precio,
                    Sentencia = codigoPenal.Sentencia
                };

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

