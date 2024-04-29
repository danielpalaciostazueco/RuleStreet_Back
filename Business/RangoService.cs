using Microsoft.Extensions.Logging;
using RuleStreet.Models;
using RuleStreet.Data;
using System.Collections.Generic;

namespace RuleStreet.Business
{
    public class RangoService : IRangoService
    {
        private readonly IRangoRepository _rangoRepository;
        private readonly ILogger<RangoService> _logger;


        public RangoService(IRangoRepository rangoRepository, ILogger<RangoService> logger)
        {
            _rangoRepository = rangoRepository;
            _logger = logger;
        }

        public List<Rango> GetAll()
        {
            try
            {
                _logger.LogInformation("Obteniendo todas los rangos");
                return _rangoRepository.GetAll();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error obteniendo todas los Rangos");
                throw;
            }
        }
        public Rango? Get(int id)
        {
            try
            {
                return _rangoRepository.Get(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error obteniendo los Rangos por id");
                throw;
            }

        }


        public void Update(Rango Rango)
        {
            try
            {
                _rangoRepository.Update(Rango);
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "Error actualizando el rango por id");
                throw;
            }
        }
    }
}
