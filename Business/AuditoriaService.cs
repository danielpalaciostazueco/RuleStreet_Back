using Microsoft.Extensions.Logging;
using RuleStreet.Models;
using RuleStreet.Data;
using System.Collections.Generic;

namespace RuleStreet.Business
{
    public class AuditoriaService : IAuditoriaService
    {
        private readonly IAuditoriaRepository _auditoriaRepository;
        private readonly ILogger<AuditoriaService> _logger;

        public AuditoriaService(IAuditoriaRepository auditoriaRepository, ILogger<AuditoriaService> logger)
        {
            _auditoriaRepository = auditoriaRepository;
            _logger = logger;
        }
        public List<Auditoria> GetAll()
        {
            try
            {
                _logger.LogInformation("Obteniendo todas las auditorias");
                return _auditoriaRepository.GetAll();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error obteniendo todas las auditorias");
                throw;
            }
        }

        public Auditoria? Get(int id)
        {
            try
            {
                return _auditoriaRepository.Get(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error obteniendo la auditoria por id");
                throw;
            }
        }


        public void Delete(int id)
        {
            try
            {
                _auditoriaRepository.Delete(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al eliminar la auditoria por ID {id}.");
                throw;
            }
        }

        public void Add(Auditoria auditoria)
        {
            try
            {
                _auditoriaRepository.Add(auditoria);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error añadiendo la auditoria");
                throw;
            }
        }
        public void Update(Auditoria auditoria)
        {
            try
            {
                _auditoriaRepository.Update(auditoria);
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "Error actualizando la auditoria por id");
                throw;
            }
        }
    }
}