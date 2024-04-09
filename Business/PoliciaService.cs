using Microsoft.Extensions.Logging;
using RuleStreet.Models;
using RuleStreet.Data;
using System.Collections.Generic;

namespace RuleStreet.Business
{
    public class PoliciaService : IPoliciaService
    {
        private readonly IPoliciaRepository _policiaRepository;
        private readonly ILogger<PoliciaService> _logger;


        public PoliciaService(IPoliciaRepository policiaRepository, ILogger<PoliciaService> logger)
        {
            _policiaRepository = policiaRepository;
            _logger = logger;
        }

        public List<PoliciaDTO> GetAll()
        {
            try
            {
                _logger.LogInformation("Obteniendo todas las ciudadanos");
                return _policiaRepository.GetAll();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error obteniendo todas las ciudadanos");
                throw;
            }
        }
        public Policia? Get(int id)
        {
            try
            {
                return _policiaRepository.Get(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error obteniendo la ciudadano por id");
                throw;
            }

        }


        public void Update(Policia policia)
        {
            try
            {
                _policiaRepository.Update(policia);
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "Error actualizando al ciudadano por id");
                throw;
            }
        }



        public void Add(Policia policia)
        {
            try
            {
                _policiaRepository.Add(policia);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error añadiendo la ciudadano");
                throw;
            }

        }
        public void Delete(int id)
        {
            try
            {
                _policiaRepository.Delete(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error eliminando al ciudadano");
                throw;
            }

        }


    }
}
