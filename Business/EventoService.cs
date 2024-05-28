using Microsoft.Extensions.Logging;
using RuleStreet.Models;
using RuleStreet.Data;
using System.Collections.Generic;

namespace RuleStreet.Business
{
    public class EventoService : IEventoService
    {
       private readonly IEventoRepository _eventoRepository;
        private readonly ILogger<EventoService> _logger;


        public EventoService(IEventoRepository eventoRepository, ILogger<EventoService> logger)
        {
            _eventoRepository = eventoRepository;
            _logger = logger;
        }


        public List<Evento> GetAll()
        {
            try
            {
                _logger.LogInformation("Obteniendo todas las eventos");
                return _eventoRepository.GetAll();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error obteniendo todas las eventos");
                throw;
            }
        }

        
       

        public Evento? Get(int id)
        {
            try
            {
                return _eventoRepository.Get(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error obteniendo la eventos por id");
                throw;
            }

        }
        


        public void Update(Evento evento)
        {
            try
            {
                _eventoRepository.Update(evento);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error actualizando al eventos por id");
                throw;
            }
        }
       

        public void Add(Evento evento)
        {
            try
            {
                _eventoRepository.Add(evento);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error añadiendo la eventos");
                throw;
            }

        }
        

        public void Delete(int id)
        {
            try
            {
                _eventoRepository.Delete(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error eliminando al eventos");
                throw;
            }

        }


    }
}
