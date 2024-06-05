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
            .ThenInclude(m => m.CodigoPenal)
            .Include(p => p.Ciudadano)
            .ThenInclude(c => c.Vehiculos)
            .Include(p => p.Rango)
            .ThenInclude(r => r.RangosPermisos)
            .ThenInclude(rp => rp.Permiso)
            .ToList();


            var policiaDTOList = policiaList.Select(p => new PoliciaDTO
            {
                IdPolicia = p.IdPolicia,
                IdCiudadano = p.IdCiudadano.Value,
                Rango = p.Rango != null ? new RangoDTO
                {
                    IdRango = p.Rango.IdRango,
                    Nombre = p.Rango.Nombre,
                    Name = p.Rango.Name,
                    Salario = p.Rango.Salario ?? 0,
                    isLocal = p.Rango.isLocal ?? true,
                    Permisos = p.Rango.RangosPermisos.Select(rp => new PermisoDTO
                    {
                        IdPermiso = rp.Permiso.IdPermiso,
                        Nombre = rp.Permiso.Nombre,
                        Name = rp.Permiso.Name
                    }).ToList()

                } : null,
                NumeroPlaca = (int)p.NumeroPlaca,
                Contrasena = p.Contrasena,
                Ciudadano = new CiudadanoDTO
                {
                    IdCiudadano = p.Ciudadano.IdCiudadano,
                    Nombre = p.Ciudadano.Nombre,
                    Apellidos = p.Ciudadano.Apellidos,
                    Dni = p.Ciudadano.Dni,
                    Genero = p.Ciudadano.Genero,
                    Gender = p.Ciudadano.Gender,
                    Nacionalidad = p.Ciudadano.Nacionalidad,
                    Nationality = p.Ciudadano.Nationality,
                    FechaNacimiento = p.Ciudadano.FechaNacimiento,
                    Direccion = p.Ciudadano.Direccion,
                    Address = p.Ciudadano.Address,
                    NumeroTelefono = p.Ciudadano.NumeroTelefono,
                    NumeroCuentaBancaria = p.Ciudadano.NumeroCuentaBancaria,
                    IsPoli = p.Ciudadano.IsPoli,
                    IsBusquedaYCaptura = p.Ciudadano.IsBusquedaYCaptura,
                    IsPeligroso = p.Ciudadano.IsPeligroso,
                    ImagenUrl = p.Ciudadano.ImagenUrl,
                    Trabajo = p.Ciudadano.Trabajo,
                    Work = p.Ciudadano.Work,
                    Multas = p.Ciudadano.Multas.Select(m => new MultaDTO
                    {
                        IdMulta = m.IdMulta,
                        IdPolicia = m.IdPolicia,
                        Fecha = m.Fecha,
                        CodigoPenal = m.CodigoPenal == null ? null : new CodigoPenalDTO
                        {
                            IdCodigoPenal = m.CodigoPenal.IdCodigoPenal,
                            Articulo = m.CodigoPenal.Articulo,
                            Descripcion = m.CodigoPenal.Descripcion,
                            Description = m.CodigoPenal.Description,
                            Precio = m.CodigoPenal.Precio,
                            Sentencia = m.CodigoPenal.Sentencia
                        },
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
                        EnColor = v.EnColor,
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
            .ThenInclude(m => m.CodigoPenal)
            .Include(p => p.Ciudadano)
            .ThenInclude(c => c.Vehiculos)
            .Include(p => p.Rango)
            .ThenInclude(r => r.RangosPermisos)
            .ThenInclude(rp => rp.Permiso)
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
                Rango = policia.Rango != null ? new RangoDTO
                {
                    IdRango = policia.Rango.IdRango,
                    Nombre = policia.Rango.Nombre,
                    Name = policia.Rango.Name,
                    Salario = policia.Rango.Salario ?? 0,
                    isLocal = policia.Rango.isLocal ?? true,
                    Permisos = policia.Rango.RangosPermisos.Select(rp => new PermisoDTO
                    {
                        IdPermiso = rp.Permiso.IdPermiso,
                        Nombre = rp.Permiso.Nombre,
                        Name = rp.Permiso.Name
                    }).ToList()

                } : null,
                NumeroPlaca = policia.NumeroPlaca.Value,
                Contrasena = policia.Contrasena,
                Ciudadano = new CiudadanoDTO
                {
                    IdCiudadano = policia.Ciudadano.IdCiudadano,
                    Nombre = policia.Ciudadano.Nombre,
                    Apellidos = policia.Ciudadano.Apellidos,
                    Dni = policia.Ciudadano.Dni,
                    Genero = policia.Ciudadano.Genero,
                    Gender = policia.Ciudadano.Gender,
                    Nacionalidad = policia.Ciudadano.Nacionalidad,
                    Nationality = policia.Ciudadano.Nationality,
                    FechaNacimiento = policia.Ciudadano.FechaNacimiento.Value,
                    Direccion = policia.Ciudadano.Direccion,
                    Address = policia.Ciudadano.Address,
                    NumeroTelefono = policia.Ciudadano.NumeroTelefono,
                    NumeroCuentaBancaria = policia.Ciudadano.NumeroCuentaBancaria,
                    IsPoli = policia.Ciudadano.IsPoli,
                    IsBusquedaYCaptura = policia.Ciudadano.IsBusquedaYCaptura,
                    IsPeligroso = policia.Ciudadano.IsPeligroso,
                    ImagenUrl = policia.Ciudadano.ImagenUrl,
                    Trabajo = policia.Ciudadano.Trabajo,
                    Work = policia.Ciudadano.Work,
                    Multas = policia.Ciudadano.Multas.Select(m => new MultaDTO
                    {
                        IdMulta = m.IdMulta,
                        IdPolicia = m.IdPolicia,
                        Fecha = m.Fecha.Value,
                        CodigoPenal = m.CodigoPenal != null ? new CodigoPenalDTO
                        {
                            IdCodigoPenal = m.CodigoPenal.IdCodigoPenal,
                            Articulo = m.CodigoPenal.Articulo,
                            Descripcion = m.CodigoPenal.Descripcion,
                            Description = m.CodigoPenal.Description,
                            Precio = m.CodigoPenal.Precio,
                            Sentencia = m.CodigoPenal.Sentencia
                        } : null,
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
                        EnColor = v.EnColor,
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

        public void Update(Policia policia, int id)
        {
            try
            {
                _context.Entry(policia).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al actualizar el Policía.");
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
