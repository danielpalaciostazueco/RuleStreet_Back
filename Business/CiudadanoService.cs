using Microsoft.Extensions.Logging;
using RuleStreet.Models;
using RuleStreet.Data;
using System.Collections.Generic;

namespace RuleStreet.Business
{
    public class CiudadanoService : ICiudadanoService
    {
        private readonly ICiudadanoRepository _ciudadanoRepository;
        private readonly ILogger<CiudadanoService> _logger;


        public CiudadanoService(ICiudadanoRepository ciudadanoRepository, ILogger<CiudadanoService> logger)
        {
            _ciudadanoRepository = ciudadanoRepository;
            _logger = logger;
        }

        public List<CiudadanoDTO> GetAll()
        {
            try
            {
                _logger.LogInformation("Obteniendo todas las ciudadanos");
                return _ciudadanoRepository.GetAll();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error obteniendo todas las ciudadanos");
                throw;
            }
        }
        public CiudadanoDTO? Get(int id)
        {
            try
            {
                return _ciudadanoRepository.Get(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error obteniendo la ciudadano por id");
                throw;
            }

        }

        public CiudadanoDTO? GetByName(string name)
        {
            try
            {
                return _ciudadanoRepository.GetByName(name);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error obteniendo la ciudadano por nombre");
                throw;
            }

        }

        public void Update(CiudadanoPostDTO ciudadanoPostDTO)
        {
            try
            {
                var ciudadano = new Ciudadano
                {
                    IdCiudadano = ciudadanoPostDTO.IdCiudadano,
                    Nombre = ciudadanoPostDTO.Nombre,
                    Apellidos = ciudadanoPostDTO.Apellidos,
                    Dni = ciudadanoPostDTO.Dni,
                    Genero = ciudadanoPostDTO.Genero,
                    Nacionalidad = ciudadanoPostDTO.Nacionalidad,
                    FechaNacimiento = ciudadanoPostDTO.FechaNacimiento,
                    Direccion = ciudadanoPostDTO.Direccion,
                    NumeroTelefono = ciudadanoPostDTO.NumeroTelefono,
                    NumeroCuentaBancaria = ciudadanoPostDTO.NumeroCuentaBancaria,
                    IsPoli = ciudadanoPostDTO.IsPoli,
                    IsBusquedaYCaptura = ciudadanoPostDTO.IsBusquedaYCaptura,
                    IsPeligroso = ciudadanoPostDTO.IsPeligroso,
                };

                _ciudadanoRepository.Update(ciudadano);
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "Error actualizando al ciudadano por id");
                throw;
            }
        }

        public void Add(CiudadanoPostDTO ciudadanoPostDTO)
        {
            try
            {
                var ciudadano = new Ciudadano
                {
                    Nombre = ciudadanoPostDTO.Nombre,
                    Apellidos = ciudadanoPostDTO.Apellidos,
                    Dni = ciudadanoPostDTO.Dni,
                    Genero = ciudadanoPostDTO.Genero,
                    Nacionalidad = ciudadanoPostDTO.Nacionalidad,
                    FechaNacimiento = ciudadanoPostDTO.FechaNacimiento,
                    Direccion = ciudadanoPostDTO.Direccion,
                    NumeroTelefono = ciudadanoPostDTO.NumeroTelefono,
                    NumeroCuentaBancaria = ciudadanoPostDTO.NumeroCuentaBancaria,
                    IsPoli = ciudadanoPostDTO.IsPoli,
                    IsBusquedaYCaptura = ciudadanoPostDTO.IsBusquedaYCaptura,
                    IsPeligroso = ciudadanoPostDTO.IsPeligroso,
                };
                _ciudadanoRepository.Add(ciudadano);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error añadiendo la ciudadano");
                throw;
            }
        }

        public void Delete(int id)
        {
            try
            {
                _ciudadanoRepository.Delete(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error eliminando al ciudadano");
                throw;
            }

        }
    }
}
