using Microsoft.Extensions.Logging;
using RuleStreet.Models;
using RuleStreet.Data;
using System.Collections.Generic;

namespace RuleStreet.Business
{
    public class RangoService : IRangoService
    {
        private readonly IRangoRepository _rangoRepository;
        private readonly ILogger<RangoService> _logger;


        public RangoService(IRangoRepository rangoRepository, ILogger<RangoService> logger)
        {
            _rangoRepository = rangoRepository;
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

        public void Update(Rango Rango)
        {
            try
            {
                _rangoRepository.Update(Rango);
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "Error actualizando el rango por id");
                throw;
            }
        }
    }
}
