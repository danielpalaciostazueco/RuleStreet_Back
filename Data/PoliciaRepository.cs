using Microsoft.EntityFrameworkCore;
using RuleStreet.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using RuleStreet.Data;

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
                    .ThenInclude(c => c.Multas)
                        .ThenInclude(m => m.Policia)
                .Include(p => p.Ciudadano)
                    .ThenInclude(c => c.Vehiculos)
                .ToList();

            var policiaDTOList = policiaList.Select(p => new PoliciaDTO
            {
                IdPolicia = p.IdPolicia,
                IdCiudadano = p.IdCiudadano.Value,
                Rango = p.Rango,
                Contrasena = p.Contrasena,
                NumeroPlaca = p.NumeroPlaca,
                Ciudadano = new CiudadanoDTO
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
                    Multas = p.Ciudadano.Multas.Select(m => new MultaDTO
                    {
                        IdMulta = m.IdMulta,
                        IdPolicia = m.IdPolicia,
                        Fecha = m.Fecha,
                        Precio = m.Precio,
                        IdArticuloPenal = m.IdArticuloPenal,
                        Descripcion = m.Descripcion,
                        Pagada = m.Pagada,
                        IdCiudadano = m.IdCiudadano

                    }).ToList(),
                    Vehiculos = p.Ciudadano.Vehiculos.Select(v => new VehiculoDTO
                    {
                        IdVehiculo = v.IdVehiculo,
                        Matricula = v.Matricula,
                        Marca = v.Marca,
                        Modelo = v.Modelo,
                        Color = v.Color,
                        IdCiudadano = v.IdCiudadano,
                        Ciudadano = new CiudadanoDTO
                        {
                            Nombre = v.Ciudadano.Nombre
                        }
                    }).ToList()
                }
            }).ToList();

            return policiaDTOList;
        }
        public PoliciaDTO Get(int id)
        {
            var policia = _context.Policia
                .Include(p => p.Ciudadano)
                    .ThenInclude(c => c.Multas)
                        .ThenInclude(m => m.Policia)
                .Include(p => p.Ciudadano)
                    .ThenInclude(c => c.Vehiculos)
                .AsNoTracking()
                .FirstOrDefault(p => p.IdPolicia == id);

            if (policia == null)
            {
                _logger.LogError("No Policía found with ID: {Id}", id);
                return null;
            }

            var policiaDTO = new PoliciaDTO
            {
                IdPolicia = policia.IdPolicia,
                IdCiudadano = policia.IdCiudadano.Value,
                Rango = policia.Rango,
                NumeroPlaca = policia.NumeroPlaca,
                Contrasena = policia.Contrasena,
                Ciudadano = new CiudadanoDTO
                {
                    IdCiudadano = policia.Ciudadano.IdCiudadano,
                    Nombre = policia.Ciudadano.Nombre,
                    Apellidos = policia.Ciudadano.Apellidos,
                    Dni = policia.Ciudadano.Dni,
                    Genero = policia.Ciudadano.Genero,
                    Nacionalidad = policia.Ciudadano.Nacionalidad,
                    FechaNacimiento = policia.Ciudadano.FechaNacimiento.Value,
                    Direccion = policia.Ciudadano.Direccion,
                    NumeroTelefono = policia.Ciudadano.NumeroTelefono,
                    NumeroCuentaBancaria = policia.Ciudadano.NumeroCuentaBancaria,
                    IsPoli = policia.Ciudadano.IsPoli,
                    IsBusquedaYCaptura = policia.Ciudadano.IsBusquedaYCaptura,
                    IsPeligroso = policia.Ciudadano.IsPeligroso,
                    Multas = policia.Ciudadano.Multas.Select(m => new MultaDTO
                    {
                        IdMulta = m.IdMulta,
                        IdPolicia = m.IdPolicia,
                        Fecha = m.Fecha.Value,
                        Precio = m.Precio,
                        IdArticuloPenal = m.IdArticuloPenal,
                        Descripcion = m.Descripcion,
                        Pagada = m.Pagada,
                        IdCiudadano = m.IdCiudadano
                    }).ToList(),
                    Vehiculos = policia.Ciudadano.Vehiculos.Select(v => new VehiculoDTO
                    {
                        IdVehiculo = v.IdVehiculo,
                        Matricula = v.Matricula,
                        Marca = v.Marca,
                        Modelo = v.Modelo,
                        Color = v.Color,
                        IdCiudadano = v.IdCiudadano,
                        Ciudadano = new CiudadanoDTO
                        {
                            Nombre = v.Ciudadano.Nombre
                        }
                    }).ToList()
                }
            };

            return policiaDTO;
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
