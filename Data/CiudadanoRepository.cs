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
            _logger.LogInformation("Consulta al contexto de la base de datos para obtener todos los ciudadanos iniciada.");
            var repoStartTime = DateTime.UtcNow;

            try
            {
                var ciudadanos = _context.Ciudadano
                    .Include(c => c.Multas)
                    .ThenInclude(m => m.Policia)
                    .Include(c => c.Multas)
                    .ThenInclude(m => m.CodigoPenal)
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
                        ImagenUrl = c.ImagenUrl,
                        Multas = c.Multas.Select(m => new MultaDTO
                        {
                            IdMulta = m.IdMulta,
                            IdPolicia = m.IdPolicia,
                            Fecha = m.Fecha,
                            CodigoPenal = m.CodigoPenal == null ? null : new CodigoPenalDTO
                            {
                                IdCodigoPenal = m.CodigoPenal.IdCodigoPenal,
                                Articulo = m.CodigoPenal.Articulo,
                                Descripcion = m.CodigoPenal.Descripcion,
                                Precio = m.CodigoPenal.Precio,
                                Sentencia = m.CodigoPenal.Sentencia
                            },
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

                var repoEndTime = DateTime.UtcNow;
                _logger.LogInformation("Consulta completada. Tiempo de ejecución de la consulta: {Duration}ms. Total de ciudadanos recuperados: {Count}.", (repoEndTime - repoStartTime).TotalMilliseconds, ciudadanos.Count);

                return ciudadanos;
            }
            catch (Exception ex)
            {
                var errorTime = DateTime.UtcNow;
                _logger.LogError(ex, "Error durante la ejecución de la consulta para obtener todos los ciudadanos. Tiempo de error: {ErrorTime}", errorTime);
                throw new Exception("Error en el repositorio al recuperar ciudadanos.", ex);
            }
            finally
            {
                var finalTime = DateTime.UtcNow;
                _logger.LogInformation("Salida del método GetAll() del repositorio. Tiempo total del proceso: {TotalTime}ms.", (finalTime - repoStartTime).TotalMilliseconds);
            }
        }




        public CiudadanoDTO Get(int id)
        {
            _logger.LogInformation("Consulta al contexto de la base de datos iniciada para el ciudadano con ID: {Id}", id);
            var repoStartTime = DateTime.UtcNow;

            try
            {
                var ciudadano = _context.Ciudadano
                    .Where(c => c.IdCiudadano == id)
                    .Include(c => c.Multas)
                    .ThenInclude(m => m.CodigoPenal)
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
                        ImagenUrl = c.ImagenUrl,
                        Multas = c.Multas.Select(m => new MultaDTO
                        {
                            IdMulta = m.IdMulta,
                            IdPolicia = m.IdPolicia,
                            Fecha = m.Fecha,
                            CodigoPenal = m.CodigoPenal == null ? null : new CodigoPenalDTO
                            {
                                IdCodigoPenal = m.CodigoPenal.IdCodigoPenal,
                                Articulo = m.CodigoPenal.Articulo,
                                Descripcion = m.CodigoPenal.Descripcion,
                                Precio = m.CodigoPenal.Precio,
                                Sentencia = m.CodigoPenal.Sentencia
                            },
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
                var repoEndTime = DateTime.UtcNow;
                _logger.LogInformation("Consulta completada para el ciudadano con ID: {Id}. Tiempo de ejecución de la consulta: {Duration}ms. Ciudadano encontrado: {IsFound}", id, (repoEndTime - repoStartTime).TotalMilliseconds, ciudadano != null);

                return ciudadano;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error en el repositorio al obtener el ciudadano con ID: {Id}", id);
                throw;
            }
            finally
            {
                _logger.LogInformation("Consulta en repositorio finalizada para el ciudadano con ID: {Id}. Tiempo total de la consulta: {TotalTime}ms", id, (DateTime.UtcNow - repoStartTime).TotalMilliseconds);
            }
        }

        public CiudadanoDTO GetByDni(string dni)
        {
            try
            {
                var ciudadano = _context.Ciudadano
                    .Where(c => c.Dni == dni)
                    .Include(c => c.Multas)
                    .ThenInclude(m => m.CodigoPenal)
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
                            CodigoPenal = m.CodigoPenal == null ? null : new CodigoPenalDTO
                            {
                                IdCodigoPenal = m.CodigoPenal.IdCodigoPenal,
                                Articulo = m.CodigoPenal.Articulo,
                                Descripcion = m.CodigoPenal.Descripcion,
                                Precio = m.CodigoPenal.Precio,
                                Sentencia = m.CodigoPenal.Sentencia
                            },
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
                _logger.LogError(ex, "Error obteniendo Ciudadano por nombre.");
                throw;
            }
        }


        public void Add(Ciudadano ciudadano)
        {
            _logger.LogInformation("Intentando guardar el Ciudadano en la base de datos con los siguientes datos: {ciudadano}", ciudadano);
            var startTime = DateTime.UtcNow;

            try
            {
                _context.Ciudadano.Add(ciudadano);
                _logger.LogInformation("Ciudadano añadido al contexto de DbContext, procediendo a guardar cambios.");
                _context.SaveChanges();
                _logger.LogInformation("Cambios guardados en la base de datos exitosamente para el Ciudadano con ID: {Id}", ciudadano.IdCiudadano);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al guardar el Ciudadano en la base de datos: {ciudadano}", ciudadano);
                throw;
            }
            finally
            {
                var endTime = DateTime.UtcNow;
                _logger.LogInformation("Intento de guardar el Ciudadano completado. Duración total: {Duration}ms", (endTime - startTime).TotalMilliseconds);
            }
        }

        public void Update(Ciudadano ciudadano)
        {
            var startTime = DateTime.UtcNow;
            _logger.LogInformation("Actualizando el ciudadano en la base de datos con ID: {Id}", ciudadano.IdCiudadano);

            try
            {
                _context.Ciudadano.Update(ciudadano);
                _context.SaveChanges();
                _logger.LogInformation("Cambios guardados en la base de datos exitosamente para el Ciudadano con ID: {Id}", ciudadano.IdCiudadano);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al actualizar el ciudadano en la base de datos con ID: {Id}", ciudadano.IdCiudadano);
                throw;
            }
            finally
            {
                var endTime = DateTime.UtcNow;
                _logger.LogInformation("Intento de actualización de datos completado. Duración total: {Duration}ms", (endTime - startTime).TotalMilliseconds);
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
