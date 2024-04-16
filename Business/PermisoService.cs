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

        public List<Permiso> GetAll()
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
        public Permiso? Get(int id)
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




    }
}
