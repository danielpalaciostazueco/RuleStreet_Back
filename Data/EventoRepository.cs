using Microsoft.EntityFrameworkCore;
using RuleStreet.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using RuleStreet.Data;

namespace RuleStreet.Data
{
    public class EventoRepository : IEventoRepository
    {
        private readonly RuleStreetAppContext _context;
        private readonly ILogger<EventoRepository> _logger;


        public EventoRepository(RuleStreetAppContext context, ILogger<EventoRepository> logger)
        {

            _context = context;
            _logger = logger;
        }
        public List<Evento> GetAll()
        {
            return _context.Evento
                .ToList();
        }

      
        public Evento Get(int id)
        {
            try
            {
                return _context.Evento
            .FirstOrDefault(Evento => Evento.IdEventos == id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error obteniendo la Evento por id.");
                throw;
            }
        }


        public void Add(Evento Evento)
        {
            try
            {
                _context.Evento.Add(Evento);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al añadir la Evento.");
                throw;
            }
        }

        public void Update(Evento evento)
        {
            try
            {
                var existingEvento = _context.Evento.FirstOrDefault(e => e.IdEventos == evento.IdEventos);
                if (existingEvento != null)
                {
                    // Actualiza directamente las propiedades del objeto existente
                    existingEvento.Imagen = evento.Imagen;
                    existingEvento.Descripcion = evento.Descripcion;
                    existingEvento.Description = evento.Description;
                    existingEvento.Fecha = evento.Fecha;

                    _context.SaveChanges();
                }
                else
                {
                    throw new Exception("Evento no encontrado");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error actualizando el evento.");
                throw;
            }
        }


        public void Delete(int id)
        {
            try
            {
                var Evento = _context.Evento.FirstOrDefault(Evento => Evento.IdEventos == id);
                _context.Evento.Remove(Evento);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al eliminar la Evento.");
                throw;

            }
        }

    }
}
