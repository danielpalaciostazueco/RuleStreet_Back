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
        public PoliciaDTO? Get(int id)
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


        public void Update(PoliciaPostDTO policia)
        {
            try
            {
                   var Policia = new Policia()
            {
                IdPolicia = (int)policia.IdPolicia,
                IdCiudadano = (int)policia.IdCiudadano,
                Rango = policia.Rango,
                NumeroPlaca = policia.NumeroPlaca
            };
                _policiaRepository.Update(Policia);
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "Error actualizando al ciudadano por id");
                throw;
            }
        }



        public void Add(PoliciaPostDTO policia)
        {

            var Policia = new Policia()
            {
                IdPolicia = (int)policia.IdPolicia,
                IdCiudadano = (int)policia.IdCiudadano,
                Rango = policia.Rango,
                NumeroPlaca = policia.NumeroPlaca
            };
            try
            {
                _policiaRepository.Add(Policia);
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
