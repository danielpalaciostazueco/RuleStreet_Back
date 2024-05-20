using Microsoft.EntityFrameworkCore;
using RuleStreet.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using RuleStreet.Data;


namespace RuleStreet.Data
{
    public class NotaRepository : INotaRepository
    {
        private readonly RuleStreetAppContext _context;
        private readonly ILogger<NotaRepository> _logger;


        public NotaRepository(RuleStreetAppContext context, ILogger<NotaRepository> logger)
        {

            _context = context;
            _logger = logger;
        }
        public List<Nota> GetAll()
        {
            return _context.Nota.Select(p => new Nota
            {
                IdNota = p.IdNota,
                Titulo = p.Titulo,
                Descripcion = p.Descripcion,
                Fecha = p.Fecha,
                ciudadano = p.ciudadano,
                policia = p.policia
            })
            .Include(p => p.ciudadano)
            .Include(p => p.policia)
            .ToList();
        }
        public List<Nota> GetAllIdioma()
        {
            return _context.Nota.Select(p => new Nota
            {
                IdNota = p.IdNota,
                Title = p.Title,
                Description = p.Description,
                Fecha = p.Fecha,
                ciudadano = p.ciudadano,
                policia = p.policia
            })
            .Include(p => p.ciudadano)
            .Include(p => p.policia)
            .ToList();
        }

        public Nota GetIdioma(int id)
        {
            try
            {
                return _context.Nota.Select(p => new Nota{
                    IdNota = p.IdNota,
                    Title = p.Title,
                    Description = p.Description,
                    Fecha = p.Fecha,
                    ciudadano = p.ciudadano,
                    policia = p.policia
                })
                    .Include(p => p.ciudadano)
                    .Include(p => p.policia)
                    .AsNoTracking()
                    .FirstOrDefault(Nota => Nota.IdNota == id);
                }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error obteniendo el Nota por id.");
                throw;
            }
        }


        public Nota Get(int id)
        {
            try
            {
                return _context.Nota.Select(p => new Nota{
                    IdNota = p.IdNota,
                    Titulo = p.Titulo,
                    Descripcion = p.Descripcion,
                    Fecha = p.Fecha,
                    ciudadano = p.ciudadano,
                    policia = p.policia
                })
                    .Include(p => p.ciudadano)
                    .Include(p => p.policia)
                    .AsNoTracking()
                    .FirstOrDefault(Nota => Nota.IdNota == id);
                }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error obteniendo el Nota por id.");
                throw;
            }
        }

        public void Update(Nota nota)
        {
            try
            {
                _context.Entry(nota).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al añadir el nota.");
                throw;
            }
        }


        public void Add(Nota nota)
        {
            try
            {
                _context.Nota.Add(nota);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al añadir el nota.");
                throw;
            }
        }


        public void Delete(int id)
        {
            try
            {
                var Nota = _context.Nota.Find(id);
                if (Nota is null)
                {
                    _logger.LogError("Error al eliminar el Nota por id.");
                    throw new Exception("Nota no encontrada.");
                }
                _context.Nota.Remove(Nota);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al eliminar el Notapor id.");
                throw;
            }
        }

    }
}
