using Microsoft.EntityFrameworkCore;
using RuleStreet.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using RuleStreet.Data;


namespace RuleStreet.Data
{
    public class AuditoriaRepository : IAuditoriaRepository
    {
        private readonly RuleStreetAppContext _context;
        private readonly ILogger<AuditoriaRepository> _logger;


        public AuditoriaRepository(RuleStreetAppContext context, ILogger<AuditoriaRepository> logger)
        {

            _context = context;
            _logger = logger;
        }
        public List<AuditoriaDTO> GetAll()
        {
            var auditorias = _context.Auditoria
                .Include(a => a.policia)
                .ThenInclude(p => p.Ciudadano)
                .Select(a => new AuditoriaDTO
                {
                    IdAuditoria = a.IdAuditoria,
                    Titulo = a.Titulo,
                    Descripcion = a.Descripcion,
                    Fecha = a.Fecha,
                    IdPolicia = a.IdPolicia,
                    policia = a.policia != null ? new Policia    
                    {
                        IdPolicia = a.policia.IdPolicia,
                        IdCiudadano = a.policia.IdCiudadano,
                        Rango = a.policia.Rango,
                        NumeroPlaca = a.policia.NumeroPlaca,

                    } : null
                }).ToList();

            return auditorias;
        }
        public AuditoriaDTO Get(int id)
        {
            var auditoria = _context.Auditoria
                .Include(m => m.policia)
                .FirstOrDefault(c => c.IdAuditoria == id);

            if (auditoria == null)
            {
                return null;
            }

            return new AuditoriaDTO
            {
                IdAuditoria = auditoria.IdAuditoria,
                Titulo = auditoria.Titulo,
                Descripcion = auditoria.Descripcion,
                Fecha = auditoria.Fecha,
                IdPolicia = auditoria.IdPolicia,
                policia = new Policia()
                {
                    IdPolicia = auditoria.policia.IdPolicia,
                    IdCiudadano = auditoria.policia.IdCiudadano,
                    Rango = auditoria.policia.Rango,
                    NumeroPlaca = auditoria.policia.NumeroPlaca,
                }
            };
        }

        public void Add(Auditoria auditoria)
        {
            try
            {
                _context.Auditoria.Add(auditoria);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al añadir la auditoria.");
                throw ex;
            }
        }

        public void Update(Auditoria auditoria)
        {
            try
            {
                _context.Entry(auditoria).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al añadir la auditoria.");
                throw;
            }
        }



        public void Delete(int id)
        {
            try
            {
                var auditoria = _context.Auditoria.FirstOrDefault(Auditoria => Auditoria.IdAuditoria == id);
                _context.Auditoria.Remove(auditoria);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al eliminar la auditoria.");
                throw;

            }
        }

    }
}
