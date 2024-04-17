using Microsoft.Extensions.Logging;
using RuleStreet.Models;
using RuleStreet.Data;
using System.Collections.Generic;

namespace RuleStreet.Business
{
    public class DenunciaService : IDenunciaService
    {
        private readonly IDenunciaRepository _DenunciaRepository;
        private readonly IDenunciaRepository _denunciaRepository;
        private readonly ILogger<DenunciaService> _logger;

        public DenunciaService(IDenunciaRepository denunciaRepository, ILogger<DenunciaService> logger)
        {
            _DenunciaRepository = denunciaRepository;
            _logger = logger;
        }

        public List<Denuncia> GetAll()
        {
            try
            {
                _logger.LogInformation("Obteniendo todas las denuncias");
                return _DenunciaRepository.GetAll();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error obteniendo todas las denuncias");
                throw;
            }
        }

        public Denuncia? Get(int id)
        {
            try
            {
                return _DenunciaRepository.Get(id);
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
                _DenunciaRepository.Delete(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al eliminar la auditoria por ID {id}.");
                throw;
            }
        }

        public void Add(DenunciaPostDTO denuncia)
        {
            try
            {
                var Denuncia = new Denuncia
                {
                    IdDenuncia = denuncia.IdDenuncia,
                    Titulo = denuncia.Titulo,
                    Descripcion = denuncia.Descripcion,
                    Fecha = denuncia.Fecha,
                    IdPolicia = denuncia.IdPolicia,
                    IdCiudadano = denuncia.IdCiudadano
                };

                _DenunciaRepository.Add(Denuncia);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error añadiendo la denuncia.");
                throw ex;
            }
        }
        public void Update(Denuncia denuncia)
        {
            try
            {
                _DenunciaRepository.Update(denuncia);
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "Error actualizando la denuncia por id");
                throw;
            }
        }
    }
}