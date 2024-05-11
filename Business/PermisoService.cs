using Microsoft.Extensions.Logging;
using RuleStreet.Models;
using RuleStreet.Data;
using System.Collections.Generic;

namespace RuleStreet.Business
{
    public class PermisoService : IPermisoService
    {
        private readonly IPermisoRepository _permisoRepository;
        private readonly ILogger<PermisoService> _logger;


        public PermisoService(IPermisoRepository permisoRepository, ILogger<PermisoService> logger)
        {
            _permisoRepository = permisoRepository;
            _logger = logger;
        }

        public List<PermisoDTO> GetAll()
        {
            try
            {
                _logger.LogInformation("Obteniendo todas los permisos");
                return _permisoRepository.GetAll();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error obteniendo todas los permisos");
                throw;
            }
        }
        public PermisoDTO? Get(int id)
        {
            try
            {
                return _permisoRepository.Get(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error obteniendo los permisos por id");
                throw;
            }

        }


        public void Update(Permiso permiso)
        {
            try
            {
                _permisoRepository.Update(permiso);
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "Error actualizando el perimso por id");
                throw;
            }
        }

        public void Delete(int id)
        {
            try
            {
                _permisoRepository.Delete(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error eliminando el permiso por id");
                throw;
            }
        }

        public void Add(Permiso permiso)
        {
            try
            {
                _permisoRepository.Add(permiso);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error añadiendo el permiso");
                throw;
            }
        }
    }
}
