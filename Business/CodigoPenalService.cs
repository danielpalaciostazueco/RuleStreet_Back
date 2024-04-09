using Microsoft.Extensions.Logging;
using RuleStreet.Models;
using RuleStreet.Data;
using System.Collections.Generic;

namespace RuleStreet.Business
{
    public class CodigoPenalService : ICodigoPenalService
    {
        private readonly ICodigoPenalRepository _codigoPenalRepository;
        private readonly ILogger<CodigoPenalService> _logger;

        public CodigoPenalService(ICodigoPenalRepository codigoPenalRepository, ILogger<CodigoPenalService> logger)
        {
            _codigoPenalRepository = codigoPenalRepository;
            _logger = logger;
        }
        public List<CodigoPenalDTO> GetAll()
        {
            try
            {
                _logger.LogInformation("Obteniendo todas los articulos del codigo penal");
                return _codigoPenalRepository.GetAll();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error obteniendo todas los articulos del codigo penal");
                throw;
            }
        }

        public CodigoPenalDTO? Get(int id)
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