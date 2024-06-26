using Microsoft.Extensions.Logging;
using RuleStreet.Models;
using RuleStreet.Data;
using System.Collections.Generic;

namespace RuleStreet.Business
{
    public class VehiculoService : IVehiculoService
    {
        private readonly IVehiculoRepository _vehiculoRepository;
        private readonly ILogger<VehiculoService> _logger;


        public VehiculoService(IVehiculoRepository vehiculoRepository, ILogger<VehiculoService> logger)
        {
            _vehiculoRepository = vehiculoRepository;
            _logger = logger;
        }

        public List<VehiculoDTO> GetAll()
        {
            try
            {
                _logger.LogInformation("Obteniendo todas los vehiculos");
                return _vehiculoRepository.GetAll();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error obteniendo todas las multas");
                throw;
            }
        }

         public VehiculoDTO? Get(int id)
        {
            try
            {
                return _vehiculoRepository.Get(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error obteniendo los vehiculos por id");
                throw;
            }

        }


        public void Update(VehiculoPostDTO vehiculo)
        {
            try
            {
                 var Vehiculo = new Vehiculo()
                {
                    IdVehiculo = vehiculo.IdVehiculo,
                    IdCiudadano = vehiculo.IdCiudadano,
                    Matricula = vehiculo.Matricula,
                    Marca = vehiculo.Marca,
                    Modelo = vehiculo.Modelo,
                    Color = vehiculo.Color,
                    EnColor = vehiculo.EnColor,
                };
                _vehiculoRepository.Update(Vehiculo);
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "Error actualizando el vehiculo por id");
                throw;
            }
        }



        public void Add(VehiculoPostDTO vehiculo)
        {
            try
            {
                
                var Vehiculo = new Vehiculo()
                {
                    IdVehiculo = vehiculo.IdVehiculo,
                    IdCiudadano = vehiculo.IdCiudadano,
                    Matricula = vehiculo.Matricula,
                    Marca = vehiculo.Marca,
                    Modelo = vehiculo.Modelo,
                    Color = vehiculo.Color,
                    EnColor = vehiculo.EnColor,
                };

                _vehiculoRepository.Add(Vehiculo);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error añadiendo el vehiculo");
                throw;
            }

        }
        public void Delete(int id)
        {
            try
            {
                _vehiculoRepository.Delete(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error eliminando el vehiculo");
                throw;
            }

        }
    }
}
