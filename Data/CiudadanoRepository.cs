using Microsoft.EntityFrameworkCore;
using RuleStreet.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using RuleStreet.Data;


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
                    .ThenInclude(m => m.Policia)
                .Include(c => c.Vehiculos)
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
                        IdPolicia = m.Policia.IdPolicia,
                        Fecha = m.Fecha,
                        Precio = m.Precio,
                        ArticuloPenal = m.ArticuloPenal,
                        Descripcion = m.Descripcion,
                        Pagada = m.Pagada,
                        IdCiudadano = m.IdCiudadano
                    }).ToList(),
                    Vehiculos = c.Vehiculos.Select(v => new VehiculoDTO
                    {
                        IdVehiculo = v.IdVehiculo,
                        Matricula = v.Matricula,
                        Marca = v.Marca,
                        Modelo = v.Modelo,
                        Color = v.Color,
                        IdCiudadano = v.IdCiudadano
                    }).ToList()
                })
                .ToList();

            return ciudadanos;
        }




        public CiudadanoDTO Get(int id)
        {
            try
            {
                var ciudadano = _context.Ciudadano
                    .Where(c => c.IdCiudadano == id)
                    .Include(c => c.Multas)
                    .Include(c => c.Vehiculos)
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
                            Precio = m.Precio,
                            ArticuloPenal = m.ArticuloPenal,
                            Descripcion = m.Descripcion,
                            Pagada = m.Pagada,
                            IdCiudadano = m.IdCiudadano
                        }).ToList(),
                        Vehiculos = c.Vehiculos.Select(v => new VehiculoDTO
                        {
                            IdVehiculo = v.IdVehiculo,
                            IdCiudadano = v.IdCiudadano,
                            Matricula = v.Matricula,
                            Marca = v.Marca,
                            Modelo = v.Modelo,
                            Color = v.Color
                        }).ToList()
                    })
                    .AsNoTracking()
                    .FirstOrDefault();

                return ciudadano;
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
                _logger.LogError(ex, "Error al añadir el Ciudadano.");
                throw;
            }
        }

        public void Update(Ciudadano ciudadanoPostDTO)
        {
            try
            {
                    _context.Ciudadano.Update(ciudadanoPostDTO);
                    _context.SaveChanges();
                
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al actualizar el Ciudadano.");
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
