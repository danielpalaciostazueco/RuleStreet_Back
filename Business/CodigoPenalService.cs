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

     
        public CodigoPenal? Get(int id)
        {
            try
            {
                return _codigoPenalRepository.Get(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error obteniendo la ciudadano por id");
                throw;
            }
        }




        public void Delete(int id)
        {
            try
            {
                _codigoPenalRepository.Delete(id);
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