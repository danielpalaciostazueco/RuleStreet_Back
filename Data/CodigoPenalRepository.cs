using Microsoft.EntityFrameworkCore;
using RuleStreet.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using RuleStreet.Data;
using RuleStreet.Business;

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

        public CodigoPenalDTO? Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Add(CodigoPenalDTO codigoPenalDTO)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(CodigoPenalDTO codigoPenalDTO)
        {
            throw new NotImplementedException();
        }
    }
}

