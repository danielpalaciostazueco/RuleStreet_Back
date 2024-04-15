using Microsoft.Extensions.Logging;
using RuleStreet.Models;
using RuleStreet.Data;
using System.Collections.Generic;

namespace RuleStreet.Business
{
    public class MultaService : IMultaService
    {
        private readonly IMultaRepository _multaRepository;
        private readonly ILogger<MultaService> _logger;


        public MultaService(IMultaRepository multaRepository, ILogger<MultaService> logger)
        {
            _multaRepository = multaRepository;
            _logger = logger;
        }

        public List<Multa> GetAll()
        {
            try
            {
                _logger.LogInformation("Obteniendo todas las multas");
                return _multaRepository.GetAll();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error obteniendo todas las multas");
                throw;
            }
        }
        public Multa? Get(int id)
        {
            try
            {
                return _multaRepository.Get(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error obteniendo las multas por id");
                throw;
            }

        }


        public void Update(Multa multa)
        {
            try
            {
                _multaRepository.Update(multa);
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "Error actualizando la multa por id");
                throw;
            }
        }



        public void Add(MultaDTO multa)
        {
            try
            {
                var Multa = new Multa
                {
                    IdMulta = multa.IdMulta,
                    IdPolicia = (int)multa.IdPolicia,
                    Fecha = multa.Fecha,
                    Precio = multa.Precio,
                    ArticuloPenal = multa.ArticuloPenal,
                    Descripcion = multa.Descripcion,
                    Pagada = multa.Pagada,
                    IdCiudadano = multa.IdCiudadano
                };
                _multaRepository.Add(Multa);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error añadiendo la multa");
                throw;
            }

        }
        public void Delete(int id)
        {
            try
            {
                _multaRepository.Delete(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error eliminando la multa");
                throw;
            }

        }


    }
}
