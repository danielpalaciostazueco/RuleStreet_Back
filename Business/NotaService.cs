using Microsoft.Extensions.Logging;
using RuleStreet.Models;
using RuleStreet.Data;
using System.Collections.Generic;

namespace RuleStreet.Business
{
    public class NotaService : INotaService
    {
        private readonly INotaRepository _notaRepository;
        private readonly ILogger<NotaService> _logger;


        public NotaService(INotaRepository notaRepository, ILogger<NotaService> logger)
        {
            _notaRepository = notaRepository;
            _logger = logger;
        }

        public List<Nota> GetAll()
        {
            try
            {
                _logger.LogInformation("Obteniendo todas las notas");
                return _notaRepository.GetAll();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error obteniendo todas las notas");
                throw;
            }
        }
        public Nota? Get(int id)
        {
            try
            {
                return _notaRepository.Get(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error obteniendo las notas por id");
                throw;
            }

        }


        public void Update(NotaPostDTO nota)
        {
            try
            {
                 var Nota = new Nota
                {
                    Titulo = nota.Titulo,
                    Descripcion = nota.Descripcion,
                    Fecha = nota.Fecha,
                    IdPolicia = nota.IdPolicia,
                    IdCiudadano = nota.IdCiudadano
                };
                _notaRepository.Update(Nota);
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "Error actualizando la nota por id");
                throw;
            }
        }


        public void Delete(int id)
        {
            try
            {
                _notaRepository.Delete(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error eliminando la nota por id");
                throw;
            }
        }

        public void Add(NotaPostDTO nota)
        {
            try
            {
                var Nota = new Nota
                {
                    Titulo = nota.Titulo,
                    Descripcion = nota.Descripcion,
                    Fecha = nota.Fecha,
                    IdPolicia = nota.IdPolicia,
                    IdCiudadano = nota.IdCiudadano
                };
                _notaRepository.Add(Nota);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error añadiendo la nota");
                throw;
            }
        }
    }
}
