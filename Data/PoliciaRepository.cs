using Microsoft.EntityFrameworkCore;
using RuleStreet.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using RuleStreet.Data;
using RuleStreet.Business;

namespace RuleStreet.Data
{
    public class PoliciaRepository : IPoliciaRepository
    {
        private readonly RuleStreetAppContext _context;
        private readonly ILogger<PoliciaRepository> _logger;


        public PoliciaRepository(RuleStreetAppContext context, ILogger<PoliciaRepository> logger)
        {

            _context = context;
            _logger = logger;
        }

        public List<PoliciaDTO> GetAll()
        {
            var policiaList = _context.Policia
                .Include(p => p.Ciudadano)
                .ToList();

            var policiaDTOList = policiaList.Select(p => new PoliciaDTO
            {
                IdPolicia = p.IdPolicia,
                IdCiudadano = p.IdCiudadano,
                Rango = p.Rango,
                NumeroPlaca = p.NumeroPlaca,
                ciudadano = new Ciudadano
                {
                    IdCiudadano = p.Ciudadano.IdCiudadano,
                    Nombre = p.Ciudadano.Nombre,
                    Apellidos = p.Ciudadano.Apellidos,
                    Dni = p.Ciudadano.Dni,
                    Genero = p.Ciudadano.Genero,
                    Nacionalidad = p.Ciudadano.Nacionalidad,
                    FechaNacimiento = p.Ciudadano.FechaNacimiento,
                    Direccion = p.Ciudadano.Direccion,
                    NumeroTelefono = p.Ciudadano.NumeroTelefono,
                    NumeroCuentaBancaria = p.Ciudadano.NumeroCuentaBancaria,
                    IsPoli = p.Ciudadano.IsPoli,
                    IsBusquedaYCaptura = p.Ciudadano.IsBusquedaYCaptura,
                    IsPeligroso = p.Ciudadano.IsPeligroso,
                }
            }).ToList();

            return policiaDTOList;
        }


        public Policia Get(int id)
        {
            try
            {
                return _context.Policia.AsNoTracking().FirstOrDefault(Policia => Policia.IdPolicia == id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error obteniendo Ciudadano por id.");
                throw;

            }
        }


        public void Add(Policia policia)
        {
            try
            {
                _context.Policia.Add(policia);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al añadir la Ciudadano.");
                throw;
            }
        }

        public void Update(Policia policia)
        {
            try
            {
                _context.Entry(policia).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al añadir la Ciudadano.");
                throw;
            }
        }


        public void Delete(int id)
        {
            try
            {
                var policia = _context.Policia.FirstOrDefault(Policia => Policia.IdPolicia == id);
                _context.Policia.Remove(policia);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al eliminar la Ciudadano.");
                throw;

            }
        }

    }
}
