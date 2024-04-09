using Microsoft.EntityFrameworkCore;
using RuleStreet.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using RuleStreet.Data;
using RuleStreet.Business;

namespace RuleStreet.Data
{
    public class CiudadanoRepository : ICiudadanoRepository
    {
        private readonly RuleStreetAppContext _context;
        private readonly ILogger<CiudadanoRepository> _logger;


        public CiudadanoRepository(RuleStreetAppContext context, ILogger<CiudadanoRepository> logger)
        {

            _context = context;
            _logger = logger;
        }

        public List<CiudadanoDTO> GetAll()
        {
            var ciudadanos = _context.Ciudadano
                .Include(c => c.Multas) 
                .Select(c => new CiudadanoDTO
                {
                    IdCiudadano = c.IdCiudadano,
                    Nombre = c.Nombre,
                    Apellidos = c.Apellidos,
                    Dni = c.Dni,
                    Genero = c.Genero,
                    Nacionalidad = c.Nacionalidad,
                    FechaNacimiento = c.FechaNacimiento,
                    Direccion = c.Direccion,
                    NumeroTelefono = c.NumeroTelefono,
                    NumeroCuentaBancaria = c.NumeroCuentaBancaria,
                    IsPoli = c.IsPoli,
                    IsBusquedaYCaptura = c.IsBusquedaYCaptura,
                    IsPeligroso = c.IsPeligroso,
                    Multas = c.Multas.Select(m => new MultaDTO
                    {
                        IdMulta = m.IdMulta,
                        IdPolicia = m.IdPolicia,
                        Fecha = m.Fecha,
                        Hora = m.Hora,
                        Precio = m.Precio,
                        ArticuloPenal = m.ArticuloPenal,
                        Descripcion = m.Descripcion,
                        Pagada = m.Pagada,
                        IdCiudadano = m.IdCiudadano
                    }).ToList()
                })
                .ToList();

            return ciudadanos;
        }

        public Ciudadano Get(int id)
        {
            try
            {
                return _context.Ciudadano.AsNoTracking().FirstOrDefault(Ciudadano => Ciudadano.IdCiudadano == id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error obteniendo Ciudadano por id.");
                throw;

            }
        }


        public void Add(Ciudadano ciudadano)
        {
            try
            {
                _context.Ciudadano.Add(ciudadano);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al añadir la Ciudadano.");
                throw;
            }
        }

        public void Update(Ciudadano ciudadano)
        {
            try
            {
                _context.Entry(ciudadano).State = EntityState.Modified;
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
                var Ciudadano = _context.Ciudadano.FirstOrDefault(Ciudadano => Ciudadano.IdCiudadano == id);
                _context.Ciudadano.Remove(Ciudadano);
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
