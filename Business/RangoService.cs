using Microsoft.Extensions.Logging;
using RuleStreet.Models;
using RuleStreet.Data;
using System.Collections.Generic;

namespace RuleStreet.Business
{
    public class RangoService : IRangoService
    {
        private readonly IRangoRepository _rangoRepository;
        private readonly IPermisoRepository _permisoRepository;
        private readonly ILogger<RangoService> _logger;


        public RangoService(IRangoRepository rangoRepository, IPermisoRepository permisoRepository, ILogger<RangoService> logger)
        {
            _rangoRepository = rangoRepository;
            _permisoRepository = permisoRepository;
            _logger = logger;
        }

        public List<RangoDto> GetAll()
        {
            _logger.LogInformation("Obteniendo todos los rangos.");
            try
            {
                var rangos = _rangoRepository.GetAll();

                var rangoDtos = rangos.Select(r => new RangoDto
                {
                    IdRango = r.IdRango,
                    Nombre = r.Nombre,
                    Salario = r.Salario ?? 0,
                    isLocal = r.isLocal ?? false,
                    Permisos = r.RangosPermisos.Select(rp => new PermisoDto
                    {
                        IdPermiso = rp.Permiso.IdPermiso,
                        Nombre = rp.Permiso.Nombre
                    }).ToList()
                }).ToList();
                _logger.LogInformation($"Retornados {rangos.Count} rangos.");
                return rangoDtos;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener todos los rangos.");
                throw;
            }
        }

        public RangoDto? Get(int id)
        {
            _logger.LogInformation($"Buscando rango con ID: {id}");
            try
            {
                var rango = _rangoRepository.Get(id);
                if (rango == null)
                {
                    _logger.LogWarning($"Rango con ID: {id} no encontrado.");
                    return null;
                }

                var rangoDto = new RangoDto
                {
                    IdRango = rango.IdRango,
                    Nombre = rango.Nombre,
                    Salario = rango.Salario ?? 0,
                    isLocal = rango.isLocal ?? false,
                    Permisos = rango.RangosPermisos.Select(rp => new PermisoDto
                    {
                        IdPermiso = rp.Permiso.IdPermiso,
                        Nombre = rp.Permiso.Nombre
                    }).ToList()
                };
                _logger.LogInformation($"Rango con ID: {id} encontrado.");
                return rangoDto;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al obtener el rango con ID: {id}.");
                throw;
            }
        }

        public void Update(RangoDto rangoDto, int id)
        {
            try
            {
                _logger.LogInformation($"Intentando actualizar el rango con ID: {id}");
                var rango = _rangoRepository.Get(id);
                if (rango == null)
                {
                    _logger.LogWarning($"No se encontró el rango con ID: {id} para actualizar.");
                    return;
                }

                rango.Nombre = rangoDto.Nombre;
                _logger.LogInformation($"Cambiando Nombre de '{rango.Nombre}' a '{rangoDto.Nombre}'.");
                rango.Salario = rangoDto.Salario;
                _logger.LogInformation($"Cambiando Salario de '{rango.Salario}' a '{rangoDto.Salario}'.");
                rango.isLocal = rangoDto.isLocal;
                _logger.LogInformation($"Cambiando Localidad de '{rango.isLocal}' a '{rangoDto.isLocal}'.");

                var permisosActualizados = new List<RangoPermiso>();
                foreach (var permisoDto in rangoDto.Permisos)
                {
                    var permiso = _permisoRepository.Get(permisoDto.IdPermiso);
                    if (permiso != null)
                    {
                        permisosActualizados.Add(new RangoPermiso { IdRango = id, IdPermiso = permiso.IdPermiso });
                        _logger.LogInformation($"Permiso con ID: {permiso.IdPermiso} añadido al rango con ID: {id}.");
                    }
                    else
                    {
                        _logger.LogWarning($"Permiso con ID: {permisoDto.IdPermiso} no encontrado y no se añadirá al rango con ID: {id}.");
                    }
                }

                rango.RangosPermisos = permisosActualizados;
                _rangoRepository.Update(rango);
                _logger.LogInformation($"Rango con ID: {id} actualizado correctamente.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al actualizar el rango con ID: {id}");
                throw;
            }
        }
    }
}
